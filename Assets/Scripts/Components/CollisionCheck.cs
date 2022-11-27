using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class CollisionCheck : MonoBehaviour
    {
        [SerializeField] int objects = 0;

        LayerMask detect;
        //LayerMask[] detect;

        public bool IsObstructed => objects > 0;

        private void Awake()
        {
            // Include NON-DESTRUCTIBLE walls and objects
            //detect = new LayerMask[] { LayerMask.GetMask("Walls") };
            detect = LayerMask.GetMask("Wall", "Object");
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == detect) objects++;
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.layer == detect) objects--;
        }
    }
}