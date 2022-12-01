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

        [SerializeField] Image[] elementIcons;

        private void Awake()
        {
            hud = GetComponentInParent<BattleHUD>();
        }

        public void InitUI()
        {
            party = hud.Player;
            character = party.PartyMembers[Index].Character;

            SetElementIcon(0);
            SetElementIcon(1);
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

        void SetElementIcon(int index)
        {
            var element = GameManager.instance.CombatData.GetElement(character.Elements[index]);

            elementIcons[index].sprite = element.Icon;
            if (element.Id != ElementID.Typeless)
                elementIcons[index].color = new Color(1f, 1f, 1f, 1f);
            else elementIcons[index].color = new Color(1f, 1f, 1f, 0f);
        }
    }
}