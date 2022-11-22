using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    [System.Serializable]
    public class SpawnData
    {
        [field: SerializeField] public string CharName { get; private set; }

        public CharData CharData => GameManager.instance.CharData.GetCharacter(CharName);
    }

    public class Spawner : MonoBehaviour
    {
        [field: SerializeField] public PartyController PartyPrefab { get; private set; }

        protected CharacterDatabase data;

        protected virtual void Awake()
        {
            transform.position = new Vector3(Mathf.RoundToInt(transform.position.x), 
                transform.position.y, Mathf.RoundToInt(transform.position.z));
        }

        private void Start()
        {
            data = GameManager.instance.CharData;
        }

        public virtual PartyController Spawn()
        {
            return null;
        }
    }
}