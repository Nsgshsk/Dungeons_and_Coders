namespace Dungeon_Logic
{
    internal abstract class Item
    {
        internal abstract string Name { get; }
        internal abstract int Weight { get; }
        internal abstract void AffectCharacter(Character character);
    }
}