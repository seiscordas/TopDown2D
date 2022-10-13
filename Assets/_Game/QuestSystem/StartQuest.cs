using System;
using UnityEngine;

namespace QuestSystem
{
    public class StartQuest : MonoBehaviour
    {
        public static event Action<Quest> OnCreateQuest = delegate { };

        [SerializeField] private Quest puzzle;

        public void CreateQuest()
        {
            GenerateQuest();
            OnCreateQuest?.Invoke(puzzle);
        }

        private void GenerateQuest()
        {
            QuestGoal goal = GetComponentInChildren<QuestGoal>();
            QuestReward reward = GetComponentInChildren<QuestReward>();

            puzzle = new Quest(goal, reward);
        }
    }
}
