using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class MainMenu : MonoBehaviour
    {
        public StateID currentState;

        public MainMenuHome Home { get; private set; }

        public MenuBase CurrentMenu { get; set; }

        public readonly StateMachine sm = new StateMachine();

        private void Awake()
        {
            Home = GetComponentInChildren<MainMenuHome>();

            InitSM();

            Home.gameObject.SetActive(false);
        }

        private void Update()
        {
            sm.Update();
        }

        void InitSM()
        {
            sm.AddState(StateID.MainMenuHome, new MainMenuHomeState(this));
        }
    }
}