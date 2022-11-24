using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RPG_Project
{
    public class ActionPanel : MonoBehaviour, IUIElement
    {
        [SerializeField] Text nameText;

        [SerializeField] Text typeText;
        [SerializeField] Text elementText;
        [SerializeField] Text staminaText;
        [SerializeField] Text usageText;

        [SerializeField] Image vignette;

        public void InitUI()
        {

        }

        public void SubscribeToDelegates()
        {

        }

        public void UnsubscribeFromDelegates()
        {

        }

        public void UpdateUI()
        {

        }

        void UpdateUseable()
        {

        }
    }
}