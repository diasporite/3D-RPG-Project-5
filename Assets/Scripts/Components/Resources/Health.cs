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

        protected override void Start()
        {
            baseSpeed = GameManager.instance.Combat.HealthRegen;
            ResourceCooldown = new Cooldown(150f, baseSpeed, 150f);
        }

        protected override void UpdateUI()
        {
            party.InvokeHealthTick();
        }
    }
}