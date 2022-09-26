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

            ResourceCooldown = new Cooldown(100f, 1f, 100f);
        }

        protected override void UpdateUI()
        {
            party.InvokeHealthTick();
        }
    }
}