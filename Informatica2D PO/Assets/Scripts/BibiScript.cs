using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class BibiScript : MonoBehaviour
{

    [SerializeField]
    internal BibiInputScript bibiInputScript;

    [SerializeField]
    internal BibiMovementScript bibiMovementScript;

    [SerializeField]
    internal BibiCollisionScript bibiCollisionScript;

    LogicScript logicScript;
    private GameObject logic;

    internal Rigidbody2D rb;
    
    private GameObject bibi;
    public Vector2 spawnPos;

    // Start is called before the first frame update
    void Start()
    {
        bibi = GameObject.FindWithTag("Bibi");
        
        rb = GetComponent<Rigidbody2D>();
        spawnPos = transform.position;

        logic = GameObject.FindWithTag("Logic");
        logicScript = logic.GetComponent<LogicScript>();

    }

    // Update is called once per frame
    void Update()
    {
        MovementManager();
    }

    private void MovementManager()
    {

        if (transform.position.y < -5)
        {
            logicScript.HandlePlayerDeath();
        }

    }

    private void ladderClimbing()
    {
        
    }

}
