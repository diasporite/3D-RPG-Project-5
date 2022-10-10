using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class EnemyAIIdleState : IState
    {
        EnemyAIController ai;
        StateMachine aism;

        EnemyInputReader eir;

        public EnemyAIIdleState(EnemyAIController ai)
        {
            this.ai = ai;
            aism = ai.sm;

            eir = ai.Ir;
        }

        public void Enter(params object[] args)
        {
            if (ai.Player.Aggro.Contains(ai.Party))
            {
                ai.Party.Aggro.Remove(ai.Player);
                ai.Player.Aggro.Remove(ai.Party);
            }
        }

        public void ExecuteFrame()
        {
            eir.MoveEnemy(Vector3.zero);

            if (Vector3.Distance(ai.Follow.position, ai.transform.position) < 8f)
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

        }
    }
}