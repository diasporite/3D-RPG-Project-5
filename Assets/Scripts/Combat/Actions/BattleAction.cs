using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    [Serializable]
    public class BattleAction
    {
        [SerializeField] string name;
        [SerializeField] ElementID element;

        [SerializeField] int spCost;
        [SerializeField] int ppCost;

        [SerializeField] AnimationCurve motionCurve;

        // Trigger colliders will be used to determine if there is
        //   sufficient space for the action
        [SerializeField] int collisionCheckIndex;

        PartyController party;

        public bool IsActionValid
        {
            get
            {
                return party.Stamina.ResourcePoints >= spCost;
            }
        }

        public float EvaluateCurve(float normTime) => 
            motionCurve.Evaluate(normTime);

        public BattleAction(ActionData data, PartyController party)
        {
            name = data.ActionName;
            element = data.Element;

            spCost = data.StaminaCost;
            ppCost = data.PowerCost;

            motionCurve = data.MotionCurve;

            collisionCheckIndex = data.CollisionCheckIndex;

            this.party = party;
        }
    }
}