﻿using System.Collections;
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

        Movement movement;

        public ControllerStandbyState(Controller con)
        {
            controller = con;
            csm = con.sm;

            health = controller.Health;
            stamina = controller.Stamina;

            movement = controller.Movement;
        }

        public void Enter(params object[] args)
        {
            health.SpeedFactor = 0f;
            if (controller.InCombat) stamina.SpeedFactor = 0.667f;
            else stamina.SpeedFactor = 0f;

            stamina.Charged = stamina.Full;

            controller.Cm.gameObject.SetActive(false);
        }

        public void ExecuteFrame()
        {
            health.Tick();
            stamina.Tick();

            if (controller.InCombat) stamina.SpeedFactor = 0.333f;
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
            controller.Cm.gameObject.SetActive(true);
        }
    }
}