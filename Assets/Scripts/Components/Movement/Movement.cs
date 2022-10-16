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
        FirstPerson = 3,
    }

    public enum SpeedMode
    {
        Walk = 0,
        Run = 1,
        Strafe = 2,
        Fall = 3,
    }

    public class Movement : MonoBehaviour
    {
        [field: SerializeField] public MovementState CurrentMovementState { get; private set; } = 
            MovementState.ThirdPerson;

        [field: Header("Speeds")]
        [field: SerializeField] public float WalkSpeed { get; private set; } = 5f;
        [field: SerializeField] public float RunSpeed { get; private set; } = 8f;
        [field: SerializeField] public float StrafeSpeed { get; private set; } = 3f;
        [field: SerializeField] public float FallSpeed { get; set; } = 2f;
        public float CurrentSpeed { get; private set; }

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

        [field: SerializeField] public SideScrollPathLinear CurrentPath { get; private set; }
        [SerializeField] float distanceFromNearestPoint;

        PartyController party;

        CharacterController cc;

        PlayerCameraController pcc;
        TargetSphere ts;

        CharacterModel cm;

        Camera main;

        GroundCheck gc;

        private void Awake()
        {
            party = GetComponent<PartyController>();

            cc = GetComponent<CharacterController>();

            pcc = GetComponentInChildren<PlayerCameraController>();
            ts = GetComponentInChildren<TargetSphere>();

            cm = GetComponentInChildren<CharacterModel>();

            main = Camera.main;

            gc = GetComponentInChildren<GroundCheck>();
        }

        private void Start()
        {
            isPlayer = GetComponent<PartyController>().IsPlayer;

            //SwitchMovementState(MovementState.TopDown, null);
            SwitchMovementState(MovementState.ThirdPerson, null);
        }

        private void Update()
        {
            UpdateForce();
            UpdateGravity();
        }

        private void OnEnable()
        {
            party.OnCharacterChange += UpdateCharacter;
        }

        private void OnDisable()
        {
            party.OnCharacterChange -= UpdateCharacter;
        }

        #region MovePosition
        public void MovePosition(Vector2 inputDir, float dt, SpeedMode mode)
        {
            var speed = 0f;

            switch (mode)
            {
                case SpeedMode.Walk:
                    speed = WalkSpeed;
                    break;
                case SpeedMode.Run:
                    speed = RunSpeed;
                    break;
                case SpeedMode.Strafe:
                    speed = StrafeSpeed;
                    break;
                case SpeedMode.Fall:
                    speed = FallSpeed;
                    break;
            }
            
            switch (CurrentMovementState)
            {
                case MovementState.ThirdPerson:
                    MovePosition3rdPerson(inputDir, speed, dt);
                    break;
                case MovementState.TopDown:
                    MovePositionTopDown(inputDir, speed, dt);
                    break;
                case MovementState.SideScroll:
                    MovePositionSideScroll(inputDir, speed, dt);
                    break;
                case MovementState.FirstPerson:
                    MovePosition1stPerson(inputDir, speed, dt);
                    break;
                default:
                    MovePosition3rdPerson(inputDir, speed, dt);
                    break;
            }
        }

        public void MovePosition(Vector2 inputDir, float dt, float speed)
        {
            switch (CurrentMovementState)
            {
                case MovementState.ThirdPerson:
                    MovePosition3rdPerson(inputDir, speed, dt);
                    break;
                case MovementState.TopDown:
                    MovePositionTopDown(inputDir, speed, dt);
                    break;
                case MovementState.SideScroll:
                    MovePositionSideScroll(inputDir, speed, dt);
                    break;
                case MovementState.FirstPerson:
                    MovePosition1stPerson(inputDir, speed, dt);
                    break;
                default:
                    MovePosition3rdPerson(inputDir, speed, dt);
                    break;
            }
        }

        public void MovePosition3rdPerson(Vector2 inputDir, float speed, float dt)
        {
            Vector3 ds;

            if (ts.Locked)
            {
                CurrentSpeed = StrafeSpeed;

                ds = inputDir.x * cm.transform.right + inputDir.y * cm.transform.forward;

                cm.RotateTowardsTarget(transform.rotation, ts.CurrentTargetTransform);

                if (ds != Vector3.zero) cc.Move(CurrentSpeed * ds * dt);
            }
            else
            {
                CurrentSpeed = speed;

                ds = inputDir.x * cm.transform.right + inputDir.y * cm.transform.forward;

                if (party.IsPlayer) cm.RotateTowards(inputDir, -pcc.Tp.Theta);
                else cm.RotateTowards(inputDir);

                if (ds != Vector3.zero) cc.Move(CurrentSpeed * cm.transform.forward * dt);
            }
        }

        public void MovePositionTopDown(Vector2 dir, float speed, float dt)
        {
            if (ts.Locked)
            {
                CurrentSpeed = StrafeSpeed;

                var ds = dir.x * Vector3.right + dir.y * Vector3.forward;

                cm.RotateTowardsTarget(party.transform.rotation, ts.CurrentTargetTransform);

                if (ds != Vector3.zero) cc.Move(CurrentSpeed * ds * dt);
            }
            else
            {
                CurrentSpeed = speed;

                var ds = dir.x * cm.transform.right + dir.y * cm.transform.forward;

                cm.RotateTowards(dir);

                if (ds != Vector3.zero) cc.Move(CurrentSpeed * cm.transform.forward * dt);
            }
        }

        public void MovePositionSideScroll(Vector2 dir, float speed, float dt)
        {
            CurrentSpeed = speed;

            var ds = CurrentPath.Rightward * dir.x;

            cm.RotateTowards(ds);

            if (ds != Vector3.zero)
                cc.Move(CurrentSpeed * Mathf.Sign(dir.x) * CurrentPath.Rightward * dt);
        }

        public void MovePosition1stPerson(Vector2 dir, float speed, float dt)
        {
            Vector3 ds;

            if (ts.Locked)
            {
                CurrentSpeed = StrafeSpeed;
            }
            else
            {
                CurrentSpeed = speed;

                if (party.IsPlayer) cm.Rotation(pcc.Fp.EulerY);

                ds = dir.x * party.CurrentController.Cm.transform.right +
                    dir.y * party.CurrentController.Cm.transform.forward;

                if (ds != Vector3.zero)
                    cc.Move(CurrentSpeed * ds * dt);
            }
        }

        public void MovePositionAction(Vector3 dir, float dt, float speed)
        {
            cc.Move(speed * dir * dt);
        }

        public void MoveToPosition(Vector3 pos)
        {
            cc.Move(pos - transform.position);
        }
        #endregion

        #region Forces
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
        #endregion

        #region Rotation
        void RotateTowards(Vector2 inputDir)
        {
            if (inputDir != Vector2.zero)
            {
                var rotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg;
                cm.transform.localRotation = Quaternion.RotateTowards(transform.localRotation,
                    Quaternion.Euler(0, rotation, 0), RotationSpeed * Time.deltaTime);
            }
        }

        void RotateRelativeToCamera(Vector2 inputDir)
        {
            if (inputDir != Vector2.zero && isPlayer)
            {
                var rotation = main.transform.eulerAngles.y + 
                    Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg;

                cm.transform.localRotation = Quaternion.RotateTowards(transform.localRotation,
                    Quaternion.Euler(0, rotation, 0), RotationSpeed * Time.deltaTime);
            }
        }
        #endregion

        void UpdateCharacter()
        {
            if (party.CurrentController.Character != null)
            {
                cm = party.CurrentController.Cm;

                WalkSpeed = party.CurrentController.Character.WalkSpeed;
                RunSpeed = party.CurrentController.Character.RunSpeed;
                StrafeSpeed = party.CurrentController.Character.StrafeSpeed;
            }
        }

        public void SwitchMovementState(MovementState state, SideScrollPathLinear linear)
        {
            var oldState = CurrentMovementState;
            CurrentMovementState = state;

            switch (CurrentMovementState)
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
                    if (linear != null)
                    {
                        CurrentPath = linear;
                        MoveToPosition(linear.ClosestEnd(transform.position));
                    }
                    else CurrentMovementState = MovementState.ThirdPerson;
                    break;
            }

            pcc?.SwitchCamera(CurrentMovementState);
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

        public float AnimBlendValue(float speed)
        {
            if (speed > 0 && speed <= WalkSpeed) return .5f;
            if (speed > WalkSpeed) return 1f;

            return 0f;
        }
    }
}