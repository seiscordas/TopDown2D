using kl;
using UnityEngine;

namespace DialogueSystem
{
    public class DialogueTrigger : MonoBehaviour
    {
        [SerializeField] private GameObject visualCue;
        [SerializeField] private TextAsset inkJSON;

        private bool isDialogueFinished = false;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (isDialogueFinished)
                return;

            if (collision.gameObject.CompareTag("Player"))
            {
                visualCue.SetActive(true);
                InputManager.OnInteractPressed += LoadInkJSON;
                DialogueManager.OnDialogueFinish += SetFinishedDialogue;
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
            DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
        }

        private void SetFinishedDialogue()
        {
            isDialogueFinished = true;
        }
    }
}
