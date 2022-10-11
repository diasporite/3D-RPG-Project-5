using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    [System.Serializable]
    public class DamageInfo
    {
        [SerializeField] Character instigator;
        [SerializeField] Vector3 instPos;

        [field: SerializeField] public int Damage { get; private set; }

        CombatDatabase combat;

        public int FinalDamage => Damage;

        public DamageInfo(Character instigator, int basePower)
        {
            this.instigator = instigator;
            instPos = instigator.transform.position;

            combat = GameManager.instance.Combat;

            Damage = combat.Damage(basePower);
        }
    }
}