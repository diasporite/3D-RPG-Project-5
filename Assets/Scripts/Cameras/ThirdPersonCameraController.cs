using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    [System.Serializable]
    public class CameraOrbit
    {
        [field: SerializeField] public float Radius { get; private set; } = 1f;
        [field: SerializeField] public float Height { get; private set; } = 1f;

        public CameraOrbit(float radius, float height)
        {
            Radius = radius;
            Height = height;
        }
    }

    public class ThirdPersonCameraController : PlayerCamera
    {
        [SerializeField] public bool Locked { get; private set; }

        [Header("Settings")]
        [SerializeField] float pitchSpeed = 1f;
        [SerializeField] float yawSpeed = 90f;

        [Header("Variables")]
        [SerializeField] float height = 0f;
        [SerializeField] float radius = 0f;
        [SerializeField] float theta = 0f;

        [field: Header("Orbits")]
        [field: SerializeField] public CameraOrbit TopOrbit { get; private set; }
        [field: SerializeField] public CameraOrbit MiddleOrbit { get; private set; }
        [field: SerializeField] public CameraOrbit BottomOrbit { get; private set; }

        [Header("Transforms")]
        [SerializeField] Transform freeTarget;
        [SerializeField] Transform lockTarget;

        InputReader input;

        public Transform CurrentTarget
        {
            get
            {
                if (Locked) return lockTarget;

                return freeTarget;
            }
        }

        protected override void Awake()
        {
            base.Awake();

            input = GetComponentInParent<InputReader>();

            height = MiddleOrbit.Height;
            radius = MiddleOrbit.Radius;
            theta = 0;
        }

        private void Update()
        {
            Move(input.Rotate);
        }

        protected override void Move(Vector2 input)
        {
            height = Mathf.Clamp(height + input.y * pitchSpeed * Time.unscaledDeltaTime,
                BottomOrbit.Height, TopOrbit.Height);
            theta = (theta + input.x * yawSpeed * Time.unscaledDeltaTime) % 360f;

            radius = InterpolateRadius(height);
        }

        public Vector3 TargetCamPos()
        {
            return pcc.Follow.transform.position +
                height * Vector3.up + radius * (Mathf.Sin(theta * Mathf.Deg2Rad) *
                Vector3.right - Mathf.Cos(theta * Mathf.Deg2Rad) * Vector3.forward);
        }

        void DrawRadii(CameraOrbit orbit)
        {
            Gizmos.DrawLine(transform.position + orbit.Height * transform.up -
                orbit.Radius * transform.forward, transform.position + orbit.Height * transform.up +
                orbit.Radius * transform.forward);
            Gizmos.DrawLine(transform.position + orbit.Height * transform.up -
                orbit.Radius * transform.right, transform.position + orbit.Height * transform.up +
                orbit.Radius * transform.right);
        }

        float InterpolateRadius(float height)
        {
            if (height >= TopOrbit.Height) return TopOrbit.Radius;

            if (height >= MiddleOrbit.Height)
            {
                return Interpolate(height, MiddleOrbit.Height, TopOrbit.Height, 
                    MiddleOrbit.Radius, TopOrbit.Radius);
            }

            if (height >= BottomOrbit.Height)
            {
                return Interpolate(height, BottomOrbit.Height, MiddleOrbit.Height, 
                    BottomOrbit.Radius, MiddleOrbit.Radius);
            }
            
            return 3f;
        }

        float Interpolate(float height, float h0, float h1, float r0, float r1)
        {
            return r0 + (r1 - r0) * (height - h0) / (h1 - h0);
        }

        #region InterfaceMethods
        public Vector3 ExpectedCamPosition(Transform follow, Transform target)
        {
            if (Locked)
            {
                var ds = (target.position - follow.position).normalized;
                ds.y = 0;

                theta = -Camera.main.transform.eulerAngles.y;

                return follow.transform.position + height * Vector3.up - radius * ds;
            }

            return follow.transform.position +
                height * Vector3.up + radius * (Mathf.Sin(theta * Mathf.Deg2Rad) *
                Vector3.right - Mathf.Cos(theta * Mathf.Deg2Rad) * Vector3.forward);
        }

        public void LockCamera(bool value)
        {
            Locked = value;

            if (Locked)
            {
                height = 0.5f * (TopOrbit.Height - MiddleOrbit.Height) + MiddleOrbit.Height;
                radius = InterpolateRadius(height);
            }
        }
        #endregion
    }
}