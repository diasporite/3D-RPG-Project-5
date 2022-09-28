using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RPG_Project
{
    public class DamageText : MonoBehaviour
    {
        [SerializeField] PartyController party;

        [SerializeField] Text text;

        [SerializeField] float showtime = 4f;
        [SerializeField] int totalDamage = 0;

        Cooldown Timer;

        private void Awake()
        {
            text = GetComponentInChildren<Text>();

            Timer = new Cooldown(showtime, 0f, 0f);
        }

        private void Update()
        {
            if (Timer.Full)
            {
                Timer.Tick();

                if (Timer.Full) text.gameObject.SetActive(false);
            }
        }

        private void OnEnable()
        {
            totalDamage = 0;

            Timer.Reset();

            text.gameObject.SetActive(true);
        }

        public void InitUI(PartyController party)
        {
            this.party = party;
        }

        public void UpdateDamage(int damage)
        {
            if (damage > 0) return;

            Timer.Reset();
            
            totalDamage += damage;

            if (!text.gameObject.activeSelf)
                text.gameObject.SetActive(true);
            text.text = totalDamage.ToString();
        }
    }
}