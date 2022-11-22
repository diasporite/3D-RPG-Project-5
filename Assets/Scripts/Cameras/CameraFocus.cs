using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class CameraFocus : MonoBehaviour
    {
        [field: SerializeField] public Transform Hips { get; private set; }

        PartyController party;

        private void Awake()
        {
            party = GetComponentInParent<PartyController>();
        }

        private void Update()
        {
            if (Hips != null)
                transform.position = Hips.transform.position;
        }

        private void OnEnable()
        {
            party.OnCharacterChange += UpdateHips;
        }

        private void OnDisable()
        {
            party.OnCharacterChange -= UpdateHips;
        }

        void UpdateHips()
        {
            if (party.CurrentController.Model != null)
                Hips = party.CurrentController.Model.Hips;
        }
    }
}