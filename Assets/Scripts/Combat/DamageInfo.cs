using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    [System.Serializable]
    public class DamageInfo
    {
        [SerializeField] Vector3 instPos;

        [field: SerializeField] public int Damage { get; private set; }

        CombatDatabase combat;

        public DamageInfo(int basePower, Vector3 instPos)
        {
            this.instPos = instPos;

            //combat = GameManager.instance.Combat;

            Damage = combat.Damage(basePower);
        }

        public int FinalDamage(Vector3 pos)
        {
            return Damage;
        }
    }
}