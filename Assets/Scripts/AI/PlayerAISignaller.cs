using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class PlayerAISignaller : MonoBehaviour
    {
        [SerializeField] PlayerAIPulse pulsePrefab;

        Cooldown pulseTimer = new Cooldown(1f, 1f, 0f);

        public void Tick()
        {
            pulseTimer.Tick();

            if (pulseTimer.Full)
            {
                SendPulse();
            }
        }

        public void SendPulse()
        {
            GameObject pulseObj = Instantiate(pulsePrefab.gameObject, transform.position, 
                Quaternion.identity) as GameObject;

            pulseTimer.Reset();
        }
    }
}