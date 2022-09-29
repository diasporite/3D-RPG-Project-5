using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class StaminaBar : ResourceBar
    {
        Stamina stamina;

        [SerializeField] Color charging = new Color(0.376f, 0.376f, 0.376f);
        [SerializeField] Color charged = new Color(0f, 0f, 0.753f);

        public override void InitUI(PartyController party)
        {
            this.party = party;
            resource = party.CurrentStamina;
            stamina = (Stamina)resource;

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

        protected override void Tick()
        {
            base.Tick();

            if (stamina.Charged) fill.color = charged;
            else fill.color = charging;
        }

        protected override void UpdateResource()
        {
            resource = party.CurrentStamina;
        }
    }
}