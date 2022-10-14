using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class EnemyAIStrafeState : IState
    {
        EnemyAIController ai;
        StateMachine aism;

        EnemyInputReader eir;

        public EnemyAIStrafeState(EnemyAIController ai)
        {
            this.ai = ai;
            aism = ai.sm;

            eir = ai.Ir;
        }

        public void Enter(params object[] args)
        {
            eir.ToggleLock();
        }

        public void ExecuteFrame()
        {
            if (eir.InputQueue.Inputs.Count <= 0) ai.Timer.Tick();

            eir.MoveEnemy(Vector2.one);

            //if (ai.Timer.Full)
            //{
                if (ai.Party.CurrentStamina.Full)
                {
                    eir.Action(ai.Pattern.RandomPattern);
                    ai.Timer.Reset();
                }
            //}

            float dist = Vector3.Distance(ai.Follow.position, ai.transform.position);

            if (dist >= 5f)
            {
                aism.ChangeState(StateID.EnemyAIChase);
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
            eir.ToggleLock();
        }
    }
}