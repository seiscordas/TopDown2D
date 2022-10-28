using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace kl
{
    [CreateAssetMenu(fileName = "New State AnimationController", menuName = "KL/AnimationController/AnimationController")]
    public class AnimationController : StateData
    {
        CharacterControl characterControl;
        private IDamageable damageable;
        Animator animator;
        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {            
            characterControl = characterState.GetCharacterControl(animator);
            this.animator = animator;
            if (characterControl.TryGetComponent<IDamageable>(out damageable))
            {
                damageable.DeathEvent += OnDeath;
            }
        }

        private void OnDeath()
        {
            if (characterControl.Dead)
            {
                animator.SetTrigger(TransitionParameter.Dead.ToString());
                damageable.DeathEvent -= OnDeath;
            }
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            characterControl = characterState.GetCharacterControl(animator);
            if (characterControl.Attack)
            {
                animator.SetBool(TransitionParameter.Attack.ToString(), true);
            }
            if (characterControl.Jump)
            {
                animator.SetBool(TransitionParameter.Jump.ToString(), value: true);
            }
            if (characterControl.MoveX || characterControl.MoveY)
            {
                animator.SetBool(TransitionParameter.Move.ToString(), true);
            }
        }
        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
    }
}

