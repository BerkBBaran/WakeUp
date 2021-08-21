using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogController : MonoBehaviour
{
    // UI object references
    public TextMeshProUGUI textDisplay;
    public TextMeshProUGUI speakerName;
    public List<Line> lines;

    // text reveal/writing speed
    public float timeBetweenCharacters = 0.2f;

    // transition time between lines of the dialog
    public float delayBetweenLines = 1.5f;

    // index for current line of the dialog
    private int index = 0;


    private void Start()
    {
        textDisplay.gameObject.SetActive(false);
        speakerName.gameObject.SetActive(false);
        // starts the dialog X secs after scene is loaded.
        // might wanna change this.
        Invoke("StartTyping", 5f);
    }

    // Is also called when the player interacts with the Teddy bear in the scene.
    public void StartTyping()
    {
        textDisplay.gameObject.SetActive(true);
        speakerName.gameObject.SetActive(true);
        ResetDialogue();
        NextSentence();
    }

    public void NextSentence()
    {
        textDisplay.text = "";
        speakerName.text = lines[index].speakerName;
        if (lines[index].hasSoundEffect)
        {
            // play sound effect
        }
        StartCoroutine(Type());
    }
    IEnumerator Type()
    {
        foreach (char letter in lines[index].text.ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(timeBetweenCharacters);
        }
        // written all, wait for delay time, then move on to the next line
        yield return new WaitForSeconds(delayBetweenLines);

        if(index < lines.Count - 1)
        {   // show next sentence
            index++;
            NextSentence();
        }
        else
        {
            // no more lines to show
            textDisplay.text = "";
            index = 0;
        }
    }
    public void ResetDialogue()
    {
        index = 0;
        textDisplay.text = "";
        StopAllCoroutines();
    }
}
