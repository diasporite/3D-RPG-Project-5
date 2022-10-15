using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class EnemyAIChaseState : IState
    {
        EnemyAIController ai;
        StateMachine aism;

        EnemyInputReader eir;

        public EnemyAIChaseState(EnemyAIController ai)
        {
            this.ai = ai;
            aism = ai.sm;

            eir = ai.Ir;
        }

        public void Enter(params object[] args)
        {
            if (!ai.Player.Aggro.Contains(ai.Party))
            {
                ai.Party.Aggro.Add(ai.Player);
                ai.Player.Aggro.Add(ai.Party);
            }
        }

        public void ExecuteFrame()
        {
            if (eir.InputQueue.Inputs.Count <= 0) ai.Timer.Tick();

            eir.MoveEnemy(ai.RelativeDirToPlayer);

            //if (ai.Timer.Full)
            //{
                if (ai.Party.CurrentStamina.Full)
                {
                    eir.Action(ai.Pattern.RandomPattern);
                    ai.Timer.Reset();
                }
            //}

            float dist = Vector3.Distance(ai.Follow.position, ai.transform.position);

            if (dist >= 12f)
            {
                aism.ChangeState(StateID.EnemyAIIdle);
            }
            else if (dist < 2f)
            {
                aism.ChangeState(StateID.EnemyAIStrafe);
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