using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public enum MovementState
    {
        ThirdPersonFree = 0,
        ThirdPersonStrafe = 1,
        TopDown = 2,
        SideScroll = 3,
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
        public event Action OnStateSwitch;

        [field: SerializeField] public MovementState State { get; private set; } = 
            MovementState.ThirdPersonFree;

        [field: Header("Speeds")]
        [field: SerializeField] public float WalkSpeed { get; private set; } = 5f;
        [field: SerializeField] public float RunSpeed { get; private set; } = 8f;
        [field: SerializeField] public float StrafeSpeed { get; private set; } = 3f;
        [field: SerializeField] public float FallSpeed { get; private set; } = 2f;
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

        [SerializeField] SideScrollPathLinear currentPath;
        [SerializeField] float distanceFromNearestPoint;

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

            SwitchMovementState(MovementState.ThirdPersonFree, null);
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

        private void OnDrawGizmos()
        {
            Gizmos.DrawRay(transform.position, 5f * transform.forward);
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
            
            switch (State)
            {
                case MovementState.ThirdPersonFree:
                    MovePosition3rdPersonFree(inputDir, speed, dt);
                    break;
                case MovementState.ThirdPersonStrafe:
                    MovePosition3rdPersonStrafe(inputDir, speed, dt);
                    break;
                case MovementState.TopDown:
                    MovePositionTopDown(inputDir, speed, dt);
                    break;
                case MovementState.SideScroll:
                    MovePositionSideScroll(inputDir, speed, dt);
                    break;
                default:
                    MovePosition3rdPersonFree(inputDir, speed, dt);
                    break;
            }
        }

        public void MovePosition(Vector2 inputDir, float dt, float speed)
        {
            switch (State)
            {
                case MovementState.ThirdPersonFree:
                    MovePosition3rdPersonFree(inputDir, speed, dt);
                    break;
                case MovementState.TopDown:
                    MovePositionTopDown(inputDir, speed, dt);
                    break;
                case MovementState.SideScroll:
                    MovePositionSideScroll(inputDir, speed, dt);
                    break;
                default:
                    MovePosition3rdPersonFree(inputDir, speed, dt);
                    break;
            }
        }

        public void MovePosition3rdPersonFree(Vector2 inputDir, float speed, float dt)
        {
            CurrentSpeed = speed;

            var ds = inputDir.x * transform.right + inputDir.y * transform.forward;

            if (isPlayer) RotateRelativeToCamera(inputDir);
            else RotateTowards(inputDir);

            cm.RotateTowards(inputDir);

            if (ds != Vector3.zero) cc.Move(CurrentSpeed * ds * dt);
        }

        public void MovePosition3rdPersonStrafe(Vector2 dir, float speed, float dt)
        {

        }

        public void MovePositionTopDown(Vector2 dir, float speed, float dt)
        {
            CurrentSpeed = speed;

            var x = 1f;
            var y = 1f;

            if (invertX) x = -1f;
            if (invertY) y = -1f;

            var ds = x * dir.x * transform.right + y * dir.y * transform.forward;
            //RotateRelativeToCamera(ds);
            //cm.RotateTowards(dir);
            if (ds != Vector3.zero) cc.Move(CurrentSpeed * ds * dt);
        }

        public void MovePositionSideScroll(Vector2 dir, float speed, float dt)
        {
            CurrentSpeed = speed;

            var ds = currentPath.Rightward * dir.x;
            cm.RotateTowards(ds);
            if (ds != Vector3.zero) cc.Move(CurrentSpeed * ds * dt);
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
        #endregion

        void UpdateCharacter()
        {
            cm = party.CurrentController.Cm;

            WalkSpeed = party.CurrentController.Character.WalkSpeed;
            RunSpeed = party.CurrentController.Character.RunSpeed;
            StrafeSpeed = party.CurrentController.Character.StrafeSpeed;
            FallSpeed = party.CurrentController.Character.FallSpeed;
        }

        public void SwitchMovementState(MovementState state, SideScrollPathLinear linear)
        {
            var oldState = State;
            State = state;

            switch (State)
            {
                case MovementState.ThirdPersonFree:
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
                        currentPath = linear;
                        MoveToPosition(linear.ClosestEnd(transform.position));
                    }
                    else State = MovementState.ThirdPersonFree;
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

        public float AnimBlendValue(float speed)
        {
            if (speed > 0 && speed <= WalkSpeed) return .5f;
            if (speed > WalkSpeed) return 1f;

            return 0f;
        }
    }
}