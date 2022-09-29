using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class Resource : MonoBehaviour
    {
        [field: SerializeField] public Cooldown ResourceCooldown { get; protected set; }

        [SerializeField] protected float baseSpeed;
        [SerializeField] float speedFactor;

        protected PartyController party;

        public float SpeedFactor
        {
            get => speedFactor;
            set
            {
                speedFactor = value;
                ResourceCooldown.Speed = speedFactor * baseSpeed;
            }
        }

        public int ResourcePoints => Mathf.CeilToInt(ResourceCooldown.Count);

        public bool Empty => ResourceCooldown.Empty;
        public bool Full => ResourceCooldown.Full;

        protected virtual void Awake()
        {
            party = GetComponentInParent<PartyController>();
        }

        public virtual void Tick()
        {
            ResourceCooldown.Tick();

            UpdateUI();
        }

        public void Tick(float dt)
        {
            ResourceCooldown.Tick(dt);

            UpdateUI();
        }

        public void ChangeValue(float amount)
        {
            ResourceCooldown.Count += amount;

            UpdateUI();
        }

        public void SetValue(float amount)
        {
            ResourceCooldown.Count = amount;

            UpdateUI();
        }

        public void SetFraction(float fraction)
        {
            ResourceCooldown.CooldownFraction = fraction;

            UpdateUI();
        }

        protected virtual void UpdateUI()
        {

        }
    }
}