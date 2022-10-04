using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class PowerBar : ResourceBar
    {
        public override void InitUI(PartyController party)
        {
            this.party = party;

            forCurrent = true;
            resource = party.CurrentPower;

            base.InitUI(party);
        }

        public override void InitUI(PartyController party, int index)
        {
            this.party = party;

            forCurrent = false;
            if (index < party.PartyMembers.Count) resource = party.PartyMembers[index].Power;

            base.InitUI(party);
        }

        public override void SubscribeToDelegates()
        {
            if (forCurrent) party.OnCharacterChange += UpdateResource;

            party.OnPowerTick += Tick;
        }

        public override void UnsubscribeFromDelegates()
        {
            if (forCurrent) party.OnCharacterChange -= UpdateResource;

            party.OnPowerTick -= Tick;
        }

        protected override void UpdateResource()
        {
            resource = party.CurrentPower;

            fill.fillAmount = resource.ResourceCooldown.CooldownFraction;
            fillShadow.fillAmount = resource.ResourceCooldown.CooldownFraction;
        }
    }
}