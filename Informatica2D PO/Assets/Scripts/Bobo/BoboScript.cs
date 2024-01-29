using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoboScript : MonoBehaviour
{

    [SerializeField]
    internal BoboInputScript boboInputScript;

    [SerializeField]
    internal BobomovementScript boboMovementScript;

    [SerializeField]
    internal BobocollisionScript boboCollisionScript;

    internal LogicScript logicScript;
    private GameObject logic;

    internal Rigidbody2D rb;

    


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        logic = GameObject.FindWithTag("Logic");
        logicScript = logic.GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {

    }



}
