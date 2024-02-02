using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BibiPortalScript : MonoBehaviour
{

    public bool isPortalActivated = false;

    private SpriteRenderer m_SpriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        m_SpriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("BibiTokens").Length == 0)
        {
            isPortalActivated = true;
        }
        else
        {
            isPortalActivated = false;
        }

        if (isPortalActivated)
        {
            m_SpriteRenderer.color = Color.green;
        }
    }
}
