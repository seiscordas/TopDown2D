using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace kl
{
    [CreateAssetMenu(fileName = "New State SwordAttack", menuName = "KL/AbilityData/SwordAttack")]
    public class SwordAttack : StateData
    {
        public float Speed;

        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            animator.SetBool(TransitionParameter.Attack.ToString(), false);
            CharacterControl characterControl = characterState.GetCharacterControl(animator);
            characterControl.Attack = false;
        }
    }
}
