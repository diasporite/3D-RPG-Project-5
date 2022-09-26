using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    [System.Serializable]
    public class TeleportCommand : InputCommand
    {
        public TeleportCommand(PartyController party, InputReader ir, Vector2 inputDir) : base(party, ir)
        {
            inputName = "teleport " + inputDir;
        }

        public override void Execute()
        {
            ir.InvokeTeleport();
        }
    }
}