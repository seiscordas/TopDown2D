using UnityEngine;

namespace kl
{
    public class KeyboardInput : MonoBehaviour
    {
        [SerializeField] private CharacterControl characterControl;
        void Update()
        {            
            if (Input.GetAxisRaw("Horizontal") == 0 || Input.GetAxisRaw("Vertical") == 0)
            {
                VirtualInputManager.Instance.MoveRight = false;
                VirtualInputManager.Instance.MoveLeft = false;
                VirtualInputManager.Instance.MoveUp = false;
                VirtualInputManager.Instance.MoveDown = false;
            }
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                if (characterControl.FacingRight)
                {
                    VirtualInputManager.Instance.MoveRight = true;
                }
            }
            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                if (!characterControl.FacingRight)
                {
                    VirtualInputManager.Instance.MoveLeft = true;
                }
            }
            VirtualInputManager.Instance.Jump = (Input.GetKey(KeyCode.Space));

        }
    }
}
