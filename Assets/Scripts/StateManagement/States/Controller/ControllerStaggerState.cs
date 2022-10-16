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
            controller.IsStaggered = true;

            controller.Ir.InputQueue.ClearInputs();

            controller.Character.DisableHitDetectors();

            normalizedTime = 0f;

            cm.PlayAnimation(controller.staggerHash);
        }

        public void ExecuteFrame()
        {
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