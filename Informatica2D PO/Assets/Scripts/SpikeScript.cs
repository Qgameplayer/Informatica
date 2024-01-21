using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpikeScript : MonoBehaviour
{

    BibiScript bibiScript;
    private GameObject bibi;

    LogicScript logicScript;
    private GameObject logic;

    private void Start()
    {
        bibi = GameObject.FindWithTag("Bibi");
        bibiScript = bibi.GetComponent<BibiScript>();

        logic = GameObject.FindWithTag("Logic");
        logicScript = logic.GetComponent<LogicScript>();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == bibi)
        {
            logicScript.HandlePlayerDeath();
        }
    }

}
