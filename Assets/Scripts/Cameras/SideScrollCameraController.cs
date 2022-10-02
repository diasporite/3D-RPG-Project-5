using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class SideScrollCameraController : PlayerCamera
    {
        [SerializeField] float distance = 4f;

        private void Update()
        {
            Move(Vector2.zero);
        }

        protected override void Move(Vector2 inputDir)
        {

        }

        public Vector3 TargetCamPos()
        {
            return pcc.Follow.position - distance * Vector3.forward;
        }
    }
}