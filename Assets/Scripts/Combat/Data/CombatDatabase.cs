using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    [CreateAssetMenu(fileName = "CombatDatabase", menuName = "Database/Combat")]
    public class CombatDatabase : ScriptableObject
    {
        [field: Header("Damage Multipliers")]
        [field: SerializeField] public float WeakMultiplier { get; private set; } = 1.4f;
        [field: SerializeField] public float ResistMultiplier { get; private set; } = 0.7f;

        [field: SerializeField] public float FrontMultiplier { get; private set; } = 0.7f;
        [field: SerializeField] public float BackMultiplier { get; private set; } = 1.4f;

        [field: Header("Regen")]
        [field: SerializeField] public float HealthRegen { get; private set; } = 1f;
        [field: SerializeField] public float StaminaRegen { get; private set; } = 12f;
        [field: SerializeField] public float EnemyStaminaRegen { get; private set; } = 40f;

        [field: Header("Weight Scaling")]
        [field: SerializeField] public float MinDodgeResist { get; private set; } = 0.1f;
        [field: SerializeField] public float MaxDodgeResist { get; private set; } = 0.5f;

        [field: SerializeField] public float MinGuardResist { get; private set; } = 0.3f;
        [field: SerializeField] public float MaxGuardResist { get; private set; } = 0.7f;

        public int Damage(int basePower)
        {
            return Mathf.Max(basePower, 0);
        }

        public float DodgeReduction(int weight)
        {
            weight = Mathf.Clamp(weight, 0, 255);
            float t = (float)weight / 255;

            return Mathf.Lerp(MinDodgeResist, MaxDodgeResist, 1 - t);
        }

        public float GuardReduction(int weight)
        {
            weight = Mathf.Clamp(weight, 0, 255);
            float t = (float)weight / 255;

            return Mathf.Lerp(MinGuardResist, MaxGuardResist, t);
        }
    }
}