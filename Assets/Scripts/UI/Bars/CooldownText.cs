using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RPG_Project
{
    public class CooldownText : MonoBehaviour, IUIElement
    {
        protected string header;

        protected Text text;

        private void Awake()
        {
            text = GetComponentInChildren<Text>();
        }

        public virtual void InitUI()
        {

        }

        public virtual void SubscribeToDelegates()
        {

        }

        public virtual void UnsubscribeFromDelegates()
        {

        }

        public virtual void UpdateUI()
        {

        }
    }
}