using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{

    private GameObject bibi;
    private GameObject bobo;

    // Start is called before the first frame update
    void Start()
    {
        bibi = GameObject.FindWithTag("Bibi");
        bobo = GameObject.FindWithTag("Bobo");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3((float)(0.5 * (bibi.transform.position.x + bobo.transform.position.x)), 0, 0);
    }
}
