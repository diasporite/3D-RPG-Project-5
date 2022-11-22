using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    [CreateAssetMenu(fileName = "PlayerPartyDatabase", menuName = "Database/Player Party")]
    public class PlayerPartyDatabase : ScriptableObject
    {
        [field: SerializeField] public SpawnData[] Characters { get; private set; }

        [field: SerializeField] public SpawnData[] CurrentParty { get; private set; }

        int partyCap = 4;
    }
}