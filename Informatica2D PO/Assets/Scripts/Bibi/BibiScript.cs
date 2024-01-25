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

    internal GameObject water;

    internal Rigidbody2D rb;

    internal GameObject bibi;
    public Vector2 spawnPos;

    internal Vector2 location;

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

        water = GameObject.FindWithTag("Water");

    }

    // Update is called once per frame
    void Update()
    {
        MovementManager();
        stateManager();
        location = transform.position;
    }

    private void MovementManager()
    {

        if (transform.position.y < -5)
        {
            logicScript.HandlePlayerDeath();
        }

    }

    internal bool jumpAbleGround()
    {
        if (bibiCollisionScript.isOnGround || bibiCollisionScript.isOnBobo)
        {
            return true;
        }
        return false;
    }

    internal string stateManager()
    {
        string status;
        if (bibiCollisionScript.isNearLadder) //&& bibiInputScript.isUpPressed
        {
            status = "CLIMBING";
        }

        else if (bibiInputScript.isUpPressed && jumpAbleGround())
        {
            status = "JUMPING";
        }

        else if (bibiInputScript.isLeftPressed || bibiInputScript.isRightPressed)
        {
            status = "MOVING";
        }

        else { status = "IDLE"; }
        //Debug.Log(status);
        return status;
    }

}
