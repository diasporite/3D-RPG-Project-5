using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class TimeController : MonoBehaviour
    {
        [SerializeField] float minTimescale = 0.1f;

        public void SetTimescale(float scale)
        {
            Time.timeScale = Mathf.Clamp(scale, minTimescale, 1f);
        }
    }
}