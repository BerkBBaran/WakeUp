using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeEffect : MonoBehaviour
{
    public Image fadePanel;

    public float fadeInDuration;
    public float fadeOutDuration;

    Color transparent;
    void Start()
    {
        transparent = new Color(0,0,0,0);
        StartCoroutine(FadeIn(null));
    }

    public void StartFadeOut(Action callback, float duration = 99f)
    {
        if(duration != 99f)
        {
            // use given duration
            fadeOutDuration = duration;
        }
        StartCoroutine(FadeOut(callback));
    }
    public void StartFadeIn(Action callback, float duration = 99f)
    {
        if (duration != 99f)
        {
            // use given duration
            fadeInDuration = duration;
        }
        StartCoroutine(FadeIn(callback));
    }
    IEnumerator FadeIn(Action callback)
    {
        fadePanel.gameObject.SetActive(true);
        float timePassed = 0f;
        while(timePassed <= fadeInDuration)
        {
            timePassed += Time.deltaTime;
            float t = timePassed / fadeInDuration;
            fadePanel.color = Color.Lerp(Color.black, transparent, t);
            yield return null;
        }
        fadePanel.color = transparent;
        fadePanel.gameObject.SetActive(false);

        callback?.Invoke();
    }

    IEnumerator FadeOut(Action callback)
    {
        fadePanel.gameObject.SetActive(true);
        float timePassed = 0f;
        while (timePassed <= fadeOutDuration)
        {
            timePassed += Time.deltaTime;
            float t = timePassed / fadeOutDuration;
            fadePanel.color = Color.Lerp(transparent, Color.black, t);
            yield return null;
        }
        fadePanel.color = Color.black;

        callback?.Invoke();
    }
}
