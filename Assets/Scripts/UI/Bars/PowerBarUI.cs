using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class PowerBarUI : CooldownBar, IUIElement
    {
        Cooldown delayTimer;

        [SerializeField] bool forCurrentCharacter;
        [SerializeField] int index;

        [SerializeField] PartyController player;
        [SerializeField] Power power;

        BattleHUD hud;

        private void Awake()
        {
            hud = GetComponentInParent<BattleHUD>();

            delayTimer = new Cooldown(updateDelay, 1f, updateDelay);

            updateSpeed = 0.3f;
            shadowThreshold = 0.005f;
        }

        public void InitUI()
        {
            player = hud.Player;

            if (forCurrentCharacter)
                power = player.CurrentController.Power;
            else power = player.PartyMembers[index].Power;

            Fill.fillAmount = power.ResourceFraction;
            FillShadow.fillAmount = power.ResourceFraction;
        }

        public void UpdateUI()
        {
            if (Fill.fillAmount != power.ResourceFraction)
                Fill.fillAmount = power.ResourceFraction;

            if (Mathf.Abs(power.ChangeFraction) < shadowThreshold)
            {
                if (FillShadow.fillAmount != power.ResourceFraction)
                    FillShadow.fillAmount = power.ResourceFraction;
            }
            else
            {
                if (!delayTimer.Full)
                    delayTimer.TickUnscaled();
                else
                {

                    if (FillShadow.fillAmount != power.ResourceFraction)
                        FillShadow.fillAmount = Mathf.MoveTowards(FillShadow.fillAmount,
                            power.ResourceFraction, updateSpeed * Time.unscaledDeltaTime);
                }
            }
        }

        public void SubscribeToDelegates()
        {
            player.OnPowerTick += UpdateUI;

            if (forCurrentCharacter)
                player.OnPowerTick += UpdateCharacter;
        }

        public void UnsubscribeFromDelegates()
        {
            player.OnPowerTick -= UpdateUI;

            if (forCurrentCharacter)
                player.OnPowerTick -= UpdateCharacter;
        }

        void UpdateCharacter()
        {
            power = player.CurrentController.Power;

            Fill.fillAmount = power.ResourceFraction;
            FillShadow.fillAmount = power.ResourceFraction;
        }
    }
}