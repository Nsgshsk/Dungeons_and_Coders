namespace Dungeon_Logic
{
    internal class HealthPotion : Item
    {
        private const int weight = 5;
        internal override string Name { get { return "HealthPotion";  } }
        internal override int Weight { get { return weight; } }
        internal override void AffectCharacter(Character character)
        {
            if (!character.IsAlive)
            {
                throw new ArgumentException("Name cannot be null or whitespace!");
            }
            else
            {
                character.Health += 20;
            }
        }
    }
}
