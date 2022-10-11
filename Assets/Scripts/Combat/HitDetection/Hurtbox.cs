using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class Hurtbox : MonoBehaviour
    {
        [field: SerializeField] public bool IsWeakPoint { get; private set; } = false;
        [field: SerializeField] public Damageable Damageable { get; private set; } = null;

        private void Awake()
        {
            if (Damageable == null) Damageable = GetComponentInParent<Damageable>();
        }
    }
}