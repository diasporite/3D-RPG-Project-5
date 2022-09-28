using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public interface IUIElement
    {
        void SubscribeToDelegates();
        void UnsubscribeFromDelegates();
    }
}