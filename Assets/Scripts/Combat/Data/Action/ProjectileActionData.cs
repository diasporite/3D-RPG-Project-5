using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    [CreateAssetMenu(fileName = "New Projectile", menuName = "Combat/Actions/Projectile")]
    public class ProjectileActionData : AttackActionData
    {
        [field: Header("Projectile Data")]
        [field: SerializeField] public Projectile ProjectilePrefab { get; private set; }

        [field: SerializeField] public float[] FireNormTimes { get; private set; }

        [field: SerializeField] public bool IsPiercing { get; private set; } = false;

        [field: Tooltip("0 is perfectly straight, 1 is perfect homing on target")]
        [field: Range(0f, 1f)]
        [field: SerializeField] public float ProjectileTracking { get; private set; } = 0f;
        [field: Tooltip("Gravity = 19.62 at 1.")]
        [field: Range(0f, 1f)]
        [field: SerializeField] public float GravityStrength { get; private set; } = 0f;
        [field: SerializeField] public float Lifetime { get; private set; } = 1f;
        [field: SerializeField] public float Speed { get; private set; } = 20f;

        public override void TriggerAttack(float normTime, Hitbox[] hitboxes, 
            ProjectileWeapon[] weapons)
        {
            foreach (var f in FireNormTimes)
                if (Mathf.Abs(normTime - f) <= 0.01f)
                    weapons[HitboxIndex].Fire(this);
        }
    }
}