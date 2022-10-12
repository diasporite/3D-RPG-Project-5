using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class ControllerMoveState : IState
    {
        Controller controller;
        StateMachine csm;

        Health health;
        Stamina stamina;

        Movement movement;

        CharacterModel cm;

        public ControllerMoveState(Controller con)
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
            health.SpeedFactor = 1f;
            stamina.SpeedFactor = 1f;

            stamina.Charged = stamina.Full;

            controller.Ir.InputQueue.ClearInputs();

            cm.PlayAnimation(controller.moveHash);
        }

        public void ExecuteFrame()
        {
            var dir = controller.Ir.Move;

            if (dir == Vector2.zero) health.Tick(0f);
            else health.Tick();
            stamina.Tick();

            UpdateAnim(dir);

            controller.Ir.InputQueue.Execute();

            movement.MovePosition(dir, Time.deltaTime, SpeedMode.Walk);

            if (controller.Ir.Run) csm.ChangeState(StateID.ControllerRun);
            if (controller.Ir.Guard) csm.ChangeState(StateID.ControllerGuard);
            if (controller.Party.Ts.Locked)
            {
                csm.ChangeState(StateID.ControllerStrafe);
            }
            if (!movement.Grounded)
            {
                movement.FallSpeed = movement.WalkSpeed;

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

        void UpdateAnim(Vector2 input)
        {
            var value = movement.AnimBlendValue(movement.CurrentSpeed);
            if (input != Vector2.zero) cm.SetFloat("RelativeSpeed", value);
            else cm.SetFloat("RelativeSpeed", 0f);
        }
    }
}