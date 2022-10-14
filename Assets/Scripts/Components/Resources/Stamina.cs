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

        protected override void Awake()
        {
            base.Awake();
        }

        public override void Init()
        {
            Charged = false;

            if (party.IsPlayer)
                pauseTime = GameManager.instance.Combat.PlayerStaminaPause;
            else
                pauseTime = GameManager.instance.Combat.EnemyStaminaPause;

            baseSpeed = character.CharData.StaminaRegen;

            var sp = 2f * character.CharData.Stamina;
            ResourceCooldown = new Cooldown(sp, baseSpeed, Random.Range(0.2f, 0.8f) * sp);
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