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
            characterControl.MoveRight = VirtualInputManager.Instance.MoveRight;
            characterControl.MoveLeft = VirtualInputManager.Instance.MoveLeft;
            characterControl.MoveUp = VirtualInputManager.Instance.MoveUp;
            characterControl.MoveDown = VirtualInputManager.Instance.MoveDown;
            characterControl.Jump = VirtualInputManager.Instance.Jump;
        }
    }
}
