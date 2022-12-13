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

        PartyController party;

        public ControllerGuardState(Controller con)
        {
            controller = con;
            csm = con.sm;

            health = controller.Health;
            stamina = controller.Stamina;

            party = controller.Party;
        }

        public void Enter(params object[] args)
        {
            controller.currentState = StateID.ControllerGuard;

            health.ResourceCooldown.Speed = 0f;
            stamina.ResourceCooldown.Speed = 0f;

            party.Tc?.MoveTowardTimescale(1f);

            controller.Model.PlayAnimation(controller.guardHash);
        }

        public void ExecuteFrame()
        {
            controller.ResourceTick(0f, 0f, 0f);

            party.Tc?.MoveTowardTimescale(1f);

            party.PlayerSignal?.Tick();

            if (party.TargetSphere.Locked)
                controller.Model.RotateTowardsTarget(party.transform.rotation, 
                    party.TargetSphere.CurrentTargetTransform);

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