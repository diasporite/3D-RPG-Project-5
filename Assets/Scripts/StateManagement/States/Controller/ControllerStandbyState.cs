using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class ControllerStandbyState : IState
    {
        Controller controller;
        StateMachine csm;

        Health health;
        Stamina stamina;
        Power power;

        Movement movement;

        public ControllerStandbyState(Controller con)
        {
            controller = con;
            csm = con.sm;

            health = controller.Health;
            stamina = controller.Stamina;
            power = controller.Power;

            movement = controller.Movement;
        }

        public void Enter(params object[] args)
        {
            controller.currentState = StateID.ControllerStandby;

            stamina.Charged = stamina.Full;

            controller.Model.gameObject.SetActive(false);
        }

        public void ExecuteFrame()
        {
            controller.ResourceTick(0f, 
                (controller.InCombat && !controller.IsDead) ? .333f : 0f, 0f);
        }

        public void ExecuteFrameFixed()
        {

        }

        public void ExecuteFrameLate()
        {

        }

        public void Exit()
        {
            controller.Model.gameObject.SetActive(true);
        }
    }
}