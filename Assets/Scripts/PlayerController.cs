using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D playerRB;
    public Animator playerAnimator;
    public float moveSpeed = 1f;

    //private components
    SpriteRenderer myRender;

    private bool facingRight = false;
    private bool facingLeft = false;
    private bool facingDown = false;

    Vector2 movement;


    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        myRender = GetComponent<SpriteRenderer>();
        
        //playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //Face Animation

        //Left Right

        if (Math.Abs(movement.x) < 0.01 && Math.Abs(movement.y) < 0.01 && !facingDown)
        {
            LookDown();
        }
        
        else if (movement.x < 0 && !facingLeft)
        {
            TurnLeft();
        }
        else if ( movement.x > 0 && !facingRight)
        {
            TurnRight();
        }
        else if ((Math.Abs(movement.y) > 0.01) && !facingRight && (Math.Abs(movement.x) < 0.01))
        {
            TurnRight();
        }




    }

    private void LookDown()
    {
        playerAnimator.SetBool("isWalking",false);

        facingDown = true;
        facingRight = false;
        facingLeft = false;
    }

    private void TurnLeft()
    {
       
        playerAnimator.SetBool("isWalking", true);
        myRender.flipX = false;

        facingDown = false;
        facingRight = false;
        facingLeft = true;
    }
    private void TurnRight()
    {
        
        playerAnimator.SetBool("isWalking", true);
        myRender.flipX = true;

        facingDown = false;
        facingRight = true;
        facingLeft = false;
    }

    private void FixedUpdate()
    {
        playerRB.MovePosition(playerRB.position + movement * moveSpeed);
    }

    //Face Directions

}
