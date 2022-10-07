using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    [System.Serializable]
    public class AISequence
    {
        [field: SerializeField] public int Weight = 1;
        [field: SerializeField] public int[] ActionIndices;
    }

    [CreateAssetMenu(fileName = "New AI Pattern", menuName = "Combat/AI")]
    public class EnemyAIPattern : ScriptableObject
    {
        [field: SerializeField] public float MinDelay { get; private set; } = 2f;
        [field: SerializeField] public AISequence[] AttackPatterns { get; private set; }

        public int[] RandomPattern => AttackPatterns[Random.Range(0, 
            AttackPatterns.Length)].ActionIndices;
    }
}