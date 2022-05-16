using Dungeon_Logic;

do
{
    string[] command = Console.ReadLine().Split(' ');
    string tmp;
    switch (command[0])
    {
        case "JoinParty":
            Console.WriteLine(DungeonMaster.JoinParty(command));
            break;
        case "AddItemToPool":
            Console.WriteLine(DungeonMaster.AddItemToPool(command));
            break;
        case "PickUpItem":
            Console.WriteLine(DungeonMaster.PickUpItem(command));
            break;
        case "UseItem":
            Console.WriteLine(DungeonMaster.UseItem(command));
            break;
        case "UseItemOn":
            Console.WriteLine(DungeonMaster.UseItemOn(command));
            break;
        case "GiveCharacterItem":
            Console.WriteLine(DungeonMaster.GiveCharacterItem(command));
            break;
        case "GetStats":
            tmp = DungeonMaster.GetStats();
            if (tmp != null)
                Console.WriteLine(tmp);
            break;
        case "Attack":
            Console.WriteLine(DungeonMaster.Attack(command));
            break;
        case "Heal":
            Console.WriteLine(DungeonMaster.Heal(command));
            break;
        case "EndTurn":
            tmp = DungeonMaster.EndTurn();
            if (tmp != null)
                Console.WriteLine(tmp);
            break;
        case "IsGameOver":
            Console.WriteLine(DungeonMaster.IsGameOver());
            break;
    }
} while (!DungeonMaster.IsGameOver());
Console.WriteLine("Final stats:");
Console.WriteLine(DungeonMaster.GetStats());