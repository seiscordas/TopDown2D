using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace kl
{
    [CreateAssetMenu(fileName = "New State Idle", menuName = "KL/AbilityData/Idle")]
    public class Idle : StateData
    {
        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

            CharacterControl characterControl = characterState.GetCharacterControl(animator);
            if (characterControl.Jump)
            {
                animator.SetBool(TransitionParameter.Jump.ToString(), value: true);
            }
            if (characterControl.MoveX || characterControl.MoveY)
            {
                animator.SetBool(TransitionParameter.Move.ToString(), true);
                animator.SetFloat(TransitionParameter.MoveX.ToString(), KeyboardInput.MoveInput.x);
                animator.SetFloat(TransitionParameter.MoveY.ToString(), KeyboardInput.MoveInput.y);
            }
        }
        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
    }
}
