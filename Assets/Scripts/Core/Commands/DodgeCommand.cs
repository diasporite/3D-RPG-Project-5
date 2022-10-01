using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    [System.Serializable]
    public class DodgeCommand : InputCommand
    {
        public DodgeCommand(PartyController party, InputReader ir, Vector2 inputDir) : base(party, ir)
        {
            inputName = "dodge " + inputDir;
        }

        public override void Execute()
        {
            ir.InvokeDodge();
        }
    }
}