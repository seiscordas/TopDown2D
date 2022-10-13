using System;
using UnityEngine;

namespace QuestSystem
{
    public class Quest
    {
        public static event Action OnPuzzleCompleted = delegate { };

        [SerializeField] public QuestGoal QuestGoal { get; }
        [SerializeField] public QuestReward QuestReward { get; }

        public Quest(QuestGoal questGoal, QuestReward questReward)
        {            
            StartQuest.OnCreateQuest += ActiveQuestGoal;

            QuestGoal = questGoal;
            QuestReward = questReward;
        }

        public void ActiveQuestGoal(Quest quest)
        {
            quest.QuestGoal.QuestGoalActive = true;
            QuestGoal.OnQuestGoalCompleted += CompleteQuest;
        }

        public void FinishQuest()
        {
            QuestGoal.OnQuestGoalCompleted -= CompleteQuest;
        }

        private void ReceiveRewards()
        {
            QuestReward.GetReward();
        }

        private void CompleteQuest()
        {
            OnPuzzleCompleted?.Invoke();
            FinishQuest();
            ReceiveRewards();
        }
    }
}
