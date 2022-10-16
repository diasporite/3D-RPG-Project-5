using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class ControllerDeathState : IState
    {
        Controller controller;
        StateMachine csm;

        CharacterModel cm;

        public ControllerDeathState(Controller controller)
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

            controller.IsDead = true;

            controller.Ir.InputQueue.ClearInputs();

            controller.Character.DisableHitDetectors();

            controller.Party.Tc?.SetTimescale(1f);

            cm.PlayAnimation(controller.deathHash);
        }

        public void ExecuteFrame()
        {
            controller.Health.Tick();
            controller.Stamina.Tick();
            controller.Power.Tick();

            controller.Party.Tc?.SetTimescale(1f);
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