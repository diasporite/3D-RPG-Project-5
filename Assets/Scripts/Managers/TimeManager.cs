using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class TimeManager : MonoBehaviour
    {
        public event Action OnRealTick;
        public event Action OnIGTick;
        public event Action OnLevelTick;

        [field: SerializeField] public float RealTime { get; private set; } = 0f;
        [field: SerializeField] public float InGameTime { get; private set; } = 0f;
        [field: SerializeField] public float LevelTime { get; private set; } = 0f;

        GameManager game;

        // Look for better way to do this
        public string LevelTimestamp
        {
            get
            {
                int h = Mathf.FloorToInt(LevelTime / 3600f);
                int m = Mathf.FloorToInt(LevelTime / 60f) - 60 * h;
                float s = LevelTime - 60 * m;

                //return ScaledGameTime.ToString();

                if (h > 0) return h + ":" + m.ToString("00") + ":" + s.ToString("0.000");

                return m.ToString("00") + ":" + s.ToString("00.000");
            }
        }

        private void Awake()
        {
            game = GetComponent<GameManager>();
        }

        private void Start()
        {
            InGameTime = 0;
            LevelTime = 0;
        }

        private void Update()
        {
            Tick();
        }

        void Tick()
        {
            RealTime += Time.unscaledDeltaTime;
            OnRealTick?.Invoke();

            if (!game.sm.InState(StateID.GameMainMenu, StateID.GameLoading, StateID.GameOver))
            {
                InGameTime += Time.unscaledDeltaTime;
                OnIGTick?.Invoke();

                LevelTime += Time.deltaTime;
                OnLevelTick?.Invoke();
            }
        }

        public void InvokeRealTick()
        {
            OnRealTick?.Invoke();
        }

        public void InvokeIGTick()
        {
            OnIGTick?.Invoke();
        }

        public void InvokeLevelTick()
        {
            OnLevelTick?.Invoke();
        }

        public void ResetLevelTime()
        {
            LevelTime = 0;
        }
    }
}