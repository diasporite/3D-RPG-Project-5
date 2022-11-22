using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class EnemyAIStandbyState : IState
    {
        EnemyAIController ai;
        StateMachine aism;

        EnemyInputReader eir;

        public EnemyAIStandbyState(EnemyAIController ai)
        {
            this.ai = ai;
            aism = ai.sm;

            eir = ai.Ir;
        }

        public void Enter(params object[] args)
        {
            if (ai.Player != null)
            {
                if (ai.Player.Aggro.Contains(ai.Party))
                {
                    ai.Party.Aggro.Remove(ai.Player);
                    ai.Player.Aggro.Remove(ai.Party);
                }
            }
        }

        public void ExecuteFrame()
        {
            // Timer tick

            // If timer full spawn new enemy, change to EnemyAIIdle
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