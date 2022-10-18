using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    [CreateAssetMenu(fileName = "New Projectile", menuName = "Combat/Action/Projectile")]
    public class ProjectileActionData : ActionData
    {
        [field: SerializeField] public float[] SpawnNormTimes { get; private set; }
    }
}