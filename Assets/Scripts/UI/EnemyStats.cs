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

        [field: SerializeField] public PartyController Party { get; private set; }
        [SerializeField] EnemyAIController ai;

        [SerializeField] Transform uiHolder;

        [SerializeField] HealthBarUI hBar;
        [SerializeField] StaminaBarUI sBar;
        [SerializeField] DamageText dText;

        [SerializeField] Cooldown Timer;

        private void Awake()
        {
            Party = GetComponentInParent<PartyController>();

            hBar = GetComponentInChildren<HealthBarUI>();
            sBar = GetComponentInChildren<StaminaBarUI>();
            dText = GetComponentInChildren<DamageText>();

            Timer = new Cooldown(showtime, 1f, showtime);
        }

        private void Start()
        {
            ai = Party.GetComponent<EnemyAIController>();

            uiHolder.transform.position =
                Camera.main.WorldToScreenPoint(Party.transform.position +
                height * Vector3.up);

            hBar.InitUI();
            sBar.InitUI();
            dText.InitUI(Party);

            hBar.SubscribeToDelegates();
            sBar.SubscribeToDelegates();

            hBar.gameObject.SetActive(false);
            sBar.gameObject.SetActive(false);
            dText.gameObject.SetActive(false);
        }

        private void Update()
        {
            var visible = Party.GetComponent<EnemyAIController>().InPlayerRange && 
                !Party.GetComponentInChildren<Renderer>().isVisible;

            hBar.gameObject.SetActive(visible && !Party.Dead);
            sBar.gameObject.SetActive(visible && !Party.Dead);
            dText.gameObject.SetActive(visible && !Party.Dead && !Timer.Full);

            uiHolder.transform.position = Vector3.MoveTowards(uiHolder.transform.position,
                Camera.main.WorldToScreenPoint(Party.transform.position +
                height * Vector3.up), updateSpeed * Time.unscaledDeltaTime);

            Timer.TickUnscaled();

            //if (!Timer.Full)
            //{
            //    Timer.TickUnscaled();

            //    if (Timer.Full)
            //        dText.gameObject.SetActive(false);
            //}
        }

        private void OnEnable()
        {
            hBar.SubscribeToDelegates();
        }

        private void OnDisable()
        {
            hBar.UnsubscribeFromDelegates();
        }
    }
}