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

            forCurrent = true;
            resource = party.CurrentHealth;

            base.InitUI(party);
        }

        public override void InitUI(PartyController party, int index)
        {
            this.party = party;

            forCurrent = false;
            if (index < party.PartyMembers.Count) resource = party.PartyMembers[index].Health;

            base.InitUI(party);
        }

        public override void SubscribeToDelegates()
        {
            if (forCurrent) party.OnCharacterChange += UpdateResource;

            party.OnHealthTick += Tick;
        }

        public override void UnsubscribeFromDelegates()
        {
            if (forCurrent) party.OnCharacterChange -= UpdateResource;

            party.OnHealthTick -= Tick;
        }

        protected override void UpdateResource()
        {
            resource = party.CurrentHealth;

            fill.fillAmount = resource.ResourceCooldown.CooldownFraction;
            fillShadow.fillAmount = resource.ResourceCooldown.CooldownFraction;
        }
    }
}