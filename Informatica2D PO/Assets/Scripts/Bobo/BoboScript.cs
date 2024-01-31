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
    private GameObject[] inventoryBlocks;
    private GameObject[] inventorySlotObjects;

    private bool isInventoryActive = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        logic = GameObject.FindWithTag("Logic");
        logicScript = logic.GetComponent<LogicScript>();

        inventoryBlocks = new GameObject[3];
        inventorySlotObjects = new GameObject[3];
    }

    // Update is called once per frame
    void Update()
    {
        if (isInventoryActive)
        {
            inventory.SetActive(true);
        }
        else
        {
            inventory.SetActive(false);
        }


        HandlePickup();
        HandleInventory();
        HandleDrop();
        Debug.Log(inventoryBlocks[currentSlot]);
    }

    void HandlePickup()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(0, .5f, 0), Vector2.right * transform.localScale.x, pickupRange, pickupLayer);
            RaycastHit2D hit2 = Physics2D.Raycast(transform.position - new Vector3(0, .5f, 0), Vector2.right * transform.localScale.x, pickupRange, pickupLayer);

            if (hit.collider != null)
            {
                if (inventoryBlocks[currentSlot] == null)
                {
                    AddToInventory(hit.collider.gameObject);
                    hit.collider.gameObject.SetActive(false);
                }
                
            }

            else if (hit2.collider != null)
            {
                AddToInventory(hit2.collider.gameObject);
                hit2.collider.gameObject.SetActive(false);

                if (inventoryBlocks[currentSlot] == null)
                {
                    AddToInventory(hit.collider.gameObject);
                    hit.collider.gameObject.SetActive(false);
                }
            }
        }

    }

    private void AddToInventory(GameObject block)
    {
        if (currentSlot < 3 && inventoryBlocks[currentSlot] == null)
        {
            inventoryBlocks[currentSlot] = block;
            UpdateInventoryUI();
        }
    }

    private void HandleInventory()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            isInventoryActive = !isInventoryActive;

            if (isInventoryActive)
            {
                lastInventoryInputTime = Time.time;
            }
        }

        if (isInventoryActive && Time.time - lastInventoryInputTime > 5f)
        {
            isInventoryActive = false;
        }

        if (isInventoryActive)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                currentSlot = 0;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                currentSlot = 1;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                currentSlot = 2;
            }
        }
        UpdateInventoryUI();
    }

    private void HandleDrop()
    {
        if (Input.GetKeyDown(KeyCode.I) && isInventoryActive && inventoryBlocks[currentSlot] != null)
        {
            GameObject blockToDrop = inventoryBlocks[currentSlot];
            blockToDrop.transform.position = transform.position + Vector3.right * transform.localScale.x;
            blockToDrop.SetActive(true);
            inventoryBlocks[currentSlot] = null;

            UpdateInventoryUI();
        }
    }

    private void UpdateInventoryUI()
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            if (i == currentSlot)
            {
                // Set the current slot to green
                inventorySlots[i].color = Color.green;
            }
            else
            {
                // Set other slots to white
                inventorySlots[i].color = Color.white;
            }
        }
    }
}
