using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class AttackActionData : ActionData
    {
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