using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeScript : MonoBehaviour
{

    BibiScript bibiScript;
    [SerializeField] private GameObject bibi;

    LogicScript logicScript;
    [SerializeField] private GameObject logic;

    private void Start()
    {
        bibiScript = bibi.GetComponent<BibiScript>();
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
