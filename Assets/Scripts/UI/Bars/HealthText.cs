using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RPG_Project
{
    public class HealthText : CooldownText, IUIElement
    {
        PartyController party;
        Health health;

        public override void InitUI()
        {
            party = GetComponentInParent<BattleHUD>().Player;
            health = party.Health;

            header = "HP ";

            UpdateUI();
        }

        public override void SubscribeToDelegates()
        {
            party.OnHealthTick += UpdateUI;
            party.OnHealthChange += UpdateUI;
        }

        public override void UnsubscribeFromDelegates()
        {
            party.OnHealthTick -= UpdateUI;
            party.OnHealthChange -= UpdateUI;
        }

        public override void UpdateUI()
        {
            text.text = header + health.ResourcePoints + "/" +
                health.ResourceCooldown.CooldownValue;
        }

        void UpdateUI(int change)
        {
            UpdateUI();
        }
    }
}