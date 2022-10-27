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
        public static event Action OnDialogueFinish = delegate { };

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
                if (currentStory.currentChoices.Count > 0)
                {
                    DisplayChoices();
                }
                else
                {
                    ToggleShowContinueButtom(true);
                    HideChoiceButtons(0);
                }
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

            InputManager.OnSubmitPressed += ContinueStrory;
            OnDialogueEnter?.Invoke();
        }

        private void ExitDialogueMode()
        {
            DialogueIsPlaying = false;
            dialoguePanel.SetActive(false);
            dialogueText.text = "";
            InputManager.OnSubmitPressed -= ContinueStrory;
            OnDialogueExit?.Invoke();

            dialogueVariables.StopListenig(currentStory);
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
            ToggleShowContinueButtom(false);
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

        private void HideChoiceButtons(int index)
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

        /// Calling on UI
        public void DialogueChosen(int index)
        {
            currentStory.ChooseChoiceIndex(index);
            ContinueStrory();
            HideChoiceButtons(0);
            ToggleShowContinueButtom(true);
        }

        private void ToggleShowContinueButtom(bool active)
        {
            continueButtom.SetActive(active);
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

        public void FinishedDialogue()
        {
            OnDialogueFinish?.Invoke();
        }
    }
}
