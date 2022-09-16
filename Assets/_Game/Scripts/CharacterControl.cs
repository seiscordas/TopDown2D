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
        [SerializeField] private bool moveX;
        [SerializeField] private bool moveY;
        [SerializeField] private bool jump;
        [SerializeField] private bool facingRight;
        [SerializeField] private bool facingUp = true;

        public bool MoveX { get => moveX; set => moveX = value; }
        public bool MoveY { get => moveY; set => moveY = value; }
        public bool Jump { get => jump; set => jump = value; }
        public bool FacingRight { get => facingRight; set => facingRight = value; }
        public bool FacingUp { get => facingUp; set => facingUp = value; }

        private void OnAttackInput(InputAction.CallbackContext obj)
        {
            Debug.Log("Do Attack!");
        }
    }
    public enum TransitionParameter
    {
        Jump,
        ForceTransition,
        Move,
        MoveX,
        MoveY
    }
}