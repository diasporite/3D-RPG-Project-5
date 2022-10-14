using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class EnemyStats : MonoBehaviour
    {
        [SerializeField] PartyController party;

        [SerializeField] Transform uiHolder;

        [SerializeField] HealthBar hBar;
        [SerializeField] StaminaBar sBar;
        [SerializeField] DamageText dText;

        [SerializeField] float showtime = 6f;
        [SerializeField] float height = 1.5f;

        [SerializeField] Cooldown Timer;

        private void Awake()
        {
            party = GetComponentInParent<PartyController>();

            hBar = GetComponentInChildren<HealthBar>();
            sBar = GetComponentInChildren<StaminaBar>();
            dText = GetComponentInChildren<DamageText>();

            Timer = new Cooldown(showtime, 1f, showtime);
        }

        private void Start()
        {
            uiHolder.transform.position =
                Camera.main.WorldToScreenPoint(party.transform.position +
                height * Vector3.up);

            hBar.InitUI(party);
            sBar.InitUI(party);
            dText.InitUI(party);

            //hBar.gameObject.SetActive(false);
            //sBar.gameObject.SetActive(false);
            dText.gameObject.SetActive(false);
        }

        private void Update()
        {
            uiHolder.transform.position = Vector3.Lerp(uiHolder.transform.position,
    Camera.main.WorldToScreenPoint(party.transform.position +
    height * Vector3.up), 0.8f);

            //uiHolder.transform.position = Vector3.MoveTowards(uiHolder.transform.position,
            //    Camera.main.WorldToScreenPoint(party.transform.position +
            //    height * Vector3.up), 250f * Time.deltaTime);

            if (!Timer.Full)
            {
                Timer.Tick();

                if (Timer.Full)
                {
                    //hBar.gameObject.SetActive(false);
                    //sBar.gameObject.SetActive(false);

                    dText.gameObject.SetActive(false);
                }
            }
        }

        public void OnDamage(int hChange, int sChange)
        {
            ShowHealthBar(hChange);
            ShowStaminaBar(sChange);
        }

        void ShowHealthBar(int change)
        {
            Timer.Reset();

            hBar.gameObject.SetActive(true);
            dText.gameObject.SetActive(true);

            dText.UpdateDamage(change);
        }

        void ShowStaminaBar(int change)
        {
            if (change > 0 && hBar.gameObject.activeSelf)
                sBar.gameObject.SetActive(true);
        }
    }
}