using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class PartyController : MonoBehaviour
    {
        public event Action OnHealthTick;
        public event Action OnStaminaTick;
        public event Action OnPowerTick;

        public event Action<int> OnHealthChange;
        public event Action<int> OnStaminaChange;

        public event Action OnCharacterChange;
        public event Action OnMovementChange;

        public event Action OnStagger;
        public event Action OnDeath;

        [field: SerializeField] public bool IsPlayer { get; private set; }

        [SerializeField] Transform memberHolder;

        [field: SerializeField] public List<Controller> PartyMembers { get; private set; } = 
            new List<Controller>();

        [field: SerializeField] public Controller CurrentController { get; private set; }

        [field: SerializeField] public Quaternion CurrentModelRotation { get; private set; }

        [field: SerializeField] public List<PartyController> Aggro { get; private set; } = 
            new List<PartyController>();

        public Movement Movement { get; private set; }
        public InputReader Ir { get; private set; }
        public Health Health { get; private set; }
        public TimeController Tc { get; private set; }

        public TargetSphere TargetSphere { get; private set; }
        public Target OwnTarget { get; private set; }

        [field: SerializeField] public EnemyStats Es { get; private set; }

        public readonly StateMachine sm = new StateMachine();

        public Stamina CurrentStamina => CurrentController?.Stamina;
        public Power CurrentPower => CurrentController?.Power;

        public bool Dead => Health.Empty;

        public int Hp
        {
            get
            {
                var totalHp = 0;
                foreach (var pm in PartyMembers)
                    totalHp += Mathf.RoundToInt(3f * pm.Character.CharData.Health);
                return totalHp;
            }
        }

        private void Awake()
        {
            Movement = GetComponent<Movement>();
            Ir = GetComponent<InputReader>();
            Health = GetComponent<Health>();
            Tc = GetComponent<TimeController>();

            TargetSphere = GetComponentInChildren<TargetSphere>();
            OwnTarget = GetComponentInChildren<Target>();

            Es = GetComponentInChildren<EnemyStats>();

            IsPlayer = Ir is PlayerInputReader;
        }

        private void Update()
        {
            CurrentController?.sm.Update();
        }

        private void OnEnable()
        {
            Ir.OnSwitchAction += SwitchCharDpad;
        }

        private void OnDisable()
        {
            Ir.OnSwitchAction -= SwitchCharDpad;
        }

        #region Instantiation
        public void InitParty(SpawnData[] data, Quaternion spawnerRotation)
        {
            foreach (var d in data)
            {
                GameObject chObj = Instantiate(d.CharData.Character.gameObject, transform.position,
                    Quaternion.identity, memberHolder) as GameObject;

                // Initialise combat data
                var controller = chObj.GetComponent<Controller>();

                PartyMembers.Add(controller);
                controller.Init();
                controller.Model.transform.localRotation = spawnerRotation;
            }

            SwitchCharacter(0);

            Health.Init();

            if (IsPlayer)
            {
                FindObjectOfType<CameraController>().Init(GetComponentInChildren<CameraFocus>().transform);
            }
        }
        #endregion

        void SwitchCharDpad(int index)
        {
            if (index >= PartyMembers.Count) return;
            if (CurrentController.sm.InState(StateID.ControllerStagger)) return;
            if (PartyMembers[index].sm.InState(StateID.ControllerDeath)) return;

            switch (index)
            {
                case 0: SwitchCharacter(0);
                    break;
                case 1: SwitchCharacter(1);
                    break;
                case 2: SwitchCharacter(2);
                    break;
                case 3: SwitchCharacter(3);
                    break;
                default:
                    break;
            }
        }

        void SwitchCharacter(int index)
        {
            if (CurrentController != null)
                CurrentModelRotation = CurrentController.Model.transform.localRotation;

            index = Mathf.Clamp(index, 0, PartyMembers.Count);

            for (int i = 0; i < PartyMembers.Count; i++)
            {
                if (i == index) PartyMembers[i].SetStandby(false);
                else PartyMembers[i].SetStandby(true);
            }

            CurrentController = PartyMembers[index];

            if (CurrentController.Model != null)
                CurrentController.Model.transform.localRotation = CurrentModelRotation;

            InvokeCharacterChange();
        }

        public void SwitchToNextCharacter(Controller controller)
        {
            for (int i = 0; i < PartyMembers.Count; i++)
            {
                var member = PartyMembers[i];
                if (member != controller && !member.IsDead && !member.IsStaggered)
                    SwitchCharacter(i);
            }
        }

        public void DestroySelf()
        {
            Destroy(gameObject);
        }

        #region Delegates
        public void InvokeHealthTick()
        {
            OnHealthTick?.Invoke();
        }

        public void InvokeStaminaTick()
        {
            OnStaminaTick?.Invoke();
        }

        public void InvokePowerTick()
        {
            OnPowerTick?.Invoke();
        }

        public void InvokeHealthChange(int change)
        {
            OnHealthChange?.Invoke(change);
        }

        public void InvokeStaminaChange(int change)
        {
            OnStaminaChange?.Invoke(change);
        }

        public void InvokeCharacterChange()
        {
            OnCharacterChange?.Invoke();
        }

        public void InvokeMovementChange()
        {
            OnMovementChange?.Invoke();
        }

        public void InvokeStagger()
        {
            OnStagger?.Invoke();
        }

        public void InvokeDeath()
        {
            OnDeath?.Invoke();
        }
        #endregion
    }
}