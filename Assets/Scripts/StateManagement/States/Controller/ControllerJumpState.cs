using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class ControllerJumpState : IState
    {
        Controller controller;
        StateMachine csm;

        Health health;
        Stamina stamina;

        Movement movement;

        public ControllerJumpState(Controller con)
        {
            controller = con;
            csm = con.sm;

            health = controller.Health;
            stamina = controller.Stamina;

            movement = controller.Movement;
        }

        public void Enter(params object[] args)
        {
            health.SpeedFactor = 1f;
            stamina.SpeedFactor = 0f;
        }

        public void ExecuteFrame()
        {
            var dir = controller.Ir.Move;

            if (dir == Vector2.zero) health.Tick(0f);
            else health.Tick();
            stamina.Tick();

            movement.MovePosition(dir, Time.deltaTime, SpeedMode.Fall);

            if (movement.Grounded) csm.ChangeState(StateID.ControllerMove);
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
    }
}