﻿using System.Collections;
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

        [field: SerializeField] public ElementID Element1 { get; private set; }
        [field: SerializeField] public ElementID Element2 { get; private set; }

        [field: SerializeField] public Character Character { get; private set; }

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

        [field: SerializeField] public int Attack { get; private set; } = 50;
        [field: SerializeField] public int Defence { get; private set; } = 50;

        [field: Range(0, 255)]
        [field: SerializeField] public int Weight { get; private set; } = 128;

        [field: Header("Actions")]
        [field: SerializeField] public DodgeActionData DodgeAction { get; private set; }

        [field: Tooltip("Index in array corresponds to action hash.")]
        [field: SerializeField] public AttackActionData[] CombatActions { get; private set; }

        public string ElementString
        {
            get
            {
                var output = "";

                if (Element1 != ElementID.Typeless) output += Element1.ToString();
                if (Element2 != ElementID.Typeless) output += "/" + Element2.ToString();

                return output;
            }
        }
    }
}