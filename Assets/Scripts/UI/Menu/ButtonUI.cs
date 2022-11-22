using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace RPG_Project
{
    public class ButtonUI : MonoBehaviour
    {
        [field: SerializeField] public Color Selected { get; private set; } = 
            new Color(0.5f, 0.5f, 0.5f);
        [field: SerializeField] public Color Unselected { get; private set; } = 
            new Color(0f, 0f, 0f);

        [field: SerializeField] public UnityEvent OnPress { get; private set; }

        Image image;

        private void Awake()
        {
            image = GetComponent<Image>();
            image.color = Unselected;
        }

        public void Select()
        {
            if (image != null) image.color = Selected;
        }

        public void Deselect()
        {
            image.color = Unselected;
        }
    }
}