namespace ItemController
{
    enum Items
    {
        Wool,
        Scissors
    }

    class Item
    {
        public Item(Items item, ushort amount)
        {
            this.item = item;
            this.amount = amount;
        }
        Items item;
        ushort amount;
    }
}