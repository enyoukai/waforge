public enum InventoryItem
{
    none, carrot, wheat, cookedCarrot, bread, breadDough, rawFish, cookedFish, waterBucket, berry
}

public static class Inventory
{
    public static InventoryItem[] items = new InventoryItem[10];

    public static void AddItem(InventoryItem item)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == InventoryItem.none)
            {
                items[i] = item;
                return;
            }
        }
    }

    public static void RemoveItem(int index)
    {
        items[index] = InventoryItem.none;
    }

    public static void AddFish()
    {
        AddItem(InventoryItem.rawFish);
    }

    public static void AddCarrot()
    {
        AddItem(InventoryItem.carrot);
    }

    public static void AddWheat()
    {
        AddItem(InventoryItem.wheat);
    }

    public static void AddBerries()
    {
        AddItem(InventoryItem.berry);
    }
}