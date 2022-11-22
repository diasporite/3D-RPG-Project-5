using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RPG_Project
{
    public class PlayerSpawner : Spawner
    {
        PlayerPartyDatabase playerParty;

        protected override void Awake()
        {
            base.Awake();

            
        }

        public override void Spawn()
        {
            // Check if player exists
            if (GameManager.instance.Player != null) return;

            // If not spawn player (look for way to move party into Persistent scene)
            print("spawn player");

            GameObject pObj = Instantiate(PartyPrefab.gameObject, transform.position,
                Quaternion.identity) as GameObject;
            pObj.name = "PlayerController";

            var party = pObj.GetComponent<PartyController>();

            //party.InstantiateParty(GameManager.instance.CharData.GetCharacters("Capsule", "Capsule", "Capsule"));
            party.InstantiateParty(GameManager.instance.CharData.GetCharacters("Mutant"));

            GameManager.instance.Player = party;
        }
    }
}