using UnityEngine;

namespace kl
{
    public class ManualInput : MonoBehaviour
    {
        private CharacterControl characterControl;

        private void Awake()
        {
            characterControl = this.GetComponent<CharacterControl>();
        }

        private void Update()
        {
            characterControl.MoveX = VirtualInputManager.Instance.MoveX;
            characterControl.MoveY = VirtualInputManager.Instance.MoveY;
            characterControl.Jump = VirtualInputManager.Instance.Jump;
            characterControl.Attack = VirtualInputManager.Instance.Attack;
        }
    }
}
