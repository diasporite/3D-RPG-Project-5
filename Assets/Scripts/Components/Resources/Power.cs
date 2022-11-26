using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class Power : Resource
    {
        protected override void Awake()
        {
            party = GetComponentInParent<PartyController>();
            character = GetComponent<Character>();
        }

        public override void Init()
        {
            baseSpeed = character.CharData.PowerRegen;

            var pp = Mathf.RoundToInt(5.76f * character.CharData.Power);
            ResourceCooldown = new Cooldown(pp, baseSpeed, pp);
        }

        protected override void UpdateUI()
        {
            party.InvokePowerTick();
        }
    }
}