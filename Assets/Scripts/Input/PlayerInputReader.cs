﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace RPG_Project
{
    public class PlayerInputReader : InputReader, PlayerControls.IPlayerActions
    {
        PlayerControls controls;

        // Key corresponds to button number, value corresponds to index in character's
        //   CombatActions array
        Dictionary<int, int> buttonActionMap = new Dictionary<int, int>();

        protected override void Awake()
        {
            base.Awake();

            controls = new PlayerControls();
            controls.Player.SetCallbacks(this);

            buttonActionMap.Add(1, 0);
            buttonActionMap.Add(2, 1);
            buttonActionMap.Add(3, 2);
            buttonActionMap.Add(4, 3);
        }

        private void OnEnable()
        {
            controls.Enable();
        }

        private void OnDestroy()
        {
            controls.Disable();
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            Move = context.ReadValue<Vector2>();
        }

        public void OnRotate(InputAction.CallbackContext context)
        {
            Rotate = context.ReadValue<Vector2>();
        }

        public void OnDpad(InputAction.CallbackContext context)
        {
            Dpad = context.ReadValue<Vector2>();

            if (context.performed)
            {
                int index = 0;

                if (Dpad == Vector2.up) index = 0;
                else if (Dpad == Vector2.left) index = 1;
                else if (Dpad == Vector2.right) index = 2;
                else if (Dpad == Vector2.down) index = 3;

                InputQueue.AddInput(new SwitchCommand(Party, this, index));
            }
        }

        public void OnDodge(InputAction.CallbackContext context)
        {
            if (context.performed)
                InputQueue.AddInput(new DodgeCommand(Party, this, Move));
        }

        public void OnGuard(InputAction.CallbackContext context)
        {
            if (context.performed) Guard = true;
        }

        public void OnGuardCancel(InputAction.CallbackContext context)
        {
            if (context.performed) Guard = false;
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            if (context.performed)
                InputQueue.AddInput(new JumpCommand(Party, this, Vector2.zero));
        }

        public void OnRun(InputAction.CallbackContext context)
        {
            if (context.performed) Run = true;
        }

        public void OnRunCancel(InputAction.CallbackContext context)
        {
            if (context.performed) Run = false;
        }

        public void OnAction1(InputAction.CallbackContext context)
        {
            if (context.performed/* && Party.Stamina.Charged*/)
                InputQueue.AddInput(new AttackCommand(Party, this, buttonActionMap[1]));
        }

        public void OnAction2(InputAction.CallbackContext context)
        {
            if (context.performed/* && Party.Stamina.Charged*/)
                InputQueue.AddInput(new AttackCommand(Party, this, buttonActionMap[2]));
        }

        public void OnAction3(InputAction.CallbackContext context)
        {
            if (context.performed/* && Party.Stamina.Charged*/)
                InputQueue.AddInput(new AttackCommand(Party, this, buttonActionMap[3]));
        }

        public void OnAction4(InputAction.CallbackContext context)
        {
            if (context.performed/* && Party.Stamina.Charged*/)
                InputQueue.AddInput(new AttackCommand(Party, this, buttonActionMap[4]));
        }

        public void OnPauseSelect(InputAction.CallbackContext context)
        {
            if (context.performed) InvokePauseSelect();
        }

        public void OnToggleTarget(InputAction.CallbackContext context)
        {
            if (context.performed) InvokeToggleLock();
        }

        public void OnOpenClose(InputAction.CallbackContext context)
        {
            if (context.performed) InvokeMenu();
        }
    }
}