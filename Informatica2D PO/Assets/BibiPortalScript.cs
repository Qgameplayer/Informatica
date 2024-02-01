using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BibiPortalScript : MonoBehaviour
{

    [SerializeField] private string layerToCheck;

    private int amountOfTokens;

    public bool isPortalActived = false;

    // Start is called before the first frame update
    void Start()
    {
        amountOfTokens = GameObject.FindGameObjectsWithTag("BibiTokens").Length;

    }

    // Update is called once per frame
    void Update()
    {
        if (amountOfTokens == 0)
        {
            isPortalActived = true;
        }
        else
        {
            isPortalActived = false;
        }
    }
}
