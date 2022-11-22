using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class AreaManager : MonoBehaviour
    {
        public bool IsInitialised { get; private set; } = false;

        [field: SerializeField] public string AreaName { get; private set; } = "Area 1";

        [Range(0.5f, 5f)]
        [SerializeField] float buffer = 2f;

        private void Awake()
        {

        }

        public IEnumerator InitAreaCo()
        {
            print("init");

            yield return new WaitForSeconds(0.05f);

            var eSpawners = FindObjectsOfType<EnemySpawner>();

            foreach (var s in eSpawners) s.Spawn();

            FindObjectOfType<PlayerSpawner>().Spawn();

            yield return new WaitForSeconds(0.5f);

            IsInitialised = true;
        }
    }
}