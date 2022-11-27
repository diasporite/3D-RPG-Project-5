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
        Character character;

        [field: SerializeField] public int Index { get; private set; }

        StaminaBarUI stamina;

        [SerializeField] Text nameText;
        [SerializeField] Text elementText;

        private void Awake()
        {
            stamina = GetComponentInChildren<StaminaBarUI>();

            hud = GetComponentInParent<BattleHUD>();
        }

        public void InitUI()
        {
            party = hud.Player;
            character = party.PartyMembers[Index].Character;

            nameText.text = character.CharName;
            elementText.text = character.CharData.ElementString;
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