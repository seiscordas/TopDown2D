using System;
using System.Collections;
using System.Collections.Generic;
using TriggerButtonSystem;
using UnityEngine;

namespace QuestSystem.QuestGoals
{
    public class QuestKillDragon : QuestGoal
    {
        [SerializeField] private InventoryItem letter;

        public void GiveLetterToPlayer(TriggerButton button)
        {
            PlaySound();
        }

        private static int GetIndex(TriggerButton button)
        {
            return button.buttonKey - 1;
        }

        private void PlaySound()
        {
            Debug.Log("PlaySound Letter");
            //gameObject.GetComponent<AudioSource>().PlayOneShot(button.AudioClip);
        }
    }
}
