using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class ControllerActionState : IState
    {
        Controller controller;
        StateMachine csm;

        Health health;
        Stamina stamina;

        InputReader input;

        bool advancing;

        int index;
        int actionHash;

        float normalisedTime = 0f;
        float advanceThreshold = 0.85f;

        CharacterModel cm;

        public ControllerActionState(Controller con)
        {
            controller = con;
            csm = con.sm;

            health = controller.Health;
            stamina = controller.Stamina;

            input = controller.Ir;

            cm = controller.Cm;
        }

        public ControllerActionState(Controller con, int index)
        {
            controller = con;
            csm = con.sm;

            health = controller.Health;
            stamina = controller.Stamina;

            input = controller.Ir;

            cm = controller.Cm;

            this.index = index;
            actionHash = controller.actionHashes[index];
        }

        public void Enter(params object[] args)
        {
            health.SpeedFactor = 0f;
            stamina.SpeedFactor = 0f;

            advancing = false;

            normalisedTime = 0f;

            //Debug.Log("action state " + index);
            // Play correct animation
            cm.PlayAnimationInstant(controller.CurrentActionHash);
            //cm.PlayAnimationInstant(actionHash);
        }

        public void ExecuteFrame()
        {
            health.Tick();
            stamina.Tick();

            normalisedTime = NormalizedTime();

            if (!advancing && normalisedTime >= advanceThreshold)
            {
                advancing = true;

                var actionsLeft = input.InputQueue.Advance();

                if (actionsLeft)
                    input.InputQueue.Execute();
                else
                {
                    if (!controller.Movement.Grounded)
                        csm.ChangeState(StateID.ControllerFall);
                    else csm.ChangeState(StateID.ControllerMove);
                }
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