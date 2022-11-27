using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public enum ElementID
    {
        Typeless = 0,

        Neutral = 1,
    }

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
        [field: SerializeField] public float PlayerStaminaPause { get; private set; } = 0.5f;
        [field: SerializeField] public float EnemyStaminaPause { get; private set; } = 1.5f;

        [field: Header("Weight Scaling")]
        [field: SerializeField] public float MinResist { get; private set; } = 0.3f;
        [field: SerializeField] public float MaxResist { get; private set; } = 0.7f;

        [field: Header("Element Database")]
        [field: SerializeField] public ElementData[] Elements { get; private set; }

        Dictionary<ElementID, ElementData> elementDatabase = 
            new Dictionary<ElementID, ElementData>();

        public void BuildDatabase()
        {
            foreach (var e in Elements)
                if (!elementDatabase.ContainsKey(e.Id))
                    elementDatabase.Add(e.Id, e);
        }

        public int Damage(int basePower)
        {
            return Mathf.Max(basePower, 0);
        }

        public float DodgeReduction(int weight)
        {
            weight = Mathf.Clamp(weight, 0, 255);
            float t = (float)weight / 255;

            return Mathf.Lerp(MinResist, MaxResist, 1 - t);
        }

        public float GuardReduction(int weight)
        {
            weight = Mathf.Clamp(weight, 0, 255);
            float t = (float)weight / 255;

            return Mathf.Lerp(MinResist, MaxResist, t);
        }
    }
}