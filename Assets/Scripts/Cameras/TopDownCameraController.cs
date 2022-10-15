using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class TopDownCameraController : PlayerCamera
    {
        [SerializeField] float distance = 16f;
        [SerializeField] float angleFromVertical = 12f;

        float afvRad;

        protected override void Awake()
        {
            base.Awake();

            afvRad = angleFromVertical * Mathf.Deg2Rad;
        }

        private void Update()
        {
            Move(Vector2.zero);

            if (pcc.Party.Ts.Locked) transform.LookAt(pcc.Party.Ts.Tf.transform);
            else transform.LookAt(pcc.Follow);
        }

        protected override void Move(Vector2 inputDir)
        {
            if (pcc.Party.Ts.Locked)
            {
                transform.position = pcc.Party.Ts.Tf.transform.position + 
                    distance * Mathf.Cos(afvRad) * Vector3.up - 
                    distance * Mathf.Sin(afvRad) * Vector3.forward;
            }
            else
            {
                transform.position = pcc.Follow.position + 
                    distance * Mathf.Cos(afvRad) * Vector3.up -
                    distance * Mathf.Sin(afvRad) * Vector3.forward;
            }
        }

        public Vector3 TargetCamPos()
        {
            return pcc.Follow.position + distance * Mathf.Cos(afvRad) * Vector3.up - 
                distance * Mathf.Sin(afvRad) * Vector3.forward;
        }
    }
}