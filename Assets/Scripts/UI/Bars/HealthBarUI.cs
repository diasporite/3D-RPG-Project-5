using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class HealthBarUI : CooldownBar, IUIElement
    {
        float updateDelay = 0.8f;
        float updateSpeed = 0.6f;
        float shadowThreshold = 0.04f;

        Cooldown delayTimer;

        [SerializeField] PartyController player;
        [SerializeField] Health health;

        BattleHUD hud;

        private void Awake()
        {
            hud = GetComponentInParent<BattleHUD>();

            delayTimer = new Cooldown(updateDelay, 1f, updateDelay);
        }

        public void InitUI()
        {
            player = hud.Player;
            health = player.Health;

            Fill.fillAmount = health.ResourceFraction;
            FillShadow.fillAmount = health.ResourceFraction;
        }

        public void UpdateUI()
        {
            if (Fill.fillAmount != health.ResourceFraction)
                Fill.fillAmount = health.ResourceFraction;

            if (Mathf.Abs(health.ChangeFraction) < shadowThreshold)
            {
                if (FillShadow.fillAmount != health.ResourceFraction)
                    FillShadow.fillAmount = health.ResourceFraction;
            }
            else
            {
                if (!delayTimer.Full)
                    delayTimer.TickUnscaled();
                else
                {

                    if (FillShadow.fillAmount != health.ResourceFraction)
                        FillShadow.fillAmount = Mathf.MoveTowards(FillShadow.fillAmount,
                            health.ResourceFraction, updateSpeed * Time.unscaledDeltaTime);
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