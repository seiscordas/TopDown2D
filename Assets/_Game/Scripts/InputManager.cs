using DialogueSystem;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace kl
{
    public class InputManager : MonoBehaviour
    {
        private CharacterControl characterControl;
        private PlayerInputActions inputActions;
        private Vector2 moveInput;

        public static event Action OnSubmitPressed = delegate { };
        public static event Action OnInteractPressed = delegate { };
        public static event Action OnAttackPressed = delegate { };

        private void Start()
        {
            characterControl = this.GetComponent<CharacterControl>();
            inputActions = new PlayerInputActions();
            inputActions.PlayerControls.Enable();
            AddEventOnListener();
        }

        private void AddEventOnListener()
        {
            inputActions.PlayerControls.Attack.performed += AttackButtonPressed;
            inputActions.PlayerControls.Interact.performed += InteractButtonPressed;
            inputActions.PlayerControls.Submit.performed += SubmitButtonPressed;
            DialogueManager.OnDialogueEnter += PauseInputManager;
        }

        private void OnDisable()
        {
            if (inputActions != null)
            {
                RemoveEventFromListener();
            }
        }

        private void PauseInputManager()
        {
            DialogueManager.OnDialogueExit += ResumeInputManger;
            DialogueManager.OnDialogueEnter -= PauseInputManager;
            inputActions.PlayerControls.Attack.performed -= AttackButtonPressed;
        }

        private void ResumeInputManger()
        {
            DialogueManager.OnDialogueExit -= ResumeInputManger;
            DialogueManager.OnDialogueEnter += PauseInputManager;
            inputActions.PlayerControls.Attack.performed += AttackButtonPressed;
        }

        private void RemoveEventFromListener()
        {
            inputActions.PlayerControls.Attack.performed -= AttackButtonPressed;
            inputActions.PlayerControls.Interact.performed -= InteractButtonPressed;
            inputActions.PlayerControls.Submit.performed -= SubmitButtonPressed;
        }

        void Update()
        {
            if(DialogueManager.GetInstance().DialogueIsPlaying)
                return;

            moveInput = inputActions.PlayerControls.Movement.ReadValue<Vector2>();
            characterControl.MoveInput = moveInput;

            characterControl.MoveX = moveInput.x > 0 || moveInput.x < 0;
            characterControl.MoveY = moveInput.y > 0 || moveInput.y < 0;
            //characterControl.Jump   = (Input.GetKey(KeyCode.Space));
        }
        private void AttackButtonPressed(InputAction.CallbackContext obj)
        {
            characterControl.Attack = true;
            Debug.Log("Attack");
            OnAttackPressed?.Invoke();
        }

        public void InteractButtonPressed(InputAction.CallbackContext context)
        {
            OnInteractPressed?.Invoke();
        }

        public void SubmitButtonPressed(InputAction.CallbackContext context)
        {
            OnSubmitPressed?.Invoke();
        }
    }
}
