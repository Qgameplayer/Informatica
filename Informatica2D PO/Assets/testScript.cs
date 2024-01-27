using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testScript : MonoBehaviour
{

    public KeyCode targetKey = KeyCode.Space;
    public float doublePressTimeThreshold = 0.5f;
    private float lastPressTime;
    private void Update()
    {
        if (Input.GetKeyDown(targetKey))
        {
            float currentTime = Time.time;
            
            if (currentTime - lastPressTime < doublePressTimeThreshold)
            {
                Debug.Log("Double press detected!");
            }
            lastPressTime = currentTime;
        }

    }

}
