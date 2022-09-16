using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        [SerializeField] private bool facingUp = false;
        [SerializeField] private bool attackSword = true;

        public bool MoveX { get => moveX; set => moveX = value; }
        public bool MoveY { get => moveY; set => moveY = value; }
        public bool Jump { get => jump; set => jump = value; }
        public bool FacingRight { get => facingRight; set => facingRight = value; }
        public bool FacingUp { get => facingUp; set => facingUp = value; }
        public bool Attack { get => attackSword; set => attackSword = value; }        
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