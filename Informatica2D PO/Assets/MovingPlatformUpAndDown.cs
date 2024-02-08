using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformUpAndDown : MonoBehaviour
{
    private bool movingUp = true;

    private void MovingPlatformUp()
    {
        StartCoroutine(MoveUp());
    }

    IEnumerator MoveUp()
    {
        while (transform.position.y < -0.01f)
        {
            transform.Translate(0, 0.01f, 0);
            yield return null; // Wacht op het volgende frame voordat de loop opnieuw wordt gecontroleerd
        }
    }
        private void MovingPlatformDown()
        {
            StartCoroutine(MoveDown());
        }

        IEnumerator MoveDown()
        {
            while (transform.position.y > -3.87f)
            {
                transform.Translate(0, -0.01f, 0);
                yield return null; // Wacht op het volgende frame voordat de loop opnieuw wordt gecontroleerd
            }
        }
        // Start is called before the first frame update
        void Start()
    {
        
        }

    // Update is called once per frame
    void Update()
    {
        if (movingUp)
        {
            MovingPlatformUp();

            if (transform.position.y > -0.01f)
            {
                movingUp = false;
            }
        }
        else
        {
            MovingPlatformDown();

            if (transform.position.y <= -3.87f)
            {
                movingUp = true;
            }
        }
    }
}

