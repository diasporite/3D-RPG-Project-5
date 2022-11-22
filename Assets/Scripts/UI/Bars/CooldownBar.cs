using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RPG_Project
{
    public class CooldownBar : MonoBehaviour
    {
        [field: SerializeField] public Image Background { get; private set; }
        [field: SerializeField] public Image FillShadow { get; private set; }
        [field: SerializeField] public Image Fill { get; private set; }
    }
}