using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class ControllerDeathState : IState
    {
        Controller controller;
        StateMachine csm;

        Health health;

        Stamina stamina;
        Power power;

        CharacterModel cm;

        public ControllerDeathState(Controller controller)
        {
            this.controller = controller;
            csm = controller.sm;

            health = controller.Party.Health;

            stamina = controller.Stamina;
            power = controller.Power;

            cm = controller.Cm;
        }

        public void Enter(params object[] args)
        {
            health.SpeedFactor = 0f;
            stamina.SpeedFactor = 0f;
            power.SpeedFactor = 0f;

            stamina.Charged = false;

            controller.IsDead = true;

            controller.Ir.InputQueue.ClearInputs();

            controller.Character.DisableHitDetectors();

            controller.Party.Tc?.SetTimescale(1f);

            controller.Party.OwnTarget.NotifyDeath();

            controller.GetComponent<EnemyAIController>()?.Standby();

            cm.PlayAnimation(controller.deathHash);
        }

        public void ExecuteFrame()
        {
            health.Tick();
            stamina.Tick();
            power.Tick();

            controller.Party.Tc?.SetTimescale(1f);
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