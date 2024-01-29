using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BibiInputScript : MonoBehaviour
{

    [SerializeField]
    BibiScript bibiScript;

    internal bool isLeftPressed;
    internal bool isRightPressed;
    internal bool isUpPressed;
    internal bool isDownPressed;
    internal bool isDoubleDownPressed;

    [SerializeField] private KeyCode left;
    [SerializeField] private KeyCode right;
    [SerializeField] private KeyCode up;
    [SerializeField] private KeyCode down;

    private float lastPressTime;
    [SerializeField] internal float doublePressTimeThreshold = 0.2f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(left))
        {
            isLeftPressed = true;
        }
        else { isLeftPressed = false; }

        if (Input.GetKey(right))
        {
            isRightPressed = true;
        }
        else { isRightPressed = false; }

        if (Input.GetKey(up))
        {
            isUpPressed = true;
        }
        else { isUpPressed = false; }

        if (Input.GetKey(down))
        {
            isDownPressed = true;
        }
        else { isDownPressed = false; }

        if (Input.GetKeyDown(down))
        {
            float currentTime = Time.time;

            if (currentTime - lastPressTime < doublePressTimeThreshold)
            {
                isDoubleDownPressed = true;
            }

            lastPressTime = currentTime;
        }
        else { isDoubleDownPressed = false; }

    }

}
