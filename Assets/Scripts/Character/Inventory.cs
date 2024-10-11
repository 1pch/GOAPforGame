using System;
using ItemController;
using Unity.VisualScripting;
namespace EntityController
{
    class InventoryManager
    {
        public InventoryManager(ushort inventorySize)
        {
            Inventory = new Item[inventorySize];
            wallet = 0;
        }
        public Item[] Inventory;
        public int wallet;

        public bool HasItem(Item item)
        {
            foreach(Item i in Inventory)
            {
                if(i != null && i.item == item.item && i.amount >= item.amount) 
                {
                    return true;
                }
            }
            return false;
        }

        public bool HasItem(Items item)
        {
            foreach(Item i in Inventory)
            {
                if(i != null &&i.item == item)
                {
                    return true;
                }
            }
            return false;
        }
        public bool RemoveItem(Item item)
        {
            foreach(Item i in Inventory)
            {
                if(i != null && i.item == item.item && i.amount > item.amount) 
                {
                    i.amount -= item.amount;
                    return true;
                }
            }
            return false;
        }
        public bool RemoveItem(Items item)
        {
            for(int i = 0; i < Inventory.Length; i++)
            {
                if(item == Inventory[i].item)
                {
                    Inventory[i] = null;
                    return true;
                }
            }
            return false;
        }

        public bool AddItem(Item item)
        {
            for(int i = 0; i < Inventory.Length; i++)
            {
                if(Inventory[i] == null)
                {
                    Inventory[i] = item;
                    return true;
                }
            }
            return false;
        }

        public Item FindItem(Items item)
        {
            for(int i = 0; i < Inventory.Length; i++)
            {
                if(Inventory[i] != null && Inventory[i].item == item)
                {
                    return Inventory[i];
                }
            }
            return null;
        }

        public Item GetItem(Items item)
        {
            foreach(Item i in Inventory)
            {
                if(i.item == item)
                {
                    return i;
                }
            }
            return null;
        }
    }
}