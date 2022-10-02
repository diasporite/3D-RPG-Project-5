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

            forCurrent = true;
            resource = party.CurrentStamina;
            stamina = (Stamina)resource;

            base.InitUI(party);
        }

        public override void InitUI(PartyController party, int index)
        {
            this.party = party;

            forCurrent = false;

            if (index < party.PartyMembers.Count)
            {
                resource = party.PartyMembers[index].Stamina;
                stamina = (Stamina)resource;
            }

            base.InitUI(party);
        }

        public override void SubscribeToDelegates()
        {
            if (forCurrent) party.OnCharacterChange += UpdateResource;

            party.OnStaminaTick += Tick;
        }

        public override void UnsubscribeFromDelegates()
        {
            if (forCurrent) party.OnCharacterChange -= UpdateResource;

            party.OnStaminaTick -= Tick;
        }

        protected override void Tick()
        {
            base.Tick();

            if (stamina != null)
            {
                if (stamina.Charged) fill.color = charged;
                else fill.color = charging;
            }
        }

        protected override void UpdateResource()
        {
            resource = party.CurrentStamina;
            stamina = (Stamina)resource;

            fill.fillAmount = resource.ResourceCooldown.CooldownFraction;
            fillShadow.fillAmount = resource.ResourceCooldown.CooldownFraction;
        }
    }
}