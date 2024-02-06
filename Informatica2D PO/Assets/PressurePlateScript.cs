using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateScript : MonoBehaviour
{
    public Vector3 originalPos; 
    bool moveBack = false;
    internal GameObject MovingPlatform;


    private void Start () { 
    originalPos = transform.position;
    Platform = GameObject.FindWithTag("MovingPlatform");
    }

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.name == "Bobo")
        {
            collision.transform.parent = transform;
            GetComponent<SpriteRenderer>().color = Color.red;
        }

        
    }
    private void OnCollisionStay2D(Collision2D collision)
    {

       
        if (collision.transform.name == "Bobo" && transform.position.y  > -4.6f)
        {
        
            transform.Translate(0, -0.01f, 0);
            
            
            moveBack = false;
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.name == "Bobo")
        {
            collision.transform.parent = null;
            moveBack = true;
            GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
    private void Update()
    {
        if (moveBack)
        {
            if (transform.position.y < originalPos.y) {
                transform.Translate(0, 0.01f, 0);
            }
            else
            {
                moveBack = false;
            }
        }
    }
}
