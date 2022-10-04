using Pada1.BBCore;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

namespace kl
{
    public class EnemyAIController : MonoBehaviour
    {
        private CharacterControl characterControl;
        private Rigidbody2D rigidbody2;

        [SerializeField] private List<Transform> wayPoints;
        [SerializeField] private float patrolSpeed;
        [SerializeField] private float chaseSpeed;
        [SerializeField] private float targetDistanceChase;
        [SerializeField] private float targetDistancePatrol;
        [SerializeField] private bool atTarget = false;
        [SerializeField] public string DebugStr;

        private Vector2 moveAxis;
        public Vector2 MoveAxis { get => moveAxis; set => moveAxis = value; }
        public List<Transform> WayPoints { get => wayPoints; set => wayPoints = value; }
        public float PatrolSpeed { get => patrolSpeed; set => patrolSpeed = value; }
        public float ChaseSpeed { get => chaseSpeed; set => chaseSpeed = value; }
        public bool AtTarget { get => atTarget; set => atTarget = value; }

        private void Awake()
        {
            characterControl = this.GetComponent<CharacterControl>();
            rigidbody2 = this.GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            //Debug.Log(MoveAxis.x +"//"+MoveAxis.x);
            //characterControl.Jump = VirtualInputManager.Instance.Jump;
            //characterControl.Attack = VirtualInputManager.Instance.Attack;
            SetAxis();
        }

        private void SetAxis()
        {
            characterControl.MoveX = MoveAxis.x > 0 || MoveAxis.x < 0;
            characterControl.MoveY = MoveAxis.y > 0 || MoveAxis.y < 0;
        }

        public void Move(Transform target, float chaseSpeed, float targetDistance)
        {
            atTarget = false;
            Vector3 toTarget = target.position - transform.position;
            toTarget.Normalize();
            MoveAxis = new Vector2(Mathf.Round(toTarget.x), Mathf.Round(toTarget.y));

            if (Vector3.Distance(target.position, transform.position) < targetDistance)
            {
                atTarget = true;
                MoveAxis = Vector2.zero;
            }
            if (!atTarget)
            {
                transform.Translate(chaseSpeed * Time.fixedDeltaTime * toTarget);
            }
        }

        internal void DoAttack(float attackForce)
        {
            throw new NotImplementedException();
        }
    }
}
////TODO: CRIAR ATTACK