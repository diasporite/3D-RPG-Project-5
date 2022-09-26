using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    [System.Serializable]
    public class InputCommand : ICommand
    {
        [SerializeField] protected string inputName;

        protected PartyController party;
        protected InputReader ir;

        public virtual bool CanExecute { get; }

        public InputCommand(PartyController party, InputReader ir)
        {
            this.party = party;
            this.ir = ir;
        }

        public virtual void Execute()
        {

        }

        public IEnumerator ExecuteCo()
        {
            yield return null;
        }

        public void Undo()
        {

        }

        public IEnumerator UndoCo()
        {
            yield return null;
        }
    }
}