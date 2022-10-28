using Unity.VisualScripting;
using UnityEngine;

namespace kl
{
    public class DragonAttack : MonoBehaviour
    {
        [SerializeField] private float attackForce;
        [SerializeField] private float attackSpeed;
        [SerializeField] private float attackDistance;

        private EnemyAIController enemyAIController;
        private CharacterControl characterControl;

        private void Start()
        {
            enemyAIController = GetComponent<EnemyAIController>();
            characterControl = GetComponent<CharacterControl>();
        }

        private void Update()
        {
            if (characterControl.Attack)
            {
                DoAttack();
            }
            else
            {
                ResetAttack();
            }
        }
        private void DoAttack()
        {
            enemyAIController.AnimatorAttack.SetBool(TransitionParameter.Attack.ToString(), true);
            enemyAIController.TriggerDamage.Translate(attackSpeed * Time.deltaTime * Vector3.right, Space.Self);
            enemyAIController.TriggerDamage.localPosition = new Vector3(Mathf.Clamp(enemyAIController.TriggerDamage.position.x, 0, attackDistance), 0, 0);
        }

        private void ResetAttack()
        {
            enemyAIController.TriggerDamage.localPosition = Vector3.zero;
        }
    }
}