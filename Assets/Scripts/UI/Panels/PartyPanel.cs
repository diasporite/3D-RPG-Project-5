using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RPG_Project
{
    public class PartyPanel : MonoBehaviour, IUIElement
    {
        PartyController party;
        BattleHUD hud;

        [field: SerializeField] public int Index { get; private set; }

        StaminaBarUI stamina;

        [SerializeField] Text nameText;

        private void Awake()
        {
            stamina = GetComponentInChildren<StaminaBarUI>();

            hud = GetComponentInParent<BattleHUD>();
        }

        public void InitUI()
        {
            party = hud.Player;
            nameText.text = party.PartyMembers[Index].Character.CharName;
        }

        public void SubscribeToDelegates()
        {

        }

        public void UnsubscribeFromDelegates()
        {

        }

        public void UpdateUI()
        {

        }
    }
}