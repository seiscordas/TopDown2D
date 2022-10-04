using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace kl
{
    [CreateAssetMenu(fileName = "New State EnemyMove", menuName = "KL/AbilityData/EnemyMove")]
    public class EnemyMove : StateData
    {
        public float Speed;

        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            CharacterControl characterControl = characterState.GetCharacterControl(animator);
            Vector2 moveAxis = characterControl.GetComponent<EnemyAIController>().MoveAxis;
            if (moveAxis.x != 0 || moveAxis.y != 0)
            {
                animator.SetBool(TransitionParameter.Move.ToString(), true);
                animator.SetFloat(TransitionParameter.MoveX.ToString(), moveAxis.x);
                animator.SetFloat(TransitionParameter.MoveY.ToString(), moveAxis.y);
                characterControl.SetFaceDirection(moveAxis.x, moveAxis.y);                
            }
            else
            {
                animator.SetBool(TransitionParameter.Move.ToString(), false);
            }

        }
        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
    }
}
