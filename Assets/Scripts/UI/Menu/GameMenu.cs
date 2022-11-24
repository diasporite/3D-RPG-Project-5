using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class GameMenu : MenuScreen
    {
        //public MainMenuHome Home { get; private set; }

        protected override void Awake()
        {
            //Home = GetComponentInChildren<MainMenuHome>();

            InitSM();

            //Home.gameObject.SetActive(false);

            base.Awake();
        }

        private void Update()
        {
            sm.Update();
        }

        protected override void InitSM()
        {

        }
    }
}