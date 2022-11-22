using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class GameOverMenu : MenuBase
    {
        public void Retry()
        {
            print("retry");

            GameManager.instance.LoadScene(1);
        }

        public void Quit()
        {
            print("quit");

            Application.Quit();
        }
    }
}