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

        protected override void Start()
        {
            Charged = false;

            baseSpeed = GameManager.instance.Combat.StaminaRegen;
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