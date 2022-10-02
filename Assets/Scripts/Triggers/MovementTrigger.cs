using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class MovementTrigger : MonoBehaviour
    {
        [SerializeField] MovementState state;
        SideScrollPathLinear sspath;

        private void Awake()
        {
            sspath = GetComponent<SideScrollPathLinear>();
        }

        private void OnTriggerEnter(Collider other)
        {
            var move = other.GetComponent<Movement>();

            if (move)
            {
                switch (state)
                {
                    case MovementState.TopDown:
                        move.SwitchMovementState(MovementState.TopDown, null);
                        break;
                    case MovementState.SideScroll:
                        move.SwitchMovementState(MovementState.SideScroll, sspath);
                        break;
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            var move = other.GetComponent<Movement>();

            if (move)
                move.SwitchMovementState(MovementState.ThirdPersonFree, null);
        }
    }
}