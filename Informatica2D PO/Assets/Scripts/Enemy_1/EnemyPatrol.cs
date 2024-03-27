using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private GameObject EnemyPointA;
    private GameObject EnemyPointB;
    private Rigidbody2D rb;
    private Animator anim;
    private Transform currentPoint;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {

        EnemyPointA = GameObject.FindGameObjectWithTag("EPA");
        EnemyPointB = GameObject.FindGameObjectWithTag("EPB");

        if (EnemyPointA == null || EnemyPointB == null)
        {
            Debug.LogError("Could not find enemy points with tags EPA and EPB.");
        }

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentPoint = EnemyPointB.transform;
        anim.SetBool("isRunning", true);


    }


    // Update is called once per frame
    void Update()
    {
        Vector2 point = currentPoint.position - transform.position;
        if (currentPoint == EnemyPointB.transform)
        {
            rb.velocity = new Vector2(speed, 0);
        } else {
            rb.velocity = new Vector2(-speed, 0);
        }

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == EnemyPointB.transform)
        {
            flip();
            currentPoint = EnemyPointA.transform;
        }

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == EnemyPointA.transform)
        {
;           flip();
            currentPoint = EnemyPointB.transform;
        }
    }

    private void flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
    
    //private void OnDrawGizmos()
    //{
        //Gizmos.DrawWireSphere(EnemyPointA.transform.position, 0.5f);
        //Gizmos.DrawWireSphere(EnemyPointB.transform.position, 0.5f);
        //Gizmos.DrawLine(EnemyPointA.transform.position, EnemyPointB.transform.position);
    //}

}
