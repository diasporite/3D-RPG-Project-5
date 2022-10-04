using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class ActionInfo : MonoBehaviour
    {
        [SerializeField] PowerBar power;
        [SerializeField] PowerText pText;

        private void Awake()
        {
            power = GetComponentInChildren<PowerBar>();
            pText = GetComponentInChildren<PowerText>();
        }

        public void InitUI(PartyController party)
        {
            power.InitUI(party);
            pText.InitUI(party);
        }
    }
}