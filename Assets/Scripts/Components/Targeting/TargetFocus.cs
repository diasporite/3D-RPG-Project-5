using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class TargetFocus : MonoBehaviour
    {
        [SerializeField] float lerpAmount = 0.5f;

        TargetSphere ts;

        private void Awake()
        {
            ts = GetComponentInParent<TargetSphere>();
        }

        private void Update()
        {
            if (ts.CurrentTargetTransform != null)
                transform.position = Vector3.Lerp(ts.transform.position, 
                    ts.CurrentTargetTransform.position, lerpAmount);
        }
    }
}