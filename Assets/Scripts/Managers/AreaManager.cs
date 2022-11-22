using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class AreaManager : MonoBehaviour
    {
        [field: SerializeField] public string AreaName { get; private set; } = "Area 1";

        public IEnumerator InitAreaCo()
        {
            print("init");

            var player = FindObjectOfType<PlayerSpawner>().Spawn();

            if (player != null) GameManager.instance.Player = player;

            yield return new WaitForSecondsRealtime(1f);

            var eSpawners = FindObjectsOfType<EnemySpawner>();

            foreach (var s in eSpawners) s.Spawn();

            yield return new WaitForSecondsRealtime(1f);
        }
    }
}