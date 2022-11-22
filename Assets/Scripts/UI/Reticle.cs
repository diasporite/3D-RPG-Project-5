using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RPG_Project
{
    public class Reticle : MonoBehaviour
    {
        [SerializeField] float rotationSpeed = 120f;

        Image reticle;

        TargetSphere ts;

        Camera main;

        private void Awake()
        {
            reticle = GetComponentInChildren<Image>();

            main = Camera.main;
        }

        private void Update()
        {
            reticle.gameObject.SetActive(ts.CurrentTargetTransform != null);

            if (reticle.gameObject.activeSelf)
            {
                reticle.transform.Rotate(0f, 0f, rotationSpeed * Time.unscaledDeltaTime);

                reticle.transform.position =
                    main.WorldToScreenPoint(ts.CurrentTargetTransform.position);
            }
        }

        public void Init(PartyController party)
        {
            ts = party.TargetSphere;
        }
    }
}