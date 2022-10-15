using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class Health : Resource
    {
        protected override void Awake()
        {
            party = GetComponent<PartyController>();
        }

        public override void Init()
        {
            baseSpeed = party.CurrentController.Character.CharData.HealthRegen;

            var hp = party.Hp;
            ResourceCooldown = new Cooldown(hp, baseSpeed, hp);
        }

        protected override void UpdateUI()
        {
            party.InvokeHealthTick();
        }
    }
}