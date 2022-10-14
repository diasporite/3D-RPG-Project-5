using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    [CreateAssetMenu(fileName = "New Action", menuName = "Combat/Action")]
    public class ActionData : ScriptableObject
    {
        [field: SerializeField] public string ActionName { get; private set; }

        [field: SerializeField] public int StaminaCost { get; private set; } = 20;
        [field: SerializeField] public int PowerCost { get; private set; } = 4;

        [field: SerializeField] public AnimationCurve MotionCurve { get; private set; }

        [field: Header("HitDetection")]
        [field: SerializeField] public int HitboxIndex { get; private set; }
        [field: SerializeField] public HitboxWindow[] Windows { get; private set; }

        public bool IsHitDetectorActive(float normTime)
        {
            foreach (var w in Windows)
            {
                if (normTime >= w.EnableHitbox &&
                    normTime <= w.DisableHitbox) return true;
            }

            return false;
        }

        public virtual DamageInfo Damage(Character character)
        {
            return null;
        }
    }
}