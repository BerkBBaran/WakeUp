using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2EndScript : MonoBehaviour
{
    //set in unity editor
    private Goal goal;

    //trigger
    private bool isGameOver = false;

    private void Awake()
    {   
        //find with name !!!!!!!
        goal = GameObject.Find("GoalBeher").GetComponent<Goal>();
    }

    void Update()
    {   

        //requireds items bittiginde kod bir kere calisiyor
        if(goal.requiredItems.Count == 0 && !isGameOver)
        {
            //Game Over
            Debug.Log("Game Over");
            Debug.Log(gameObject.name);
            isGameOver = true;
            Invoke("EndGameWithDelay", 2f);
        }
    }
    private void EndGameWithDelay()
    {
        GameManager.Instance.EndLevel();
    }
}
