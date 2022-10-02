using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace RPG_Project
{
    [Serializable]
    public class InputQueue
    {
        int inputCap = 5;

        [field: SerializeField] public List<InputCommand> Inputs { get; private set; } = 
            new List<InputCommand>();

        public void AddInput(InputCommand input)
        {
            if (Inputs.Count < inputCap) Inputs.Add(input);
        }

        // Returns true if there are actions to be executed
        public bool Advance()
        {
            if (Inputs.Count > 0) Inputs.Remove(Inputs[0]);
            //Debug.Log(Inputs.Count);
            return Inputs.Count > 0;
        }

        public void Execute()
        {
            if (Inputs.Count > 0) Inputs[0].Execute();
        }

        public void ClearInputs()
        {
            Inputs.Clear();
        }
    }

    public class InputReader : MonoBehaviour
    {
        public event Action<int> OnSwitchAction;

        public event Action OnDodgeAction;

        public event Action OnGuardAction;
        public event Action OnGuardCancel;

        public event Action OnJumpAction;

        public event Action OnRunAction;
        public event Action OnRunCancel;

        public event Action<int> OnAttackAction;

        [field: SerializeField] public Vector2 Move { get; protected set; }
        [field: SerializeField] public Vector2 Rotate { get; protected set; }
        [field: SerializeField] public Vector2 Dpad { get; protected set; }

        [field: SerializeField] public bool Run { get; protected set; } = false;

        [field: SerializeField] public InputQueue InputQueue { get; protected set; } = 
            new InputQueue();

        public PartyController Party { get; private set; }

        protected virtual void Awake()
        {
            Party = GetComponent<PartyController>();
        }

        #region Delegates
        public void InvokeSwitch(int index)
        {
            OnSwitchAction?.Invoke(index);
        }

        public void InvokeDodge()
        {
            OnDodgeAction?.Invoke();
        }

        public void InvokeGuard()
        {
            OnGuardAction?.Invoke();
        }

        public void InvokeGuardCancel()
        {
            OnGuardCancel?.Invoke();
        }

        public void InvokeJump()
        {
            OnJumpAction?.Invoke();
        }

        public void InvokeRun()
        {
            OnRunAction?.Invoke();
        }

        public void InvokeRunCancel()
        {
            OnRunCancel?.Invoke();
        }

        public void InvokeAttack(int index)
        {
            OnAttackAction?.Invoke(index);
        }
        #endregion
    }
}