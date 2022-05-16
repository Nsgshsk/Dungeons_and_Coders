namespace Dungeon_Logic
{
    internal abstract class Character
    {
        internal abstract string Faction { get; }
        internal abstract string Name { get; }
        internal abstract double BaseHealth { get; }
        internal abstract double Health { get; set; }
        internal abstract double BaseArmor { get; }
        internal abstract double Armor { get; set; }
        internal abstract double AbilityPoints { get; }
        internal abstract Bag Bag { get; }
        internal abstract bool IsAlive { get; set; }
        internal abstract double RestHealMultiplier { get; }
        internal abstract void TakeDamage(double hitPoints);
        internal abstract void Rest();
        internal abstract void UseItem(Item item);
        internal abstract void UseItemOn(Item item, Character character);
        internal abstract void GiveCharacterItem(Item item, Character character);
        internal abstract void RecieveItem(Item item);
        internal abstract void Attack(Character character);
        internal abstract void Heal(Character character);
    }
}
