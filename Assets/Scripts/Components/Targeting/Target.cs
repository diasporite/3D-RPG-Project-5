using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class Target : MonoBehaviour
    {
        [field: SerializeField] public bool IsPlayer { get; private set; }

        private void Awake()
        {
            IsPlayer = GetComponentInParent<PlayerInputReader>();
        }
    }
}