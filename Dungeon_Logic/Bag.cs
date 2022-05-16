namespace Dungeon_Logic
{
    internal abstract class Bag
    {
        internal abstract int Capacity { get; }
        internal abstract int Load { get; }
        internal abstract List<Item> Items { get; }
        internal abstract void AddItem(Item item);
        internal abstract Item GetItem(string name);
    }
}
