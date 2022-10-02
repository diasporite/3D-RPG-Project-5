using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class BattleHUD : MonoBehaviour
    {
        [field: SerializeField] public CharInfo CharInfo { get; private set; }
        [field: SerializeField] public PartyInfo PartyInfo { get; private set; }

        private void Awake()
        {
            CharInfo = GetComponentInChildren<CharInfo>();
            PartyInfo = GetComponentInChildren<PartyInfo>();
        }

        public void InitHUD(PartyController party)
        {
            CharInfo.InitUI(party);
            PartyInfo.InitUI(party);
        }
    }
}