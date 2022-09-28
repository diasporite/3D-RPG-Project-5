using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class StaminaBar : ResourceBar
    {
        Stamina stamina;

        public override void InitUI(PartyController party)
        {
            this.party = party;
            resource = party.CurrentStamina;

            base.InitUI(party);
        }

        public override void SubscribeToDelegates()
        {
            party.OnStaminaTick += Tick;
        }

        public override void UnsubscribeFromDelegates()
        {
            party.OnStaminaTick -= Tick;
        }

        protected override void UpdateResource()
        {
            resource = party.CurrentStamina;
        }
    }
}