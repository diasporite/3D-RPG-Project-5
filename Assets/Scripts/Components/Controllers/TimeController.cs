using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class TimeController : MonoBehaviour
    {
        [SerializeField] bool completeFreeze = false;
        [SerializeField] float minTimescale = 0.1f;
        [SerializeField] float acceleration = 10f;

        public void SetTimescale(float scale)
        {
            if (Time.timeScale == scale) return;

            var ts_min = 0f;
            if (!completeFreeze) ts_min = minTimescale;

            Time.timeScale = Mathf.Clamp(Mathf.MoveTowards(Time.timeScale, scale, 
                acceleration * Time.unscaledDeltaTime), ts_min, 1f);
        }

        public void SetTimescaleInstant(float scale)
        {
            if (Time.timeScale == scale) return;

            var ts_min = 0f;
            if (!completeFreeze) ts_min = minTimescale;

            Time.timeScale = Mathf.Clamp(scale, ts_min, 1f);
        }
    }
}