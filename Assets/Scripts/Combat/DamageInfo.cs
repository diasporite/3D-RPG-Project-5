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

        [field: SerializeField] public int HealthDamage { get; private set; }
        [field: SerializeField] public int StaminaDamage { get; private set; }

        [field: SerializeField] public bool FlatDamage { get; private set; } = false;

        CombatDatabase combat;

        public DamageInfo(Character instigator, int basePower)
        {
            this.instigator = instigator;
            instPos = instigator.transform.position;

            combat = GameManager.instance.Combat;

            HealthDamage = combat.Damage(basePower);
        }

        public DamageInfo(Character instigator, DamageData data)
        {
            this.instigator = instigator;
            instPos = instigator.transform.position;

            combat = GameManager.instance.Combat;

            HealthDamage = combat.Damage(data.HealthDamage);
            StaminaDamage = combat.Damage(data.StaminaDamage);
        }

        // For flat damage
        public DamageInfo(int hDamage, int sDamage)
        {
            HealthDamage = hDamage;
            StaminaDamage = sDamage;

            FlatDamage = true;
        }
    }
}