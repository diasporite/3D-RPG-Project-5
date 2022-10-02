using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RPG_Project
{
    public class ResourceBar : MonoBehaviour, IUIElement
    {
        protected bool forCurrent = false;

        [SerializeField] protected PartyController party;
        [SerializeField] protected Resource resource;

        [SerializeField] protected Image fill;
        [SerializeField] protected Image fillShadow;

        [SerializeField] protected float updateSpeed = 0.3f;

        public virtual void InitUI(PartyController party)
        {
            SubscribeToDelegates();
        }

        public virtual void InitUI(PartyController party, int index)
        {
            SubscribeToDelegates();
        }

        private void Update()
        {
            fillShadow.fillAmount = Mathf.MoveTowards(fillShadow.fillAmount, 
                fill.fillAmount, updateSpeed * Time.unscaledDeltaTime);
        }

        public virtual void SubscribeToDelegates()
        {

        }

        public virtual void UnsubscribeFromDelegates()
        {
            
        }

        protected virtual void Tick()
        {
            if (resource != null)
                fill.fillAmount = resource.ResourceCooldown.CooldownFraction;
        }

        protected virtual void UpdateResource()
        {

        }
    }
}