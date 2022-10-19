using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    [System.Serializable]
    public class DamageData
    {
        [field: SerializeField] public bool IsDamaging { get; private set; } = true;

        [field: SerializeField] public int HealthDamage { get; private set; } = 0;
        [field: SerializeField] public int StaminaDamage { get; private set; } = 0;
    }

    [System.Serializable]
    public class KnockbackData
    {
        [field: SerializeField] public bool HasKnockback { get; private set; } = true;

        [field: SerializeField] public bool Interrupts { get; private set; } = false;
        [field: SerializeField] public float Force { get; private set; } = 0f;
        [field: Tooltip("From side view, facing right, relative to attacker" +
            " - x is forward, y is upward.")]
        [field: SerializeField] public Vector2 Direction { get; private set; }
    }

    [CreateAssetMenu(fileName = "New Melee", menuName = "Combat/Actions/Melee")]
    public class MeleeActionData : AttackActionData
    {
        public override void TriggerAttack(float normTime, Hitbox[] hitboxes, 
            ProjectileWeapon[] weapons)
        {
            hitboxes[HitboxIndex].gameObject.SetActive(IsHitDetectorActive(normTime));
        }

        public override bool IsHitDetectorActive(float normTime)
        {
            foreach (var w in Windows)
            {
                if (normTime >= w.EnableHitbox &&
                    normTime <= w.DisableHitbox) return true;
            }

            return false;
        }
    }
}