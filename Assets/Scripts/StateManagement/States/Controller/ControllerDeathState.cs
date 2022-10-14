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
            controller.IsDead = true;

            controller.Ir.InputQueue.ClearInputs();

            cm.PlayAnimation(controller.deathHash);
        }

        public void ExecuteFrame()
        {
            if (cm.CurrentNormalizedTime >= 0.9f)
            {
                controller.Party.SwitchToNextCharacter(controller);
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
    }
}