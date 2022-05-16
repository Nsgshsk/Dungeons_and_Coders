namespace Dungeon_Logic
{
    internal class Cleric : Character
    {
        private readonly string faction;
        private readonly string name;
        private const double baseHealth = 50;
        private double health = baseHealth;
        private const double baseArmor = 25;
        private double armor = baseArmor;
        private const double abilityPoints = 40;
        private Bag bag = new Backpack();
        private bool isAlive = true;
        private const double restHealMultiplier = 0.5;
        internal Cleric(string name, string faction)
        {
            if (name == null || name == " ")
            {
                throw new ArgumentException("Name cannot be null or whitespace!");
            }
            else
            {
                this.name = name;
                this.faction = faction;
            }
        }
        internal override string Faction { get { return faction; } }
        internal override string Name { get { return name; } }
        internal override double BaseHealth { get { return baseHealth; } }
        internal override double Health { get { return health; } set { health = value; } }
        internal override double BaseArmor { get { return armor; } }
        internal override double Armor { get { return armor; } set { armor = value; } }
        internal override double AbilityPoints { get { return abilityPoints; } }
        internal override Bag Bag { get { return bag; } }
        internal override bool IsAlive { get { return isAlive; } set { isAlive = value; } }
        internal override double RestHealMultiplier { get { return restHealMultiplier; } }
        internal override void GiveCharacterItem(Item item, Character character)
        {
            if (!IsAlive && !character.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
            else
            {
                character.Bag.AddItem(item);
            }
        }
        internal override void RecieveItem(Item item)
        {
            if (!IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
            else
            {
                bag.AddItem(item);
            }
        }
        internal override void Rest()
        {
            if (!IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
            else
            {
                health += baseHealth * restHealMultiplier;
                if (health > baseHealth)
                    health = baseHealth;
            }
        }
        internal override void TakeDamage(double hitPoints)
        {
            if (!IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
            else
            {
                if (hitPoints <= armor)
                {
                    armor -= hitPoints;
                }
                else
                {
                    hitPoints -= armor;
                    armor = 0;
                    if (hitPoints < health)
                    {
                        health -= hitPoints;
                    }
                    else
                    {
                        health = 0;
                        isAlive = false;
                    }
                }
            }
        }
        internal override void UseItem(Item item)
        {
            if (!IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
            else
            {
                item.AffectCharacter(this);
            }
        }
        internal override void UseItemOn(Item item, Character character)
        {
            if (!IsAlive && !character.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
            else
            {
                item.AffectCharacter(character);
            }
        }
        internal override void Attack(Character character)
        {
            throw new ArgumentException($"{name} cannot attack!");
        }
        internal override void Heal(Character character)
        {
            if (!IsAlive && !character.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
            else if (this.faction != character.Faction)
            {
                throw new ArgumentException($"Cannot heal enemy character!");
            }
            else
            {
                character.Health += abilityPoints;
            }
        }
    }
}
