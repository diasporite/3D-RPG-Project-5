using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class PartyInfo : MonoBehaviour
    {
        PartyPanel[] panels;

        private void Awake()
        {
            panels = GetComponentsInChildren<PartyPanel>();
        }

        public void InitUI(PartyController party)
        {
            for (int i = 0; i < panels.Length; i++)
                panels[i].InitUI(party, i);
        }
    }
}