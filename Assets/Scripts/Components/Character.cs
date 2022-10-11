using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class Character : Damageable
    {
        [field: SerializeField] public CharData CharData { get; private set; }
        [field: SerializeField] public EnemyAIPattern EnemyAi { get; private set; }

        [field: SerializeField] public string CharName { get; private set; }

        [field: Header("Movement")]
        [field: SerializeField] public float WalkSpeed { get; private set; } = 4f;
        [field: SerializeField] public float RunSpeed { get; private set; } = 8f;
        [field: SerializeField] public float StrafeSpeed { get; private set; } = 3f;
        [field: SerializeField] public float FallSpeed { get; private set; } = 2f;

        [field: Header("Weight")]
        [field: Range(0, 255)]
        [field: SerializeField] public int Weight { get; private set; } = 128;
        public float DodgeReduction { get; private set; }
        public float GuardReduction { get; private set; }

        [field: Header("Dodge")]
        [field: SerializeField] public ActionData DodgeAction { get; private set; }

        [field: Header("Hitboxes")]
        [field: SerializeField] public HitDetector[] HitDetectors { get; private set; }

        PartyController party;
        Movement movement;

        Controller con;
        Health health;
        Stamina stamina;
        Power power;

        CombatDatabase combat;

        private void Awake()
        {
            party = GetComponentInParent<PartyController>();
            movement = GetComponentInParent<Movement>();

            con = GetComponent<Controller>();
            health = GetComponent<Health>();
            stamina = GetComponent<Stamina>();
            power = GetComponent<Power>();

            HitDetectors = GetComponentsInChildren<HitDetector>();
        }

        private void Start()
        {
            combat = GameManager.instance.Combat;

            DodgeReduction = combat.DodgeReduction(Weight);
            GuardReduction = combat.GuardReduction(Weight);

            InitCharacter();
        }

        void InitCharacter()
        {
            CharName = CharData.CharName;

            Weight = CharData.Weight;

            DodgeAction = CharData.DodgeAction;
        }

        public override void OnDamage(DamageInfo info)
        {
            if (con.sm.InState(StateID.ControllerDeath)) return;

            var hDamage = info.FinalDamage;

            health.ChangeValue(-hDamage);
            stamina.ChangeValue(0);

            print(name + " " + (party.Es == null));
            party.Es?.OnDamage(hDamage, 0);

            if (health.Empty)
            {
                //con.sm.ChangeState(StateID.ControllerDeath);
                //party.InvokeDeath();
            }
            else if (stamina.Empty)
            {
                if (con.sm.InState(StateID.ControllerStagger)) return;

                //con.sm.ChangeState(StateID.ControllerStagger);
                //party.InvokeStagger();
            }
        }

        public override void OnImpact(Vector3 impulse)
        {
            movement.ApplyForce(impulse);
        }

        public void EnableHitDetector(int actionIndex, float normTime)
        {
            var action = CharData.CombatActions[actionIndex];
            HitDetectors[action.HitboxIndex].gameObject.SetActive(action.IsHitDetectorActive(normTime));
        }
    }
}