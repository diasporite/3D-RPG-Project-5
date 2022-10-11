using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class Damageable : MonoBehaviour, IDamageable
    {
        public virtual void OnDamage(DamageInfo info)
        {

        }

        public virtual IEnumerator OnDamageCo(DamageInfo info)
        {
            yield return null;
        }

        public virtual void OnImpact(Vector3 impulse)
        {

        }

        public virtual IEnumerator OnImpactCo(Vector3 impulse)
        {
            yield return null;
        }
    }
}