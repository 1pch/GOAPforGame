using System.Collections.Generic;

namespace ItemController
{
    enum Items
    {
        Wool,
        Scissors,
        Fabric
    }

    class Item
    {
        public Item(Items item, ushort amount)
        {
            this.item = item;
            this.amount = amount;
            this.attributes = new Dictionary<string, object>();
        }
        public Item(Items item, ushort amount, Dictionary<string, object> attributes)
        {
            this.item = item;
            this.amount = amount;
            this.attributes = attributes;
        }
        public Items item;
        public ushort amount;
        public Dictionary<string, object> attributes;
    }
}