using System.Collections;
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
        Character character;

        CharacterModel cm;

        float normalizedTime = 0f;

        bool advancing = false;

        Vector3 dodgeDir;

        public ControllerDodgeState(Controller con)
        {
            controller = con;
            csm = con.sm;

            health = controller.Health;
            stamina = controller.Stamina;
            character = controller.Character;

            cm = controller.Cm;
        }

        public void Enter(params object[] args)
        {
            health.ResourceCooldown.Speed = 0f;
            stamina.ResourceCooldown.Speed = 0f;

            normalizedTime = 0f;

            advancing = false;

            cm.SetFloat("InputX", controller.Ir.Move.x);
            cm.SetFloat("InputY", controller.Ir.Move.y);

            cm.PlayAnimationInstant(controller.dodgeHash);

            if (controller.Party.Ts.Locked)
            {
                if (controller.CurrentDodgeDir != Vector3.zero)
                    dodgeDir = controller.CurrentDodgeDir;
                else dodgeDir = controller.Cm.transform.forward;
            }
            else dodgeDir = controller.Cm.transform.forward;
        }

        public void ExecuteFrame()
        {
            health.Tick();
            stamina.Tick();

            normalizedTime = NormalizedTime();

            controller.Movement.MovePositionAction(dodgeDir, Time.deltaTime, 
                controller.Character.DodgeAction.MotionCurve.Evaluate(normalizedTime));

            if (!controller.DirectionalDodging)
                cm.RotateTowards(controller.Party.transform.rotation * dodgeDir);

            if (!advancing && normalizedTime >= 0.8f)
            {
                advancing = true;

                var actionsLeft = controller.Ir.InputQueue.Advance();

                if (actionsLeft)
                    controller.Ir.InputQueue.Execute();
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