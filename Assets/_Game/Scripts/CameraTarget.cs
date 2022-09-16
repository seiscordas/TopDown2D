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
        [SerializeField] float cameraTargetOffset = 2f;
        [Range(0.5f, 50f)]
        [SerializeField] float cameraTargetFlipSpeed = 2f;
        [Range(0f, 5f)]
        [SerializeField] float characterSpeedInfluence = 2f;

        private void FixedUpdate()
        {
            float targetOffsetX = KeyboardInput.MoveInput.x * cameraTargetOffset;
            float targetOffsetY = KeyboardInput.MoveInput.y * cameraTargetOffset;
            float currentOffsetX = Mathf.Lerp(cameraTarget.localPosition.x, targetOffsetX, Time.fixedDeltaTime * cameraTargetFlipSpeed);
            float currentOffsetY = Mathf.Lerp(cameraTarget.localPosition.y, targetOffsetY, Time.fixedDeltaTime * cameraTargetFlipSpeed);
            cameraTarget.localPosition = new Vector3(currentOffsetX, currentOffsetY, cameraTarget.localPosition.z);
        }
    }
}