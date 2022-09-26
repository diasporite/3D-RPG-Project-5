using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class AttackCommand : InputCommand
    {
        [SerializeField] int index;

        public AttackCommand(PartyController party, InputReader ir, int index) : base(party, ir)
        {
            this.index = index;

            inputName = "attack " + index;
        }

        public override void Execute()
        {
            ir.InvokeAttack(index);
        }
    }
}