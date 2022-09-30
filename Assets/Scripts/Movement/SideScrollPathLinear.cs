using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class SideScrollPathLinear : MonoBehaviour
    {
        // One is kept at (0, 0, 0)
        [SerializeField] Transform left;
        [SerializeField] Transform right;

        Vector3 Size => right.position - left.position;
        public Vector3 Rightward => Size.normalized;

        public Vector3 ClosestEnd(Vector3 pos)
        {
            var leftDist = Vector3.Distance(pos, left.position);
            var rightDist = Vector3.Distance(pos, right.position);

            if (leftDist <= rightDist) return left.position;

            return right.position;
        }

        private void Awake()
        {
            var col = GetComponent<BoxCollider>();
            col.center = 0.5f * Size;
            col.size = Size;
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawLine(left.position, right.position);
        }
    }
}