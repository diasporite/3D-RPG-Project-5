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

        [field: Header("Stats")]
        [field: Range(0, 255)]
        [field: SerializeField] public int Weight { get; private set; } = 128;

        [field: SerializeField] public ActionData DodgeAction { get; private set; }
    }
}