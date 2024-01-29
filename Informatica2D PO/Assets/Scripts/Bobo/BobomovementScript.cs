using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobomovementScript : MonoBehaviour
{

    [SerializeField]
    BoboScript boboScript;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpHeight;

    // Start is called before the first frame update
    void Start()
    {

    }


    void FixedUpdate()
    {
        if (boboScript.boboInputScript.isLeftPressed)
        {
            MoveBoboLeft();
        }
        else if (boboScript.boboInputScript.isRightPressed)
        {
            MoveBoboRight();
        }
        else
        {
            StopMovement();
        }

        if (boboScript.boboInputScript.isUpPressed && boboScript.boboCollisionScript.isOnGround)
        {
            Jump();
        }
    }

    private void MoveBoboLeft()
    {
        boboScript.rb.velocity = new Vector2(-moveSpeed, boboScript.rb.velocity.y);
    }

    private void MoveBoboRight()
    {
        boboScript.rb.velocity = new Vector2(moveSpeed, boboScript.rb.velocity.y);
    }

    private void StopMovement()
    {
        boboScript.rb.velocity = new Vector2(0, boboScript.rb.velocity.y);
    }

    private void Jump()
    {
        boboScript.rb.velocity = new Vector2(boboScript.rb.velocity.x, jumpHeight);
    }
}
