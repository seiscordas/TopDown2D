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
            Rigidbody2D rb = characterControl.GetComponent<Rigidbody2D>();
            if (characterControl.MoveX || characterControl.MoveY)
            {
                characterControl.transform.Translate(Speed * SpeedGraph.Evaluate(stateInfo.normalizedTime) * Time.fixedDeltaTime * KeyboardInput.MoveInput);
            }
            animator.SetBool(TransitionParameter.Move.ToString(), KeyboardInput.MoveInput.x != 0 || KeyboardInput.MoveInput.y != 0);
            animator.SetFloat(TransitionParameter.MoveX.ToString(), KeyboardInput.MoveInput.x);
            animator.SetFloat(TransitionParameter.MoveY.ToString(), KeyboardInput.MoveInput.y);
        }
        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
    }
}
