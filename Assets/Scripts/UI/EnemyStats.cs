using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class EnemyStats : MonoBehaviour
    {
        [SerializeField] float showtime = 6f;
        [SerializeField] float height = 1.5f;
        [SerializeField] float updateSpeed = 250f;

        [SerializeField] PartyController party;
        [SerializeField] EnemyAIController ai;

        [SerializeField] Transform uiHolder;

        [SerializeField] HealthBar hBar;
        [SerializeField] StaminaBar sBar;
        [SerializeField] DamageText dText;

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
            ai = party.GetComponent<EnemyAIController>();

            uiHolder.transform.position =
                Camera.main.WorldToScreenPoint(party.transform.position +
                height * Vector3.up);

            hBar.InitUI(party);
            sBar.InitUI(party);
            dText.InitUI(party);

            hBar.gameObject.SetActive(false);
            sBar.gameObject.SetActive(false);
            dText.gameObject.SetActive(false);
        }

        private void Update()
        {
            var visible = party.GetComponent<EnemyAIController>().InPlayerRange && 
                !party.GetComponentInChildren<Renderer>().isVisible;

            hBar.gameObject.SetActive(visible && !party.Dead);
            sBar.gameObject.SetActive(visible && !party.Dead);
            dText.gameObject.SetActive(visible && !party.Dead && !Timer.Full);

            uiHolder.transform.position = Vector3.MoveTowards(uiHolder.transform.position,
                Camera.main.WorldToScreenPoint(party.transform.position +
                height * Vector3.up), updateSpeed * Time.unscaledDeltaTime);

            Timer.TickUnscaled();

            //if (!Timer.Full)
            //{
            //    Timer.TickUnscaled();

            //    if (Timer.Full)
            //        dText.gameObject.SetActive(false);
            //}
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