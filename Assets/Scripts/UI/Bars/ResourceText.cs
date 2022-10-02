using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RPG_Project
{
    public class ResourceText : MonoBehaviour, IUIElement
    {
        protected string header;

        [SerializeField] protected PartyController party;

        [SerializeField] protected Text text;

        private void Awake()
        {
            text = GetComponentInChildren<Text>();
        }

        private void OnEnable()
        {
            if (party != null) SubscribeToDelegates();
        }

        private void OnDisable()
        {
            if (party != null) UnsubscribeFromDelegates();
        }

        public virtual void InitUI(PartyController party)
        {
            SubscribeToDelegates();
        }

        public virtual void SubscribeToDelegates()
        {

        }

        public virtual void UnsubscribeFromDelegates()
        {

        }

        protected virtual void UpdateTick()
        {

        }
    }
}