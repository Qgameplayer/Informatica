using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

public class BibiMovementScript : MonoBehaviour
{

    [SerializeField]
    BibiScript bibiScript;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpHeight;

    [SerializeField] private float climbSpeedY;
    [SerializeField] private float climbSpeedX;

    Vector2 moveDirection;
    Vector2 location;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {
        if (bibiScript.stateManager() == "CLIMBING")
        {

            bibiScript.rb.gravityScale = 0;
            bibiScript.rb.velocity = Vector2.zero;
            //transform.position = new Vector3(bibiScript.ladder.transform.position.x, transform.position.y, transform.position.z);

            if (bibiScript.bibiInputScript.isUpPressed && bibiScript.bibiCollisionScript.CanMoveUp())
            {
                ClimbUp();
            }

            if (bibiScript.bibiInputScript.isDownPressed && bibiScript.bibiCollisionScript.CanMoveDown())
            {
                ClimbDown();
            }

            if (bibiScript.bibiInputScript.isLeftPressed && bibiScript.bibiCollisionScript.CanMoveLeft())
            {
                ClimbLeft();
            }

            if (bibiScript.bibiInputScript.isRightPressed && bibiScript.bibiCollisionScript.CanMoveRight())
            {
                ClimbRight();
            }
        }
    }

    void FixedUpdate()
    {
        switch (bibiScript.stateManager())
        {
            case "MOVING":
            case "JUMPING":
            case "IDLE":
                bibiScript.rb.gravityScale = 4;

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

                if (bibiScript.stateManager() == "JUMPING")
                {
                    Jump();
                }
                break;
        }
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

    private void ClimbDown()
    {
        bibiScript.bibi.transform.position += new Vector3(0, -climbSpeedY * Time.deltaTime, 0);
    }
    private void ClimbUp()
    {
        bibiScript.bibi.transform.position += new Vector3(0, climbSpeedY * Time.deltaTime, 0);
    }

    private void ClimbLeft()
    {
        bibiScript.bibi.transform.position += new Vector3(-climbSpeedX * Time.deltaTime, 0, 0);
    }

    private void ClimbRight()
    {
        bibiScript.bibi.transform.position += new Vector3(climbSpeedX * Time.deltaTime, 0, 0);
    }


}

