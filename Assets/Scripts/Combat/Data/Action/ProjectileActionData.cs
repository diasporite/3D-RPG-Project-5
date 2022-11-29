﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    [CreateAssetMenu(fileName = "New Projectile", menuName = "Combat/Actions/Projectile")]
    public class ProjectileActionData : AttackActionData
    {
        [field: SerializeField] public Projectile ProjectilePrefab { get; private set; }

        [field: Header("Damage")]
        [field: SerializeField] public float[] FireNormTimes { get; private set; }

        [field: SerializeField] public bool IsPiercing { get; private set; } = false;
        [field: Tooltip("Strength of attack decreases with (normalized) distance.")]
        [field: SerializeField] public AnimationCurve StrengthCurve { get; private set; }

        [field: Header("Movement")]
        [field: Tooltip("0 is perfectly straight, 1 is perfect homing on target")]
        [field: Range(0f, 1f)]
        [field: SerializeField] public float ProjectileTracking { get; private set; } = 0f;
        [field: Tooltip("Gravity = 19.62 at 1.")]
        [field: Range(0f, 1f)]
        [field: SerializeField] public float GravityStrength { get; private set; } = 0f;
        [field: SerializeField] public float Distance { get; private set; } = 10f;
        [field: SerializeField] public float Speed { get; private set; } = 20f;
        [field: SerializeField] public float AngularSpeed { get; private set; } = 360f;

        public override void TriggerAttack(float normTime, Hitbox[] hitboxes, 
            ProjectileWeapon[] weapons)
        {
            foreach (var f in FireNormTimes)
                if (Mathf.Abs(normTime - f) <= 0.01f)
                    weapons[HitboxIndex].Fire(this);
        }
    }
}