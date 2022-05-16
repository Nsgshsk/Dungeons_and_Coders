namespace Dungeon_Logic
{
    public static class DungeonMaster
    {
        private static List<Character> characters = new List<Character>();
        private static List<Item> itemPool = new List<Item>();
        private static int survivalRounds = 0;
        public static string JoinParty(string[] args)
        {
            if (args[1] != "Java" && args[1] != "CSharp")
            {
                throw new ArgumentException($"Invalid faction \"{args[1]}\"!");
            }
            else if (args[2] != "Warrior" && (args[2] != "Cleric"))
            {
                throw new ArgumentException($"Invalid character type \"{args[2]}\"!");
            }
            else
            {
                if (args[2] == "Warrior")
                {
                    characters.Add(new Warrior(args[3], args[1]));
                }
                else
                {
                    characters.Add(new Cleric(args[3], args[1]));
                }
                return $"{args[3]} joined the party!";
            }
        }

        public static string AddItemToPool(string[] args)
        {
            if (args[1] == "ArmorRepairKit")
            {
                itemPool.Add(new ArmorRepairKit());
            }
            else if (args[1] == "HealthPotion")
            {
                itemPool.Add(new HealthPotion());
            }
            else if (args[1] == "PoisonPotion")
            {
                itemPool.Add(new PoisonPotion());
            }
            else
            {
                throw new ArgumentException($"Invalid item \"{args[1]}\"!");
            }
            return $"{args[1]} added to pool.";
        }

        public static string PickUpItem(string[] args)
        {
            string itemName;
            if (characters.Exists(e => e.Name == args[1]))
            {
                if (itemPool.Count == 0)
                {
                    throw new InvalidOperationException("No items left in pool!");
                }
                else
                {
                    int index = characters.FindIndex(e => e.Name == args[1]);
                    itemName = itemPool.Last().Name;
                    characters[index].Bag.AddItem(itemPool.Last());
                    itemPool.RemoveAt(itemPool.Count - 1);
                }
            }
            else
            {
                throw new ArgumentException($"Character {args[1]} not found!");
            }
            return $"{args[1]} picked up {itemName}!";
        }

        public static string UseItem(string[] args)
        {
            if (characters.Exists(e => e.Name == args[1]))
            {
                int index = characters.FindIndex(e => e.Name == args[1]);
                characters[index].UseItem(characters[index].Bag.GetItem(args[2]));
            }
            else
            {
                throw new ArgumentException($"Character {args[1]} not found!");
            }
            return $"{args[1]} used {args[2]}.";
        }

        public static string UseItemOn(string[] args)
        {
            if (characters.Exists(e => e.Name == args[1]))
            {
                if (characters.Exists(e => e.Name == args[2]))
                {
                    int indexG = characters.FindIndex(e => e.Name == args[1]);
                    int indexR = characters.FindIndex(e => e.Name == args[2]);
                    characters[indexG].UseItemOn(characters[indexG].Bag.GetItem(args[3]), characters[indexR]);
                    return $"{args[1]} used {args[3]} on {args[2]}.";
                }
                else
                {
                    throw new ArgumentException($"Character {args[2]} not found!");
                }
            }
            else
            {
                throw new ArgumentException($"Character {args[1]} not found!");
            }
        }

        public static string GiveCharacterItem(string[] args)
        {
            if (characters.Exists(e => e.Name == args[1]))
            {
                if (characters.Exists(e => e.Name == args[2]))
                {
                    int indexG = characters.FindIndex(e => e.Name == args[1]);
                    int indexR = characters.FindIndex(e => e.Name == args[2]);
                    characters[indexG].GiveCharacterItem(characters[indexG].Bag.GetItem(args[3]), characters[indexR]);
                    return $"{args[1]} gave {args[2]} {args[3]}.";
                }
                else
                {
                    throw new ArgumentException($"Character {args[2]} not found!");
                }
            }
            else
            {
                throw new ArgumentException($"Character {args[1]} not found!");
            }
        }

        public static string? GetStats()
        {
            if (!characters.Any())
                return null;
            string tmp = $"{characters.First().Name} - HP: {characters.First().Health}/{characters.First().BaseHealth}, AP: {characters.First().Armor}/{characters.First().BaseArmor}, Status: {characters.First().IsAlive}";
            foreach (var item in characters.Skip(1).OrderByDescending(e => e.IsAlive).ThenByDescending(e => e.Health))
            {
                tmp += $"\n{item.Name} - HP: {item.Health}/{item.BaseHealth}, AP: {item.Armor}/{item.BaseArmor}, Status: {item.IsAlive}";
            }
            return tmp;
        }

        public static string Attack(string[] args)
        {
            if (characters.Exists(e => e.Name == args[1]))
            {
                if (characters.Exists(e => e.Name == args[2]))
                {
                    string tmp;
                    int indexG = characters.FindIndex(e => e.Name == args[1]);
                    int indexR = characters.FindIndex(e => e.Name == args[2]);
                    characters[indexG].Attack(characters[indexR]);
                    tmp = $"{characters[indexG].Name} attacks {characters[indexR].Name} for {characters[indexG].AbilityPoints} hit points! {characters[indexR].Name} has {characters[indexR].Health}/{characters[indexR].BaseHealth} HP and {characters[indexR].Armor}/{characters[indexR].BaseArmor} AP left!";
                    if (!characters[indexR].IsAlive)
                    {
                        tmp += $"\n{characters[indexR].Name} is dead!";
                    }
                    return tmp;
                }
                else
                {
                    throw new ArgumentException($"Character {args[2]} not found!");
                }
            }
            else
            {
                throw new ArgumentException($"Character {args[1]} not found!");
            }
        }

        public static string Heal(string[] args)
        {
            if (characters.Exists(e => e.Name == args[1]))
            {
                if (characters.Exists(e => e.Name == args[2]))
                {
                    int indexG = characters.FindIndex(e => e.Name == args[1]);
                    int indexR = characters.FindIndex(e => e.Name == args[2]);
                    characters[indexG].Heal(characters[indexR]);
                    return $"{characters[indexG].Name} heals {characters[indexR].Name} for {characters[indexG].AbilityPoints}! {characters[indexR].Name} has {characters[indexR].Health} health now!";
                }
                else
                {
                    throw new ArgumentException($"Character {args[2]} not found!");
                }
            }
            else
            {
                throw new ArgumentException($"Character {args[1]} not found!");
            }
        }

        public static string? EndTurn()
        {
            if (!characters.Any())
                return null;
            string tmp = "";
            int alive = 0;
            foreach (var item in characters)
            {
                if (item.IsAlive)
                {
                    alive++;
                    double hpBefore = item.Health;
                    item.Rest();
                    tmp += $"\n{item.Name} rests ({hpBefore} => {item.Health})";
                }
            }
            if (alive <= 1)
            {
                survivalRounds++;
            }
            return tmp.Substring(1);
        }

        public static bool IsGameOver()
        {
            if (survivalRounds > 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
