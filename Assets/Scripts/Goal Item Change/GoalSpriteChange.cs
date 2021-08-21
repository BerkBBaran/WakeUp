using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalSpriteChange : MonoBehaviour
{
    //editor
    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;

    private string sprite1String;
    private string sprite2String;

    private int itemCount;

    private Goal goal;
    // Start is called before the first frame update
    void Start()
    {
        sprite1String = goal.requiredItems[0];
        sprite2String = goal.requiredItems[1];
        itemCount = goal.requiredItems.Count;
    }

    private void Awake()
    {
        goal = FindObjectOfType<Goal>();

    }

    // Update is called once per frame
    void Update()
    {
        if(goal.requiredItems.Count < itemCount)
        {   
            if(goal.requiredItems.Count == 0)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = sprite3;
            }
            else if(!(goal.requiredItems.Contains(sprite1String)))
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = sprite1;
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = sprite2;
            }

            itemCount--;
        }
    }









}
