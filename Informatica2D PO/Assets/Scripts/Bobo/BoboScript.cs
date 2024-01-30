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


    [SerializeField] private float pickupRange = 2f;
    [SerializeField] private LayerMask pickupLayer;
    private GameObject heldBlock;
    private GameObject inventory;


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
        HandlePickup();
    }

    void HandlePickup()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(0, .5f, 0), Vector2.right * transform.localScale.x, pickupRange, pickupLayer);
            RaycastHit2D hit2 = Physics2D.Raycast(transform.position - new Vector3(0, .5f, 0), Vector2.right * transform.localScale.x, pickupRange, pickupLayer);

            if (hit.collider != null)
            {
                // Pickup the block
                heldBlock = hit.collider.gameObject;
                heldBlock.SetActive(false);
            }

            else if (hit2.collider != null) 
            {
                heldBlock = hit2.collider.gameObject;
                heldBlock.SetActive(false);
            }
        }

    }
}
