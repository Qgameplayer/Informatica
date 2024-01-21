using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class BibiScript : MonoBehaviour
{
    LogicScript logicScript;
    private GameObject logic;


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
    private bool isOnBobo;

    private GameObject bibi;
    public Vector2 spawnPos;

    // Start is called before the first frame update
    void Start()
    {
        bibi = GameObject.FindWithTag("Bibi");
        
        rb = GetComponent<Rigidbody2D>();
        spawnPos = transform.position;

        logic = GameObject.FindWithTag("Logic");
        logicScript = logic.GetComponent<LogicScript>();

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

        if (transform.position.y < -5)
        {
            logicScript.HandlePlayerDeath();
        }

    }

    private void ladderClimbing()
    {
        
    }

}
