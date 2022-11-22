using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    [System.Serializable]
    public class Cooldown
    {
        [SerializeField] float cooldown = 1f;
        [SerializeField] float speed = 1f;
        [SerializeField] float count = 0f;

        public float CooldownValue
        {
            get => cooldown;
            set => cooldown = Mathf.Abs(cooldown);
        }

        public float Speed
        {
            get => speed;
            set => speed = value;
        }

        public float Count
        {
            get => count;
            set
            {
                var count0 = count;
                count = Mathf.Clamp(value, 0f, cooldown);
                Change = count - count0;
            }
        }

        public float CooldownFraction
        {
            get => count / cooldown;
            set
            {
                var count0 = count;
                count = Mathf.Clamp01(value) * CooldownValue;
                Change = count - count0;
            }
        }

        public float Change { get; private set; }

        public bool Empty => count <= 0;
        public bool Full => count >= cooldown;

        public Cooldown(float cooldown, float speed, float count)
        {
            this.cooldown = Mathf.Abs(cooldown);
            this.speed = speed;
            this.count = Mathf.Clamp(count, 0f, cooldown);
        }

        public void Tick()
        {
            Change = speed * Time.deltaTime;
            Count += Change;
        }

        public void Tick(float dt)
        {
            Change = speed * dt;
            Count += Change;
        }

        public void TickUnscaled()
        {
            Change = speed * Time.unscaledDeltaTime;
            Count += Change;
        }

        public void Reset()
        {
            Count = 0;
        }
    }
}