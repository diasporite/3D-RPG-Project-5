using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    [CreateAssetMenu(fileName = "New Element", menuName = "Combat/Element")]
    public class ElementData : ScriptableObject
    {
        [field: Header("Information")]
        [field: SerializeField] public string ElementName { get; private set; }
        [field: SerializeField] public Sprite Icon { get; private set; }
        [field: SerializeField] public ElementID Id { get; private set; }

        [field: Header("Matchups")]
        [field: SerializeField] public ElementID[] Weaknesses { get; private set; }
        [field: SerializeField] public ElementID[] Resistances { get; private set; }
        [field: SerializeField] public ElementID[] Immunities { get; private set; }
    }
}