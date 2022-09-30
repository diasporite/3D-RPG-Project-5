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

        Movement movement;

        CharacterModel cm;

        public ControllerRunState(Controller controller)
        {
            this.controller = controller;
            csm = controller.sm;

            health = controller.Health;
            stamina = controller.Stamina;

            movement = controller.Movement;

            cm = controller.Cm;
        }

        #region InterfaceMethods
        public void Enter(params object[] args)
        {
            health.SpeedFactor = 0f;
            stamina.SpeedFactor = -0.5f;
            stamina.Charged = false;

            cm.PlayAnimation(controller.moveHash);
        }

        public void ExecuteFrame()
        {
            var dir = controller.Ir.Move;

            health.Tick();
            stamina.Tick();

            if (dir == Vector2.zero || stamina.Empty)
                csm.ChangeState(StateID.ControllerMove);

            UpdateAnim(controller.Ir.Move);

            controller.Ir.InputQueue.Execute();

            controller.Movement.MovePosition(dir, Time.deltaTime, SpeedMode.Run);

            if (!movement.Grounded) csm.ChangeState(StateID.ControllerFall);
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