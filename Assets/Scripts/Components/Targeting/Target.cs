using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public enum TargetType
    {
        Player = 0,
        Enemy = 1,
        Object = 2,
    }

    public class Target : MonoBehaviour
    {
        [field: SerializeField] public TargetType Type { get; private set; }

        List<TargetSphere> subscribers = new List<TargetSphere>();

        private void Awake()
        {
            var input = GetComponentInParent<InputReader>();

            if (input is PlayerInputReader) Type = TargetType.Player;
            else if (input is EnemyInputReader) Type = TargetType.Enemy;
            else Type = TargetType.Object;
        }

        public void Subscribe(TargetSphere ts)
        {
            if (!subscribers.Contains(ts)) subscribers.Add(ts);
        }

        public void Unsubscribe(TargetSphere ts)
        {
            if (subscribers.Contains(ts)) subscribers.Remove(ts);
        }

        public void NotifyDeath()
        {
            foreach (var s in subscribers) s.RemoveTarget(this);
        }
    }
}