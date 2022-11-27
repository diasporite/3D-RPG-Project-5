using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class Stamina : Resource
    {
        public bool Charged { get; set; }

        float pauseTime;

        Cooldown PauseTimer;

        public override void Init()
        {
            Charged = false;

            if (party.IsPlayer)
            {
                pauseTime = GameManager.instance.CombatData.PlayerStaminaPause;
                baseSpeed = GameManager.instance.CombatData.StaminaRegen;
            }
            else
            {
                pauseTime = GameManager.instance.CombatData.EnemyStaminaPause;
                baseSpeed = GameManager.instance.CombatData.EnemyStaminaRegen;
            }

            var sp = party.Sp;
            ResourceCooldown = new Cooldown(sp, baseSpeed, sp);
            PauseTimer = new Cooldown(pauseTime, 1f, pauseTime);
        }

        public override void Tick()
        {
            if (!PauseTimer.Full) PauseTimer.Tick();
            else ResourceCooldown.Tick();

            if (Full) Charged = true;

            UpdateUI();
        }

        protected override void UpdateUI()
        {
            party.InvokeStaminaTick();
        }

        public void Pause()
        {
            if (PauseTimer.Full) PauseTimer.Reset();
        }
    }
}