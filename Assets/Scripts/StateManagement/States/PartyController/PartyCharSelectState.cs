using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class PartyCharSelectState : IState
    {
        PartyController party;
        StateMachine psm;

        public PartyCharSelectState(PartyController party)
        {
            this.party = party;
            psm = party.sm;
        }

        public void Enter(params object[] args)
        {
            throw new System.NotImplementedException();
        }

        public void ExecuteFrame()
        {
            throw new System.NotImplementedException();
        }

        public void ExecuteFrameFixed()
        {
            throw new System.NotImplementedException();
        }

        public void ExecuteFrameLate()
        {
            throw new System.NotImplementedException();
        }

        public void Exit()
        {
            throw new System.NotImplementedException();
        }
    }
}