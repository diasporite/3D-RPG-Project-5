using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class ControllerActionState : IState
    {
        Controller controller;
        StateMachine csm;

        PartyController party;

        Health health;
        Stamina stamina;

        InputReader input;

        bool advancing;

        int actionHash;

        float normalisedTime = 0f;
        float advanceThreshold = 0.9f;

        CharacterModel cm;

        public ControllerActionState(Controller con)
        {
            controller = con;
            csm = con.sm;

            party = controller.Party;

            health = controller.Health;
            stamina = controller.Stamina;

            input = controller.Ir;

            cm = controller.Cm;
        }

        public void Enter(params object[] args)
        {
            health.SpeedFactor = 0f;
            stamina.SpeedFactor = 0f;

            advancing = false;

            normalisedTime = 0f;

            cm.PlayAnimationInstant(controller.CurrentActionHash);
        }

        public void ExecuteFrame()
        {
            health.Tick();
            stamina.Tick();

            normalisedTime = NormalizedTime();

            if (party.Ts.Locked)
                cm.RotateTowardsTarget(party.transform.rotation, party.Ts.CurrentTargetTransform);

            controller.Movement.MovePositionAction(controller.Cm.transform.forward, Time.deltaTime,
                controller.Character.CharData.CombatActions[controller.CurrentActionIndex].MotionCurve.Evaluate(normalisedTime));

            controller.Character.EnableHitDetector(controller.CurrentActionIndex, normalisedTime);

            ProcessQueue();
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

        float NormalizedTime()
        {
            float t = cm.Anim.GetCurrentAnimatorStateInfo(0).normalizedTime;
            return t - Mathf.Floor(t);
        }
    }
}