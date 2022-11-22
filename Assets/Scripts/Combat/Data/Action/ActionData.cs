using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    [System.Serializable]
    public class HitboxWindow
    {
        [field: SerializeField] public float EnableHitbox { get; private set; } = 0.5f;
        [field: SerializeField] public float DisableHitbox { get; private set; } = 0.6f;
    }

    [CreateAssetMenu(fileName = "New Action", menuName = "Combat/Actions/Action")]
    public class ActionData : ScriptableObject
    {
        [field: SerializeField] public string ActionName { get; private set; }

        [field: SerializeField] public int StaminaCost { get; private set; } = 20;

        [field: SerializeField] public bool InfiniteUse { get; private set; } = false;
        [field: SerializeField] public int Uses { get; private set; } = 20;

        [field: SerializeField] public AnimationCurve MotionCurve { get; private set; }

        [field: Header("HitDetection")]
        [field: SerializeField] public int HitboxIndex { get; protected set; }
        [field: SerializeField] public HitboxWindow[] Windows { get; protected set; }

        public virtual bool IsHitDetectorActive(float normTime)
        {
            return false;
        }

        public virtual DamageInfo GetDamageInfo(Character character)
        {
            return null;
        }
    }
}