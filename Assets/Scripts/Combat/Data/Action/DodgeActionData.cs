using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    [CreateAssetMenu(fileName = "New Dodge", menuName = "Combat/Actions/Dodge")]
    public class DodgeActionData : ActionData
    {
        [field: SerializeField] public bool IsDirectional { get; private set; }
    }
}