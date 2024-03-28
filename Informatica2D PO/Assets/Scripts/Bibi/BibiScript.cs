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

    internal GameObject[] spike;
    internal GameObject ladder;
    internal GameObject[] water;
    internal GameObject[] enemy;

    internal Rigidbody2D rb;

    internal GameObject bibi;
    internal Vector2 spawnPos;

    internal Vector2 location;

    private bool isClimbing;

    // Start is called before the first frame update
    void Start()
    {
        bibi = this.gameObject;

        rb = GetComponent<Rigidbody2D>();
        spawnPos = transform.position;

        logic = GameObject.FindWithTag("Logic");
        logicScript = logic.GetComponent<LogicScript>();

        spike = GameObject.FindGameObjectsWithTag("Spike");

        ladder = GameObject.FindWithTag("Ladder");

        water = GameObject.FindGameObjectsWithTag("Water");

        enemy = GameObject.FindGameObjectsWithTag("Enemy");

        Debug.Log(spike);
    }

    // Update is called once per frame
    void Update()
    {

        MovementManager();
        location = transform.position;

        
    }

    private void MovementManager()
    {

        if (transform.position.y < -5)
        {
            logicScript.HandlePlayerDeath(this.gameObject);
        }

    }

    internal bool JumpAbleGround()
    {
        if (bibiCollisionScript.isOnGround || bibiCollisionScript.isOnBobo)
        {
            return true;
        }
        return false;
    }

    internal string StateManager()
    {
        if (bibiCollisionScript.isNearLadder)
        {
            if (bibiInputScript.isUpPressed && !isClimbing && !(bibiInputScript.isLeftPressed || bibiInputScript.isRightPressed))
            {
                isClimbing = true;
                return "CLIMBING";
            }
            else if (isClimbing == true)
            {
                if (bibiInputScript.isDoubleDownPressed || bibiInputScript.isLeftPressed || bibiInputScript.isRightPressed)
                {
                    isClimbing = false;
                    return "MOVING";
                }

                else { return "CLIMBING"; }
            }
        }
        else
        {
            isClimbing = false;
            if (bibiInputScript.isUpPressed && JumpAbleGround())
            {
                return "JUMPING";
            }
            else if (bibiInputScript.isLeftPressed || bibiInputScript.isRightPressed)
            {
                return "MOVING";
            }
        }


        return "IDLE";
    }

}
