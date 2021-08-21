using System.Collections;
using TMPro;
using UnityEngine;

public class Talkable : Pickable
{
    public TextMeshProUGUI overheadText;
    public string playerReactionText;
    public float disappearTime = 3f;

    private void Awake()
    {
        overheadText.text = "";
    }
    public override void OnInteract(PlayerInteraction playerInt)
    {
        // show the item text on interact
        overheadText.gameObject.SetActive(true);
        overheadText.text = playerReactionText;

        StopAllCoroutines();
        StartCoroutine(ShowOverheadText());
    }

    IEnumerator ShowOverheadText()
    {
        yield return new WaitForSeconds(disappearTime);
        overheadText.text = "";
    }
}
