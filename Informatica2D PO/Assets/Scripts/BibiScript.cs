using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BibiScript : MonoBehaviour
{


    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpHeight;

    [SerializeField] private KeyCode left;
    [SerializeField] private KeyCode right;
    [SerializeField] private KeyCode jump;

    private Rigidbody2D rb;

    [SerializeField] private Transform groundCheckPoint;

    [SerializeField] private bool isOnGround;
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private LayerMask groundCheckLayerMask;

    [SerializeField] private LayerMask boboCheckLayerMask;
    [SerializeField] private bool isOnBobo;

   // Start is called before the first frame update
   void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       
        MovementManager();
    }

    private void MovementManager()
    {

        isOnGround = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundCheckLayerMask);
        isOnBobo = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, boboCheckLayerMask);

        if (Input.GetKey(left))
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }
        else if (Input.GetKey(right))
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if (Input.GetKey(jump) && (isOnGround || isOnBobo))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        }

    }
 

}
