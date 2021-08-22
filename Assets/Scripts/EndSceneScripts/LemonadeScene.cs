using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LemonadeScene : MonoBehaviour
{
    Inventory inventory;
    //Reference
    public GameObject bee;


    //private
    private Rigidbody2D playerRB;


    private void Awake()
    {
        inventory = FindObjectOfType<Inventory>();
    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") )
        {
            if (inventory.item !=null && inventory.item.objectName.Equals("Lemonade"))
            {
                Debug.Log("Scene Over");
                bee.SetActive(true);
                collision.GetComponent<Animator>().enabled = false;
                collision.GetComponent<PlayerController>().enabled = false;
                
                //End Scene (Dead) Animation
                //Go next scene
                Invoke("EndGameWithDelay", 2f);
            }
               
        }
    }
    private void EndGameWithDelay()
    {
        GameManager.Instance.EndLevel();
    }

}
