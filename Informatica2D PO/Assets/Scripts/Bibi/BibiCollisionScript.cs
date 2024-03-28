using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class BibiCollisionScript : MonoBehaviour
{

    [SerializeField]
    BibiScript bibiScript;

    internal bool isOnGround;
    internal bool isOnBobo;

    [SerializeField] private float groundCheckRadius;

    [SerializeField] private LayerMask groundCheckLayerMask;
    [SerializeField] private LayerMask pickUpAbleBlock;
    [SerializeField] private LayerMask boboCheckLayerMask;

    [SerializeField] private Transform groundCheckPoint;

    [SerializeField] private float rayCastDistance = 0.55f;

    internal bool isNearLadder;

    internal bool rightObject;
    internal bool leftObject;
    internal bool upObject;
    internal bool downObject;

    public bool isInBibiPortal;

    // Start is called before the first frame update
    void Start()
    {
        isInBibiPortal = false;
    }

    private void Update()
    {
        if (bibiScript.StateManager() == "CLIMBING")
        {
            Physics2D.IgnoreLayerCollision(8, 6, true);
        }
        else { Physics2D.IgnoreLayerCollision(8, 6, false); }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        isOnGround = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundCheckLayerMask | pickUpAbleBlock);
        isOnBobo = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, boboCheckLayerMask);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == bibiScript.spike)
        {
            bibiScript.logicScript.HandlePlayerDeath(this.gameObject);
        }

        if (collision.gameObject == bibiScript.water)
        {
            bibiScript.logicScript.HandlePlayerDeath(this.gameObject);
        }

        if (collision.gameObject == bibiScript.enemy)
        {
            bibiScript.logicScript.HandlePlayerDeath(this.gameObject);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject gameObject = collision.gameObject;
        if (collision.gameObject == bibiScript.ladder)
        {
            isNearLadder = true;
        }

        if (collision.gameObject.tag == "BibiTokens")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "BibiPortal")
        {
            isInBibiPortal = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == bibiScript.ladder)
        {
            isNearLadder = false;
        }
        if (collision.gameObject.tag == "BibiPortal")
        {
            isInBibiPortal = false;
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
