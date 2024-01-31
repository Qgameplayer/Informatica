using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField] private GameObject inventory;

    private float lastInventoryInputTime;
    private int currentSlot = 0;

    public Image[] inventorySlots;

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
        HandleInventory();
        HandleDrop();
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

    private void HandleInventory()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            inventory.SetActive(!inventory.activeSelf);

            if (inventory.activeSelf)
            {
                lastInventoryInputTime = Time.time;
            }
        }

        if (inventory.activeSelf && Time.time - lastInventoryInputTime > 5f)
        {
            Debug.Log("test");
            inventory.SetActive(false);
        }

        if (inventory.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                currentSlot = 0;
                Debug.Log(currentSlot);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                currentSlot = 1;
                Debug.Log(currentSlot);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                currentSlot = 2;
                Debug.Log(currentSlot);
            }
        }
        UpdateInventoryUI();
    }

    private void HandleDrop()
    {
        Debug.Log(inventory.activeSelf);
        if (Input.GetKeyDown(KeyCode.I) && inventory.activeSelf && heldBlock != null && currentSlot < 3)
        {
            // Drop the block from the current inventory slot
            heldBlock.transform.position = transform.position + Vector3.right * transform.localScale.x;
            heldBlock.SetActive(true);
            heldBlock = null;
        }
    }

    private void UpdateInventoryUI()
    {
        
    }
}
