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

        Character character;
        Health health;
        Stamina stamina;
        Power power;

        InputReader input;

        bool advancing;

        int actionHash;

        float normalizedTime = 0f;
        float advanceThreshold = 0.9f;

        CharacterModel cm;

        public ControllerActionState(Controller con)
        {
            controller = con;
            csm = con.sm;

            party = controller.Party;

            character = controller.Character;
            health = controller.Health;
            stamina = controller.Stamina;
            power = controller.Power;

            input = controller.Ir;

            cm = controller.Cm;
        }

        public void Enter(params object[] args)
        {
            health.SpeedFactor = 0f;
            stamina.SpeedFactor = 0f;
            power.SpeedFactor = 0f;

            advancing = false;

            normalizedTime = 0f;

            controller.Party.Tc?.SetTimescaleInstant(1f);

            cm.PlayAnimation(controller.CurrentActionHash);
        }

        public void ExecuteFrame()
        {
            health.Tick();
            stamina.Tick();
            power.Tick();

            controller.Party.Tc?.SetTimescale(1f);

            //normalizedTime = NormalizedTime();
            normalizedTime = cm.GetNormalizedTime(controller.CurrentActionTag);

            if (party.Ts.Locked)
                cm.RotateTowardsTarget(party.transform.rotation, party.Ts.CurrentTargetTransform);

            controller.Movement.MovePositionAction(cm.transform.forward, Time.deltaTime,
                character.EvaluateActionMovement(normalizedTime));

            character.EnableHitDetector(controller.CurrentActionIndex, normalizedTime);

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
            if (!advancing && normalizedTime >= advanceThreshold)
            {
                advancing = true;

                var actionsLeft = input.InputQueue.Advance();

                if (stamina.Empty)
                {
                    input.InputQueue.ClearInputs();
                    csm.ChangeState(StateID.ControllerMove);
                }
                else
                {
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
        }

        float NormalizedTime()
        {
            float t = cm.Anim.GetCurrentAnimatorStateInfo(0).normalizedTime;
            return t - Mathf.Floor(t);
        }
    }
}