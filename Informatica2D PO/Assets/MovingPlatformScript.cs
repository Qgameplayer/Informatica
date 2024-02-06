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

    public void movingPlatform()
    {
        if (transform.position.y < -0,3) 
            {
            transform.Translate(0, 0.05f, 0);
        }

    }

    void Update()
    {
        movingPlatform();
    }
}
