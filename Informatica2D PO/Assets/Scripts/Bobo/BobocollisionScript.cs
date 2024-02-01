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

    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void Update()
    {
        if (isOnBibi)
        {
            boboScript.logicScript.HandlePlayerDeath();
        }
    }


    // Update is called once per frame
    private void FixedUpdate()
    {
        isOnJumpAbleGround = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundCheckLayerMask | waterLayerMask | pickUpAbleBlock);
        isOnBibi = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, bibiCheckLayerMask);
    }
}
