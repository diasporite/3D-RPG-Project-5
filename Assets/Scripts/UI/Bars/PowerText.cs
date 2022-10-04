using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class PowerText : ResourceText
    {
        public override void InitUI(PartyController party)
        {
            header = "PP ";

            this.party = party;

            base.InitUI(party);
        }

        public override void SubscribeToDelegates()
        {
            party.OnCharacterChange += UpdateTick;
            party.OnPowerTick += UpdateTick;
        }

        public override void UnsubscribeFromDelegates()
        {
            party.OnCharacterChange -= UpdateTick;
            party.OnPowerTick -= UpdateTick;
        }

        protected override void UpdateTick()
        {
            text.text = header + party.CurrentPower.ResourcePoints + "/" +
                Mathf.RoundToInt(party.CurrentPower.ResourceCooldown.CooldownValue);
        }
    }
}