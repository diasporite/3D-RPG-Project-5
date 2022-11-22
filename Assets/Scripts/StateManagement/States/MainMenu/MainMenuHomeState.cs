using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class MainMenuHomeState : IState
    {
        MainMenu menu;
        StateMachine mmsm;

        public MainMenuHomeState(MainMenu menu)
        {
            this.menu = menu;
            mmsm = menu.sm;
        }

        #region InterfaceMethods
        public void Enter(params object[] args)
        {
            menu.currentState = StateID.MainMenuHome;

            menu.Home.gameObject.SetActive(true);
            menu.CurrentMenu = menu.Home;
        }

        public void ExecuteFrame()
        {

        }

        public void ExecuteFrameFixed()
        {

        }

        public void ExecuteFrameLate()
        {

        }

        public void Exit()
        {
            menu.Home.gameObject.SetActive(false);
        }
        #endregion
    }
}