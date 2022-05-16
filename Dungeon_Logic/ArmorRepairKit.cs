namespace Dungeon_Logic
{
    internal class ArmorRepairKit : Item
    {
        private const int weight = 10;
        internal override string Name { get { return "ArmorRepairKit"; } }
        internal override int Weight { get { return weight; } }
        internal override void AffectCharacter(Character character)
        {
            if (!character.IsAlive)
            {
                throw new ArgumentException("Name cannot be null or whitespace!");
            }
            else
            {
                character.Armor = character.BaseArmor;
            }
        }
    }
}
