using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class GroundCheck : MonoBehaviour
    {
        [SerializeField] float skinWidth = 0.05f;

        [SerializeField] float radius = 0.5f;

        LayerMask ground;

        CharacterController cc;

        public bool Grounded =>
                Physics.CheckSphere(transform.position, radius, ground);

        public bool Grounded2 => true;

        private void Awake()
        {
            cc = GetComponentInParent<CharacterController>();

            radius = cc.radius;
            transform.position = cc.transform.position - 
                (0.25f + skinWidth) * cc.height * Vector3.up;

            ground = LayerMask.GetMask("Environment");
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.black;
            Gizmos.DrawWireSphere(transform.position, radius);
        }
    }
}