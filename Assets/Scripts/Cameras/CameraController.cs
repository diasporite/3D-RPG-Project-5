using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] float linearUpdateSpeed = 50f;
        [SerializeField] float rotationalUpdateSpeed = 180f;

        [field: SerializeField] public PlayerCamera CurrentCamera { get; set; }

        public Transform Follow { get; private set; }

        private void LateUpdate()
        {
            if (CurrentCamera != null)
            {
                transform.position = Vector3.MoveTowards(transform.position,
                    CurrentCamera.transform.position, linearUpdateSpeed * Time.unscaledDeltaTime);

                transform.rotation = Quaternion.RotateTowards(transform.rotation,
                    CurrentCamera.transform.rotation, rotationalUpdateSpeed * Time.unscaledDeltaTime);
            }
        }

        public void Init(Transform player)
        {
            Follow = player.transform;
        }

        float RoundAngle(float angle)
        {
            if (angle < 90) return 0;
            if (angle <= 90 && angle < 270) return 180;

            return 0;
        }

        public void InstantFollow()
        {
            if (CurrentCamera != null)
            {
                transform.position = CurrentCamera.transform.position;
                transform.LookAt(Follow);
            }
        }
    }
}