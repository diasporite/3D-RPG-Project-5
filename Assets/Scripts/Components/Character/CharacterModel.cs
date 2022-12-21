using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class CharacterModel : MonoBehaviour
    {
        float rotationSpeed = 720f;
        float animFadeTime = 0.15f;

        [field: SerializeField] public Transform Hips { get; private set; }

        public Animator Anim { get; private set; }

        Camera main;

        PartyController party;

        public float GetNormalizedTime(string tag)
        {
            var currentState = Anim.GetCurrentAnimatorStateInfo(0);
            var nextState = Anim.GetNextAnimatorStateInfo(0);

            if (Anim.IsInTransition(0) && nextState.IsTag(tag))
                return nextState.normalizedTime - Mathf.Floor(nextState.normalizedTime);
            else if (!Anim.IsInTransition(0) && currentState.IsTag(tag))
                return currentState.normalizedTime - Mathf.Floor(currentState.normalizedTime);
            else return 0f;
        }

        private void Awake()
        {
            Anim = GetComponent<Animator>();

            party = GetComponentInParent<PartyController>();
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawRay(transform.position, 5f * transform.forward);
        }

        public void Init(Quaternion rotation)
        {
            main = Camera.main;

            rotationSpeed = GetComponentInParent<Movement>().RotationSpeed;

            if (party.IsPlayer) Anim.updateMode = AnimatorUpdateMode.UnscaledTime;

            transform.rotation = rotation;
        }

        public void SetRotation(float eulerY)
        {
            transform.localRotation = Quaternion.Euler(0, eulerY, 0);
        }

        public void RotationOffset(float dy)
        {
            transform.Rotate(0f, dy, 0f);
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

        public void RotateTowards(Vector3 dir)
        {
            if (dir != Vector3.zero)
            {
                transform.localRotation = Quaternion.RotateTowards(transform.localRotation,
                    Quaternion.LookRotation(dir), rotationSpeed * Time.deltaTime);
            }
        }

        public void PlayerRotateTowards(Vector2 inputDir, Transform camera)
        {
            if (inputDir != Vector2.zero)
            {
                var dx = camera.right;
                dx.y = 0;
                var dy = camera.forward;
                dy.y = 0;

                var ds = inputDir.x * dx + inputDir.y * dy;

                transform.localRotation = Quaternion.RotateTowards(transform.localRotation, 
                    Quaternion.LookRotation(ds), rotationSpeed* Time.unscaledDeltaTime);
            }
        }

        public void RotateTowardsTarget(Quaternion partyRot, Transform target)
        {
            if (target == null) return;

            var dir = target.position - transform.position;
            dir.y = 0;

            transform.localRotation = Quaternion.RotateTowards(transform.localRotation, 
                Quaternion.LookRotation(partyRot * dir), rotationSpeed * Time.unscaledDeltaTime);
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