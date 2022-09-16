using UnityEngine;
namespace kl
{
    [CreateAssetMenu(fileName = "New State", menuName = "KL/AbilityData/Jump")]
    public class Jump : StateData
    {
        public float JumpForce;
        public AnimationCurve Gravity;
        public AnimationCurve Pull;

        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
        }
        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
        }
        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
        }
    }
}
