using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class StaminaBarUI : CooldownBar, IUIElement
    {
        float updateDelay = 0.8f;
        float updateSpeed = 0.6f;
        float shadowThreshold = 0.04f;

        [SerializeField] Color charging = new Color(.753f, .753f, .753f);
        [SerializeField] Color charged = new Color(.125f, .753f, .125f);

        Cooldown delayTimer;

        [SerializeField] PartyController player;
        [SerializeField] Stamina stamina;

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

            if (stamina.Charged) Fill.color = charged;
            else Fill.color = charging;

            if (Mathf.Abs(stamina.ChangeFraction) < shadowThreshold)
            {
                if (FillShadow.fillAmount != stamina.ResourceFraction)
                    FillShadow.fillAmount = stamina.ResourceFraction;
            }
            else
            {
                if (!delayTimer.Full) delayTimer.TickUnscaled();
                else
                {

                    if (FillShadow.fillAmount != stamina.ResourceFraction)
                        FillShadow.fillAmount = Mathf.MoveTowards(FillShadow.fillAmount, 
                            stamina.ResourceFraction, updateSpeed * Time.unscaledDeltaTime);
                }
            }
        }

        public void SubscribeToDelegates()
        {
            player.OnHealthTick += UpdateUI;
            player.OnCharacterChange += UpdateStamina;
        }

        public void UnsubscribeFromDelegates()
        {
            player.OnHealthTick -= UpdateUI;
            player.OnCharacterChange -= UpdateStamina;
        }

        void UpdateStamina()
        {
            stamina = player.CurrentStamina;

            Fill.fillAmount = stamina.ResourceFraction;
            FillShadow.fillAmount = stamina.ResourceFraction;
        }
    }
}