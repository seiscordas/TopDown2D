using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Miscellaneous;
using kl;

namespace BattleSystem
{
    public class Attack : MonoBehaviour
    {
        [SerializeField] private float strength;
        [SerializeField] private LayerMask enemyLayer;

        private readonly Dictionary<GameObject, Health> selectedHealths = new();

        private void Awake()
        {
            Enemy.OnEnemyDeath += RemoveEnemy;
        }

        private void RemoveEnemy(Enemy enemy)
        {
            selectedHealths.Remove(enemy.gameObject);
        }

        private void TakeAttack()
        {
            for (int index = 0; index < selectedHealths.Count; index++)
                selectedHealths.Values.ToArray()[index].TakeDamage(strength);
        }

        private void OnTriggerEnter(Collider collision)
        {
            if (!collision.CompareLayer(enemyLayer) || selectedHealths.ContainsKey(collision.gameObject))
                return;
            
            selectedHealths.Add(collision.gameObject, collision.GetComponent<Health>());
        }

        private void OnTriggerExit(Collider collision)
        {
            if (!collision.CompareLayer(enemyLayer) || !selectedHealths.ContainsKey(collision.gameObject))
                return;

            selectedHealths.Remove(collision.gameObject);
        }
    }
}