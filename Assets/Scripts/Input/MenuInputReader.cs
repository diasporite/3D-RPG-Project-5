using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace RPG_Project
{
    public class MenuInputReader : MonoBehaviour, PlayerControls.IMainMenuActions
    {
        MenuScreen menu;

        PlayerControls controls;

        private void Awake()
        {
            menu = GetComponent<MenuScreen>();

            controls = new PlayerControls();
            controls.MainMenu.SetCallbacks(this);
        }

        private void OnEnable()
        {
            controls.Enable();
        }

        private void OnDisable()
        {
            controls.Disable();
        }

        public void OnBack(InputAction.CallbackContext context)
        {
            if (context.performed) menu.CurrentMenu.Back();
        }

        public void OnConfirm(InputAction.CallbackContext context)
        {
            if (context.performed) menu.CurrentMenu.Confirm();
        }

        public void OnNext(InputAction.CallbackContext context)
        {
            if (context.performed) menu.CurrentMenu.Next();
        }

        public void OnPrevious(InputAction.CallbackContext context)
        {
            if (context.performed) menu.CurrentMenu.Previous();
        }

        public void OnOpenClose(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                if (menu.CurrentMenu.Open) menu.CurrentMenu.MenuClose();
                else menu.CurrentMenu.MenuOpen();
            }
        }
    }
}