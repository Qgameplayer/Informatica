using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeScript : MonoBehaviour
{

    BibiScript bibiScript;

    [SerializeField] private GameObject bibi;

    private void Start()
    {
        bibiScript = bibi.GetComponent<BibiScript>();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == bibi)
        {
            Debug.Log(collision);
            bibiScript.BibiDeath();
        }
    }

}
