using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class BattleHUD : MonoBehaviour
    {
        [field: SerializeField] public HealthBar Health { get; private set; }
        [field: SerializeField] public StaminaBar Stamina { get; private set; }

        private void Awake()
        {
            Health = GetComponentInChildren<HealthBar>();
            Stamina = GetComponentInChildren<StaminaBar>();
        }

        public void InitHUD(PartyController party)
        {
            Health.InitUI(party);
            Stamina.InitUI(party);
        }
    }
}