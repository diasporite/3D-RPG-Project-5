using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class ControllerInactiveState : IState
    {
        Controller controller;

        public ControllerInactiveState(Controller con)
        {
            controller = con;
        }

        public void Enter(params object[] args)
        {
            controller.currentState = StateID.ControllerInactive;

            if (controller.Party.IsPlayer)
                controller.Model.Anim.updateMode = AnimatorUpdateMode.Normal;
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
            if (controller.Party.IsPlayer)
                controller.Model.Anim.updateMode = AnimatorUpdateMode.UnscaledTime;
        }
    }
}