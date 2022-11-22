using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class GameOverScreen : MenuBase
    {
        public void Retry()
        {
            print("retry");
        }

        public void Quit()
        {
            print("quit");

            Application.Quit();
        }
    }
}