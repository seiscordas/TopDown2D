using Pada1.BBCore;
using Pada1.BBCore.Framework;
using Pada1.BBCore.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

namespace kl
{
    [Action("Game/ChaseTarget")]
    public class ChaseTarget : BasePrimitiveAction
    {  
        [InParam("Target")]
        private GameObject target;

        [InParam("EnemyAICrontroller")]
        private EnemyAIController enemyAICrontroller;

        [InParam("TargetChaseDistance")]
        private float targetChaseDistance;

        public override void OnStart()
        {
            base.OnStart();
        }

        public override TaskStatus OnUpdate()
        {
            if(target == null)
            {
                return TaskStatus.ABORTED;
            }
            enemyAICrontroller.Move(target.transform, enemyAICrontroller.ChaseSpeed, targetChaseDistance);
            enemyAICrontroller.LookAtTarget(target.transform);
            return TaskStatus.RUNNING;
        }
        public override void OnAbort()
        {
            base.OnAbort();
            enemyAICrontroller.MoveAxis = Vector2.zero;
        }
    }
}


/*
 
 using Pada1.BBCore;
using Pada1.BBCore.Framework;
using Pada1.BBCore.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

namespace kl
{
    [Action("Game/ChaseTarget")]
    public class ChaseTarget : BasePrimitiveAction
    {  
        [InParam("Target")]
        private GameObject target;

        [InParam("EnemyAICrontroller")]
        private EnemyAIController enemyAICrontroller;

        [InParam("TargetChaseDistance")]
        private float targetChaseDistance;

        public override void OnStart()
        {
            base.OnStart();
        }

        public override TaskStatus OnUpdate()
        {
            if(target == null)
            {
                return TaskStatus.ABORTED;
            }
            enemyAICrontroller.Move(target.transform, enemyAICrontroller.ChaseSpeed, targetChaseDistance);
            enemyAICrontroller.LookAtTarget(target.transform);
            return TaskStatus.RUNNING;
        }
        public override void OnAbort()
        {
            base.OnAbort();
            enemyAICrontroller.MoveAxis = Vector2.zero;
        }
    }
}

 
 */