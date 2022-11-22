using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class ControllerStrafeState : IState
    {
        Controller controller;
        StateMachine csm;

        Health health;
        Stamina stamina;

        Movement movement;

        CharacterModel cm;

        public ControllerStrafeState(Controller con)
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
            controller.currentState = StateID.ControllerStrafe;

            health.SpeedFactor = 1f;
            stamina.SpeedFactor = 1f;

            stamina.Charged = stamina.Full;

            controller.InputReader.InputQueue.ClearInputs();

            cm.PlayAnimation(controller.strafeHash);
        }

        public void ExecuteFrame()
        {
            var dir = controller.InputReader.Move;

            if (dir == Vector2.zero) health.Tick(0f);
            else health.Tick();
            stamina.Tick();

            UpdateAnim(dir);

            controller.InputReader.InputQueue.Execute();

            controller.Party.Tc?.MoveTowardTimescale(dir.magnitude);

            movement.MovePosition(dir, Time.deltaTime, SpeedMode.Strafe);

            if (!controller.Party.TargetSphere.Locked)
                csm.ChangeState(StateID.ControllerMove);
            if (controller.InputReader.Guard) csm.ChangeState(StateID.ControllerGuard);
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
            cm.SetFloat("InputX", input.x);
            cm.SetFloat("InputY", input.y);

            switch (movement.CurrentMovementState)
            {
                case MovementState.ThirdPerson:
                    cm.SetFloat("DirX", input.x);
                    cm.SetFloat("DirY", input.y);
                    break;
                case MovementState.TopDown:
                    if (controller.Party.TargetSphere.CurrentTargetTransform != null)
                    {
                        if (input != Vector2.zero)
                        {
                            var dir = (controller.Party.TargetSphere.CurrentTargetTransform.position -
                                controller.transform.position).normalized;
                            cm.SetFloat("DirX", dir.x);
                            cm.SetFloat("DirY", dir.y);
                        }
                        else
                        {
                            cm.SetFloat("DirX", 0f);
                            cm.SetFloat("DirY", 0f);
                        }
                    }
                    else
                    {
                        cm.SetFloat("DirX", input.x);
                        cm.SetFloat("DirY", input.y);
                    }
                    break;
            }
        }
    }
}