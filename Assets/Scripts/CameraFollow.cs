using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float topBorder;
    public float botBorder;
    public float leftBorder;
    public float rightBorder;


    private Transform playerTransform;
    private void Awake()
    {
        playerTransform = FindObjectOfType<PlayerInteraction>().middlePoint.transform;
    }

    private void Update()
    {   
        // with clamp camera cant pass borders
        transform.position = new Vector3(Mathf.Clamp(playerTransform.position.x, leftBorder, rightBorder), 
                                        Mathf.Clamp(playerTransform.position.y, botBorder, topBorder), 
                                        -10);
    }

}
