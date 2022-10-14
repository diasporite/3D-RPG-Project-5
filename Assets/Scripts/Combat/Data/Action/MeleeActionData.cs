using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    [System.Serializable]
    public class HitboxWindow
    {
        [field: SerializeField] public float EnableHitbox { get; private set; } = 0.5f;
        [field: SerializeField] public float DisableHitbox { get; private set; } = 0.6f;
    }

    [CreateAssetMenu(fileName = "New Melee", menuName = "Combat/Actions/Melee")]
    public class MeleeActionData : ActionData
    {
        [field: Header("Damage")]
        [field: SerializeField] public int BasePower { get; private set; } = 30;

        [field: Header("Knockback")]
        [field: SerializeField] public int Force { get; private set; } = 5;

        public override DamageInfo Damage(Character character)
        {
            return new DamageInfo(character, BasePower);
        }
    }
}