using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace kl
{
    public class AIVision : MonoBehaviour
    {
        [Range(0.5f, 10f)]
        [SerializeField] private float visionRange = 5;

        [Range(0, 360)]
        [SerializeField] private float visionAngle = 45;

        private CharacterControl characterControl;

        private void Start()
        {
            characterControl = GetComponent<CharacterControl>();
        }

        public bool IsVisible(GameObject target)
        {
            if (target == null)
            {
                return false;
            }
            if (Vector2.Distance(transform.position, target.transform.position) > visionRange)
            {
                return false;
            }

            Vector2 toTarget = target.transform.position - transform.position;
            Vector2 visionDirection = GetFaceDirection();

            if (Vector2.Angle(visionDirection, toTarget) > visionAngle / 2)
            {
                return false;
            }
            //TODO: checar objetos bloqueando visão
            return true;
        }

        private void OnDrawGizmosSelected()
        {

            Gizmos.DrawWireSphere(transform.position, visionRange);
            Vector3 visionDirection = GetFaceDirection();
            Gizmos.DrawLine(transform.position, transform.position + Quaternion.Euler(0, 0, visionAngle / 2) * visionDirection * visionRange);
            Gizmos.DrawLine(transform.position, transform.position + Quaternion.Euler(0, 0, -visionAngle / 2) * visionDirection * visionRange);
            //Debug.Log("visionDirection..."+ visionDirection);
        }

        private Vector2 GetFaceDirection()
        {
            Vector3 direction = Vector3.down;
            if (characterControl)
            {
                if (characterControl.FacingUp)
                {
                    direction = Vector3.up;
                }
                if (characterControl.FacingLeft)
                {
                    direction = Vector3.left;
                }
                if (characterControl.FacingDown)
                {
                    direction = Vector3.down;
                }
                if (characterControl.FacingRight)
                {
                    direction = Vector3.right;
                }
            }
            return direction;
        }
    }
}

