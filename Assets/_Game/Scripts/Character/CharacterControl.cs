using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace kl
{
    public class CharacterControl : MonoBehaviour
    {
        //public Animator Animator;

        [SerializeField] private Transform root;

        [SerializeField] private bool moveX;
        [SerializeField] private bool moveY;
        [SerializeField] private bool jump;
        [SerializeField] private bool facingUp;
        [SerializeField] private bool facingLeft;
        [SerializeField] private bool facingDown = true;
        [SerializeField] private bool facingRight;
        [SerializeField] private bool attack;
        [SerializeField] private bool dead;

        [SerializeField] private Vector2 moveInput;
        public Vector2 MoveInput { get => moveInput; set => moveInput = value; }

        public bool MoveX { get => moveX; set => moveX = value; }
        public bool MoveY { get => moveY; set => moveY = value; }
        public bool Jump { get => jump; set => jump = value; }
        public bool FacingUp { get => facingUp; set => facingUp = value; }
        public bool FacingLeft { get => facingLeft; set => facingLeft = value; }
        public bool FacingDown { get => facingDown; set => facingDown = value; }
        public bool FacingRight { get => facingRight; set => facingRight = value; }
        public bool Attack { get => attack; set => attack = value; }
        public bool Dead { get => dead; set => dead = value; }
        public virtual bool Interact { get; internal set; }
        public Transform Root { get => root; set => root = value; }

        public void SetFaceDirection(float x, float y)
        {
            if (x != 0 || y != 0)
            {
                facingRight = x > 0;
                facingLeft = x < 0;
                facingUp = y > 0;
                facingDown = y < 0;
            }
        }
    }
    public enum TransitionParameter
    {
        Jump,
        ForceTransition,
        Move,
        MoveX,
        MoveY,
        Attack,
        Dead
    }
}