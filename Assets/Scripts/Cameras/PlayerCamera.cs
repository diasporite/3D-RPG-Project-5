using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class PlayerCamera : MonoBehaviour
    {
        protected PlayerCameraController pcc;

        protected virtual void Awake()
        {
            pcc = GetComponentInParent<PlayerCameraController>();
        }

        protected virtual void Move(Vector2 inputDir)
        {

        }
    }
}