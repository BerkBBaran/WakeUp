using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level0 : MonoBehaviour
{

    //Reference
    public GameObject character;
    public GameObject JumpOffObject;


    private bool inArea = false;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            if (inArea)
            {
                character.SetActive(false);
                JumpOffObject.SetActive(true);


            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        inArea = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        inArea = false;
    }
}

    
