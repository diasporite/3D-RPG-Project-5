using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class Projectile : HitDetector
    {
        [SerializeField] bool isPiercing;
        [SerializeField] float projectileTracking;
        [SerializeField] float gravityStrength;
        [SerializeField] float speed;
        [SerializeField] float angularSpeed;

        [SerializeField] Transform follow;

        float verticalVelocity = 0f;
        float gravity = -19.62f;

        Cooldown distanceTravelled;

        Vector3 planeFollow;
        Vector3 planeStraight;

        Vector3 ds;
        Vector3 dy;
        Vector3 dv;

        ProjectileWeapon weapon;

        public void InitProjectile(ProjectileWeapon weapon, ProjectileActionData data, 
            Transform muzzle, Transform follow)
        {
            transform.rotation = Quaternion.LookRotation(muzzle.forward);

            this.weapon = weapon;
            this.follow = follow;

            projectileTracking = data.ProjectileTracking;
            gravityStrength = data.GravityStrength;
            speed = data.Speed;
            angularSpeed = data.AngularSpeed;

            distanceTravelled = new Cooldown(data.Distance, data.Speed, 0f);

            verticalVelocity = 0f;
        }

        private void Update()
        {
            Move(Time.deltaTime);

            Tick();
        }

        private void OnTriggerEnter(Collider other)
        {
            var hurt = other.GetComponent<Hurtbox>();

            if (hurt)
            {
                var dam = hurt.Damageable;

                if (dam != null && dam != weapon.Character)
                {
                    if (Array.Exists(weapon.TargetTypes, i => i == hurt.TargetType))
                    {
                        DealDamage(dam);

                        if (!isPiercing)
                            Destroy(gameObject);
                    }
                }
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawRay(transform.position, 4f * transform.forward);
            Gizmos.DrawRay(transform.position, 4f * dv);
        }

        void Tick()
        {
            distanceTravelled.Tick();

            if (distanceTravelled.Full)
                Destroy(gameObject);
        }

        void Move(float dt)
        {
            planeFollow = follow != null ? (follow.position - 
                transform.position).normalized : transform.forward;
            planeFollow.y = 0;

            planeStraight = transform.forward;
            planeStraight.y = 0;

            verticalVelocity += gravityStrength * gravity * Time.deltaTime;

            ds = Vector3.Lerp(planeStraight, planeFollow, projectileTracking);
            dy = verticalVelocity * Vector3.up;
            dv = (ds + dy).normalized;

            transform.rotation = Quaternion.LookRotation(ds);
            transform.position += speed * (transform.forward + dy) * dt;

            transform.RotateAround(transform.position, transform.forward, angularSpeed * dt);
        }

        void DealDamage()
        {
            foreach (var dam in hits.Keys)
            {
                var damage = weapon.Character.CharData.
                    CombatActions[weapon.Controller.CurrentActionIndex].Damage.Damage(weapon.Character);
                var knockback = weapon.Character.CharData.CombatActions[weapon.Controller.CurrentActionIndex].
                    Knockback.Knockback(weapon.Character.transform);
                dam.OnDamage(damage);
                dam.OnImpact(knockback);
            }
        }

        void DealDamage(Damageable dam)
        {
            var damage = weapon.Character.CharData.
                CombatActions[weapon.Controller.CurrentActionIndex].Damage.Damage(weapon.Character);
            var knockback = weapon.Character.CharData.CombatActions[weapon.Controller.CurrentActionIndex].
                Knockback.Knockback(weapon.Character.transform);
            dam.OnDamage(damage);
            dam.OnImpact(knockback);
        }
    }
}