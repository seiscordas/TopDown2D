using System;
using UnityEngine;

namespace QuestSystem
{
    public class QuestReward : MonoBehaviour
    {
        public static event Action OnReward = delegate { };
        public void GetReward() => OnReward?.Invoke();
    }
}
