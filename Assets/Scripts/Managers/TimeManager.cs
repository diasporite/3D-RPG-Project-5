using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class TimeManager : MonoBehaviour
    {
        [field: SerializeField] public float InGameTime { get; private set; } = 0f;
        [field: SerializeField] public float ScaledGameTime { get; private set; } = 0f;

        private void Start()
        {
            InGameTime = 0;
            ScaledGameTime = 0;
        }

        private void Update()
        {
            Tick();
        }

        void Tick()
        {
            InGameTime += Time.unscaledDeltaTime;
            ScaledGameTime += Time.deltaTime;
        }
    }
}