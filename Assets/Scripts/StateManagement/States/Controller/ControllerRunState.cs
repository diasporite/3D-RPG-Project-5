using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class ControllerRunState : IState
    {
        Controller controller;
        StateMachine csm;

        Health health;
        Stamina stamina;

        Movement movement;

        CharacterModel cm;

        public ControllerRunState(Controller controller)
        {
            this.controller = controller;
            csm = controller.sm;

            health = controller.Health;
            stamina = controller.Stamina;

            movement = controller.Movement;

            cm = controller.Cm;
        }

        #region InterfaceMethods
        public void Enter(params object[] args)
        {
            health.SpeedFactor = 0f;
            if (controller.InCombat) stamina.SpeedFactor = -0.5f;
            else stamina.SpeedFactor = 1f;

            stamina.Charged = false;

            cm.PlayAnimation(controller.moveHash);
        }

        public void ExecuteFrame()
        {
            if (controller.InCombat) stamina.SpeedFactor = -0.5f;
            else stamina.SpeedFactor = 1f;

            var dir = controller.Ir.Move;

            health.Tick();
            stamina.Tick();

            if (dir == Vector2.zero || stamina.Empty)
                csm.ChangeState(StateID.ControllerMove);

            UpdateAnim(controller.Ir.Move);

            controller.Ir.InputQueue.Execute();

            controller.Movement.MovePosition(dir, Time.deltaTime, SpeedMode.Run);

            if (!controller.Ir.Run) csm.ChangeState(StateID.ControllerMove);
            if (controller.Ir.Guard) csm.ChangeState(StateID.ControllerGuard);
            if (controller.Party.Ts.Locked)
            {
                csm.ChangeState(StateID.ControllerStrafe);
            }
            if (!movement.Grounded)
            {
                movement.FallSpeed = movement.RunSpeed;
                csm.ChangeState(StateID.ControllerFall);
            }
        }

        public void ExecuteFrameFixed()
        {
            
        }

        public void ExecuteFrameLate()
        {

        }

        public void Exit()
        {

        }
        #endregion

        void UpdateAnim(Vector2 input)
        {
            var value = movement.AnimBlendValue(movement.CurrentSpeed);
            if (input != Vector2.zero) cm.SetFloat("RelativeSpeed", value);
            else cm.SetFloat("RelativeSpeed", 0f);
        }
    }
}