using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    [CreateAssetMenu(fileName = "New Projectile", menuName = "Combat/Actions/Projectile")]
    public class ProjectileActionData : ActionData
    {
        [field: SerializeField] public Projectile ProjectilePrefab { get; private set; }

        [field: SerializeField] public float[] SpawnNormTimes { get; private set; }
        [field: Tooltip("0 is perfectly straight, 1 is perfect homing on target")]
        [field: Range(0f, 1f)]
        [field: SerializeField] public float ProjectileTracking { get; private set; } = 0f;
        [field: SerializeField] public bool UseGravity { get; private set; } = false;
        [field: SerializeField] public float Lifetime { get; private set; } = 1f;
        [field: SerializeField] public float Speed { get; private set; } = 20f;
    }
}