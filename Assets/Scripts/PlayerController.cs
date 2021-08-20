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

    private bool facingLeft = false;
    private bool facingRight = true;
    private bool facingTop = false;
    private bool facingDown = false;

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

        if (movement.x < 0 && !facingLeft)
        {
            TurnLeft();
        }
        else if (movement.x > 0 && !facingRight)
        {
            TurnRight();
        }

        //Top Down

        else if (movement.y < 0 && !facingDown)
        {
            TurnTop();
        }
        else if (movement.y > 0 && !facingTop)
        {
            TurnDown();
        }


    }
    private void FixedUpdate()
    {
        playerRB.MovePosition(playerRB.position + movement * moveSpeed);
    }

    //Face Directions
    private void TurnDown()
    {
        facingLeft = false;
        facingRight = false;
        facingTop = false;
        facingDown = true;

    }
    private void TurnTop()
    {
        facingLeft = false;
        facingRight = false;
        facingTop = true;
        facingDown = false;
    }

    private void TurnLeft()
    {
        facingLeft = true;
        facingRight = false;
        facingTop = false;
        facingDown = false;
    }
    private void TurnRight()
    {
        facingLeft = false;
        facingRight = true;
        facingTop = false;
        facingDown = false;
    }
}
