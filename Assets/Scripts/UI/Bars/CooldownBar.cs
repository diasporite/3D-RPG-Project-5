using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RPG_Project
{
    public class CooldownBar : MonoBehaviour
    {
        protected float updateDelay = 0.8f;
        protected float updateSpeed = 0.6f;
        protected float shadowThreshold = 0.04f;

        [field: SerializeField] public Image Background { get; private set; }
        [field: SerializeField] public Image FillShadow { get; private set; }
        [field: SerializeField] public Image Fill { get; private set; }
    }
}