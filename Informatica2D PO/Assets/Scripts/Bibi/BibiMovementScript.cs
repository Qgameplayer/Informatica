using System.Runtime.CompilerServices;
using UnityEngine;

public class BibiMovementScript : MonoBehaviour
{

    [SerializeField]
    BibiScript bibiScript;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpHeight;

    [SerializeField] private float climbSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bibiScript.bibiInputScript.isLeftPressed)
        {
            MoveBibiLeft();
        }
        else if (bibiScript.bibiInputScript.isRightPressed)
        {
            MoveBibiRight();
        }
        else
        {
            StopMovement();
        }

        if (bibiScript.bibiInputScript.isUpPressed && (bibiScript.bibiCollisionScript.isOnGround || bibiScript.bibiCollisionScript.isOnBobo))
        {
            Jump();
        }

        if (bibiScript.isClimbing)
        {
            bibiScript.rb.gravityScale = 0;
        }
        else { bibiScript.rb.gravityScale = 5; }
    }

    private void MoveBibiLeft()
    {
        bibiScript.rb.velocity = new Vector2(-moveSpeed, bibiScript.rb.velocity.y);
    }

    private void MoveBibiRight()
    {
        bibiScript.rb.velocity = new Vector2(moveSpeed, bibiScript.rb.velocity.y);
    }

    private void StopMovement()
    {
        bibiScript.rb.velocity = new Vector2(0, bibiScript.rb.velocity.y);
    }

    private void Jump()
    {
        bibiScript.rb.velocity = new Vector2(bibiScript.rb.velocity.x, jumpHeight);
    }

    internal void ClimbUp()
    {
        bibiScript.rb.velocity = new Vector2(bibiScript.rb.velocity.x, climbSpeed);
    }

    internal void ClimbDown()
    {
        bibiScript.rb.velocity = new Vector2(bibiScript.rb.velocity.x, -climbSpeed);
    }
}
