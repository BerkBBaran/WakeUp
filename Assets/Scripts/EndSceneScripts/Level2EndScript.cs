using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2EndScript : MonoBehaviour
{

    private Goal goal;

    //trigger
    private bool isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        goal = FindObjectOfType<Goal>();
    }

    // Update is called once per frame


    void Update()
    {   

        //requireds items bittiginde kod bir kere calisiyor
        if(goal.requiredItems.Count == 0 && !isGameOver)
        {
            //Game Over
            Debug.Log("Game Over");
            isGameOver = true;
        }
    }

}
