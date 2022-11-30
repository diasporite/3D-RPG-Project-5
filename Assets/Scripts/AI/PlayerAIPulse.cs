using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class PlayerAIPulse : MonoBehaviour
    {
        [SerializeField] float speed = 7f;
        [SerializeField] float maxRadius = 8f;

        float radius;
        Vector3 scale = new Vector3(0f, 2f, 0f);

        private void Start()
        {
            transform.localScale = scale;
        }

        private void Update()
        {
            radius += speed * Time.deltaTime;

            if (radius >= maxRadius)
                Destroy(gameObject);

            scale.x = radius;
            scale.z = radius;

            transform.localScale = scale;
        }

        private void OnTriggerEnter(Collider other)
        {
            var ai = other.GetComponent<EnemyAIController>();

            if (ai != null)
            {
                // Increment attack count on EnemyAIController

                Destroy(gameObject);
            }
        }
    }
}