using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LemonadeScene : MonoBehaviour
{
    private Inventory inventory;

    //Reference
    public GameObject character;
    public GameObject bee;

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
                bee.SetActive(true);

            }
               
        }
    }
}
