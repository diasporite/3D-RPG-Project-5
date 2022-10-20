using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

namespace RPG_Project
{
    public class PlayerCameraControllerCinemachine : MonoBehaviour
    {
        [field: SerializeField] public CinemachineFreeLook TpFree { get; private set; }
        [field: SerializeField] public CinemachineVirtualCamera TpLocked { get; private set; }

        PartyController party;

        Movement movement;
        TargetSphere ts;

        private void Awake()
        {
            party = GetComponentInParent<PartyController>();
            movement = GetComponentInParent<Movement>();
            ts = party.GetComponentInChildren<TargetSphere>();
        }

        private void OnEnable()
        {
            ts.OnTargetLock += SwitchToLockedCamera;
            ts.OnTargetUnlock += SwitchToFreeCamera;
        }

        private void OnDisable()
        {
            ts.OnTargetLock -= SwitchToLockedCamera;
            ts.OnTargetUnlock -= SwitchToFreeCamera;
        }

        public void SwitchCamera(MovementState state)
        {
            switch (state)
            {
                case MovementState.ThirdPerson:
                    TpFree.Priority = 15;
                    break;
                case MovementState.TopDown:
                    break;
                case MovementState.SideScroll:
                    break;
                case MovementState.FirstPerson:
                    break;
            }
        }

        void SwitchToLockedCamera()
        {
            TpLocked.Priority = 15;
            TpFree.Priority = 10;
        }

        void SwitchToFreeCamera()
        {
            TpFree.Priority = 15;
            TpLocked.Priority = 10;
        }
    }
}