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

        public ControllerRunState(Controller controller)
        {
            this.controller = controller;
            csm = controller.sm;

            health = controller.Health;
            stamina = controller.Stamina;

            movement = controller.Movement;
        }

        #region InterfaceMethods
        public void Enter(params object[] args)
        {
            health.SpeedFactor = 0f;
            stamina.SpeedFactor = -1f;
            stamina.Charged = false;

            //controller.Cm.PlayAnimation(controller.moveHash);
        }

        public void ExecuteFrame()
        {
            var dir = controller.Ir.Move;

            health.Tick();
            stamina.Tick();

            if (dir == Vector2.zero || stamina.Empty)
                csm.ChangeState(StateID.ControllerMove);

            //UpdateAnim(controller.Ir.Move);

            controller.Ir.InputQueue.Execute();

            controller.Movement.MovePosition(dir, Time.deltaTime, SpeedMode.Run);

            if (!movement.Grounded) csm.ChangeState(StateID.ControllerFall);
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
            if (input != Vector2.zero)
                controller.Cm.SetFloat("Speed", controller.Movement.RunSpeed);
            else controller.Cm.SetFloat("Speed", 0f);
        }
    }
}