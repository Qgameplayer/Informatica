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

    internal LogicScript logicScript;
    private GameObject logic;

    internal GameObject spike;

    internal GameObject ladder;

    internal Rigidbody2D rb;
    
    private GameObject bibi;
    public Vector2 spawnPos;

    internal bool isClimbing;

    // Start is called before the first frame update
    void Start()
    {
        bibi = this.gameObject;

        rb = GetComponent<Rigidbody2D>();
        spawnPos = transform.position;

        logic = GameObject.FindWithTag("Logic");
        logicScript = logic.GetComponent<LogicScript>();

        spike = GameObject.FindWithTag("Spike");

        ladder = GameObject.FindWithTag("Ladder");

    }

    // Update is called once per frame
    void Update()
    {
        MovementManager();

        if (bibiInputScript.isUpPressed && bibiCollisionScript.isNearLadder)
        {
            isClimbing = true;
        }
        while (isClimbing)
        {
            if (bibiInputScript.isUpPressed)
            {
                bibiMovementScript.ClimbUp();
            }
            else if (bibiInputScript.isDownPressed)
            {
                bibiMovementScript.ClimbDown();
            }
        }

        Debug.Log(isClimbing);

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
