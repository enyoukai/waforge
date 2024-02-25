using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryRenderer : MonoBehaviour
{
    [SerializeField] public Image draggableImage;
    [SerializeField] Sprite carrotIcon;
    [SerializeField] Sprite wheatIcon;
    [SerializeField] Sprite cookedCarrotIcon;
    [SerializeField] Sprite breadIcon;
    [SerializeField] Sprite breadDoughIcon;
    [SerializeField] Sprite rawFishIcon;
    [SerializeField] Sprite cookedFishIcon;
    [SerializeField] Sprite waterBucket;
    [SerializeField] Sprite berryIcon;

    [SerializeField] Image[] inventorySlots;

    public static InventoryRenderer Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        for (int i = 0; i < inventorySlots.Length; i++)
        {
            inventorySlots[i].GetComponent<ItemDragHandler>().SetIndex(i);
            inventorySlots[i].GetComponent<ItemDragHandler>().SetItem(Inventory.items[i]);
        }
    }

    void Start()
    {
        Render();
    }

    void Render()
    {
        InventoryItem[] items = Inventory.items;

        for (int i = 0; i < items.Length; i++)
        {
            switch (items[i])
            {
                case InventoryItem.none:
                    inventorySlots[i].enabled = false;
                    inventorySlots[i].sprite = null;
                    break;
                case InventoryItem.carrot:
                    inventorySlots[i].enabled = true;
                    inventorySlots[i].sprite = carrotIcon;
                    break;
                case InventoryItem.wheat:
                    inventorySlots[i].enabled = true;
                    inventorySlots[i].sprite = wheatIcon;
                    break;
                case InventoryItem.cookedCarrot:
                    inventorySlots[i].enabled = true;
                    inventorySlots[i].sprite = cookedCarrotIcon;
                    break;
                case InventoryItem.bread:
                    inventorySlots[i].enabled = true;
                    inventorySlots[i].sprite = breadIcon;
                    break;
                case InventoryItem.breadDough:
                    inventorySlots[i].enabled = true;
                    inventorySlots[i].sprite = breadDoughIcon;
                    break;
                case InventoryItem.rawFish:
                    inventorySlots[i].enabled = true;
                    inventorySlots[i].sprite = rawFishIcon;
                    break;
                case InventoryItem.cookedFish:
                    inventorySlots[i].enabled = true;
                    inventorySlots[i].sprite = cookedFishIcon;
                    break;
                case InventoryItem.waterBucket:
                    inventorySlots[i].enabled = true;
                    inventorySlots[i].sprite = waterBucket;
                    break;
                case InventoryItem.berry:
                    inventorySlots[i].enabled = true;
                    inventorySlots[i].sprite = berryIcon;
                    break;
            }
        }
    }

    void Update()
    {
        Render();
    }
}
