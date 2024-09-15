using ItemController;
using Unity.VisualScripting;
namespace EntityController
{
    class InventoryManager
    {
        public InventoryManager(ushort inventorySize)
        {
            Inventory = new Item[inventorySize];
        }
        public Item[] Inventory;

        public bool HasItem(Item item)
        {
            ushort count = 0;
            foreach(Item i in Inventory)
            {
                if(i == item) {count++;}
            }
            if(item.amount <= count)
            {
                return true;
            }
            return false;
        }
    }
}