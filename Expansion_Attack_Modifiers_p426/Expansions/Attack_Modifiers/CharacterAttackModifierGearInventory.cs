using Expansion_Attack_Modifiers_p426.Actions;
using Expansion_Attack_Modifiers_p426.Expansions.Gear;

namespace Expansion_Attack_Modifiers_p426.Expansions.Attack_Modifiers
{
    public class CharacterAttackModifierGearInventory : CharacterGearInventory
    {
        public List<AttackModifierOffensive> AttackModifiersOffensive { get; set; }
        public List<AttackModifierDefensive> AttackModifiersDefensive { get; set; }
        public CharacterAttackModifierGearInventory(string name, int maxHP, string characterID, Inventory characterInventory, List<AttackModifierOffensive> attackModifiersOffensive, List<AttackModifierDefensive> attackModifiersDefensive) : base(name, maxHP, characterID, characterInventory)
        {
            AttackModifiersOffensive = attackModifiersOffensive;
            AttackModifiersDefensive = attackModifiersDefensive;
        }

        public CharacterAttackModifierGearInventory(string name, List<AvailableAction> availableActions, int maxHP, string characterID, Inventory characterInventory, List<AttackModifierOffensive> attackModifiersOffensive, List<AttackModifierDefensive> attackModifiersDefensive) : base(name, availableActions, maxHP, characterID, characterInventory)
        {
            AttackModifiersOffensive = attackModifiersOffensive;
            AttackModifiersDefensive = attackModifiersDefensive;
        }
    }
}