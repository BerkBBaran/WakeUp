using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroAnim : MonoBehaviour
{
    public GameObject animParent;
    public GameObject crashed;

    public float animDuration = 3f;

    bool trigger = false;
    void Start()
    {
        StartCoroutine(AnimPlayer());
    }

    IEnumerator AnimPlayer()
    {
        yield return new WaitForSecondsRealtime(animDuration);

        // eye
        var fade = FindObjectOfType<FadeEffect>();
        animParent.SetActive(false);
        crashed.SetActive(true);

        yield return new WaitForSeconds(5f);
        GameManager.Instance.EndLevel();
    }
}
