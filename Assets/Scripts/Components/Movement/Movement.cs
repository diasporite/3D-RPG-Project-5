using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public enum MovementState
    {
        ThirdPerson = 0,
        TopDown = 1,
        SideScroll = 2,
    }

    public class Movement : MonoBehaviour
    {
        public event Action OnStateSwitch;

        [field: SerializeField] public MovementState State { get; private set; } = 
            MovementState.ThirdPerson;

        [field: Header("Speeds")]
        [field: SerializeField] public float WalkSpeed { get; private set; } = 5f;
        [field: SerializeField] public float RunSpeed { get; private set; } = 8f;
        [field: SerializeField] public float StrafeSpeed { get; private set; } = 3f;
        [field: SerializeField] public float FallSpeed { get; private set; } = 2f;

        [Header("Forces")]
        [SerializeField] Vector3 forceVelocity;
        [SerializeField] float damping = 50f;
        [field: SerializeField] public float VerticalVelocity { get; private set; } = 0f;
        [SerializeField] float terminalVelocity = -60f;
        [field: SerializeField] public bool Grounded { get; private set; }
        float gravity = -19.62f;    // 9.81 too weak

        [field: Header("Rotation")]
        [field: SerializeField] public float RotationSpeed { get; private set; } = 720f;
        [SerializeField] bool invertX = false;
        [SerializeField] bool invertY = false;
        bool isPlayer;

        PartyController party;

        CharacterController cc;

        CharacterModel cm;

        Camera main;

        GroundCheck gc;

        private void Awake()
        {
            party = GetComponent<PartyController>();

            cc = GetComponent<CharacterController>();

            cm = GetComponentInChildren<CharacterModel>();

            main = Camera.main;

            gc = GetComponentInChildren<GroundCheck>();
        }

        private void Start()
        {
            isPlayer = GetComponentInParent<PartyController>().IsPlayer;
        }

        private void Update()
        {
            UpdateForce();
            UpdateGravity();
        }

        private void OnEnable()
        {
            party.OnCharacterChange += UpdateSpeeds;
        }

        private void OnDisable()
        {
            party.OnCharacterChange -= UpdateSpeeds;
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawRay(transform.position, 5f * transform.forward);
        }

        public void MovePosition(Vector2 inputDir, float dt, bool running)
        {
            switch (State)
            {
                case MovementState.ThirdPerson:
                    MovePosition3rdPerson(inputDir, dt, running);
                    break;
                case MovementState.TopDown:
                    MovePositionTopDown(inputDir, dt, running);
                    break;
                case MovementState.SideScroll:
                    MovePositionSideScroll(inputDir, dt, running);
                    break;
                default:
                    MovePosition3rdPerson(inputDir, dt, running);
                    break;
            }
        }

        public void MovePosition3rdPerson(Vector2 inputDir, float dt, bool running)
        {
            var speed = WalkSpeed;

            if (running) speed = RunSpeed;

            var ds = inputDir.x * transform.right + inputDir.y * transform.forward;

            if (isPlayer) RotateRelativeToCamera(inputDir);
            else RotateTowards(inputDir);

            //cm.RotateTowards(inputDir);

            if (ds != Vector3.zero) cc.Move(WalkSpeed * ds * dt);
        }

        public void MovePositionTopDown(Vector2 dir, float dt, bool running)
        {
            var speed = WalkSpeed;

            if (running) speed = RunSpeed;

            var x = 1f;
            var y = 1f;

            if (invertX) x = -1f;
            if (invertY) y = -1f;

            var ds = x * dir.x * transform.right + y * dir.y * transform.forward;
            //RotateRelativeToCamera(ds);
            //cm.RotateTowards(dir);
            if (ds != Vector3.zero) cc.Move(speed * ds * dt);
        }

        public void MovePositionSideScroll(Vector2 dir, float dt, bool running)
        {
            var speed = WalkSpeed;

            if (running) speed = RunSpeed;

            var ds = transform.right * dir.x;
            //cm.RotateTowards(ds);
            if (ds != Vector3.zero) cc.Move(speed * ds * dt);
        }

        public void MoveAir(Vector2 inputDir, float dt)
        {
            
        }

        public void ApplyForce(Vector3 impulse)
        {
            forceVelocity += impulse;
        }

        void UpdateForce()
        {
            if (forceVelocity == Vector3.zero) return;

            cc.Move(forceVelocity * Time.deltaTime);

            forceVelocity = Vector3.MoveTowards(forceVelocity, 
                Vector3.zero, damping * Time.deltaTime);

            if (forceVelocity.sqrMagnitude < 1e-3f)
                forceVelocity = Vector3.zero;
        }

        void UpdateGravity()
        {
            Grounded = gc.Grounded;

            if (!Grounded)
            {
                VerticalVelocity = Mathf.Clamp(VerticalVelocity + gravity * Time.deltaTime,
                    -Mathf.Abs(terminalVelocity), Mathf.Abs(terminalVelocity));
                cc.Move(VerticalVelocity * Vector3.up * Time.deltaTime);
            }
            else
            {
                VerticalVelocity = 0;
                cc.Move(gravity * Vector3.up * Time.deltaTime);
            }
        }

        void RotateTowards(Vector2 inputDir)
        {
            if (inputDir != Vector2.zero)
            {
                var rotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg;
                transform.localRotation = Quaternion.RotateTowards(transform.localRotation,
                    Quaternion.Euler(0, rotation, 0),
                    RotationSpeed * Time.deltaTime);
            }
        }

        void RotateRelativeToCamera(Vector2 inputDir)
        {
            if (inputDir != Vector2.zero && isPlayer)
            {
                var rotation = main.transform.eulerAngles.y;

                transform.localRotation = Quaternion.RotateTowards(transform.localRotation,
                    Quaternion.Euler(0, rotation, 0), RotationSpeed * Time.deltaTime);
            }
        }

        public void MoveToPosition(Vector3 pos)
        {
            cc.Move(pos);
        }

        void UpdateSpeeds()
        {
            //WalkSpeed = party.CurrentController.Character.WalkSpeed;
            //RunSpeed = party.CurrentController.Character.RunSpeed;
            //StrafeSpeed = party.CurrentController.Character.StrafeSpeed;
            //FallSpeed = party.CurrentController.Character.FallSpeed;
        }

        public void SwitchMovementState(MovementState state)
        {
            State = state;

            switch (State)
            {
                case MovementState.ThirdPerson:
                    break;
                case MovementState.TopDown:
                    invertX = false;
                    invertY = false;
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                    cm.ResetRotation();
                    break;
                case MovementState.SideScroll:
                    //FindSideScrollPath();
                    cm.ResetRotation();
                    break;
            }

            OnStateSwitch?.Invoke();
        }

        float RoundAngle(float angle)
        {
            if (angle < 90) return 0;
            if (angle <= 90 && angle < 270) return 180;

            return 0;
        }

        public void Jump(float speed)
        {
            VerticalVelocity = speed;
            cc.Move(VerticalVelocity * Vector3.up * Time.unscaledDeltaTime);
        }
    }
}