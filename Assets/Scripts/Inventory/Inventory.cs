using System;

[System.Serializable]
public class Inventory
{
    public InventoryEntry[] inventoryEntries;

    public Inventory()
    {
    }

    public bool HasItemAt(int itemIndex)
    {
        return inventoryEntries[itemIndex].itemName != "";
    }

    public string GetItemNameAt(int itemIndex)
    {
        return inventoryEntries[itemIndex].itemName;
    }

    public int GetAmountOfItemAt(int itemIndex)
    {
        return inventoryEntries[itemIndex].itemAmount;
    }

    internal void Sort()
    {
        Array.Sort(inventoryEntries);
    }
}
