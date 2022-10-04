using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    [System.Serializable]
    public class JumpCommand : InputCommand
    {
        public JumpCommand(PartyController party, InputReader ir, Vector2 inputDir) : base(party, ir)
        {
            inputName = "jump";
        }

        public override void Execute()
        {
            ir.InvokeJump();
        }
    }
}