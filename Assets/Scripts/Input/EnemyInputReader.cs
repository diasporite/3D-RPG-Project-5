using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class EnemyInputReader : InputReader
    {
        Vector2 moveDir = new Vector2(0, 0);

        public void MoveEnemy(Vector3 dir)
        {
            moveDir.x = dir.x;
            moveDir.y = dir.z;

            Move = moveDir.normalized;
        }

        public void Action(params int[] index)
        {
            foreach(var i in index)
            {
                InputQueue.AddInput(new AttackCommand(Party, this, i));
            }
        }
    }
}