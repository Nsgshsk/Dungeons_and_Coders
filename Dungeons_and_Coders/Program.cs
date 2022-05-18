using Dungeon_Logic;

do
{
    string[] command = Console.ReadLine().Split(' ');
    switch (command[0])
    {
        case "JoinParty":
            try
            {
                Console.WriteLine(DungeonMaster.JoinParty(command));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            break;
        case "AddItemToPool":
            try
            {
                Console.WriteLine(DungeonMaster.AddItemToPool(command));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            break;
        case "PickUpItem":
            try
            {
                Console.WriteLine(DungeonMaster.PickUpItem(command));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            break;
        case "UseItem":
            try
            {
                Console.WriteLine(DungeonMaster.UseItem(command));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            break;
        case "UseItemOn":
            try
            {
                Console.WriteLine(DungeonMaster.UseItemOn(command));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            break;
        case "GiveCharacterItem":
            try
            {
                Console.WriteLine(DungeonMaster.GiveCharacterItem(command));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            break;
        case "GetStats":
            try
            {
                Console.WriteLine(DungeonMaster.GetStats());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            break;
        case "Attack":
            try
            {
                Console.WriteLine(DungeonMaster.Attack(command));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            break;
        case "Heal":
            try
            {
                Console.WriteLine(DungeonMaster.Heal(command));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            break;
        case "EndTurn":
            try
            {
                Console.WriteLine(DungeonMaster.EndTurn());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            break;
        case "IsGameOver":
            Console.WriteLine(DungeonMaster.IsGameOver());
            break;
    }
} while (!DungeonMaster.IsGameOver());
Console.WriteLine("Final stats:");
Console.WriteLine(DungeonMaster.GetStats());