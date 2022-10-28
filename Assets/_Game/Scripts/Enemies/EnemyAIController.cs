using Pada1.BBCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using Random = UnityEngine.Random;

namespace kl
{
    public class EnemyAIController : MonoBehaviour
    {
        private CharacterControl characterControl;
        private Rigidbody2D rigidbody2;

        [SerializeField] private Transform target;

        [Header("Patrol Settings")]
        [SerializeField] private List<Transform> wayPoints;
        [Range(0f, 8f)]
        [SerializeField] private float patrolSpeed;
        [Range(0f, 1f)]
        [SerializeField] private float targetPatrolDistance;
        [Header("Chase Settings")]
        [SerializeField] private AIVision aiVision;
        [SerializeField] private bool isTargetVisible = false;
        [SerializeField] private bool isAtTarget = false;
        [Range(0f, 5f)]
        [SerializeField] private float chaseSpeed;
        [Range(0f, 10f)]
        [SerializeField] private float targetChaseDistance;
        [Range(0f, 10f)]
        [SerializeField] private float targetMemoryDuration;
        [Range(0, 2)]
        [SerializeField] private float chaseDalay;
        [SerializeField] private float forgetTargetTime;
        [Header("Attack Settings")]
        [SerializeField] private Animator animatorAttack;
        [Range(1f, 2f)]
        [SerializeField] private float timeToAttack = 2f;
        [Range(0.1f, 2f)]
        [SerializeField] private float attackSpeed = 0.1f;
        [SerializeField] private Transform muzzle;
        [SerializeField] private Transform triggerDamage;
        [Header("DEBUG")]
        [SerializeField] public string DebugStr;//somente para debug
        [SerializeField] private Vector2 moveAxis;
        [SerializeField] private bool isCoroutineStarted = false;//SerializedField apenas pra debug

        private int wayPointIndex;

        public Vector2 MoveAxis { get => moveAxis; set => moveAxis = value; }
        public List<Transform> WayPoints { get => wayPoints; set => wayPoints = value; }
        public float PatrolSpeed { get => patrolSpeed; set => patrolSpeed = value; }
        public float ChaseSpeed { get => chaseSpeed; set => chaseSpeed = value; }
        public bool IsAtTarget { get => isAtTarget; set => isAtTarget = value; }
        public Transform TriggerDamage { get => triggerDamage; set => triggerDamage = value; }
        public float AttackSpeed { get => attackSpeed; set => attackSpeed = value; }
        public Transform Target { get => target; set => target = value; }
        public Animator AnimatorAttack { get => animatorAttack; set => animatorAttack = value; }

        protected virtual void Awake()
        {
            characterControl = this.GetComponent<CharacterControl>();
            rigidbody2 = this.GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            StartCoroutine(TriggerTimerAttack());
            StartCoroutine(Patrol());
            StartCoroutine(ChaseTarget());
        }

        private void Update()
        {
            SetMove();
            CheckIsTargetVisible();
        }

        private void SetMove()
        {
            if (isAtTarget)
            {
                MoveAxis = Vector2.zero;
            }
            characterControl.MoveX = MoveAxis.x > 0 || MoveAxis.x < 0;
            characterControl.MoveY = MoveAxis.y > 0 || MoveAxis.y < 0;
        }

        public void Move(Transform target, float chaseSpeed, float targetDistance)
        {
            Vector3 toTarget = target.position - transform.position;
            toTarget.Normalize();
            MoveAxis = new Vector2(Mathf.Round(toTarget.x), Mathf.Round(toTarget.y));

            if (Vector3.Distance(target.position, transform.position) < targetDistance)
            {
                isAtTarget = true;
                MoveAxis = Vector2.zero;
            }
            else
            {
                if (!isAtTarget)
                    transform.Translate(chaseSpeed * Time.fixedDeltaTime * toTarget);
            }
        }

        #region Attack
        IEnumerator TriggerTimerAttack()
        {
            while (true)
            {
                if (isAtTarget)
                {
                    characterControl.Attack = true;
                }
                float randomDalay = Random.Range(0.5f, timeToAttack);
                yield return new WaitForSeconds(randomDalay);
            }
        }
        #endregion

        #region Chase Target

        public void LookAtTarget(Transform target)
        {
            float angle = Angle(target.position, muzzle.position);
            muzzle.eulerAngles = new Vector3(0, 0, angle);
        }

        private float Angle(Vector3 point1, Vector3 point2)
        {
            Vector3 points = point1 - point2;
            points.Normalize();
            return Mathf.Atan2(points.y, points.x) * Mathf.Rad2Deg;
        }

        public void CheckIsTargetVisible()
        {
            if (aiVision.IsVisible(target))
            {
                forgetTargetTime = Time.time + targetMemoryDuration;
                isTargetVisible = true;
            }
            else
            {
                isTargetVisible = Time.time < forgetTargetTime;
            }
        }

        IEnumerator ChaseTarget()
        {
            while (true)
            {
                if (isTargetVisible)
                {
                    if (IsAtTarget)
                    {
                        LookAtTarget(target);
                        if(Vector3.Distance(target.position, transform.position) > targetChaseDistance)
                        {
                            yield return new WaitForSeconds(chaseDalay);
                            IsAtTarget = false;
                        }
                    }
                    else
                    {
                        Move(target, chaseSpeed, targetChaseDistance);
                    }
                }
                yield return new WaitForSeconds(0.02f);
            }
        }
        #endregion

        #region Patrol

        IEnumerator Patrol()
        {
            wayPointIndex = Random.Range(0, WayPoints.Count);
            while (true)
            {
                if (!isTargetVisible)
                {
                    if (isAtTarget)
                    {
                        yield return new WaitForSeconds(wayPointIndex);
                        wayPointIndex = Random.Range(0, WayPoints.Count);
                        isAtTarget = false;
                    }
                    else
                    {
                        Move(WayPoints[wayPointIndex], patrolSpeed, targetPatrolDistance);
                    }
                }
                yield return new WaitForSeconds(seconds: 0.02f);
            }
        }
        #endregion
    }
}