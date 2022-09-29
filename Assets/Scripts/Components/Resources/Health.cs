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

            baseSpeed = 1f;
            ResourceCooldown = new Cooldown(100f, baseSpeed, 100f);
        }

        protected override void UpdateUI()
        {
            party.InvokeHealthTick();
        }
    }
}