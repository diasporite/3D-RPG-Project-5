using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    [CreateAssetMenu(fileName = "New Character", menuName = "Combat/Character")]
    public class CharData : ScriptableObject
    {
        [field: Header("Basic Info")]
        [field: SerializeField] public string CharName { get; private set; }

        [field: SerializeField] public Sprite Portrait { get; private set; }

        [field: Header("Movement")]
        [field: SerializeField] public float WalkSpeed { get; private set; } = 2f;
        [field: SerializeField] public float RunSpeed { get; private set; } = 4f;
        [field: SerializeField] public float StrafeSpeed { get; private set; } = 1.5f;

        [field: Header("Regen")]
        [field: SerializeField] public float HealthRegen { get; private set; } = 1f;
        [field: SerializeField] public float StaminaRegen { get; private set; } = 15f;
        [field: SerializeField] public float PowerRegen { get; private set; } = 0.05f;

        [field: Header("Stats")]
        [field: SerializeField] public int Health { get; private set; } = 50;
        [field: SerializeField] public int Stamina { get; private set; } = 50;
        [field: SerializeField] public int Power { get; private set; } = 50;
        [field: Range(0, 255)]
        [field: SerializeField] public int Weight { get; private set; } = 128;

        [field: Header("Actions")]
        [field: SerializeField] public DodgeActionData DodgeAction { get; private set; }

        [field: Tooltip("Index in array corresponds to action hash.")]
        [field: SerializeField] public ActionData[] CombatActions { get; private set; }
    }
}