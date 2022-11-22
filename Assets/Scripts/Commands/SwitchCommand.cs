using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class SwitchCommand : InputCommand
    {
        [SerializeField] int index;

        public SwitchCommand(PartyController party, InputReader ir, int index) : base(party, ir)
        {
            this.index = index;

            inputName = "switch " + index;
        }

        public override void Execute()
        {
            ir.InvokeSwitch(index);
        }
    }
}