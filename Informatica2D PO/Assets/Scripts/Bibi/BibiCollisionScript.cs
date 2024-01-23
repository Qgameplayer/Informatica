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

    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        isOnGround = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundCheckLayerMask);
        isOnBobo = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, boboCheckLayerMask);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == bibiScript.spike)
        {
            bibiScript.logicScript.HandlePlayerDeath();
        }
    }
}
