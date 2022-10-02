using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class StaminaText : ResourceText
    {
        public override void InitUI(PartyController party)
        {
            header = "SP ";

            this.party = party;

            base.InitUI(party);
        }

        public override void SubscribeToDelegates()
        {
            party.OnCharacterChange += UpdateTick;
            party.OnStaminaTick += UpdateTick;
        }

        public override void UnsubscribeFromDelegates()
        {
            party.OnCharacterChange -= UpdateTick;
            party.OnStaminaTick -= UpdateTick;
        }

        protected override void UpdateTick()
        {
            text.text = header + party.CurrentStamina.ResourcePoints + "/" +
                Mathf.RoundToInt(party.CurrentStamina.ResourceCooldown.CooldownValue);
        }
    }
}