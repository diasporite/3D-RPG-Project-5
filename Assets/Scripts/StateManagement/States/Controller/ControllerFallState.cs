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

            cm = controller.Model;
        }

        public void Enter(params object[] args)
        {
            controller.currentState = StateID.ControllerFall;

            controller.Party.Tc?.MoveTowardTimescale(1f);

            cm.PlayAnimation(controller.fallHash);
        }

        public void ExecuteFrame()
        {
            var dir = controller.InputReader.Move;

            controller.ResourceTick(0f, 1f, 0f);

            controller.Party.Tc?.MoveTowardTimescale(1f);

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