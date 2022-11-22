using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace RPG_Project
{
    public class AreaName : MonoBehaviour
    {
        float fadeTime = 0.5f;

        TextMeshProUGUI text;

        CanvasGroup canvasGroup;

        private void Awake()
        {
            text = GetComponentInChildren<TextMeshProUGUI>();
            canvasGroup = GetComponentInChildren<CanvasGroup>();

            canvasGroup.alpha = 0;
        }

        public void DisplayText(string text, float duration)
        {
            this.text.text = text;

            StartCoroutine(DisplayTextCo(duration));
        }

        IEnumerator DisplayTextCo(float duration)
        {
            float t = 0;
            float speed = 1 / fadeTime;

            canvasGroup.alpha = 0;

            while (t < 1)
            {
                t += speed * Time.deltaTime;
                canvasGroup.alpha = t;
                yield return null;
            }

            canvasGroup.alpha = 1;

            yield return new WaitForSeconds(duration);

            t = 0;

            while (t < 1)
            {
                t += speed * Time.deltaTime;
                canvasGroup.alpha = 1 - t;
                yield return null;
            }

            canvasGroup.alpha = 0;
        }
    }
}