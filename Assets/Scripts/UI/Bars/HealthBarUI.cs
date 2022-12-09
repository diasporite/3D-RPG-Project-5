using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public enum ResourceBarType
    {
        Battle = 0,
        Enemy = 1,
    }

    public class HealthBarUI : CooldownBar, IUIElement
    {
        [SerializeField] ResourceBarType type;

        Cooldown delayTimer;

        [SerializeField] PartyController player;
        [SerializeField] Health health;

        BattleHUD hud;
        EnemyStats stats;

        private void Awake()
        {
            hud = GetComponentInParent<BattleHUD>();
            stats = GetComponentInParent<EnemyStats>();

            delayTimer = new Cooldown(updateDelay, 1f, updateDelay);
        }

        public void InitUI()
        {
            if (type == ResourceBarType.Battle)
                player = hud.Player;
            else player = stats.Party;

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
            if (player != null)
                player.OnHealthTick += UpdateUI;
        }

        public void UnsubscribeFromDelegates()
        {
            if (player != null)
                player.OnHealthTick -= UpdateUI;
        }
    }
}