using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class MinimapCamera : MonoBehaviour
    {
        PartyController player;

        private void Awake()
        {
            player = GetComponentInParent<PartyController>();
        }

        private void LateUpdate()
        {
            //transform.rotation = Quaternion.Euler(90f, 0f, -player.
            //    CurrentController.Model.transform.eulerAngles.y);

            transform.rotation = Quaternion.Euler(90f, 0f, 0f);
        }
    }
}