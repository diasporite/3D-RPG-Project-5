using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RPG_Project
{
    public class UIManager : MonoBehaviour
    {
        // Temporary - look into shaders for grayscale
        [field: SerializeField] public Image Grayscale { get; private set; }

        public BattleHUD Battle { get; private set; }

        private void Awake()
        {
            Battle = GetComponentInChildren<BattleHUD>();
        }
    }
}