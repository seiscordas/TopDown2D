using BBUnity.Conditions;
using kl;
using Pada1.BBCore;
using Pada1.BBCore.Framework;
using Pada1.BBCore.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Condition("Game/Perception/IsTargetVisible")]
public class IsTargetVisible : GOCondition
{
    [InParam("Target")]
    private Transform target;

    [InParam("AIVision")]
    private AIVision aiVision;

    [InParam("TargetMemoryDuration")]
    private float targetMemoryDuration;

    [InParam("EnemyAIController")]
    private EnemyAIController enemyAIController;

    private float forgetTargetTime;

    public override bool Check()
    {
        if (aiVision.IsVisible(target) && !enemyAIController.IsAtTarget)
        {
            forgetTargetTime = Time.time + targetMemoryDuration;
            return true;
        }
        return Time.time < forgetTargetTime;
    }
}
