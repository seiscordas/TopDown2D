using Ink.Runtime;
using kl;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Ink.UnityIntegration;

namespace DialogueSystem
{
    public class DialogueManager : MonoBehaviour
    {
        public static event Action OnDialogueEnter = delegate { };
        public static event Action OnDialogueExit = delegate { };

        [Header("Params")]
        [SerializeField] private InkFile globalInkFile;

        [Header("Dialogue UI")]
        [SerializeField] private GameObject dialoguePanel;
        [SerializeField] private GameObject continueButtom;
        [SerializeField] private TextMeshProUGUI dialogueText;

        [Header("Choices UI")]
        [SerializeField] private GameObject[] choices;
        private TextMeshProUGUI[] choiceText;

        [SerializeField] private Story currentStory;
        public bool DialogueIsPlaying { get; private set; }
        public static Action OnFinishDialogue { get; internal set; }

        private static DialogueManager instance;
        private DialogueVariables dialogueVariables;

        private void Awake()
        {
            if (instance == null)
            {
                Debug.LogWarning("Found more than one Dialogue Manager in the scene");
            }
            instance = this;

            dialogueVariables = new DialogueVariables(globalInkFile.filePath);
        }
        public static DialogueManager GetInstance()
        {
            return instance;
        }
        private void Start()
        {
            DialogueIsPlaying = false;
            dialoguePanel.SetActive(false);

            GetAllChoicesTextComponet();
        }

        private void GetAllChoicesTextComponet()
        {
            choiceText = new TextMeshProUGUI[choices.Length];
            int index = 0;
            foreach (GameObject choice in choices)
            {
                choiceText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
                index++;
            }
        }

        public void ContinueStrory()
        {
            if (currentStory.canContinue)
            {
                dialogueText.text = currentStory.Continue();
                DisplayChoices();
            }
            else
            {
                ExitDialogueMode();
            }
        }

        public void EnterDialogueMode(TextAsset inkJSON)
        {
            currentStory = new Story(inkJSON.text);
            DialogueIsPlaying = true;
            dialoguePanel.SetActive(true);

            dialogueVariables.StartListening(currentStory);

            ContinueStrory();

            //PutInListenerDialogueChoies();

            InputManger.OnSubmitPressed += ContinueStrory;
            OnDialogueEnter?.Invoke();
        }

        private void ExitDialogueMode()
        {
            DialogueIsPlaying = false;
            dialoguePanel.SetActive(false);
            dialogueText.text = "";
            InputManger.OnSubmitPressed -= ContinueStrory;
            OnDialogueExit?.Invoke();

            dialogueVariables.StopListenig(currentStory);

            //RemoveFromListenerDialogueChoies();
        }

        private void DisplayChoices()
        {
            List<Choice> currentChoices = currentStory.currentChoices;

            if (currentChoices.Count > choices.Length)
            {
                Debug.LogError("More choices were fiven than the UI can support. Number of choices given: " + currentChoices.Count);
            }
            EnableAndInitializeChoicesButtom(currentChoices);
            StartCoroutine(SelectFirstChoice());
        }

        private void EnableAndInitializeChoicesButtom(List<Choice> currentChoices)
        {
            int index = 0;
            foreach (Choice choice in currentChoices)
            {
                choices[index].SetActive(true);
                choiceText[index].text = choice.text;
                index++;
            }
        }

        private void HiddenChoiceButtons(int index)
        {
            for (int i = index; i < choices.Length; i++)
            {
                choices[i].SetActive(false);
            }
        }

        private IEnumerator SelectFirstChoice()
        {
            EventSystem.current.SetSelectedGameObject(null);
            yield return new WaitForEndOfFrame();
            EventSystem.current.SetSelectedGameObject(choices[0]);
        }

        //private void PutInListenerDialogueChoies()
        //{
        //    for (int i = 0; i < choices.Length; i++)
        //    {
        //        int index = i;
        //        choices[i].GetComponent<Button>().onClick.AddListener(() => DialogueChosen(index));
        //    }
        //}
        //private void RemoveFromListenerDialogueChoies()
        //{
        //    for (int i = 0; i < choices.Length; i++)
        //    {
        //        int index = i;
        //        choices[i].GetComponent<Button>().onClick.RemoveListener(() => DialogueChosen(index));
        //    }
        //}

        public void DialogueChosen(int index)
        {
            currentStory.ChooseChoiceIndex(index);
            ContinueStrory();
            HiddenChoiceButtons(0);
            ShowContinueButtom();
        }

        private void ShowContinueButtom()
        {
            continueButtom.SetActive(true);
        }

        public Ink.Runtime.Object GetVariableState(string variableName)
        {
            dialogueVariables.Variables.TryGetValue(variableName, out Ink.Runtime.Object variableValue);
            if (variableValue == null)
            {
                Debug.Log("Ink Variable was found to be null: " + variableName);
            }
            return variableValue;
        }

        private void FinishDialogue()
        {
            OnFinishDialogue?.Invoke();
        }
    }
}
