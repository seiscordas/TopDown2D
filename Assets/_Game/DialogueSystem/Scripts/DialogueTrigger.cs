using kl;
using System;
using UnityEngine;

namespace DialogueSystem
{
    public class DialogueTrigger : MonoBehaviour
    {
        public static event Action OnDialogueRenge = delegate { };
        [SerializeField] private GameObject visualCue;
        [SerializeField] private TextAsset inkJSON;
        [SerializeField] private TextAsset defaultInkJSON;

        [SerializeField] private bool defaultDialogue = true;

        private bool isDialogueFinished = false;

        public virtual bool DefaultDialogue { get => defaultDialogue; set => defaultDialogue = value; }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (isDialogueFinished)
                return;

            if (collision.gameObject.CompareTag("Player"))
            {
                visualCue.SetActive(true);
                InputManager.OnInteractPressed += LoadInkJSON;
                DialogueManager.OnDialogueFinish += SetFinishedDialogue;
                OnDialogueRenge?.Invoke();
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                visualCue.SetActive(false);
                InputManager.OnInteractPressed -= LoadInkJSON;
                DialogueManager.OnDialogueFinish -= SetFinishedDialogue;
            }
        }

        private void LoadInkJSON()
        {
            if (defaultDialogue)
            {
                DialogueManager.GetInstance().EnterDialogueMode(defaultInkJSON);
            }
            else
            {
                DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
            }            
            InputManager.OnInteractPressed -= LoadInkJSON;
        }

        private void SetFinishedDialogue()
        {
            isDialogueFinished = true;
        }
    }
}
