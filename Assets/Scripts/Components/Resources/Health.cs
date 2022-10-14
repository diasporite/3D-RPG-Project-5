using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class Health : Resource
    {
        protected override void Awake()
        {
            base.Awake();
        }

        public override void Init()
        {
            baseSpeed = character.CharData.HealthRegen;

            var hp = 3f * character.CharData.Health;
            ResourceCooldown = new Cooldown(hp, baseSpeed, hp);
        }

        protected override void UpdateUI()
        {
            party.InvokeHealthTick();
        }
    }
}