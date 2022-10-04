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
    }
}