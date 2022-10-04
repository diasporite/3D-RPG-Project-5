using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class FirstPersonCameraController : PlayerCamera
    {
        [SerializeField] float speed = 120f;
        [SerializeField] float maxPitch = 30f;
        [SerializeField] float minPitch = -30f;

        [field: SerializeField] public float EulerX { get; private set; } = 0f;
        [field: SerializeField] public float EulerY { get; private set; } = 0f;

        private void Update()
        {
            Move(pcc.Party.Ir.Rotate);
        }

        protected override void Move(Vector2 inputDir)
        {
            EulerX = Mathf.Clamp(EulerX + speed * inputDir.y * Time.deltaTime, 
                minPitch, maxPitch);
            EulerY = (EulerY + speed * inputDir.x * Time.deltaTime) % 360f;

            transform.rotation = Quaternion.Euler(EulerX, EulerY, 0);
        }
    }
}