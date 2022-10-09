using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] public float updateSpeed = 50f;

        [field: SerializeField] public PlayerCamera CurrentCamera { get; set; }

        public Transform Follow { get; private set; }

        private void Start()
        {
            Follow = FindObjectOfType<PlayerInputReader>().transform;
        }

        private void LateUpdate()
        {
            if (CurrentCamera != null)
            {
                transform.position = Vector3.MoveTowards(transform.position,
                    CurrentCamera.transform.position, updateSpeed * Time.deltaTime);

                transform.rotation = CurrentCamera.transform.rotation;
            }
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