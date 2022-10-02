using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class HealthText : ResourceText
    {
        public override void InitUI(PartyController party)
        {
            header = "HP ";

            this.party = party;

            base.InitUI(party);
        }

        public override void SubscribeToDelegates()
        {
            party.OnCharacterChange += UpdateTick;
            party.OnHealthTick += UpdateTick;
        }

        public override void UnsubscribeFromDelegates()
        {
            party.OnCharacterChange -= UpdateTick;
            party.OnHealthTick -= UpdateTick;
        }

        protected override void UpdateTick()
        {
            text.text = header + party.CurrentHealth.ResourcePoints + "/" +
                Mathf.RoundToInt(party.CurrentHealth.ResourceCooldown.CooldownValue);
        }
    }
}