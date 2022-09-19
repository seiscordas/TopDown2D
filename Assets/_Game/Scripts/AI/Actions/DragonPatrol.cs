using Pada1.BBCore;
using Pada1.BBCore.Framework;
using Pada1.BBCore.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace kl
{
    [Action("Game/DrabonPatrol")]
    public class DragonPatrol : BasePrimitiveAction
    {
        [InParam("AIController")]
        private EnemyAICrontroller aiController;

        public override void OnStart()
        {
            base.OnStart();
            Debug.Log("Patrol: OnStart");
            aiController.StartCoroutine(TempWalk());
        }

        public override TaskStatus OnUpdate()
        {
            Debug.Log("Patrol: OnUpdate");
            return TaskStatus.RUNNING;
        }

        public override void OnAbort()
        {
            base.OnAbort();

            aiController.StopAllCoroutines();
        }

        IEnumerator TempWalk()
        {
            yield return new WaitForSeconds(1);
            VirtualInputManager.Instance.MoveX = true;
            VirtualInputManager.Instance.MoveY = true;
            VirtualInputManager.Instance.Jump = false;
        }
    }
}
