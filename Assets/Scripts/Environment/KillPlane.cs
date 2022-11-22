using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class KillPlane : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            var party = other.GetComponent<PartyController>();

            if (party != null)
            {
                party.CurrentController.Character.OnDamage(new DamageInfo(999, 0));
            }
        }
    }
}