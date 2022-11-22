using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class GameLoadingState : IState
    {
        GameManager game;
        StateMachine gsm;

        UIManager ui;

        public GameLoadingState(GameManager game)
        {
            this.game = game;
            gsm = game.sm;

            ui = game.Ui;
        }

        #region InterfaceMethods
        public void Enter(params object[] args)
        {
            game.currentState = StateID.GameLoading;

            ui.LoadingScreen.gameObject.SetActive(true);
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
            ui.LoadingScreen.gameObject.SetActive(false);
        }
        #endregion
    }
}