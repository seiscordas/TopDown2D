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
            float currentOffsetX = Mathf.Lerp(cameraTarget.localPosition.x, cameraTargetOffsetX, Time.fixedDeltaTime * cameraTargetFlipSpeed);
            float currentOffsetY = Mathf.Lerp(cameraTarget.localPosition.y, cameraTargetOffsetY, Time.fixedDeltaTime * cameraTargetFlipSpeed);

            currentOffsetX += Time.fixedDeltaTime * characterSpeedInfluence;
            cameraTarget.localPosition = new Vector3(currentOffsetX, cameraTarget.localPosition.y, cameraTarget.localPosition.z);
        }
    }
}