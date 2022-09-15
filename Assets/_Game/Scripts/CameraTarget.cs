using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace kl
{
    public class CameraTarget : MonoBehaviour
    {
        [SerializeField] private CharacterControl characterControl;
        [SerializeField] private Transform cameraTarget;
        [Range(0f, 5f)]
        [SerializeField] float cameraTargetOffsetX = 2f;
        [Range(0f, 5f)]
        [SerializeField] float cameraTargetOffsetY = 2f;
        [Range(0.5f, 50f)]
        [SerializeField] float cameraTargetFlipSpeed = 2f;
        [Range(0f, 5f)]
        [SerializeField] float characterSpeedInfluence = 2f;

        private void FixedUpdate()
        {
            float currentOffsetX = Mathf.Lerp(cameraTarget.localPosition.z, cameraTargetOffsetX, Time.fixedDeltaTime * cameraTargetFlipSpeed);

            currentOffsetX += Time.fixedDeltaTime * characterSpeedInfluence;
            //cameraTarget.localPosition = new Vector3(cameraTarget.localPosition.x, cameraTarget.localPosition.y, currentOffsetZ);
        }
    }
}