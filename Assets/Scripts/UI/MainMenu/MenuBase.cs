using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class MenuBase : MonoBehaviour
    {
        public bool Open { get; protected set; } = false;

        [field: SerializeField] protected ButtonUI[] Buttons { get; private set; }
        [field: SerializeField] protected ButtonUI CurrentButton { get; set; }
        [field: SerializeField] protected int CurrentButtonIndex = 0;

        private void Awake()
        {
            Buttons = GetComponentsInChildren<ButtonUI>();
        }

        private void Start()
        {
            if (Buttons.Length > 0)
            {
                CurrentButton = Buttons[0];
                CurrentButton.Select();
            }
        }

        #region InterfaceMethods
        public virtual void Back()
        {

        }

        public virtual void Confirm()
        {
            CurrentButton.OnPress.Invoke();
        }

        public virtual void Next()
        {
            CurrentButton?.Deselect();
            CurrentButtonIndex++;
            CurrentButtonIndex = CurrentButtonIndex % Buttons.Length;
            CurrentButton = Buttons[CurrentButtonIndex];
            CurrentButton?.Select();
        }

        public virtual void Previous()
        {
            CurrentButton?.Deselect();
            CurrentButtonIndex--;
            if (CurrentButtonIndex < 0) CurrentButtonIndex += Buttons.Length;
            CurrentButton = Buttons[CurrentButtonIndex];
            CurrentButton?.Select();
        }

        public virtual void MenuOpen()
        {
            if (!Open)
            {
                Open = true;
            }
        }

        public virtual void MenuClose()
        {
            if (Open)
            {
                Open = false;
            }
        }
        #endregion
    }
}