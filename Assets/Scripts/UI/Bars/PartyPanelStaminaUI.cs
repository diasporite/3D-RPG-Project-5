using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class PartyPanelStaminaUI : StaminaBarUI
    {
        PartyPanel panel;
        int index;

        protected override void Awake()
        {
            base.Awake();

            panel = GetComponentInParent<PartyPanel>();
        }

        public override void InitUI()
        {
            player = hud.Player;
            index = panel.Index;
            stamina = player.PartyMembers[index].Stamina;

            Fill.fillAmount = stamina.ResourceFraction;
            FillShadow.fillAmount = stamina.ResourceFraction;
        }

        public override void SubscribeToDelegates()
        {
            player.OnHealthTick += UpdateUI;
        }

        public override void UnsubscribeFromDelegates()
        {
            player.OnHealthTick -= UpdateUI;
        }
    }
}