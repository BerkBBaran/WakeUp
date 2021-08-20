using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D playerRB;
    public Animator playerAnimator;
    public float moveSpeed = 1f;
    

    private bool facingRight = true;

    Vector2 movement;


    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        //playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //Face Animation

        //Left Right

        if (playerRB.velocity.x < 0 && facingRight)
        {
            FlipFace();
        }
        else if (playerRB.velocity.x > 0 && !facingRight)
        {
            FlipFace();
        }

        //Top Down

        if (playerRB.velocity.x < 0 && facingRight)
        {
            //TurnTop();
        }
        else if (playerRB.velocity.x > 0 && !facingRight)
        {
            //TurnDown();
        }


    }

    private void FixedUpdate()
    {
        playerRB.MovePosition(playerRB.position + movement  * moveSpeed);
    }

    private void FlipFace()
    {

    }
}
