using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    //set in unity editor
    public Transform idleTransform;

    public float topBorder;
    public float botBorder;
    public float leftBorder;
    public float rightBorder;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {   
        // with clamp camera cant pass borders
        transform.position = new Vector3(Mathf.Clamp(idleTransform.position.x, leftBorder, rightBorder), Mathf.Clamp(idleTransform.position.y, botBorder, topBorder), -10);

    }

}
