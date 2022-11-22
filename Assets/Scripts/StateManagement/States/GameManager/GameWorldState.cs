using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class GameWorldState : IState
    {
        GameManager game;
        StateMachine gsm;

        UIManager ui;

        public GameWorldState(GameManager game)
        {
            this.game = game;
            gsm = game.sm;

            ui = game.Ui;
        }

        #region InterfaceMethods
        public void Enter(params object[] args)
        {
            game.currentState = StateID.GameWorld;

            ui.BattleHUD.gameObject.SetActive(true);
            ui.BattleHUD.InitUI();
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

        }
        #endregion
    }
}