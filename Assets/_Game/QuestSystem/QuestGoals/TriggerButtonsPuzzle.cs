using System;
using System.Collections.Generic;
using System.Linq;
using TriggerButtonSystem;
using UnityEngine;

namespace QuestSystem.QuestGoals
{
    public class TriggerButtonsPuzzle : QuestGoal
    {
        public static event Action<TriggerButton> OnCheckForProgressSuccess = delegate { };
        [SerializeField] private List<TriggerButton> triggerButtons;
        [SerializeField] private List<KeyPuzzle> placeKeys;
        [SerializeField] private List<Transform> BtnSequence;
        [SerializeField] private QuestKillDragon puzzleEvolutionPane;

        protected override void Awake()
        {
            base.Awake();
            Shuffle();
            TriggerButton.OnButtonReached += CheckForProgress;
            OnResetGoals += ResetThis;
            StartQuest.OnCreateQuest += SetBottonPlace;
        }

        private void CheckForProgress(TriggerButton button)
        {
            if (!CheckKey(button.buttonKey))
            {
                ResetGoals();
            }
            else
            {
                DisableButtonCollider(button);
                SubtractRemainingGoal(1f);
                OnCheckForProgressSuccess?.Invoke(button);
                //puzzleEvolutionPane.SetButtonAsPressed(button);
            }
        }

        private bool CheckKey(int key)
        {
            List<KeyPuzzle> checkKey = placeKeys.FindAll(x => x.Key <= key).FindAll(x => x.Check == false);
            if (checkKey.Count > 1)
            {
                return false;
            }
            else
            {
                SetKeyTrue(checkKey[0]);
                return true;
            }
        }

        private void Shuffle()
        {
            triggerButtons = triggerButtons.OrderBy(x => Guid.NewGuid()).ToList();
        }

        private void SetKeyTrue(KeyPuzzle key)
        {
            key.Check = true;
        }

        private void SetAllKeyFalse()
        {
            foreach (KeyPuzzle key in placeKeys)
            {
                key.Check = false;
            }
        }

        public void SetBottonPlace(Quest puzzle)
        {
            int i = 0;
            foreach (TriggerButton triggerButton in triggerButtons)
            {
                TriggerButton button = triggerButton.GetComponent<TriggerButton>();
                button.buttonKey = placeKeys[i].GetComponent<KeyPuzzle>().Key;
                button.BtnKeyImage.transform.parent = placeKeys[i].transform;
                button.BtnKeyImage.transform.position = placeKeys[i].transform.position;
                //puzzleEvolutionPane.sprites.Add(button.BtnKeyImage.gameObject.GetComponent<SpriteRenderer>());
                i++;
            }
        }

        private void DisableButtonCollider(TriggerButton triggerButton)
        {
            triggerButton.GetComponent<Collider2D>().enabled = false;
        }

        private void EnableAllButtons()
        {
            foreach (TriggerButton button in triggerButtons)
            {
                button.GetComponent<Collider2D>().enabled = true;
            }
        }

        private void ResetThis()
        {
            EnableAllButtons();
            SetAllKeyFalse();
        }
    }

}
