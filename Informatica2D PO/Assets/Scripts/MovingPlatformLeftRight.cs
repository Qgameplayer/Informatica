using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformLeftRight : MonoBehaviour
{
    private bool movingLeft = true;
    private Coroutine currentCoroutine;

    private void MovingPlatformLeft()
    {
        if (currentCoroutine != null)
            StopCoroutine(currentCoroutine);

        currentCoroutine = StartCoroutine(MoveLeft());
    }

    IEnumerator MoveLeft()
    {
        while (transform.position.x > -12.00f)
        {
            transform.Translate(-0.001f, 0, 0);
            yield return null;
        }
    }

    private void MovingPlatformRight()
    {
        if (currentCoroutine != null)
            StopCoroutine(currentCoroutine);

        currentCoroutine = StartCoroutine(MoveRight());
    }

    IEnumerator MoveRight()
    {
        while (transform.position.x < -6.81f)
        {
            transform.Translate(0.001f, 0, 0);
            yield return null;
        }
    }

    void Start()
    {
        // Eventuele initialisatiecode kan hier worden toegevoegd
    }

    void Update()
    {
        if (movingLeft)
        {
            MovingPlatformLeft();

            if (transform.position.x <= -12.00f)
            {
                movingLeft = false;
            }
        }
        else
        {
            MovingPlatformRight();

            if (transform.position.x >= -6.81f)
            {
                movingLeft = true;
            }
        }
    }
}