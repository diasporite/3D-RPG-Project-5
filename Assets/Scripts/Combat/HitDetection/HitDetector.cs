using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class HurtboxHits
    {
        List<Hurtbox> hurtboxes;

        public bool IsWeakPointHit
        {
            get
            {
                foreach (var box in hurtboxes)
                    if (box.IsWeakPoint) return true;

                return false;
            }
        }

        public HurtboxHits()
        {
            hurtboxes = new List<Hurtbox>();
        }

        public HurtboxHits(Hurtbox box)
        {
            hurtboxes = new List<Hurtbox>();
            hurtboxes.Add(box);
        }

        public void AddHurtbox(Hurtbox box)
        {
            if (!hurtboxes.Contains(box))
                hurtboxes.Add(box);
        }
    }

    public class HitDetector : MonoBehaviour
    {
        protected Dictionary<Damageable, HurtboxHits> hits = 
            new Dictionary<Damageable, HurtboxHits>();
    }
}