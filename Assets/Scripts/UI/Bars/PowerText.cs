using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RPG_Project
{
    public class PowerText : CooldownText, IUIElement
    {
        [SerializeField] bool forCurrentCharacter;
        [SerializeField] int index;

        PartyController party;
        Power power;

        public override void InitUI()
        {
            party = GetComponentInParent<BattleHUD>().Player;

            if (forCurrentCharacter)
                power = party.CurrentController.Power;
            else power = party.PartyMembers[index].Power;

            header = "PP ";

            UpdateUI();
        }

        public override void SubscribeToDelegates()
        {
            party.OnPowerTick += UpdateUI;

            if (forCurrentCharacter)
                party.OnCharacterChange += UpdateCharacter;
        }

        public override void UnsubscribeFromDelegates()
        {
            party.OnPowerTick -= UpdateUI;

            if (forCurrentCharacter)
                party.OnCharacterChange -= UpdateCharacter;
        }

        public override void UpdateUI()
        {
            text.text = header + power.ResourcePoints + "/" +
                power.ResourceCooldown.CooldownValue;
        }

        void UpdateUI(int change)
        {
            UpdateUI();
        }

        void UpdateCharacter()
        {
            power = party.CurrentController.Power;

            text.text = header + power.ResourcePoints + "/" +
                power.ResourceCooldown.CooldownValue;
        }
    }
}