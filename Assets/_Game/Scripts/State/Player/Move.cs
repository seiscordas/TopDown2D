using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace kl
{
    [CreateAssetMenu(fileName = "New State Move", menuName = "KL/AbilityData/Move")]
    public class Move : StateData
    {
        public AnimationCurve SpeedGraph;
        public float Speed;

        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            CharacterControl characterControl = characterState.GetCharacterControl(animator);
            characterControl.transform.Translate(Speed * SpeedGraph.Evaluate(stateInfo.normalizedTime) * Time.fixedDeltaTime * KeyboardInput.MoveInput);
            characterControl.FacingRight = KeyboardInput.MoveInput.x > 0;
            characterControl.FacingUp = KeyboardInput.MoveInput.y > 0;
            animator.SetBool(TransitionParameter.Move.ToString(), characterControl.MoveX || characterControl.MoveY);
            animator.SetFloat(TransitionParameter.MoveX.ToString(), KeyboardInput.MoveInput.x);
            animator.SetFloat(TransitionParameter.MoveY.ToString(), KeyboardInput.MoveInput.y);
        }
        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
    }
}
