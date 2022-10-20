using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    [CreateAssetMenu(fileName = "New Melee", menuName = "Combat/Actions/Melee")]
    public class MeleeActionData : AttackActionData
    {
        public override void TriggerAttack(float normTime, Hitbox[] hitboxes, 
            ProjectileWeapon[] weapons)
        {
            hitboxes[HitboxIndex].gameObject.SetActive(IsHitDetectorActive(normTime));
        }

        public override bool IsHitDetectorActive(float normTime)
        {
            foreach (var w in Windows)
            {
                if (normTime >= w.EnableHitbox &&
                    normTime <= w.DisableHitbox) return true;
            }

            return false;
        }
    }
}