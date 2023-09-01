namespace Expansion_Attack_Modifiers_p426.Expansions.Attack_Modifiers
{
    public enum AttackModifierType { OFFENSIVE, DEFENSIVE };
    public class AttackModifier
    {
        public AttackModifierType ModifierType { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        
        public AttackModifier(AttackModifierType modifierType, string name, int amount)
        {
            ModifierType = modifierType;
            Name = name;
            Amount = amount;
        }
    }
}