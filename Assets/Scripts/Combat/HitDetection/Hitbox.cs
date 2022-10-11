using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class Hitbox : HitDetector
    {
        Controller controller;
        Character character;

        private void Awake()
        {
            controller = GetComponentInParent<Controller>();
            character = GetComponentInParent<Character>();
        }

        private void OnTriggerEnter(Collider other)
        {
            var hurt = other.GetComponent<Hurtbox>();

            if (hurt)
            {
                if (hurt.transform.root == transform.root) return;

                var dam = hurt.Damageable;

                if (dam != null)
                {
                    if (!hits.ContainsKey(dam))
                        hits.Add(dam, new HurtboxHits(hurt));
                    else hits[dam].AddHurtbox(hurt);
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            foreach(var dam in hits.Keys)
            {
                var damage = character.CharData.
                    CombatActions[controller.CurrentActionIndex].Damage(character);
                dam.OnDamage(damage);
                dam.OnImpact(Vector3.zero);
            }

            hits.Clear();
        }
    }
}