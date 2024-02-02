using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobocollisionScript : MonoBehaviour
{

    [SerializeField]
    internal BoboScript boboScript;

    

    [SerializeField] private Transform groundCheckPoint;
    [SerializeField] internal bool isOnJumpAbleGround;
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private LayerMask groundCheckLayerMask;
    [SerializeField] private LayerMask waterLayerMask;
    [SerializeField] private LayerMask bibiCheckLayerMask;
    [SerializeField] private LayerMask pickUpAbleBlock;
    [SerializeField] private bool isOnBibi;

    public bool isInBoboPortal;
    // Start is called before the first frame update
    void Start()
    {
        isInBoboPortal = false;
    }


    // Update is called once per frame
    private void FixedUpdate()
    {
        isOnJumpAbleGround = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundCheckLayerMask | waterLayerMask | pickUpAbleBlock);
        isOnBibi = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, bibiCheckLayerMask);

        if (isOnBibi)
        {
            boboScript.logicScript.HandlePlayerDeath(boboScript.bibi);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BoboTokens")
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "BoboPortal")
        {
            isInBoboPortal = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BoboPortal")
        {
            isInBoboPortal = false;
        }
    }
}
