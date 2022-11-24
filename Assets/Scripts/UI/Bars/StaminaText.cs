using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RPG_Project
{
    public class StaminaText : CooldownText, IUIElement
    {
        PartyController party;
        Stamina stamina;

        public override void InitUI()
        {
            party = GetComponentInParent<BattleHUD>().Player;
            stamina = party.CurrentStamina;

            header = "SP ";

            UpdateUI();
        }

        public override void SubscribeToDelegates()
        {
            party.OnStaminaTick += UpdateUI;
            party.OnStaminaChange += UpdateUI;

            party.OnCharacterChange += UpdateCharacter;
        }

        public override void UnsubscribeFromDelegates()
        {
            party.OnStaminaTick -= UpdateUI;
            party.OnStaminaChange -= UpdateUI;

            party.OnCharacterChange -= UpdateCharacter;
        }

        public override void UpdateUI()
        {
            text.text = header + stamina.ResourcePoints + "/" + 
                stamina.ResourceCooldown.CooldownValue;
        }

        void UpdateUI(int change)
        {
            UpdateUI();
        }

        void UpdateCharacter()
        {
            stamina = party.CurrentStamina;

            UpdateUI();
        }
    }
}