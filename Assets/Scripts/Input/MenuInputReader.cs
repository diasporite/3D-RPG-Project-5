using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace RPG_Project
{
    public class MenuInputReader : MonoBehaviour, PlayerControls.IMainMenuActions
    {
        MainMenu mainMenu;

        PlayerControls controls;

        private void Awake()
        {
            mainMenu = GetComponent<MainMenu>();

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
            if (context.performed) mainMenu.CurrentMenu.Back();
        }

        public void OnConfirm(InputAction.CallbackContext context)
        {
            if (context.performed) mainMenu.CurrentMenu.Confirm();
        }

        public void OnNext(InputAction.CallbackContext context)
        {
            if (context.performed) mainMenu.CurrentMenu.Next();
        }

        public void OnPrevious(InputAction.CallbackContext context)
        {
            if (context.performed) mainMenu.CurrentMenu.Previous();
        }
    }
}