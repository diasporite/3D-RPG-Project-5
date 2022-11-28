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

        float screenThreshold = 0.95f;

        public ControllerDeathState(Controller controller)
        {
            this.controller = controller;
            csm = controller.sm;

            health = controller.Party.Health;

            stamina = controller.Stamina;
            power = controller.Power;

            cm = controller.Model;
        }

        public void Enter(params object[] args)
        {
            controller.currentState = StateID.ControllerDeath;

            controller.IsDead = true;

            controller.InputReader.InputQueue.ClearInputs();

            controller.Character.DisableHitDetectors();

            controller.Party.Tc?.MoveTowardTimescale(1f);

            controller.Party.OwnTarget.NotifyDeath();

            controller.GetComponentInParent<EnemyAIController>()?.Standby();

            controller.Party.TargetSphere.UnlockTarget();

            controller.Movement.gameObject.layer = 14;

            cm.PlayAnimation(controller.deathHash);
        }

        public void ExecuteFrame()
        {
            controller.ResourceTick(0f, 0f, 0f);

            controller.Party.Tc?.MoveTowardTimescale(1f);

            if (controller.Party.IsPlayer)
            {
                if (controller.Party.CurrentController.Model.GetNormalizedTime("Death") >= 
                    screenThreshold)
                {
                    controller.Party.InvokeDeath();
                    GameManager.instance.GameOver();
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