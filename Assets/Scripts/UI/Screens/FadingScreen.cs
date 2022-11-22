using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RPG_Project
{
    public class FadingScreen : MonoBehaviour
    {
        float fadeTime = 0.4f;

        CanvasGroup canvasGroup;
        Image image;

        private void Awake()
        {
            canvasGroup = GetComponentInChildren<CanvasGroup>();
            image = GetComponentInChildren<Image>();

            canvasGroup.alpha = 0;
        }

        public IEnumerator FadeCo(float a0, float a1, Color screenColour)
        {
            float t = 0;
            float speed = 1 / fadeTime;

            image.color = screenColour;

            canvasGroup.alpha = a0;

            while (t < 1)
            {
                t += speed * Time.deltaTime;
                canvasGroup.alpha = t;
                yield return null;
            }

            canvasGroup.alpha = a1;
        }

        public IEnumerator FadeTo(float a, Color screenColour)
        {
            float t = 0;
            float speed = 1 / fadeTime;
            float start_alpha = canvasGroup.alpha;

            image.color = screenColour;

            while (t < 1)
            {
                t += speed * Time.deltaTime;
                canvasGroup.alpha = Mathf.Lerp(start_alpha, a, t);
                yield return null;
            }

            canvasGroup.alpha = a;
        }
    }
}