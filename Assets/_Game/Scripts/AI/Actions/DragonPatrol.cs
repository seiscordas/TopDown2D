using Pada1.BBCore;
using Pada1.BBCore.Framework;
using Pada1.BBCore.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

namespace kl
{
    [Action("Game/DrabonPatrol")]
    public class DragonPatrol : BasePrimitiveAction
    {
        [InParam("EnemyAIController")]
        private EnemyAIController enemyAIController;

        [InParam("TargetPatrolDistance")]
        private float targetPatrolDistance;

        private int wayPointIndex;

        public override void OnStart()
        {
            base.OnStart();
            enemyAIController.StartCoroutine(Patrol());
        }

        public override TaskStatus OnUpdate()
        {
            return TaskStatus.RUNNING;
        }

        public override void OnAbort()
        {
            base.OnAbort();
            enemyAIController.StopAllCoroutines();
        }

        IEnumerator Patrol()
        {
            wayPointIndex = Random.Range(0, enemyAIController.WayPoints.Count);
            yield return new WaitForSeconds(wayPointIndex);
            while (true)
            {
                enemyAIController.Move(enemyAIController.WayPoints[wayPointIndex], enemyAIController.PatrolSpeed, targetPatrolDistance);
                yield return new WaitForSeconds(seconds: 0.01f);
                if (enemyAIController.AtTarget)
                {
                    yield return new WaitForSeconds(wayPointIndex);
                    wayPointIndex = Random.Range(0, enemyAIController.WayPoints.Count);
                    enemyAIController.AtTarget = false;
                }
            }
        }
    }
}
