namespace Dungeon_Logic
{
    internal class PoisonPotion : Item
    {
        private const int weight = 5;
        internal override string Name { get { return "PoisonPotion"; } }
        internal override int Weight { get { return weight; } }
        internal override void AffectCharacter(Character character)
        {
            if (!character.IsAlive)
            {
                throw new ArgumentException("Name cannot be null or whitespace!");
            }
            else
            {
                if (character.Health <= 20)
                {
                    character.Health = 0;
                    character.IsAlive = false;
                }
                else
                {
                    character.Health -= 20;
                }
            }
        }
    }
}
