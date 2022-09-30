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

        public event Action OnCharacterChange;
        public event Action OnMovementChange;

        public event Action OnStagger;
        public event Action OnDeath;

        [field: SerializeField] public bool IsPlayer { get; private set; }

        [field: SerializeField] public List<Controller> PartyMembers { get; private set; } = 
            new List<Controller>();

        public InputReader Ir { get; private set; }

        public Controller CurrentController { get; private set; }

        public Health CurrentHealth => CurrentController?.Health;
        public Stamina CurrentStamina => CurrentController?.Stamina;

        private void Awake()
        {
            //Health = GetComponent<Health>();
            //Stamina = GetComponent<Stamina>();
            Ir = GetComponent<InputReader>();

            IsPlayer = Ir is PlayerInputReader;

            var pms = GetComponentsInChildren<Controller>();

            foreach (var p in pms) PartyMembers.Add(p);

            SetCurrentMember(0);
        }

        private void Start()
        {
            FindObjectOfType<UIManager>().Battle.InitHUD(this);

            SetCurrentMember(0);
        }

        void SetCurrentMember(int index)
        {
            index = Mathf.Clamp(index, 0, PartyMembers.Count);

            CurrentController = PartyMembers[index];

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