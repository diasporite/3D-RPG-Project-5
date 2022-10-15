﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class Controller : MonoBehaviour
    {
        #region AnimationTags
        public readonly string moveTag = "Move";
        public readonly string strafeTag = "Strafe";

        public readonly string jumpTag = "Jump";
        public readonly string guardTag = "Guard";
        public readonly string dodgeTag = "Dodge";

        public readonly string fallTag = "Fall";

        public readonly string action1Tag = "Action1";
        public readonly string action2Tag = "Action2";
        public readonly string action3Tag = "Action3";
        public readonly string action4Tag = "Action4";
        public readonly string action5Tag = "Action5";
        public readonly string action6Tag = "Action6";
        public readonly string action7Tag = "Action7";
        public readonly string action8Tag = "Action8";

        public readonly string staggerTag = "Stagger";
        public readonly string deathTag = "Death";

        public readonly Dictionary<int, string> actionTags = new Dictionary<int, string>();
        #endregion

        #region AnimationHashes
        public readonly int moveHash = Animator.StringToHash("Move");
        public readonly int strafeHash = Animator.StringToHash("Strafe");

        public readonly int jumpHash = Animator.StringToHash("Jump");
        public readonly int guardHash = Animator.StringToHash("Guard");
        public readonly int dodgeHash = Animator.StringToHash("Dodge");

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

        [field: SerializeField] public bool DirectionalDodging { get; private set; }
        public bool IsDead { get; set; }
        public bool IsStaggered { get; set; }

        public string CurrentActionTag { get; private set; }
        public int CurrentActionIndex { get; private set; }
        public int CurrentActionHash { get; private set; }
        public Vector3 CurrentDodgeDir { get; private set; }

        public PartyController Party { get; private set; }
        public Movement Movement { get; private set; }
        public InputReader Ir { get; private set; }

        public Health Health { get; private set; }
        public Stamina Stamina { get; private set; }
        public Power Power { get; private set; }
        public Character Character { get; private set; }

        public CharacterModel Cm { get; private set; }

        public readonly StateMachine sm = new StateMachine();

        //Dictionary<int, StateID> actionStateMap = new Dictionary<int, StateID>();

        public bool InCombat => Party.Aggro.Count > 0;

        //bool InActionState => sm.InState(StateID.ControllerAction, StateID.ControllerAction1, 
        //    StateID.ControllerAction2, StateID.ControllerAction3, StateID.ControllerAction4, 
        //    StateID.ControllerAction5, StateID.ControllerAction6, StateID.ControllerAction7, 
        //    StateID.ControllerAction8);

        private void Awake()
        {
            Party = GetComponentInParent<PartyController>();
            Ir = GetComponentInParent<InputReader>();
            Movement = GetComponentInParent<Movement>();
            Health = GetComponentInParent<Health>();

            Stamina = GetComponent<Stamina>();
            Power = GetComponent<Power>();
            Character = GetComponent<Character>();

            Cm = GetComponentInChildren<CharacterModel>();

            actionTags.Add(0, action1Tag);
            actionTags.Add(1, action2Tag);
            actionTags.Add(2, action3Tag);
            actionTags.Add(3, action4Tag);
            actionTags.Add(4, action5Tag);
            actionTags.Add(5, action6Tag);
            actionTags.Add(6, action7Tag);
            actionTags.Add(7, action8Tag);

            actionHashes.Add(0, action1Hash);
            actionHashes.Add(1, action2Hash);
            actionHashes.Add(2, action3Hash);
            actionHashes.Add(3, action4Hash);
            actionHashes.Add(4, action5Hash);
            actionHashes.Add(5, action6Hash);
            actionHashes.Add(6, action7Hash);
            actionHashes.Add(7, action8Hash);
        }

        private void Update()
        {
            currentState = sm.CurrentStateKey;

            sm.Update();
        }

        private void OnEnable()
        {
            Ir.OnDodgeAction += Dodge;

            //Ir.OnGuardAction += Guard;
            //Ir.OnGuardCancelAction += GuardCancel;

            Ir.OnJumpAction += Jump;

            //Ir.OnRunAction += Run;
            //Ir.OnRunCancelAction += RunCancel;

            Ir.OnAttackAction += Action;
        }

        private void OnDisable()
        {
            Ir.OnDodgeAction -= Dodge;

            //Ir.OnGuardAction -= Guard;
            //Ir.OnGuardCancelAction -= GuardCancel;

            Ir.OnJumpAction -= Jump;

            //Ir.OnRunAction -= Run;
            //Ir.OnRunCancelAction -= RunCancel;

            Ir.OnAttackAction -= Action;
        }

        public void Init()
        {
            DirectionalDodging = Character.CharData.DodgeAction.IsDirectional;

            Health.Init();
            Stamina.Init();
            Power.Init();

            InitSM();

            sm.ChangeState(StateID.ControllerMove);
        }

        void InitSM()
        {
            sm.AddState(StateID.ControllerMove, new ControllerMoveState(this));
            sm.AddState(StateID.ControllerFall, new ControllerFallState(this));
            sm.AddState(StateID.ControllerStrafe, new ControllerStrafeState(this));

            sm.AddState(StateID.ControllerJump, new ControllerJumpState(this));
            sm.AddState(StateID.ControllerDodge, new ControllerDodgeState(this));
            sm.AddState(StateID.ControllerRun, new ControllerRunState(this));
            sm.AddState(StateID.ControllerGuard, new ControllerGuardState(this));

            sm.AddState(StateID.ControllerAction, new ControllerActionState(this));

            sm.AddState(StateID.ControllerStagger, new ControllerStaggerState(this));
            sm.AddState(StateID.ControllerDeath, new ControllerDeathState(this));

            sm.AddState(StateID.ControllerStandby, new ControllerStandbyState(this));
        }

        #region Actions
        void Dodge()
        {
            if (sm.InState(StateID.ControllerMove, StateID.ControllerRun, 
                StateID.ControllerStrafe, StateID.ControllerDodge, 
                StateID.ControllerGuard, StateID.ControllerAction))
            {
                CurrentDodgeDir = Ir.Move.x * Cm.transform.right + 
                    Ir.Move.y * Cm.transform.forward;
                Stamina.ChangeValue(-Character.DodgeAction.StaminaCost);
                Power.ChangeValue(-Character.DodgeAction.PowerCost);
                sm.ChangeState(StateID.ControllerDodge);
            }
        }

        void Guard()
        {
            if (sm.InState(StateID.ControllerMove, StateID.ControllerStrafe, 
                StateID.ControllerRun))
                sm.ChangeState(StateID.ControllerGuard);
        }

        void GuardCancel()
        {
            if (sm.InState(StateID.ControllerGuard))
                sm.ChangeState(StateID.ControllerMove);
        }

        void Jump()
        {
            if (sm.InState(StateID.ControllerMove, StateID.ControllerStrafe, 
                StateID.ControllerRun, StateID.ControllerGuard, StateID.ControllerDodge, 
                StateID.ControllerAction))
            {
                Movement.Jump(8f);

                if (InCombat)
                {
                    Stamina.ChangeValue(-30);
                    Stamina.Charged = false;
                }

                if (sm.InState(StateID.ControllerMove))
                    Movement.FallSpeed = Movement.WalkSpeed;
                if (sm.InState(StateID.ControllerRun))
                    Movement.FallSpeed = Movement.RunSpeed;

                sm.ChangeState(StateID.ControllerJump);
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
            if (sm.InState(StateID.ControllerMove, StateID.ControllerRun, StateID.ControllerStrafe,
                StateID.ControllerDodge, StateID.ControllerGuard, 
                StateID.ControllerAction) && Stamina.Charged)
            {
                CurrentActionIndex = Mathf.Clamp(index, 0, actionHashes.Count);
                CurrentActionTag = actionTags[index];
                CurrentActionHash = actionHashes[index];
                Stamina.ChangeValue(-Character.CharData.CombatActions[CurrentActionIndex].StaminaCost);
                Power.ChangeValue(-Character.CharData.CombatActions[CurrentActionIndex].PowerCost);
                sm.ChangeState(StateID.ControllerAction);
            }
        }
        #endregion

        public void SetStandby(bool value)
        {
            if (sm.States.ContainsKey(StateID.ControllerMove) && 
                sm.States.ContainsKey(StateID.ControllerStandby))
            {
                if (value) sm.ChangeState(StateID.ControllerStandby);
                else sm.ChangeState(StateID.ControllerMove);
            }
        }
    }
}