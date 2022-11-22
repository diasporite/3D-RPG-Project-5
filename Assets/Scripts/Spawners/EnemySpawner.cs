﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class EnemySpawner : Spawner
    {
        [SerializeField] float timeToRespawn = 20f;

        [SerializeField] SpawnData[] spawnData;

        Transform enemyHolder;

        protected override void Awake()
        {
            base.Awake();

            enemyHolder = GameObject.Find("Enemies").transform;
        }

        public override void Spawn()
        {
            print("spawn enemy");

            GameObject pObj = Instantiate(PartyPrefab.gameObject, transform.position, 
                Quaternion.identity, enemyHolder) as GameObject;

            var party = pObj.GetComponent<PartyController>();

            party.InstantiateParty(spawnData);
        }
    }
}