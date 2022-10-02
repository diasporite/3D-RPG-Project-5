using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace RPG_Project
{
    public class PlayerInputReader : InputReader, PlayerControls.IPlayerActions
    {
        PlayerControls controls;

        protected override void Awake()
        {
            base.Awake();

            controls = new PlayerControls();
            controls.Player.SetCallbacks(this);
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
            if (context.performed) InvokeGuard();
            else if (context.canceled) InvokeGuardCancel();
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            if (context.performed) InvokeJump();
        }

        public void OnRun(InputAction.CallbackContext context)
        {
            if (context.performed) InvokeRun();
            else if (context.canceled) InvokeRunCancel();
        }

        public void OnAction1(InputAction.CallbackContext context)
        {
            if (context.performed && Party.CurrentStamina.Charged)
                InputQueue.AddInput(new AttackCommand(Party, this, 0));
        }

        public void OnAction2(InputAction.CallbackContext context)
        {
            if (context.performed && Party.CurrentStamina.Charged)
                InputQueue.AddInput(new AttackCommand(Party, this, 1));
        }

        public void OnAction3(InputAction.CallbackContext context)
        {
            if (context.performed && Party.CurrentStamina.Charged)
                InputQueue.AddInput(new AttackCommand(Party, this, 2));
        }

        public void OnAction4(InputAction.CallbackContext context)
        {
            if (context.performed && Party.CurrentStamina.Charged)
                InputQueue.AddInput(new AttackCommand(Party, this, 3));
        }
    }
}