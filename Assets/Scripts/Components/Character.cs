using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class Character : MonoBehaviour, IDamageable
    {
        [field: Header("Movement")]
        [field: SerializeField] public float WalkSpeed { get; private set; } = 4f;
        [field: SerializeField] public float RunSpeed { get; private set; } = 8f;
        [field: SerializeField] public float StrafeSpeed { get; private set; } = 3f;
        [field: SerializeField] public float FallSpeed { get; private set; } = 2f;

        PartyController party;

        //Health health;
        //Stamina stamina;
        Movement movement;

        Controller con;

        private void Awake()
        {
            party = GetComponentInParent<PartyController>();

            //health = GetComponentInParent<Health>();
            //stamina = GetComponentInParent<Stamina>();

            movement = GetComponentInParent<Movement>();

            con = GetComponent<Controller>();
        }

        public void OnDamage(DamageInfo info)
        {
            //if (con.sm.InState(StateID.ControllerDeath)) return;

            //health.ChangeValue(-10);
            //stamina.ChangeValue(-5);

            //if (health.Empty)
            //{
            //    con.sm.ChangeState(StateID.ControllerDeath);
            //    party.InvokeDeath();
            //}
            //else if (stamina.Empty)
            //{
            //    if (con.sm.InState(StateID.ControllerStagger)) return;

            //    con.sm.ChangeState(StateID.ControllerStagger);
            //    party.InvokeStagger();
            //}
        }

        public IEnumerator OnDamageCo(DamageInfo info)
        {
            yield return null;
        }

        public void OnImpact(Vector3 impulse)
        {
            movement.ApplyForce(impulse);
        }

        public IEnumerator OnImpactCo(Vector3 impulse)
        {
            yield return null;
        }
    }
}