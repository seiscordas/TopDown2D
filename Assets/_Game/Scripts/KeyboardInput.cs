using UnityEngine;
using UnityEngine.InputSystem;

namespace kl
{
    public class KeyboardInput : MonoBehaviour
    {
        private CharacterControl characterControl;
        private PlayerInputActions inputActions;
        private Vector2 moveInput;

        private void Start()
        {
            characterControl = this.GetComponent<CharacterControl>();
            inputActions = new PlayerInputActions();
            inputActions.PlayerControls.Enable();
            inputActions.PlayerControls.Attack.performed += OnAttackInput;
        }
        private void OnDisable()
        {
            if (inputActions != null)
                inputActions.PlayerControls.Attack.performed -= OnAttackInput;
        }
        void Update()
        {
            moveInput = inputActions.PlayerControls.Movement.ReadValue<Vector2>();
            characterControl.MoveInput = moveInput;

            characterControl.MoveX = moveInput.x > 0 || moveInput.x < 0;
            characterControl.MoveY = moveInput.y > 0 || moveInput.y < 0;
            //characterControl.Jump   = (Input.GetKey(KeyCode.Space));
        }
        private void OnAttackInput(InputAction.CallbackContext obj)
        {
            characterControl.Attack = true;
        }
    }
}
