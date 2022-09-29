﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class ControllerFallState : IState
    {
        Controller controller;
        StateMachine csm;

        Health health;
        Stamina stamina;

        Movement movement;

        CharacterModel cm;

        public ControllerFallState(Controller con)
        {
            controller = con;
            csm = con.sm;

            health = controller.Health;
            stamina = controller.Stamina;

            movement = controller.Movement;

            cm = controller.Cm;
        }

        public void Enter(params object[] args)
        {
            health.SpeedFactor = 0f;
            stamina.SpeedFactor = 0f;

            //cm.PlayAnimation(controller.fallHash);
        }

        public void ExecuteFrame()
        {
            var dir = controller.Ir.Move;

            health.Tick();
            stamina.Tick();

            movement.MovePosition(dir, Time.deltaTime, SpeedMode.Fall);

            if (movement.VerticalVelocity <= 0)
            {
                if (movement.Grounded) csm.ChangeState(StateID.ControllerMove);
                else csm.ChangeState(StateID.ControllerFall);
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