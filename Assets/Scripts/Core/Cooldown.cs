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
            set => count = Mathf.Clamp(value, 0f, cooldown);
        }

        public float CooldownFraction
        {
            get => count / cooldown;
            set => count = Mathf.Clamp01(value) * CooldownValue;
        }

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
            Count += speed * Time.deltaTime;
        }

        public void Tick(float dt)
        {
            Count += speed * dt;
        }

        public void Reset()
        {
            Count = 0;
        }
    }
}