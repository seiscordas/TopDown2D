using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace kl
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class CharacterControl : MonoBehaviour
    {
        public Animator Animator;
        private bool moveRight;
        private bool moveLeft;
        private bool moveUp;
        private bool moveDown;
        private bool jump;
        private bool facingRight = true;

        [SerializeField] private float _speed = 10;
        private Rigidbody2D _rb;
        private PlayerInputActions _inputActions;

        public bool MoveRight { get => moveRight; set => moveRight = value; }
        public bool MoveLeft { get => moveLeft; set => moveLeft = value; }
        public bool MoveUp { get => moveUp; set => moveUp = value; }
        public bool MoveDown { get => moveDown; set => moveDown = value; }
        public bool Jump { get => jump; set => jump = value; }
        public bool FacingRight { get => facingRight; set => facingRight = value; }

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _inputActions = new PlayerInputActions();
            _inputActions.PlayerControls.Enable();

            _inputActions.PlayerControls.Attack.performed += OnAttackInput;
        }

        private void OnAttackInput(InputAction.CallbackContext obj)
        {
            Debug.Log("Do Attack!");
        }

        private void Update()
        {
            Vector2 moveInput = _inputActions.PlayerControls.Movement.ReadValue<Vector2>();
            _rb.velocity = _speed * Time.deltaTime * moveInput;
        }
    }
    public enum TransitionParameter
    {
        Move,
        MoveBackward,
        Jump,
        ForceTransition,
        ActiveAim,
        Grounded
    }
}
