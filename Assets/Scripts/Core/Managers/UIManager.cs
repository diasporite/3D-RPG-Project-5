using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RPG_Project
{
    public class UIManager : MonoBehaviour
    {
        public BattleHUD Battle { get; private set; }

        private void Awake()
        {
            Battle = GetComponentInChildren<BattleHUD>();
        }
    }
}