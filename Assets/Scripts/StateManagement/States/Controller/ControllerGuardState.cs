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
            controller.currentState = StateID.ControllerGuard;

            health.ResourceCooldown.Speed = 0f;
            stamina.ResourceCooldown.Speed = 0f;

            controller.Party.Tc?.SetTimescale(1f);

            controller.Model.PlayAnimation(controller.guardHash);
        }

        public void ExecuteFrame()
        {
            health.Tick();
            stamina.Tick();

            controller.Party.Tc?.SetTimescale(1f);

            if (controller.Party.Ts.Locked)
                controller.Model.RotateTowardsTarget(controller.Party.transform.rotation, controller.Party.Ts.CurrentTargetTransform);

            controller.InputReader.InputQueue.Execute();

            if (!controller.InputReader.Guard) csm.ChangeState(StateID.ControllerMove);
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