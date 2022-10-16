using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class Hurtbox : MonoBehaviour
    {
        [field: SerializeField] public bool IsWeakPoint { get; private set; } = false;
        [field: SerializeField] public TargetType TargetType { get; private set; }
        [field: SerializeField] public Damageable Damageable { get; private set; } = null;

        private void Awake()
        {
            if (Damageable == null) Damageable = GetComponentInParent<Damageable>();
        }

        private void Start()
        {
            var p = GetComponentInParent<PartyController>();

            if (p == null) TargetType = TargetType.Object;
            else TargetType = p.Ts.SelfType;
        }
    }
}