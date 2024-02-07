using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformScript : MonoBehaviour
{
    public Vector3 originalPos;
    // bool moveBack = false;

    // Start is called before the first frame update
    void Start()
    {
        originalPos = transform.position;
    }

    public void movingPlatformUp()
    {
        if (transform.position.y < -0.3) 
            {
            transform.Translate(0, 0.05f, 0);
        }

    }

  
    public void movingPlatformDown() { 
        while (transform.position.y > -3.87)
        {
            transform.Translate(0, -0.01f, 0);
        }
    }

    void Update()
    {
      
    }
}
