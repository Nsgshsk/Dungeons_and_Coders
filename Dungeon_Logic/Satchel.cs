namespace Dungeon_Logic
{
    internal class Satchel : Bag
    {
        private const int capacity = 20;
        private int load = 0;
        private Dictionary<string, int> itemCount = new Dictionary<string, int>();
        private List<Item> items = new List<Item>();
        internal Satchel()
        {
            itemCount.Add("ArmorRepairKit", 0);
            itemCount.Add("HealthPotion", 0);
            itemCount.Add("PoisonPotion", 0);
        }
        internal override int Capacity { get { return capacity; } }
        internal override int Load { get { return load; } }
        internal override List<Item> Items { get { return items; } }
        internal override void AddItem(Item item)
        {
            if (item.Weight + load > capacity)
            {
                throw new InvalidOperationException("Bag is full!");
            }
            else
            {
                items.Add(item);
                items = items.OrderBy(e => e.Name).ToList();
                itemCount[item.Name]++;
            }
        }
        internal override Item GetItem(string name)
        {
            if (itemCount.Sum(e => e.Value) == 0)
            {
                throw new InvalidOperationException("Bag is empty!");
            }
            else if (!itemCount.ContainsKey(name))
            {
                throw new ArgumentException($"No item with name {name} in bag!");
            }
            else if (itemCount[name] == 0)
            {
                throw new ArgumentException($"No item with name {name} in bag!");
            }
            else
            {
                items = items.OrderBy(e => e.Name).ToList();
                Item tmp;
                if (name  == "ArmorRepairKit")
                {
                    tmp = items[0];
                    items.RemoveAt(0);
                }
                else if (name == "HealthPotion")
                {
                    tmp = items[itemCount["ArmorRepairKit"]];
                    items.RemoveAt(itemCount["ArmorRepairKit"]);
                }
                else
                {
                    tmp = items.Last();
                    items.RemoveAt(items.Count - 1);
                }
                itemCount[name]--;
                return tmp;
            }
        }
    }
}
