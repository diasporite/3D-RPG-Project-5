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
            var pp = Mathf.RoundToInt(2.56f * character.CharData.Power);
            ResourceCooldown = new Cooldown(pp, 0, pp);
        }

        protected override void UpdateUI()
        {
            party.InvokePowerTick();
        }
    }
}