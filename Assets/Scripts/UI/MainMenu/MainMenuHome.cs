using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class MainMenuHome : MenuBase
    {
        public override void Back()
        {

        }

        public override void MenuOpen()
        {

        }

        public override void MenuClose()
        {

        }

        public void NewGame()
        {
            print("new game");

            GameManager.instance.LoadScene(1, true);
        }

        public void Options()
        {
            print("options");
            // Open options menu
        }

        public void Quit()
        {
            print("quit");
            Application.Quit();
        }
    }
}