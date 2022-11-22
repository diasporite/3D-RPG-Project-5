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
        Power power;

        Movement movement;

        CharacterModel cm;

        public ControllerMoveState(Controller con)
        {
            controller = con;
            csm = con.sm;

            health = controller.Health;
            stamina = controller.Stamina;
            power = controller.Power;

            movement = controller.Movement;

            cm = controller.Model;
        }

        public void Enter(params object[] args)
        {
            controller.currentState = StateID.ControllerMove;

            health.SpeedFactor = 1f;
            stamina.SpeedFactor = 1f;
            power.SpeedFactor = -1f;

            stamina.Charged = stamina.Full;

            controller.InputReader.InputQueue.ClearInputs();

            cm.PlayAnimation(controller.moveHash);
        }

        public void ExecuteFrame()
        {
            var dir = controller.InputReader.Move;

            Tick(dir);

            UpdateAnim(dir);

            controller.InputReader.InputQueue.Execute();

            controller.Party.Tc?.MoveTowardTimescale(dir.magnitude);

            movement.MovePosition(dir, Time.deltaTime, SpeedMode.Walk);

            if (controller.InputReader.Run && stamina.ResourceFraction >= 0.25f)
                csm.ChangeState(StateID.ControllerRun);
            else if (controller.InputReader.Guard)
                csm.ChangeState(StateID.ControllerGuard);
            else if (controller.Party.TargetSphere.Locked)
                csm.ChangeState(StateID.ControllerStrafe);
            else if (!movement.Grounded)
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

        void Tick(Vector2 dir)
        {
            if (dir == Vector2.zero)
            {
                health.Tick(0f);
                power.Tick(0f);
            }
            else
            {
                health.Tick();
                power.Tick();
            }

            stamina.Tick();
        }

        void UpdateAnim(Vector2 input)
        {
            var value = movement.AnimBlendValue(movement.CurrentSpeed);
            if (input != Vector2.zero) cm.SetFloat("RelativeSpeed", value);
            else cm.SetFloat("RelativeSpeed", 0f);
        }
    }
}