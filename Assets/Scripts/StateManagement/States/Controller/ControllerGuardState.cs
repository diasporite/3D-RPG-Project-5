using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class ControllerGuardState : IState
    {
        Controller controller;
        StateMachine csm;

        Health health;
        Stamina stamina;

        public ControllerGuardState(Controller con)
        {
            controller = con;
            csm = con.sm;

            health = controller.Health;
            stamina = controller.Stamina;
        }

        public void Enter(params object[] args)
        {
            health.ResourceCooldown.Speed = 0f;
            stamina.ResourceCooldown.Speed = 0f;

            controller.Cm.PlayAnimation(controller.guardHash);
        }

        public void ExecuteFrame()
        {
            health.Tick();
            stamina.Tick();

            controller.Ir.InputQueue.Execute();
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