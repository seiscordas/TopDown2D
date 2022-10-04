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
            characterControl.transform.Translate(Speed * SpeedGraph.Evaluate(stateInfo.normalizedTime) * Time.fixedDeltaTime * characterControl.MoveInput);
            if (characterControl.MoveInput.x != 0 || characterControl.MoveInput.y != 0)
            {
                animator.SetFloat(TransitionParameter.MoveX.ToString(), characterControl.MoveInput.x);
                animator.SetFloat(TransitionParameter.MoveY.ToString(), characterControl.MoveInput.y);
                characterControl.SetFaceDirection(characterControl.MoveInput.x, characterControl.MoveInput.y);
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
