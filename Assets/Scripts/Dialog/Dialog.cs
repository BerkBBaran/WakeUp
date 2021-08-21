using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialog
{
    public List<Line> lines;
}

[System.Serializable]
public class Line
{
    public bool hasSoundEffect;
    public AudioClip soundEffect;
    public string speakerName;

    [TextArea(3, 10)]
    public string text;
}