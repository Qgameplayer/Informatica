using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Unity.Collections.AllocatorManager;

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
    [SerializeField] private LayerMask bibiLayer;

    private GameObject heldBlock;
    [SerializeField] private GameObject inventory;

    private float lastInventoryInputTime;
    private int currentSlot = 0;

    private float selectedSlotScale = 1.2f;

    public Image[] inventorySlots;
    private Sprite[] originalSprites;
    private GameObject[] inventoryBlocks;


    private bool isInventoryActive = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        logic = GameObject.FindWithTag("Logic");
        logicScript = logic.GetComponent<LogicScript>();

        inventoryBlocks = new GameObject[3];
        originalSprites = new Sprite[inventorySlots.Length];
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            originalSprites[i] = inventorySlots[i].sprite;
        }
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


        PickUpDropManager();
        HandleInventory();
    }

    void PickUpDropManager()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(0, .5f, 0), Vector2.right * transform.localScale.x, pickupRange, pickupLayer);
            RaycastHit2D hit2 = Physics2D.Raycast(transform.position - new Vector3(0, .5f, 0), Vector2.right * transform.localScale.x, pickupRange, pickupLayer | bibiLayer);

            if (inventoryBlocks[currentSlot] != null)
            {
                HandleDrop();
            }

            else if (hit.collider != null)
            {
                if (inventoryBlocks[currentSlot] == null)
                {
                    AddToInventory(hit.collider.gameObject);
                    hit.collider.gameObject.SetActive(false);
                }

            }

            else if (hit2.collider != null)
            {
                if (inventoryBlocks[currentSlot] == null)
                {
                    AddToInventory(hit2.collider.gameObject);
                    hit2.collider.gameObject.SetActive(false);
                }
            }
        }

    }

    private void AddToInventory(GameObject block)
    {
        if (currentSlot < 3 && inventoryBlocks[currentSlot] == null)
        {
            // Disable the picked-up object instead of setting it inactive
            block.GetComponent<Rigidbody2D>().simulated = false;
            block.GetComponent<Collider2D>().enabled = false;

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

        GameObject blockToDrop = inventoryBlocks[currentSlot];
        blockToDrop.GetComponent<Rigidbody2D>().simulated = true;
        blockToDrop.GetComponent<Collider2D>().enabled = true;

        blockToDrop.transform.position = transform.position + Vector3.right * transform.localScale.x;
        blockToDrop.SetActive(true);
        inventoryBlocks[currentSlot] = null;

        UpdateInventoryUI();
    }

    private void UpdateInventoryUI()
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            if (i == currentSlot)
            {
                inventorySlots[i].rectTransform.localScale = Vector3.one * selectedSlotScale;
            }
            else
            {
                inventorySlots[i].rectTransform.localScale = Vector3.one;
            }

            if (inventoryBlocks[i] != null)
            {
                Sprite blockSprite = inventoryBlocks[i].GetComponent<SpriteRenderer>().sprite;
                inventorySlots[i].sprite = blockSprite;

                inventorySlots[i].color = inventoryBlocks[i].GetComponent<SpriteRenderer>().color;

                inventorySlots[i].enabled = true;
            }
            else
            {
                inventorySlots[i].sprite = originalSprites[i];
                inventorySlots[i].enabled = true;
                inventorySlots[i].color = Color.white;
            }
        }
    }
}
