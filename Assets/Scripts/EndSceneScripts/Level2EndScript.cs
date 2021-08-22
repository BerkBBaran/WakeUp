using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2EndScript : MonoBehaviour
{
    //set in unity editor
    private Goal goal;

    //trigger
    private bool isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {   
        //find with name !!!!!!!
        goal = GameObject.Find("GoalBeher").GetComponent<Goal>();
    }

    // Update is called once per frame


    void Update()
    {   

        //requireds items bittiginde kod bir kere calisiyor
        if(goal.requiredItems.Count == 0 && !isGameOver)
        {
            //Game Over
            Debug.Log("Game Over");
            Debug.Log(gameObject.name);
            isGameOver = true;
        }
    }

}
