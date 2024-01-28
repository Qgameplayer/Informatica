using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoboInputScript : MonoBehaviour
{

    [SerializeField]
    BoboScript boboScript;

    internal bool isLeftPressed;
    internal bool isRightPressed;
    internal bool isUpPressed;
    internal bool isDownPressed;

    [SerializeField] private KeyCode left;
    [SerializeField] private KeyCode right;
    [SerializeField] private KeyCode up;
    [SerializeField] private KeyCode down;

    private void Update()
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
    }

}
