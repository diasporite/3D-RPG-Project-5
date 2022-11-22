using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Project
{
    public class BattleHUD : MonoBehaviour
    {
        [field: SerializeField] public CharInfo CharInfo { get; private set; }
        [field: SerializeField] public PartyInfo PartyInfo { get; private set; }
        [field: SerializeField] public ActionInfo ActionInfo { get; private set; }
        
        [field: SerializeField] public Reticle Reticle { get; private set; }

        [field: SerializeField] public PartyController Player { get; private set; }

        public IUIElement[] Elements { get; private set; }

        private void Awake()
        {
            CharInfo = GetComponentInChildren<CharInfo>();
            PartyInfo = GetComponentInChildren<PartyInfo>();
            ActionInfo = GetComponentInChildren<ActionInfo>();

            Reticle = FindObjectOfType<Reticle>();

            Elements = GetComponentsInChildren<IUIElement>();
        }

        private void OnEnable()
        {
            SubscribeToDelegates();
        }

        private void OnDisable()
        {
            UnsubscribeFromDelegates();
        }

        public void InitUI()
        {
            Player = GameManager.instance.Player;

            if (Player == null) return;

            //CharInfo.InitUI(Player);
            //PartyInfo.InitUI(Player);
            //ActionInfo.InitUI(Player);

            Reticle.Init(Player);

            // i = 1 to exclude BattleHUD
            for (int i = 1; i < Elements.Length; i++)
            {
                Elements[i].InitUI();
                Elements[i].SubscribeToDelegates();
            }
        }

        public void UpdateUI()
        {

        }

        public void SubscribeToDelegates()
        {
            if (Player != null)
                for (int i = 1; i < Elements.Length; i++)
                    Elements[i].SubscribeToDelegates();
        }

        public void UnsubscribeFromDelegates()
        {
            if (Player != null)
                for (int i = 1; i < Elements.Length; i++)
                    Elements[i].UnsubscribeFromDelegates();
        }
    }
}