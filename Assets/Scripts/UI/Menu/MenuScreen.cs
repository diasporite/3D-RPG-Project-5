using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class MenuScreen : MonoBehaviour
    {
        public StateID currentState;

        public MenuBase CurrentMenu { get; set; }

        public readonly StateMachine sm = new StateMachine();

        protected virtual void Awake()
        {
            InitSM();
        }

        private void Update()
        {
            sm.Update();
        }

        protected virtual void InitSM()
        {

        }
    }
}