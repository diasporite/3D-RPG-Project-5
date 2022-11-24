using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace RPG_Project
{
    public class TimerDisplayUI : MonoBehaviour, IUIElement
    {
        TextMeshProUGUI text;

        TimeManager time;

        public void InitUI()
        {
            text = GetComponentInChildren<TextMeshProUGUI>();

            time = GameManager.instance.TimeManager;
        }

        public void SubscribeToDelegates()
        {
            time.OnLevelTick += UpdateUI;
        }

        public void UnsubscribeFromDelegates()
        {
            time.OnLevelTick -= UpdateUI;
        }

        public void UpdateUI()
        {
            text.text = time.LevelTimestamp;
        }
    }
}