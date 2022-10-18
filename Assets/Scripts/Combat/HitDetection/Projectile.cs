using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] bool useGravity;
        [SerializeField] float tracking;

        [SerializeField] Transform follow;

        float verticalVelocity = 0f;
        float gravity = -19.62f;

        Cooldown Lifetime;

        public void InitProjectile(ProjectileActionData data, Transform follow)
        {
            this.follow = follow;

            useGravity = data.UseGravity;
            tracking = data.ProjectileTracking;

            Lifetime = new Cooldown(data.Lifetime, 1f, 0f);
        }

        private void Update()
        {
            Move(Time.deltaTime);

            Tick();
        }

        void Tick()
        {
            Lifetime.Tick();
        }

        void Move(float dt)
        {
            var dirToFollow = (follow.position - transform.position).normalized;

            var ds = Vector3.Slerp(transform.forward, dirToFollow, tracking);

            transform.Translate(ds * dt);
        }
    }
}