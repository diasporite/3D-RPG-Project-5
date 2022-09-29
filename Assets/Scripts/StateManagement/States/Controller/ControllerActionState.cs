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

        public void Enter(params object[] args)
        {
            health.SpeedFactor = 0f;
            stamina.SpeedFactor = 0f;

            normalisedTime = 0f;

            // Play correct animation
            cm.PlayAnimation(controller.CurrentActionHash);
        }

        public void ExecuteFrame()
        {
            health.Tick();
            stamina.Tick();

            normalisedTime = cm.Anim.GetCurrentAnimatorStateInfo(0).normalizedTime;

            if (normalisedTime >= advanceThreshold)
            {
                var actionsLeft = input.InputQueue.Advance();
                if (actionsLeft) input.InputQueue.Execute();
                else
                {
                    if (!controller.Movement.Grounded) csm.ChangeState(StateID.ControllerFall);
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
    }
}