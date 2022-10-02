using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class PartyPanel : MonoBehaviour, IUIElement
    {
        PartyController party;

        [SerializeField] int index;

        [SerializeField] HealthBar health;
        [SerializeField] StaminaBar stamina;

        private void Awake()
        {
            health = GetComponentInChildren<HealthBar>();
            stamina = GetComponentInChildren<StaminaBar>();
        }

        private void OnEnable()
        {
            if (party != null) SubscribeToDelegates();
        }

        private void OnDisable()
        {
            UnsubscribeFromDelegates();
        }

        public void InitUI(PartyController party, int index)
        {
            this.party = party;

            this.index = index;

            health.InitUI(party, index);
            stamina.InitUI(party, index);

            SubscribeToDelegates();
        }

        public void SubscribeToDelegates()
        {
            party.OnCharacterChange += UpdateCharacter;
        }

        public void UnsubscribeFromDelegates()
        {
            party.OnCharacterChange -= UpdateCharacter;
        }

        void UpdateCharacter()
        {

        }

        void UpdateUI()
        {

        }
    }
}