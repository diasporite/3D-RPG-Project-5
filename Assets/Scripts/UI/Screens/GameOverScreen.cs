using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class GameOverScreen : MenuScreen
    {
        protected override void Awake()
        {
            CurrentMenu = GetComponent<GameOverMenu>();

            base.Awake();
        }
    }
}