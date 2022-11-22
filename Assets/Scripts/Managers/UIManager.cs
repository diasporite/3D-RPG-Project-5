using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RPG_Project
{
    public class UIManager : MonoBehaviour
    {
        // State dependent
        public BattleHUD BattleHUD { get; private set; }
        public MainMenu MainMenu { get; private set; }
        public LoadingScreen LoadingScreen { get; private set; }
        public GameOverScreen GameOverScreen { get; private set; }

        // Always loaded (alpha = 0)
        public FadingScreen FadingScreen { get; private set; }
        public AreaName AreaName { get; private set; }

        private void Awake()
        {
            BattleHUD = GetComponentInChildren<BattleHUD>();
            MainMenu = GetComponentInChildren<MainMenu>();
            LoadingScreen = GetComponentInChildren<LoadingScreen>();
            GameOverScreen = GetComponentInChildren<GameOverScreen>();

            FadingScreen = GetComponentInChildren<FadingScreen>();
            AreaName = GetComponentInChildren<AreaName>();

            BattleHUD.gameObject.SetActive(false);
            MainMenu.gameObject.SetActive(false);
            LoadingScreen.gameObject.SetActive(false);
            GameOverScreen.gameObject.SetActive(false);
        }
    }
}