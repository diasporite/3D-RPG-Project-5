﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class ControllerRunState : IState
    {
        Controller controller;
        StateMachine csm;

        Health health;
        Stamina stamina;
        Power power;

        Movement movement;

        CharacterModel cm;

        public ControllerRunState(Controller controller)
        {
            this.controller = controller;
            csm = controller.sm;

            health = controller.Health;
            stamina = controller.Stamina;
            power = controller.Power;

            movement = controller.Movement;

            cm = controller.Model;
        }

        #region InterfaceMethods
        public void Enter(params object[] args)
        {
            controller.currentState = StateID.ControllerRun;

            health.SpeedFactor = 0f;
            if (controller.InCombat) stamina.SpeedFactor = -0.5f;
            else stamina.SpeedFactor = 1f;
            power.SpeedFactor = -4f;

            stamina.Charged = false;

            controller.Party.Tc?.SetTimescale(1f);

            cm.PlayAnimation(controller.moveHash);
        }

        public void ExecuteFrame()
        {
            if (controller.InCombat) stamina.SpeedFactor = -1f;
            else stamina.SpeedFactor = 1f;

            var dir = controller.InputReader.Move;

            health.Tick();
            stamina.Tick();
            power.Tick();

            controller.Party.Tc?.SetTimescale(1f);

            if (dir == Vector2.zero || stamina.Empty)
                csm.ChangeState(StateID.ControllerMove);

            UpdateAnim(controller.InputReader.Move);

            controller.InputReader.InputQueue.Execute();

            controller.Movement.MovePosition(dir, Time.deltaTime, SpeedMode.Run);

            if (!controller.InputReader.Run) csm.ChangeState(StateID.ControllerMove);
            if (controller.InputReader.Guard) csm.ChangeState(StateID.ControllerGuard);
            if (controller.Party.Ts.Locked)
            {
                csm.ChangeState(StateID.ControllerStrafe);
            }
            if (!movement.Grounded)
            {
                movement.FallSpeed = movement.RunSpeed;
                csm.ChangeState(StateID.ControllerFall);
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
        #endregion

        void UpdateAnim(Vector2 input)
        {
            var value = movement.AnimBlendValue(movement.CurrentSpeed);
            if (input != Vector2.zero) cm.SetFloat("RelativeSpeed", value);
            else cm.SetFloat("RelativeSpeed", 0f);
        }
    }
}