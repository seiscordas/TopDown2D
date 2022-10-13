using System;
using UnityEngine;

namespace QuestSystem
{
    public class QuestGoal : MonoBehaviour
    {
        public static event Action OnQuestGoalCompleted = delegate { };
        public static event Action OnResetGoals = delegate { };

        public float RemainingGoalQuantity { get; protected set; }
        public bool QuestGoalActive { private get; set; }

        [SerializeField] protected float goalQuantity;

        protected virtual void Awake() => RemainingGoalQuantity = goalQuantity;

        protected virtual void SubtractRemainingGoal(float value)
        {
            if (!QuestGoalActive)
                return;

            RemainingGoalQuantity -= value;

            if (RemainingGoalQuantity <= 0f)
                CompleteQuestGoal();
        }

        protected virtual void ResetGoals()
        {
            OnResetGoals?.Invoke();
            RemainingGoalQuantity = goalQuantity;
        }

        protected virtual void CompleteQuestGoal()
        {
            QuestGoalActive = false;
            OnQuestGoalCompleted?.Invoke();
        }
    }
}
