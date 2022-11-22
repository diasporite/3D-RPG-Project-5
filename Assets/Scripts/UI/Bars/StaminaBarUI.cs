using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class StaminaBarUI : CooldownBar, IUIElement
    {
        [SerializeField] float updateDelay = 0.8f;
        [SerializeField] float updateSpeed = 0.6f;
        [SerializeField] float shadowThreshold = 0.04f;

        Cooldown delayTimer;

        PartyController player;
        Stamina stamina;

        BattleHUD hud;

        private void Awake()
        {
            hud = GetComponentInParent<BattleHUD>();

            delayTimer = new Cooldown(updateDelay, 1f, updateDelay);
        }

        public void InitUI()
        {
            player = hud.Player;
            stamina = player.CurrentController.Stamina;

            Fill.fillAmount = stamina.ResourceFraction;
            FillShadow.fillAmount = stamina.ResourceFraction;
        }

        public void UpdateUI()
        {
            if (Fill.fillAmount != stamina.ResourceFraction)
                Fill.fillAmount = stamina.ResourceFraction;

            if (Mathf.Abs(stamina.ChangeFraction) < shadowThreshold)
            {
                if (FillShadow.fillAmount != stamina.ResourceFraction)
                    FillShadow.fillAmount = stamina.ResourceFraction;
            }
            else
            {
                if (!delayTimer.Full) delayTimer.Tick();
                else
                {

                    if (FillShadow.fillAmount != stamina.ResourceFraction)
                        FillShadow.fillAmount = Mathf.MoveTowards(FillShadow.fillAmount, stamina.ResourceFraction, updateSpeed * Time.deltaTime);
                }
            }
        }

        public void SubscribeToDelegates()
        {
            player.OnHealthTick += UpdateUI;
        }

        public void UnsubscribeFromDelegates()
        {
            player.OnHealthTick -= UpdateUI;
        }
    }
}