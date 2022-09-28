using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance = null;

        public UIManager UiManager { get; private set; }

        public CombatDatabase Combat { get; private set; }

        private void Awake()
        {
            if (instance == null) instance = this;
            else Destroy(gameObject);

            UiManager = FindObjectOfType<UIManager>();
        }
    }
}