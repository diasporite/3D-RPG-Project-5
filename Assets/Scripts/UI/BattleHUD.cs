using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class BattleHUD : MonoBehaviour
    {
        [field: SerializeField] public CharInfo CharInfo { get; private set; }
        [field: SerializeField] public PartyInfo PartyInfo { get; private set; }
        [field: SerializeField] public ActionInfo ActionInfo { get; private set; }
        
        [field: SerializeField] public Reticle Reticle { get; private set; }

        private void Awake()
        {
            CharInfo = GetComponentInChildren<CharInfo>();
            PartyInfo = GetComponentInChildren<PartyInfo>();
            ActionInfo = GetComponentInChildren<ActionInfo>();

            Reticle = FindObjectOfType<Reticle>();
        }

        public void InitHUD(PartyController party)
        {
            CharInfo.InitUI(party);
            PartyInfo.InitUI(party);
            ActionInfo.InitUI(party);

            Reticle.Init(party);
        }
    }
}