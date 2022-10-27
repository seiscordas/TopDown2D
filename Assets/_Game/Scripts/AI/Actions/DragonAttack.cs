using UnityEngine;

namespace kl
{
    public class DragonAttack : MonoBehaviour
    {
        [SerializeField] private float attackForce;
        [SerializeField] private float attackSpeed;

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

            Vector3 toTarget = enemyAIController.Target.position - enemyAIController.TriggerDamage.position;
            toTarget.Normalize();
            enemyAIController.TriggerDamage.Translate(attackSpeed * Time.deltaTime * toTarget, Space.Self);
        }

        private void ResetAttack()
        {
            enemyAIController.TriggerDamage.localPosition = Vector3.zero;
        }
    }
}
/*
 namespace kl
{
    [Action("Game/DrabonAttack")]
    public class DragonAttack : BasePrimitiveAction
    {
        [InParam("Target")]
        private GameObject target;

        [InParam("EnemyAICrontroller")]
        private EnemyAIController enemyAICrontroller;

        [InParam("AttackForce")]
        private float attackForce;

        private CharacterControl characterControl;
        private Animator animatorAttack;

        public override void OnStart()
        {
            base.OnStart();
            characterControl = enemyAICrontroller.GetComponent<CharacterControl>();
            animatorAttack = enemyAICrontroller.GetComponent<Animator>();
        }

        public override TaskStatus OnUpdate()
        {
            if (!target)
                return TaskStatus.ABORTED;

            if (characterControl.Attack)
            {
                Debug.Log("attack");
                DoAttack();
            }
            return TaskStatus.RUNNING;
        }

        private void DoAttack()
        {
            animatorAttack.SetBool(TransitionParameter.Attack.ToString(), true);

            Vector3 toTarget = target.transform.position - enemyAICrontroller.TriggerDamage.position;
            toTarget.Normalize();
            enemyAICrontroller.TriggerDamage.Translate(enemyAICrontroller.AttackSpeed * Time.fixedDeltaTime * toTarget);
        }

        public override void OnAbort()
        {
            base.OnAbort();
        }


    }
}

 
 */