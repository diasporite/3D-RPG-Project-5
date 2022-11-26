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

        [field: Header("Weight")]
        [field: Range(0, 255)]
        [field: SerializeField] public int Weight { get; private set; } = 128;
        public float DodgeReduction { get; private set; }
        public float GuardReduction { get; private set; }
        float dodgeMult;
        float guardMult;
        
        [field: Header("Dodge")]
        [field: SerializeField] public ActionData DodgeAction { get; private set; }

        [field: Header("Hitboxes")]
        [field: SerializeField] public Hitbox[] Melee { get; private set; }
        [field: SerializeField] public ProjectileWeapon[] Projectile { get; private set; }

        PartyController party;
        Movement movement;

        Controller controller;
        Health health;
        Stamina stamina;
        Power power;

        CombatDatabase combat;

        private void Awake()
        {
            party = GetComponentInParent<PartyController>();
            movement = GetComponentInParent<Movement>();
            health = GetComponentInParent<Health>();
            stamina = GetComponentInParent<Stamina>();

            controller = GetComponent<Controller>();
            power = GetComponent<Power>();

            Melee = GetComponentsInChildren<Hitbox>();
            Projectile = GetComponentsInChildren<ProjectileWeapon>();

            foreach (var hit in Melee) hit.gameObject.SetActive(false);

            InitCharacter();
        }

        private void Start()
        {
            combat = GameManager.instance.Combat;

            DodgeReduction = combat.DodgeReduction(Weight);
            GuardReduction = combat.GuardReduction(Weight);

            dodgeMult = 1 - DodgeReduction;
            guardMult = 1 - GuardReduction;
        }

        void InitCharacter()
        {
            CharName = CharData.CharName;

            WalkSpeed = CharData.WalkSpeed;
            RunSpeed = CharData.RunSpeed;
            StrafeSpeed = CharData.StrafeSpeed;

            Weight = CharData.Weight;

            DodgeAction = CharData.DodgeAction;
        }

        public override void OnDamage(DamageInfo info)
        {
            if (controller.sm.InState(StateID.ControllerDeath) || info == null) return;

            var act = 1.4f;

            var hDamage = info.HealthDamage;
            var sDamage = info.StaminaDamage;

            if (!info.FlatDamage)
            {
                if (controller.sm.InState(StateID.ControllerDodge))
                    hDamage = Mathf.RoundToInt(hDamage * dodgeMult);
                if (controller.sm.InState(StateID.ControllerGuard))
                    hDamage = Mathf.RoundToInt(hDamage * guardMult);
                if (controller.sm.InState(StateID.ControllerAction, StateID.ControllerJump))
                    hDamage = Mathf.RoundToInt(hDamage * act);
            }

            health.ChangeValue(-hDamage);
            stamina.ChangeValue(-sDamage);

            if (sDamage > 0) stamina.Pause();

            party.Es?.OnDamage(hDamage, sDamage);

            if (health.Empty)
            {
                controller.sm.ChangeState(StateID.ControllerDeath);
                //party.InvokeDeath();
            }
            else if (stamina.Empty)
            {
                if (controller.sm.InState(StateID.ControllerStagger)) return;

                //con.sm.ChangeState(StateID.ControllerStagger);
                //party.InvokeStagger();
            }
        }

        public override void OnImpact(Vector3 impulse)
        {
            movement.ApplyForce(impulse);
        }

        public void TriggerAttack(int actionIndex, float normTime)
        {
            actionIndex = Mathf.Clamp(actionIndex, 0, CharData.CombatActions.Length);
            CharData.CombatActions[actionIndex].TriggerAttack(normTime, Melee, Projectile);
        }

        public void EnableHitbox(int actionIndex, float normTime)
        {
            var action = CharData.CombatActions[actionIndex];
            Melee[action.HitboxIndex].gameObject.SetActive(action.IsHitDetectorActive(normTime));
        }

        public void FireWeapon(int actionIndex, int weaponIndex, int bulletIndex, float normTime)
        {
            var action = CharData.CombatActions[actionIndex];
        }

        public void DisableHitDetectors()
        {
            foreach (var hd in Melee) hd.gameObject.SetActive(false);
        }

        public float EvaluateActionMovement(float normalisedTime)
        {
            return CharData.CombatActions[controller.CurrentActionIndex].
                MotionCurve.Evaluate(normalisedTime);
        }
    }
}