using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class StaminaBarUI : CooldownBar, IUIElement
    {
        [SerializeField] ResourceBarType type;

        Cooldown delayTimer;

        [SerializeField] protected PartyController player;
        [SerializeField] protected Stamina stamina;

        protected BattleHUD hud;
        EnemyStats stats;

        protected virtual void Awake()
        {
            hud = GetComponentInParent<BattleHUD>();
            stats = GetComponentInParent<EnemyStats>();

            delayTimer = new Cooldown(updateDelay, 1f, updateDelay);
        }

        public virtual void InitUI()
        {
            if (type == ResourceBarType.Battle)
                player = hud.Player;
            else player = stats.Party;

            stamina = player.Stamina;

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
                if (!delayTimer.Full)
                    delayTimer.TickUnscaled();
                else
                {

                    if (FillShadow.fillAmount != stamina.ResourceFraction)
                        FillShadow.fillAmount = Mathf.MoveTowards(FillShadow.fillAmount, 
                            stamina.ResourceFraction, updateSpeed * Time.unscaledDeltaTime);
                }
            }
        }

        public virtual void SubscribeToDelegates()
        {
            player.OnStaminaTick += UpdateUI;
        }

        public virtual void UnsubscribeFromDelegates()
        {
            player.OnStaminaTick -= UpdateUI;

        }
    }
}