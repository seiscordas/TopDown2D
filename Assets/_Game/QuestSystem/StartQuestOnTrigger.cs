using UnityEngine;
using UnityEngine.Events;

namespace QuestSystem.QuestGoals
{
    public class StartQuestOnTrigger : MonoBehaviour
    {
        [SerializeField] private UnityEvent onTriggerEnter;

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (!collider.CompareTag("Player"))
                return;
            onTriggerEnter.Invoke();
        }
    }
}
