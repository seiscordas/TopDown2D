using BBUnity.Conditions;
using kl;
using Pada1.BBCore;
using Pada1.BBCore.Framework;
using Pada1.BBCore.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Condition("Game/Perception/IsAtTarget")]
public class IsAtTarget : GOCondition
{
    [InParam("EnemyAIController")]
    private EnemyAIController enemyAIController;

    public override bool Check()
    {
        //TODO: EXCLUIR SCRIPT SE NÃO FOR USAR O BEHAVIOR BRIKCS
        //Debug.Log("IsAtTarget: " + enemyAIController.IsAtTarget);
        if (enemyAIController.IsAtTarget)
        {            
            return true;
        }
        return false;
    }
}
