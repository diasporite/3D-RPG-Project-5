using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class Hitbox : HitDetector
    {
        Controller controller;
        Character character;
        TargetType[] targetTypes;

        private void Awake()
        {
            controller = GetComponentInParent<Controller>();
            character = GetComponentInParent<Character>();
        }

        private void Start()
        {
            if (controller != null)
                targetTypes = controller.Party.Ts.Types;
            else targetTypes = new TargetType[] { TargetType.Player,
                TargetType.Enemy, TargetType.Object };
        }

        private void OnTriggerEnter(Collider other)
        {
            var hurt = other.GetComponent<Hurtbox>();

            if (hurt)
            {
                var dam = hurt.Damageable;

                if (dam != null && dam != character)
                {
                    if (Array.Exists(targetTypes, i => i == hurt.TargetType))
                    {
                        if (!hits.ContainsKey(dam)) hits.Add(dam, new HurtboxHits(hurt));
                        else hits[dam].AddHurtbox(hurt);
                    }
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            foreach(var dam in hits.Keys)
            {
                var damage = character.CharData.
                    CombatActions[controller.CurrentActionIndex].GetDamageInfo(character);
                dam.OnDamage(damage);
                dam.OnImpact(Vector3.zero);
            }

            hits.Clear();
        }
    }
}