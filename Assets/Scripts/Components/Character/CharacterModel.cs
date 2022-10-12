using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class CharacterModel : MonoBehaviour
    {
        float rotationSpeed = 720f;
        float animFadeTime = 0.15f;

        public Animator Anim { get; private set; }

        Camera main;

        PartyController party;

        private void Awake()
        {
            Anim = GetComponent<Animator>();

            party = GetComponentInParent<PartyController>();
        }

        private void Start()
        {
            main = Camera.main;

            rotationSpeed = GetComponentInParent<Movement>().RotationSpeed;
        }

        public void Rotation(float eulerY)
        {
            transform.localRotation = Quaternion.Euler(0, eulerY, 0);
        }

        public void RotateTowards(float eulerY)
        {
            transform.localRotation = Quaternion.RotateTowards(transform.localRotation,
                Quaternion.Euler(0, eulerY, 0), rotationSpeed * Time.deltaTime);
        }

        public void RotateTowards(Vector2 inputDir)
        {
            if (inputDir != Vector2.zero)
            {
                var rotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg;

                transform.localRotation = Quaternion.RotateTowards(transform.localRotation,
                    Quaternion.Euler(0, rotation, 0), rotationSpeed * Time.deltaTime);
            }
        }

        public void RotateTowards(Vector2 inputDir, float camTheta)
        {
            if (inputDir != Vector2.zero)
            {
                var rotation = 180f - camTheta + Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg;

                transform.localRotation = Quaternion.RotateTowards(transform.localRotation,
                    Quaternion.Euler(0, rotation, 0), rotationSpeed * Time.deltaTime);
            }
        }

        public void RotateTowards(Vector3 dir)
        {
            if (dir != Vector3.zero)
            {
                //var rotation = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;

                transform.localRotation = Quaternion.RotateTowards(transform.localRotation,
                    Quaternion.LookRotation(dir), rotationSpeed * Time.deltaTime);
            }
        }

        public void RotateTowardsTarget(Quaternion partyRot, Transform target)
        {
            if (target == null) return;

            var dir = target.position - transform.position;
            dir.y = 0;

            transform.localRotation = Quaternion.RotateTowards(transform.localRotation, 
                Quaternion.LookRotation(partyRot * dir), rotationSpeed * Time.deltaTime);
        }

        public void ResetRotation()
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }

        public void PlayAnimation(int hash)
        {
            Anim.CrossFadeInFixedTime(hash, animFadeTime, 0);
        }

        public void PlayAnimationInstant(int hash)
        {
            Anim.Play(hash, 0, 0f);
        }

        public void SetFloat(string name, float value)
        {
            Anim.SetFloat(name, value);
        }
    }
}