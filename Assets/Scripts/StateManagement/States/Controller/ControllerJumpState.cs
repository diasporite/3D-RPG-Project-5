using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class ControllerJumpState : IState
    {
        Controller controller;
        StateMachine csm;

        Health health;
        Stamina stamina;

        Movement movement;

        float normalisedTime;
        bool advancing = false;

        public ControllerJumpState(Controller con)
        {
            controller = con;
            csm = con.sm;

            health = controller.Health;
            stamina = controller.Stamina;

            movement = controller.Movement;
        }

        public void Enter(params object[] args)
        {
            controller.currentState = StateID.ControllerJump;

            health.SpeedFactor = 0f;
            stamina.SpeedFactor = 0f;

            controller.Party.Tc?.MoveTowardTimescale(1f);

            controller.Model.PlayAnimationInstant(controller.fallHash);
        }

        public void ExecuteFrame()
        {
            var dir = controller.InputReader.Move;

            health.Tick();
            stamina.Tick();

            controller.Party.Tc?.MoveTowardTimescale(1f);

            if (controller.Party.TargetSphere.Locked)
                controller.Model.RotateTowardsTarget(controller.Party.transform.rotation, controller.Party.TargetSphere.CurrentTargetTransform);

            movement.MovePosition(dir, Time.deltaTime, SpeedMode.Fall);

            if (movement.VerticalVelocity <= 0f)
                csm.ChangeState(StateID.ControllerFall);
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

        void ProcessQueue()
        {
            //normalisedTime = NormalizedTime();

            //if (!advancing && normalisedTime >= 0.9f)
            //{
            //    advancing = true;

            //    var actionsLeft = input.InputQueue.Advance();

            //    if (actionsLeft)
            //        input.InputQueue.Execute();
            //    else
            //    {
            //        if (!controller.Movement.Grounded)
            //            csm.ChangeState(StateID.ControllerFall);
            //        else csm.ChangeState(StateID.ControllerMove);
            //    }
            //}
        }

        float NormalizedTime()
        {
            float t = controller.Model.Anim.GetCurrentAnimatorStateInfo(0).normalizedTime;
            return t - Mathf.Floor(t);
        }
    }
}