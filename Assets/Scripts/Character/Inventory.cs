using ItemController;
namespace EntityController
{
    class InventoryManager
    {
        public InventoryManager(ushort inventorySize)
        {
            Inventory = new Item[inventorySize];
        }
        public Item[] Inventory;
    }
}