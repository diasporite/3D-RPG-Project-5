using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class SideScrollCameraController : PlayerCamera
    {
        [SerializeField] float distance = 4f;
        [SerializeField] float height = 1f;

        Vector2 zero = new Vector2(0, 0);

        private void Update()
        {
            Move(zero);
        }

        protected override void Move(Vector2 inputDir)
        {
            var path = pcc.Party.Movement.CurrentPath;

            if (path != null)
            {
                var rightward = pcc.Party.Movement.CurrentPath.Rightward;
                var orthoPath = Quaternion.Euler(0, 90f, 0) * rightward;

                transform.position = pcc.Party.CurrentController.Cm.transform.position +
                    distance * orthoPath + height * Vector3.up;
            }

            transform.LookAt(pcc.Follow);
        }

        public Vector3 TargetCamPos()
        {
            return pcc.Follow.position - distance * Vector3.forward;
        }
    }
}