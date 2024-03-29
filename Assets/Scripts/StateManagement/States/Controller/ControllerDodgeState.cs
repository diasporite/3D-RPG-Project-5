﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class ControllerDodgeState : IState
    {
        Controller controller;
        StateMachine csm;

        Health health;
        Stamina stamina;
        Power power;

        Character character;

        CharacterModel cm;

        float normalizedTime = 0f;

        bool advancing = false;

        Vector3 dodgeDir;

        float delay = 0.4f;
        Cooldown delayTimer;

        public ControllerDodgeState(Controller con)
        {
            controller = con;
            csm = con.sm;

            health = controller.Health;
            stamina = controller.Stamina;
            power = controller.Power;

            character = controller.Character;

            cm = controller.Model;

            delayTimer = new Cooldown(delay, 1f, 0f);
        }

        public void Enter(params object[] args)
        {
            controller.currentState = StateID.ControllerDodge;

            normalizedTime = 0f;

            advancing = false;

            cm.SetFloat("InputX", controller.InputReader.Move.x);
            cm.SetFloat("InputY", controller.InputReader.Move.y);

            controller.Party.Tc?.MoveTowardTimescale(1f);

            controller.Party.PlayerSignal?.SendPulse();

            //cm.PlayAnimationInstant(controller.dodgeHash);

            if (controller.Party.TargetSphere.Locked)
            {
                if (controller.CurrentDodgeDir != Vector3.zero)
                    dodgeDir = controller.CurrentDodgeDir;
                else dodgeDir = controller.Model.transform.forward;
            }
            else dodgeDir = controller.Model.transform.forward;

            delayTimer.Reset();
        }

        public void ExecuteFrame()
        {
            controller.ResourceTick(0f, 0f, 0f);

            controller.Party.Tc?.MoveTowardTimescale(1f);

            //normalizedTime = NormalizedTime();

            //controller.Movement.MovePositionAction(dodgeDir, Time.deltaTime, 
            //    controller.Character.DodgeAction.MotionCurve.Evaluate(normalizedTime));

            //if (!controller.DirectionalDodging)
            //    cm.RotateTowards(controller.Party.transform.rotation * dodgeDir);

            //if (!advancing && normalizedTime >= 0.8f)
            //{
            //    advancing = true;

            //    var actionsLeft = controller.InputReader.InputQueue.Advance();

            //    if (actionsLeft)
            //        controller.InputReader.InputQueue.Execute();
            //    else
            //    {
            //        if (!controller.Movement.Grounded)
            //            csm.ChangeState(StateID.ControllerFall);
            //        else csm.ChangeState(StateID.ControllerMove);
            //    }
            //}

            delayTimer.Tick();

            if (delayTimer.Full)
            {
                controller.Movement.MoveToPosition(controller.transform.position + 4f *
                    dodgeDir.normalized + 0.5f * Vector3.up);

                if (!controller.Movement.Grounded)
                    csm.ChangeState(StateID.ControllerFall);
                else csm.ChangeState(StateID.ControllerMove);
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

        float NormalizedTime()
        {
            float t = cm.Anim.GetCurrentAnimatorStateInfo(0).normalizedTime;
            return t - Mathf.Floor(t);
        }
    }
}