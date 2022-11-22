using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public interface IUIElement
    {
        void InitUI();
        void UpdateUI();

        void SubscribeToDelegates();
        void UnsubscribeFromDelegates();
    }
}