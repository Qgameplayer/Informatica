using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BibiCollisionScript : MonoBehaviour
{

    [SerializeField]
    BibiScript bibiScript;

    internal bool isOnGround;
    internal bool isOnBobo;

    [SerializeField] private float groundCheckRadius;
    [SerializeField] private LayerMask groundCheckLayerMask;

    [SerializeField] private LayerMask boboCheckLayerMask;
    [SerializeField] private Transform groundCheckPoint;

    [SerializeField] private float rayCastDistance = 0.55f;

    internal bool isNearLadder;

    internal bool rightObject;
    internal bool leftObject;
    internal bool upObject;
    internal bool downObject;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isOnGround = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundCheckLayerMask);
        isOnBobo = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, boboCheckLayerMask);

        //upObject = Physics2D.Raycast(transform.position, transform.up, rayCastDistance, groundCheckLayerMask | boboCheckLayerMask);
        downObject = Physics2D.Raycast(transform.position, transform.up * -1, rayCastDistance, groundCheckLayerMask | boboCheckLayerMask);
        rightObject = Physics2D.Raycast(transform.position, transform.right, rayCastDistance, groundCheckLayerMask | boboCheckLayerMask);
        leftObject = Physics2D.Raycast(transform.position, transform.right * -1, rayCastDistance, groundCheckLayerMask | boboCheckLayerMask);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == bibiScript.spike)
        {
            bibiScript.logicScript.HandlePlayerDeath();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == bibiScript.ladder)
        {
            isNearLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == bibiScript.ladder)
        {
            isNearLadder = false;
        }
    }

    internal bool CanMoveRight()
    {
        if(Physics2D.Raycast(transform.position + new Vector3 (0, .5f, 0), transform.right, rayCastDistance, groundCheckLayerMask | boboCheckLayerMask) || Physics2D.Raycast(transform.position - new Vector3 (0, .5f, 0), transform.right, rayCastDistance, groundCheckLayerMask | boboCheckLayerMask)){
            return false;
        }
        else { return true; }
    }

    internal bool CanMoveLeft()
    {
        if(Physics2D.Raycast(transform.position + new Vector3(0, .5f, 0), transform.right * -1, rayCastDistance, groundCheckLayerMask | boboCheckLayerMask) || Physics2D.Raycast(transform.position - new Vector3(0, .5f, 0), transform.right * -1, rayCastDistance, groundCheckLayerMask | boboCheckLayerMask))
        {
            return false;
        }
        else { return true; }
    }

    internal bool CanMoveUp()
    {
        if (Physics2D.Raycast(transform.position + new Vector3(.5f, 0, 0), transform.up, rayCastDistance, groundCheckLayerMask | boboCheckLayerMask) || Physics2D.Raycast(transform.position - new Vector3(.5f, 0, 0), transform.up, rayCastDistance, groundCheckLayerMask | boboCheckLayerMask))
        {
            return false;
        }
        else { return true; }
    }

    internal bool CanMoveDown()
    {
        if (Physics2D.Raycast(transform.position + new Vector3(.5f, 0, 0), transform.up * -1, rayCastDistance, groundCheckLayerMask | boboCheckLayerMask) || Physics2D.Raycast(transform.position - new Vector3(.5f, 0, 0), transform.up * -1, rayCastDistance, groundCheckLayerMask | boboCheckLayerMask))
        {
            return false;
        }
        else { return true; }
    }

}
