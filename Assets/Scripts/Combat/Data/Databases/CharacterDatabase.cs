using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    [CreateAssetMenu(fileName = "CharacterDatabase", menuName = "Database/Character")]
    public class CharacterDatabase : ScriptableObject
    {
        [field: SerializeField] public CharData[] Characters { get; private set; }

        Dictionary<string, CharData> database = new Dictionary<string, CharData>();

        List<CharData> query = new List<CharData>();

        public void BuildDatabase()
        {
            foreach (var c in Characters)
                if (!database.ContainsKey(c.CharName))
                    database.Add(c.CharName, c);
        }

        public CharData GetCharacter(string name)
        {
            if (database.ContainsKey(name))
                return database[name];

            return database["Capsule"];
        }

        public CharData[] GetCharacters(params string[] names)
        {
            query.Clear();

            foreach(var n in names)
                if (database.ContainsKey(n))
                    query.Add(database[n]);

            return query.ToArray();
        }
    }
}