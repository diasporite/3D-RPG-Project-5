using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class Power : Resource
    {
        protected override void Awake()
        {
            base.Awake();
        }

        public override void Init()
        {
            baseSpeed = character.CharData.PowerRegen;

            var pp = Mathf.RoundToInt(7.68f * character.CharData.Power);
            ResourceCooldown = new Cooldown(pp, baseSpeed, pp);
        }

        protected override void UpdateUI()
        {
            party.InvokePowerTick();
        }
    }
}