using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class TargetSphere : MonoBehaviour
    {
        [field: SerializeField] public bool Locked { get; private set; } = false;

        [field: SerializeField] public List<Target> Targets { get; private set; } = 
            new List<Target>();
        [field: SerializeField] public Target CurrentTarget { get; private set; }

        public TargetFocus Tf { get; private set; }

        public Movement Movement { get; private set; }
        public InputReader Ir { get; private set; }

        public Transform CurrentTargetTransform => CurrentTarget?.transform;

        private void Awake()
        {
            Tf = GetComponentInChildren<TargetFocus>();

            Movement = GetComponentInParent<Movement>();
            Ir = GetComponentInParent<InputReader>();
        }

        private void OnEnable()
        {
            Ir.OnToggleLockAction += ToggleLock;
        }

        private void OnDisable()
        {
            Ir.OnToggleLockAction -= ToggleLock;
        }

        private void OnTriggerEnter(Collider other)
        {
            var t = other.GetComponentInChildren<Target>();

            if (t)
            {
                if (!t.IsPlayer && !Targets.Contains(t))
                    Targets.Add(t);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            var t = other.GetComponentInChildren<Target>();

            if (t)
            {
                if (Targets.Contains(t))
                {                    
                    Targets.Remove(t);

                    if (t == CurrentTarget)
                    {
                        CurrentTarget = null;
                        GetCurrentTarget();

                        if (CurrentTarget == null) UnlockTarget();
                    }
                }
            }
        }

        void ToggleLock()
        {
            if (!Locked) LockTarget();
            else UnlockTarget();
        }

        void LockTarget()
        {
            Locked = true;

            GetCurrentTarget();
            if (CurrentTarget == null)
            {
                Locked = false;
            }
            else Movement.SwitchMovementState(MovementState.ThirdPersonStrafe, null);
        }

        void UnlockTarget()
        {
            Locked = false;

            CurrentTarget = null;

            Movement.SwitchMovementState(MovementState.ThirdPersonFree, null);
        }

        void GetCurrentTarget()
        {
            Target closestTarget = null;
            float closestSqrDist = Mathf.Infinity;

            foreach(var t in Targets)
            {
                var sqrDist = (t.transform.position - transform.position).sqrMagnitude;

                if (sqrDist < closestSqrDist)
                {
                    closestTarget = t;
                    closestSqrDist = sqrDist;
                }
            }

            CurrentTarget = closestTarget;
        }
    }
}