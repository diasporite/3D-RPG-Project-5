﻿using System;
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

        public event Action OnCharacterChange;
        public event Action OnMovementChange;

        public event Action OnStagger;
        public event Action OnDeath;

        [field: SerializeField] public bool IsPlayer { get; private set; }

        [field: SerializeField] public List<Controller> PartyMembers { get; private set; } = 
            new List<Controller>();

        [field: SerializeField] public Controller CurrentController { get; private set; }

        [field: SerializeField] public Quaternion CurrentModelRotation { get; private set; }

        public Movement Movement { get; private set; }
        public InputReader Ir { get; private set; }

        public Health CurrentHealth => CurrentController?.Health;
        public Stamina CurrentStamina => CurrentController?.Stamina;
        public Power CurrentPower => CurrentController?.Power;

        private void Awake()
        {
            Movement = GetComponent<Movement>();
            Ir = GetComponent<InputReader>();

            IsPlayer = Ir is PlayerInputReader;

            var pms = GetComponentsInChildren<Controller>();

            foreach (var p in pms) PartyMembers.Add(p);

            SetCurrentMember(0);
        }

        private void OnEnable()
        {
            Ir.OnSwitchAction += SwitchCharDpad;
        }

        private void OnDisable()
        {
            Ir.OnSwitchAction -= SwitchCharDpad;
        }

        private void Start()
        {
            foreach (var pm in PartyMembers) pm.Init();

            //SetCurrentMember(0);

            FindObjectOfType<UIManager>().Battle.InitHUD(this);

            SetCurrentMember(0);
        }

        void SwitchCharDpad(int index)
        {
            switch (index)
            {
                case 0: SetCurrentMember(0);
                    break;
                case 1: SetCurrentMember(1);
                    break;
                case 2: SetCurrentMember(2);
                    break;
                case 3: SetCurrentMember(3);
                    break;
                default:
                    break;
            }
        }

        void SetCurrentMember(int index)
        {
            if (CurrentController != null)
                CurrentModelRotation = CurrentController.Cm.transform.localRotation;

            index = Mathf.Clamp(index, 0, PartyMembers.Count);

            for (int i = 0; i < PartyMembers.Count; i++)
            {
                if (i == index) PartyMembers[i].SetStandby(false);
                else PartyMembers[i].SetStandby(true);
            }

            CurrentController = PartyMembers[index];

            if (CurrentController.Cm != null)
                CurrentController.Cm.transform.localRotation = CurrentModelRotation;

            InvokeCharacterChange();
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