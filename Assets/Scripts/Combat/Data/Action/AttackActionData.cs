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

        public DamageInfo Damage(Character character)
        {
            return IsDamaging ? new DamageInfo(character, this) : null;
        }
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

        public Vector3 Knockback(Transform instigator)
        {
            return HasKnockback ? - Force * (Direction.x * instigator.forward + 
                Direction.y * instigator.up) : Vector3.zero;
        }
    }

    public class AttackActionData : ActionData
    {
        [field: SerializeField] public float AngleToForward { get; private set; } = 0f;

        [field: Header("Damage")]
        [field: SerializeField] public DamageData Damage { get; private set; }

        [field: Header("Knockback")]
        [field: SerializeField] public KnockbackData Knockback { get; private set; }

        public virtual void TriggerAttack(float normTime, Hitbox[] hitboxes, 
            ProjectileWeapon[] weapons)
        {

        }

        public override DamageInfo GetDamageInfo(Character character)
        {
            return Damage.IsDamaging ? new DamageInfo(character, Damage) : null;
        }
    }
}