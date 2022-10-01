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

        CharacterModel cm;

        float normalizedTime = 0f;

        Cooldown timer = new Cooldown(1f, 1f, 0f);

        public ControllerDodgeState(Controller con)
        {
            controller = con;
            csm = con.sm;

            health = controller.Health;
            stamina = controller.Stamina;

            cm = controller.Cm;
        }

        public void Enter(params object[] args)
        {
            health.ResourceCooldown.Speed = 0f;
            stamina.ResourceCooldown.Speed = 0f;

            normalizedTime = 0f;

            timer.Reset();
        }

        public void ExecuteFrame()
        {
            health.Tick();
            stamina.Tick();

            timer.Tick();

            if (timer.Full) csm.ChangeState(StateID.ControllerMove);
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