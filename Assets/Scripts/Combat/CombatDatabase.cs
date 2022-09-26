using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    [CreateAssetMenu(fileName = "CombatDatabase", menuName = "Database/Combat")]
    public class CombatDatabase : ScriptableObject
    {
        [field: SerializeField] public float WeakMultiplier { get; private set; } = 1.4f;
        [field: SerializeField] public float ResistMultiplier { get; private set; } = 0.7f;

        [field: SerializeField] public float FrontMultiplier { get; private set; } = 0.7f;
        [field: SerializeField] public float BackMultiplier { get; private set; } = 1.4f;

        public int Damage(int basePower)
        {
            return Mathf.Max(basePower, 0);
        }
    }
}