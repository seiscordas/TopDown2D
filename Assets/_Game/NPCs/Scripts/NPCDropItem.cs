using Kl;
using UnityEngine;

namespace DialogueSystem
{
    public class NPCDropItem : MonoBehaviour
    {
        [SerializeField] private DialogueTrigger dialogueTrigger;
        private void Start()
        {
            dialogueTrigger.DefaultDialogue = false;
        }

        private void OnEnable()
        {
            DialogueManager.OnDialogueExit += SetDialogueFinished;
        }

        private void OnDisable()
        {
            DialogueManager.OnDialogueExit -= SetDialogueFinished;
        }

        private void GiveItemToPlayer()
        {
            ItemDrop.Instance.Drop();
        }

        private void SetDialogueFinished()
        {
            bool accepQuest = ((Ink.Runtime.BoolValue)DialogueManager.GetInstance().GetVariableState("acceptQuest")).value;

            if (accepQuest)
            {
                DialogueManager.GetInstance().FinishedDialogue();
                DialogueManager.OnDialogueExit -= SetDialogueFinished;
                GiveItemToPlayer();
            }
        }
    }
}
