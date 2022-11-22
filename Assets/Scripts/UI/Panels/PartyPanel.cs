using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class PartyPanel : MonoBehaviour
    {
        PartyController party;
        BattleHUD hud;

        [SerializeField] int index;

        [SerializeField] StaminaBarUI stamina;

        private void Awake()
        {
            stamina = GetComponentInChildren<StaminaBarUI>();

            hud = GetComponentInParent<BattleHUD>();
        }

    }
}