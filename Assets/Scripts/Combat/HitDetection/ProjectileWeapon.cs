using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class ProjectileWeapon : MonoBehaviour
    {
        [SerializeField] Transform muzzle;

        public Controller Controller { get; private set; }
        public Character Character { get; private set; }
        [field: SerializeField] public TargetType[] TargetTypes { get; private set; }

        Cooldown FireCooldown = new Cooldown(0.02f, 1f, 0.02f);

        private void Awake()
        {
            Controller = GetComponentInParent<Controller>();
            Character = GetComponentInParent<Character>();
        }

        private void Start()
        {
            if (Controller != null)
                TargetTypes = Controller.Party.Ts.Types;
            else TargetTypes = new TargetType[] { TargetType.Player,
                TargetType.Enemy, TargetType.Object };
        }

        private void Update()
        {
            if (!FireCooldown.Full) FireCooldown.Tick();
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawRay(muzzle.position, 5f * muzzle.forward);
        }

        public void Fire(ProjectileActionData data)
        {
            if (!FireCooldown.Full) return;

            var prObj = Instantiate(data.ProjectilePrefab.gameObject, muzzle.position,
                Quaternion.identity) as GameObject;
            var pr = prObj.GetComponent<Projectile>();
            pr.InitProjectile(this, data, muzzle, Controller.Party.Ts.CurrentTargetTransform);

            FireCooldown.Reset();
        }
    }
}