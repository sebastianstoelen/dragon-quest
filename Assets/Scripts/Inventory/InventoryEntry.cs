using System;
using System.Collections.Generic;

[System.Serializable]
public class InventoryEntry : IComparable<InventoryEntry>
{
    public string itemName;
    public int itemAmount;

    public int CompareTo(InventoryEntry other)
    {
        if (string.IsNullOrEmpty(this.itemName) && ! string.IsNullOrEmpty(other.itemName)) {
            return 1; 
        }

        if (! string.IsNullOrEmpty(this.itemName) && string.IsNullOrEmpty(other.itemName))
        {
            return -1;
        }

        return this.itemName.CompareTo(other.itemName);
    }
}