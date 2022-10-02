using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class SideScrollCameraController : PlayerCamera
    {
        [SerializeField] float distance = 4f;
        [SerializeField] float height = 1f;

        private void Update()
        {
            Move(pcc.Party.Ir.Move);
        }

        protected override void Move(Vector2 inputDir)
        {
            if (inputDir.x > 0)
                transform.position = pcc.Party.CurrentController.Cm.transform.position + 
                    distance * pcc.Party.CurrentController.Cm.transform.right + height * Vector3.up;
            else if (inputDir.x < 0)
                transform.position = pcc.Party.CurrentController.Cm.transform.position - 
                    distance * pcc.Party.CurrentController.Cm.transform.right + height * Vector3.up;
        }

        public Vector3 TargetCamPos()
        {
            return pcc.Follow.position - distance * Vector3.forward;
        }
    }
}