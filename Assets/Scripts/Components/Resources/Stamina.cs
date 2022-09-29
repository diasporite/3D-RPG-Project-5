using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class Stamina : Resource
    {
        public bool Charged { get; set; }

        protected override void Awake()
        {
            base.Awake();

            baseSpeed = 15f;
            ResourceCooldown = new Cooldown(100f, baseSpeed, 100f);
        }

        public override void Tick()
        {
            ResourceCooldown.Tick();

            if (Full) Charged = true;

            UpdateUI();
        }

        protected override void UpdateUI()
        {
            party.InvokeStaminaTick();
        }
    }
}