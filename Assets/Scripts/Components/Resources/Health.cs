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
            if (party.IsPlayer) baseSpeed = GameManager.instance.Combat.HealthRegen;
            else baseSpeed = 0;

            ResourceCooldown = new Cooldown(150f, baseSpeed, 150f);
        }

        protected override void UpdateUI()
        {
            party.InvokeHealthTick();
        }
    }
}