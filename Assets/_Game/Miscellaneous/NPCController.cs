using DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    [SerializeField] private InventoryItem InventoryItem;

    private void OnEnable()
    {
        DialogueManager.OnDialogueFinish += GiveInventoryItemToPlayer;
    }

    private void OnDisable()
    {
        DialogueManager.OnDialogueFinish -= GiveInventoryItemToPlayer;
    }

    private void GiveInventoryItemToPlayer()
    {
        //colocar item no inventario do player
        DialogueManager.OnDialogueFinish -= GiveInventoryItemToPlayer;
    }
}
