using Pada1.BBCore;
using Pada1.BBCore.Framework;
using Pada1.BBCore.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

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

        public override void OnStart()
        {
            base.OnStart();
        }

        public override TaskStatus OnUpdate()
        {
            if (!target)
                return TaskStatus.ABORTED;

            enemyAICrontroller.DoAttack(attackForce);
            return TaskStatus.RUNNING;
        }
        public override void OnAbort()
        {
            base.OnAbort();
        }
    }
}
