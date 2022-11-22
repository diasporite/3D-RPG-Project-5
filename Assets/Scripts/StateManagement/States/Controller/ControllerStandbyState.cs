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

            health.SpeedFactor = 0f;
            if (controller.InCombat && !controller.IsDead)
                stamina.SpeedFactor = 1f;
            else stamina.SpeedFactor = 0f;
           
            stamina.Charged = stamina.Full;

            controller.Model.gameObject.SetActive(false);
        }

        public void ExecuteFrame()
        {
            health.Tick(0f);
            stamina.Tick();
            power.Tick(0f);

            if (controller.InCombat && !controller.IsDead)
                stamina.SpeedFactor = 0.333f;
            else stamina.SpeedFactor = 0f;
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