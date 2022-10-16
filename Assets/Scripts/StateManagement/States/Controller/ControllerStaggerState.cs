using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class ControllerStaggerState : IState
    {
        Controller controller;
        StateMachine csm;

        CharacterModel cm;

        float normalizedTime = 0f;

        public ControllerStaggerState(Controller controller)
        {
            this.controller = controller;
            csm = controller.sm;

            cm = controller.Cm;
        }

        public void Enter(params object[] args)
        {
            controller.Health.SpeedFactor = 0f;
            controller.Stamina.SpeedFactor = 0f;
            controller.Power.SpeedFactor = 0f;

            controller.Stamina.Charged = false;

            controller.IsStaggered = true;

            controller.Ir.InputQueue.ClearInputs();

            controller.Character.DisableHitDetectors();

            normalizedTime = 0f;

            controller.Party.Tc?.SetTimescale(1f);

            cm.PlayAnimation(controller.staggerHash);
        }

        public void ExecuteFrame()
        {
            controller.Health.Tick();
            controller.Stamina.Tick();
            controller.Power.Tick();

            controller.Party.Tc?.SetTimescale(1f);

            normalizedTime = cm.GetNormalizedTime(controller.staggerTag);

            if (normalizedTime >= 0.9f) csm.ChangeState(StateID.ControllerMove);
        }

        public void ExecuteFrameFixed()
        {

        }

        public void ExecuteFrameLate()
        {

        }

        public void Exit()
        {
            controller.IsStaggered = false;

            controller.Stamina.ResourceCooldown.CooldownFraction = 0.5f;
        }
    }
}