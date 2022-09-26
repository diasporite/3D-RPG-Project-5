using System.Collections;
using UnityEngine;

namespace RPG_Project
{
    public interface IDamageable
    {
        void OnDamage(DamageInfo info);
        IEnumerator OnDamageCo(DamageInfo info);

        void OnImpact(Vector3 impulse);
        IEnumerator OnImpactCo(Vector3 impulse);
    }
}