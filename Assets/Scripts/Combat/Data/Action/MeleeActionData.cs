using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    [System.Serializable]
    public class DamageData
    {
        [field: SerializeField] public int HealthDamage { get; private set; }
        [field: SerializeField] public int StaminaDamage { get; private set; }
    }

    [System.Serializable]
    public class KnockbackData
    {
        [field: SerializeField] public float Force { get; private set; }
    }

    [CreateAssetMenu(fileName = "New Melee", menuName = "Combat/Actions/Melee")]
    public class MeleeActionData : ActionData
    {
        [field: Header("Damage")]
        [field: SerializeField] public DamageData Damage { get; private set; }

        [field: Header("Knockback")]
        [field: SerializeField] public KnockbackData Knockback { get; private set; }

        public override DamageInfo GetDamageInfo(Character character)
        {
            return new DamageInfo(character, Damage.HealthDamage);
        }
    }
}