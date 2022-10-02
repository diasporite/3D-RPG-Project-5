using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class CharInfo : MonoBehaviour
    {
        [SerializeField] HealthBar health;
        [SerializeField] HealthText hText;

        [SerializeField] StaminaBar stamina;
        [SerializeField] StaminaText sText;

        private void Awake()
        {
            health = GetComponentInChildren<HealthBar>();
            hText = GetComponentInChildren<HealthText>();

            stamina = GetComponentInChildren<StaminaBar>();
            sText = GetComponentInChildren<StaminaText>();
        }

        public void InitUI(PartyController party)
        {
            health.InitUI(party);
            hText.InitUI(party);

            stamina.InitUI(party);
            sText.InitUI(party);
        }
    }
}