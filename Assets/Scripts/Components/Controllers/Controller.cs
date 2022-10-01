﻿using System.Collections;
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

        public int CurrentActionHash { get; private set; }
        public Vector3 CurrentDodgeDir { get; private set; }

        public Movement Movement { get; private set; }
        public InputReader Ir { get; private set; }

        public Health Health { get; private set; }
        public Stamina Stamina { get; private set; }
        public Character Character { get; private set; }

        public CharacterModel Cm { get; private set; }

        public readonly StateMachine sm = new StateMachine();

        //Dictionary<int, StateID> actionStateMap = new Dictionary<int, StateID>();

        public bool InCombat => true;

        //bool InActionState => sm.InState(StateID.ControllerAction, StateID.ControllerAction1, 
        //    StateID.ControllerAction2, StateID.ControllerAction3, StateID.ControllerAction4, 
        //    StateID.ControllerAction5, StateID.ControllerAction6, StateID.ControllerAction7, 
        //    StateID.ControllerAction8);

        private void Awake()
        {
            Ir = GetComponentInParent<InputReader>();
            Movement = GetComponentInParent<Movement>();

            Health = GetComponent<Health>();
            Stamina = GetComponent<Stamina>();
            Character = GetComponent<Character>();

            Cm = GetComponentInChildren<CharacterModel>();

            actionHashes.Add(0, action1Hash);
            actionHashes.Add(1, action2Hash);
            actionHashes.Add(2, action3Hash);
            actionHashes.Add(3, action4Hash);
            actionHashes.Add(4, action5Hash);
            actionHashes.Add(5, action6Hash);
            actionHashes.Add(6, action7Hash);
            actionHashes.Add(7, action8Hash);

            //actionStateMap.Add(0, StateID.ControllerAction1);
            //actionStateMap.Add(1, StateID.ControllerAction2);
            //actionStateMap.Add(2, StateID.ControllerAction3);
            //actionStateMap.Add(3, StateID.ControllerAction4);
            //actionStateMap.Add(4, StateID.ControllerAction5);
            //actionStateMap.Add(5, StateID.ControllerAction6);
            //actionStateMap.Add(6, StateID.ControllerAction7);
            //actionStateMap.Add(7, StateID.ControllerAction8);
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
            Ir.OnDodgeAction += Dodge;

            Ir.OnGuardAction += Guard;
            Ir.OnGuardCancel += GuardCancel;

            Ir.OnJumpAction += Jump;

            Ir.OnRunAction += Run;
            Ir.OnRunCancel += RunCancel;

            Ir.OnAttackAction += Action;
        }

        private void OnDisable()
        {
            Ir.OnDodgeAction -= Dodge;

            Ir.OnGuardAction -= Guard;
            Ir.OnGuardCancel -= GuardCancel;

            Ir.OnJumpAction -= Jump;

            Ir.OnRunAction -= Run;
            Ir.OnRunCancel -= RunCancel;

            Ir.OnAttackAction -= Action;
        }

        void InitSM()
        {
            sm.AddState(StateID.ControllerMove, new ControllerMoveState(this));
            sm.AddState(StateID.ControllerFall, new ControllerFallState(this));

            sm.AddState(StateID.ControllerDodge, new ControllerDodgeState(this));
            sm.AddState(StateID.ControllerRun, new ControllerRunState(this));
            sm.AddState(StateID.ControllerGuard, new ControllerGuardState(this));

            sm.AddState(StateID.ControllerAction, new ControllerActionState(this));

            //sm.AddState(StateID.ControllerAction1, new ControllerActionState(this, 0));
            //sm.AddState(StateID.ControllerAction2, new ControllerActionState(this, 1));
            //sm.AddState(StateID.ControllerAction3, new ControllerActionState(this, 2));
            //sm.AddState(StateID.ControllerAction4, new ControllerActionState(this, 3));
            //sm.AddState(StateID.ControllerAction5, new ControllerActionState(this, 4));
            //sm.AddState(StateID.ControllerAction6, new ControllerActionState(this, 5));
            //sm.AddState(StateID.ControllerAction7, new ControllerActionState(this, 6));
            //sm.AddState(StateID.ControllerAction8, new ControllerActionState(this, 7));

            //sm.AddState(StateID.ControllerStagger, new ControllerStaggerState(this));
            //sm.AddState(StateID.ControllerDeath, new ControllerDeathState(this));

            sm.AddState(StateID.ControllerStandby, new ControllerStandbyState(this));
        }

        #region Actions
        void Dodge()
        {
            if (sm.InState(StateID.ControllerMove, StateID.ControllerMove))
            {
                CurrentDodgeDir = transform.forward;
                Stamina.ChangeValue(-30);
                sm.ChangeState(StateID.ControllerDodge);
            }
        }

        void Guard()
        {
            if (sm.InState(StateID.ControllerMove, StateID.ControllerRun))
                sm.ChangeState(StateID.ControllerGuard);
        }

        void GuardCancel()
        {
            if (sm.InState(StateID.ControllerGuard))
                sm.ChangeState(StateID.ControllerMove);
        }

        void Jump()
        {
            if (sm.InState(StateID.ControllerMove, StateID.ControllerRun))
            {
                Movement.Jump(8f);
                Stamina.ChangeValue(-30);
                Stamina.Charged = false;
                sm.ChangeState(StateID.ControllerFall);
            }
        }

        void Run()
        {
            if (sm.InState(StateID.ControllerMove))
                sm.ChangeState(StateID.ControllerRun);
        }

        void RunCancel()
        {
            if (sm.InState(StateID.ControllerRun))
                sm.ChangeState(StateID.ControllerMove);
        }

        void Action(int index)
        {
            if (sm.InState(StateID.ControllerMove, StateID.ControllerRun, 
                StateID.ControllerGuard, StateID.ControllerAction) && Stamina.Charged)
            {
                index = Mathf.Clamp(index, 0, actionHashes.Count);
                //CurrentActionHash = actionHashes[index];
                Stamina.ChangeValue(-30);
                //sm.ChangeState(actionStateMap[index]);
                sm.ChangeState(StateID.ControllerAction);
            }
        }
        #endregion

        public void SetStandby()
        {
            sm.ChangeState(StateID.ControllerStandby);
        }
    }
}