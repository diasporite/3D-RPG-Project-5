using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class CameraFocus : MonoBehaviour
    {
        float height = 1f;

        [field: SerializeField] public Transform Model { get; private set; }
        [field: SerializeField] public Transform Focus { get; private set; }

        PartyController party;

        private void Awake()
        {
            party = GetComponentInParent<PartyController>();
        }

        private void Start()
        {
            Focus = party.TargetSphere.TargetFocus.transform;
        }

        private void Update()
        {
            if (Model != null && Focus != null)
            {
                if (party.TargetSphere.Locked)
                    transform.position = Focus.transform.position;
                else transform.position = Model.transform.position + height * Model.transform.up;
            }
        }

        private void OnEnable()
        {
            party.OnCharacterChange += UpdateModelPos;
        }

        private void OnDisable()
        {
            party.OnCharacterChange -= UpdateModelPos;
        }

        void UpdateModelPos()
        {
            if (party.CurrentController.Model != null)
                Model = party.CurrentController.Model.transform;
        }
    }
}