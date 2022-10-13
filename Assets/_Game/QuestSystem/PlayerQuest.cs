using UnityEngine;

namespace QuestSystem
{
    public class PlayerQuest : MonoBehaviour
    {
        private void Awake()
        {
            StartQuest.OnCreateQuest += ActiveQuest;
        }

        private void ActiveQuest(Quest quest)
        {
            quest.ActiveQuestGoal(quest);
        }
    }
}
