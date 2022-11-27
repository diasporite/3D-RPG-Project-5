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

        public float Change { get; protected set; }

        protected PartyController party;
        protected Character character;

        public int ResourcePoints => Mathf.CeilToInt(ResourceCooldown.Count);

        public float ResourceFraction => ResourceCooldown.CooldownFraction;

        public float ChangeFraction => Change / ResourceCooldown.CooldownValue;

        public bool Empty => ResourceCooldown.Empty;
        public bool Full => ResourceCooldown.Full;

        protected virtual void Awake()
        {
            party = GetComponent<PartyController>();
            character = GetComponentInChildren<Character>();
        }

        public virtual void Init()
        {
            
        }

        public virtual void Tick()
        {
            ResourceCooldown.Tick();

            Change = ResourceCooldown.Change;

            UpdateUI();
        }

        public void Tick(float dt)
        {
            ResourceCooldown.Tick(dt);

            Change = ResourceCooldown.Change;

            UpdateUI();
        }

        public void ChangeValue(float amount)
        {
            ResourceCooldown.Count += amount;

            Change = ResourceCooldown.Change;

            UpdateUI();
        }

        public void SetValue(float amount)
        {
            ResourceCooldown.Count = amount;

            Change = ResourceCooldown.Count;

            UpdateUI();
        }

        public void SetFraction(float fraction)
        {
            ResourceCooldown.CooldownFraction = fraction;

            Change = ResourceCooldown.Count;

            UpdateUI();
        }

        protected virtual void UpdateUI()
        {

        }
    }
}