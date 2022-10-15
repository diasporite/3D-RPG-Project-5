using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class TargetSphere : MonoBehaviour
    {
        [field: SerializeField] public TargetType[] Types { get; private set; }

        [field: SerializeField] public bool Locked { get; private set; } = false;

        [field: SerializeField] public List<Target> Targets { get; private set; } = 
            new List<Target>();
        [field: SerializeField] public Target CurrentTarget { get; private set; }

        public TargetFocus Tf { get; private set; }

        public Movement Movement { get; private set; }
        public InputReader Ir { get; private set; }

        Camera main;

        public Transform CurrentTargetTransform => CurrentTarget?.transform;

        private void Awake()
        {
            Tf = GetComponentInChildren<TargetFocus>();

            Movement = GetComponentInParent<Movement>();
            Ir = GetComponentInParent<InputReader>();
        }

        private void Start()
        {
            main = Camera.main;
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
                if (t.transform.root != transform.root && !Targets.Contains(t) && 
                    Array.Exists(Types, i => i == t.Type))
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
        }

        void UnlockTarget()
        {
            Locked = false;

            CurrentTarget = null;
        }

        void GetCurrentTarget()
        {
            Target closestTarget = null;
            float closestSqrDist = Mathf.Infinity;

            Vector2 screenPos;

            foreach(var t in Targets)
            {
                screenPos = main.WorldToViewportPoint(t.transform.position);

                //if (!(screenPos.x > 0 && screenPos.x < 1 && screenPos.y > 0 && screenPos.y < 1)) continue;
                if (t.GetComponentInChildren<Renderer>().isVisible) continue;

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