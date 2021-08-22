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
    public Color speakerColor = Color.white;

    [TextArea(3, 10)]
    public string text;
}



//Vector2 movement;

//HeartRateMonitor heartRateMonitor;

//void Start()
//{
//    playerRB = GetComponent<Rigidbody2D>();
//    myRender = GetComponent<SpriteRenderer>();


//    //playerAnimator = GetComponent<Animator>();
//    heartRateMonitor = FindObjectOfType<HeartRateMonitor>();
//}

//void Update()
//@ -93,6 + 95,12 @@ public class PlayerController : MonoBehaviour
//    private void FixedUpdate()
//{
//    playerRB.MovePosition(playerRB.position + movement * moveSpeed);

//    if (heartRateMonitor != null)
//    {
//        // only in level 3 - run to die level
//        heartRateMonitor.CalculateHeartRate(movement.sqrMagnitude);
//    }
//}


