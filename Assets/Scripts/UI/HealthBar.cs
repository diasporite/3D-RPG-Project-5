using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class HealthBar : ResourceBar
    {
        public override void InitUI(PartyController party)
        {
            this.party = party;
            resource = party.CurrentHealth;

            base.InitUI(party);
        }

        public override void SubscribeToDelegates()
        {
            party.OnHealthTick += Tick;
        }

        public override void UnsubscribeFromDelegates()
        {
            party.OnHealthTick -= Tick;
        }

        protected override void UpdateResource()
        {
            resource = party.CurrentHealth;
        }
    }
}