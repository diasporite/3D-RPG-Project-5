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

        protected override void Start()
        {
            ResourceCooldown = new Cooldown(128f, 0, 128f);
        }

        protected override void UpdateUI()
        {
            party.InvokePowerTick();
        }
    }
}