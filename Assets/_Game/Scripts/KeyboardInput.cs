using UnityEngine;

namespace kl
{
    public class KeyboardInput : MonoBehaviour
    {
        private PlayerInputActions _inputActions;
        private static Vector2 moveInput;

        public static Vector2 MoveInput { get => moveInput; }

        private void Awake()
        {
            _inputActions = new PlayerInputActions();
            _inputActions.PlayerControls.Enable();
            //_inputActions.PlayerControls.Attack.performed += OnAttackInput;
        }
        void Update()
        {
            moveInput = _inputActions.PlayerControls.Movement.ReadValue<Vector2>();
            VirtualInputManager.Instance.MoveX = moveInput.x > 0 || moveInput.x < 0;
            VirtualInputManager.Instance.MoveY = moveInput.y > 0 || moveInput.y < 0;
            VirtualInputManager.Instance.Jump = (Input.GetKey(KeyCode.Space));
        }
        //private void OnAttackInput(InputAction.CallbackContext obj)
        //{
        //    Debug.Log("Do Attack!");
        //}
    }
}
