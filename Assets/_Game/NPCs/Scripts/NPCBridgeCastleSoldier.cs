using System;
using UnityEngine;

namespace DialogueSystem
{
    public class NPCBridgeCastleSoldier : MonoBehaviour
    {
        [SerializeField] private DialogueTrigger dialogueTrigger;
        [SerializeField] private string itemId;
        [SerializeField] private Collider2D bridgeCollider;

        private void OnEnable()
        {
            DialogueTrigger.OnDialogueRenge += SetDialogue;
        }

        private void OnDisable()
        {
            DialogueTrigger.OnDialogueRenge -= SetDialogue;
        }

        private void SetDialogue()
        {
            Item item = InventoryManager.Instance.CheckItemById(itemId);
            if (item == null)
            {
                print("SetDialogue: " + item);
                dialogueTrigger.DefaultDialogue = true;
            }
            else
            {
                print("SetDialogue: " + item);
                dialogueTrigger.DefaultDialogue = false;
                DialogueManager.OnDialogueExit += SetDialogueFinished;
                DialogueTrigger.OnDialogueRenge -= SetDialogue;
            }
        }

        private void SetDialogueFinished()
        {
            bool accepQuest = ((Ink.Runtime.BoolValue)DialogueManager.GetInstance().GetVariableState("acceptQuest")).value;

            if (accepQuest)
            {
                DialogueManager.GetInstance().FinishedDialogue();
                DialogueManager.OnDialogueExit -= SetDialogueFinished;
                GetItemFromPlayer();
                DisableBridgeCollider();
            }
        }

        private void GetItemFromPlayer()
        {
            InventoryManager.Instance.GetItemById(itemId);
        }

        private void DisableBridgeCollider()
        {
            bridgeCollider.enabled = false;
        }
    }
}
