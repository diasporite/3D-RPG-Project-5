using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class Controller : MonoBehaviour
    {
        #region AnimationHashes
        public readonly int moveHash = Animator.StringToHash("Move");
        public readonly int strafeHash = Animator.StringToHash("Strafe");

        public readonly int jumpHash = Animator.StringToHash("Jump");
        public readonly int guardHash = Animator.StringToHash("Guard");

        public readonly int fallHash = Animator.StringToHash("Fall");

        public readonly int action1Hash = Animator.StringToHash("Action1");
        public readonly int action2Hash = Animator.StringToHash("Action2");
        public readonly int action3Hash = Animator.StringToHash("Action3");
        public readonly int action4Hash = Animator.StringToHash("Action4");
        public readonly int action5Hash = Animator.StringToHash("Action5");
        public readonly int action6Hash = Animator.StringToHash("Action6");
        public readonly int action7Hash = Animator.StringToHash("Action7");
        public readonly int action8Hash = Animator.StringToHash("Action8");

        public readonly int staggerHash = Animator.StringToHash("Stagger");
        public readonly int deathHash = Animator.StringToHash("Death");

        public readonly Dictionary<int, int> actionHashes = new Dictionary<int, int>();
        #endregion

        [SerializeField] StateID currentState;

        public Movement Movement { get; private set; }
        public InputReader Ir { get; private set; }

        public Health Health { get; private set; }
        public Stamina Stamina { get; private set; }

        //public Character Character { get; private set; }

        //public CharacterModel Cm { get; private set; }

        public readonly StateMachine sm = new StateMachine();

        private void Awake()
        {
            Ir = GetComponentInParent<InputReader>();
            Movement = GetComponentInParent<Movement>();

            Health = GetComponent<Health>();
            Stamina = GetComponent<Stamina>();

            //Character = GetComponent<Character>();

            //Cm = GetComponentInChildren<CharacterModel>();

            actionHashes.Add(0, action1Hash);
            actionHashes.Add(1, action2Hash);
            actionHashes.Add(2, action3Hash);
            actionHashes.Add(3, action4Hash);
            actionHashes.Add(4, action5Hash);
            actionHashes.Add(5, action6Hash);
            actionHashes.Add(6, action7Hash);
            actionHashes.Add(7, action8Hash);
        }

        private void Start()
        {
            InitSM();

            sm.ChangeState(StateID.ControllerMove);
        }

        private void Update()
        {
            currentState = sm.CurrentStateKey;

            sm.Update();
        }

        private void OnEnable()
        {
            //Ir.OnTeleportAction += Teleport;

            //Ir.OnGuardAction += Guard;
            //Ir.OnGuardCancel += GuardCancel;

            //Ir.OnJumpAction += Jump;

            //Ir.OnRunAction += Run;
            //Ir.OnRunCancel += RunCancel;

            //Ir.OnAttackAction += Action;
        }

        private void OnDisable()
        {
            //Ir.OnTeleportAction -= Teleport;

            //Ir.OnGuardAction -= Guard;
            //Ir.OnGuardCancel -= GuardCancel;

            //Ir.OnJumpAction -= Jump;

            //Ir.OnRunAction -= Run;
            //Ir.OnRunCancel -= RunCancel;

            //Ir.OnAttackAction -= Action;
        }

        void InitSM()
        {
            sm.AddState(StateID.ControllerMove, new ControllerMoveState(this));
            //sm.AddState(StateID.ControllerRun, new ControllerRunState(this));
            //sm.AddState(StateID.ControllerFall, new ControllerFallState(this));
            //sm.AddState(StateID.ControllerAction, new ControllerActionState(this, 0));
            //sm.AddState(StateID.ControllerGuard, new ControllerGuardState(this));
            //sm.AddState(StateID.ControllerTeleport, new ControllerTeleportState(this));
            //sm.AddState(StateID.ControllerStagger, new ControllerStaggerState(this));
            //sm.AddState(StateID.ControllerDeath, new ControllerDeathState(this));

            //sm.AddState(StateID.ControllerAction1, new ControllerActionState(this, 0));
            //sm.AddState(StateID.ControllerAction2, new ControllerActionState(this, 1));
            //sm.AddState(StateID.ControllerAction3, new ControllerActionState(this, 2));
            //sm.AddState(StateID.ControllerAction4, new ControllerActionState(this, 3));
        }
    }
}