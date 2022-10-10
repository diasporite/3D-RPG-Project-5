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
        }

        public override void Init()
        {
            Charged = false;

            if (party.IsPlayer) baseSpeed = GameManager.instance.Combat.StaminaRegen;
            else baseSpeed = GameManager.instance.Combat.EnemyStaminaRegen;

            ResourceCooldown = new Cooldown(100f, baseSpeed, Random.Range(20f, 80f));
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