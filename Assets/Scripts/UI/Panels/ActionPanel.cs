using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RPG_Project
{
    public class ActionPanel : MonoBehaviour, IUIElement
    {
        [SerializeField] int index = 0;

        [SerializeField] Text nameText;

        [SerializeField] Text typeText;
        [SerializeField] Text elementText;
        [SerializeField] Text staminaText;
        [SerializeField] Text powerText;

        [SerializeField] Image vignette;

        Color canUse = new Color(.125f, .125f, .125f, 0f);
        Color cantUse = new Color(.125f, .125f, .125f, .5f);

        BattleHUD hud;
        PartyController party;
        Character character;
        ActionData action;

        private void Awake()
        {
            hud = GetComponentInParent<BattleHUD>();
        }

        public void InitUI()
        {
            party = hud.Player;
            character = party.CurrentController.Character;
            action = character.CharData.CombatActions[index];

            nameText.text = action.ActionName;
            typeText.text = action.Type.ToString().ToUpper();
            elementText.text = action.Element.ToString();
            staminaText.text = "SP " + action.StaminaCost;
            powerText.text = "PP " + action.PowerCost;

            vignette.color = canUse;
        }

        public void SubscribeToDelegates()
        {
            party.OnCharacterChange += UpdateCharacter;
        }

        public void UnsubscribeFromDelegates()
        {
            party.OnCharacterChange -= UpdateCharacter;
        }

        public void UpdateUI()
        {

        }

        void UpdateCharacter()
        {
            character = party.CurrentController.Character;
            action = character.CharData.CombatActions[index];

            nameText.text = action.ActionName;
            typeText.text = "PHYS";
            elementText.text = action.Element.ToString();
            staminaText.text = "SP " + action.StaminaCost;
            powerText.text = "PP " + action.PowerCost;

            vignette.color = canUse;
        }

        void UpdateUseable()
        {

        }
    }
}