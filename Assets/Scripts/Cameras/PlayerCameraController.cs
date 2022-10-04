using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class PlayerCameraController : MonoBehaviour
    {
        public CameraController Cc { get; private set; }

        public ThirdPersonCameraController Tp { get; private set; }
        public TopDownCameraController Td { get; private set; }
        public SideScrollCameraController Ss { get; private set; }
        public FirstPersonCameraController Fp { get; private set; }

        public PartyController Party { get; private set; }
        public Transform Follow { get; private set; }

        public Movement Movement { get; private set; }

        private void Awake()
        {
            Party = GetComponentInParent<PartyController>();
            Follow = Party.transform;

            Movement = GetComponentInParent<Movement>();

            Tp = GetComponentInChildren<ThirdPersonCameraController>();
            Td = GetComponentInChildren<TopDownCameraController>();
            Ss = GetComponentInChildren<SideScrollCameraController>();
            Fp = GetComponentInChildren<FirstPersonCameraController>();

            Cc = FindObjectOfType<CameraController>();
        }

        public void SwitchCamera(MovementState state)
        {
            switch (state)
            {
                case MovementState.ThirdPersonFree:
                    Cc.CurrentCamera = Tp;
                    break;
                case MovementState.TopDown:
                    Cc.CurrentCamera = Td;
                    break;
                case MovementState.SideScroll:
                    Cc.CurrentCamera = Ss;
                    break;
                case MovementState.FirstPersonFree:
                    Cc.CurrentCamera = Fp;
                    break;
            }
        }
    }
}