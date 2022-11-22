using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class GameOverState : IState
    {
        GameManager game;
        StateMachine gsm;

        UIManager ui;

        public GameOverState(GameManager game)
        {
            this.game = game;
            gsm = game.sm;

            ui = game.Ui;
        }

        #region InterfaceMethods
        public void Enter(params object[] args)
        {
            game.currentState = StateID.GameOver;

            ui.GameOverScreen.gameObject.SetActive(true);
            //ui.MainMenu.sm.ChangeState(StateID.MainMenuHome);
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
            ui.GameOverScreen.gameObject.SetActive(false);
        }
        #endregion
    }
}