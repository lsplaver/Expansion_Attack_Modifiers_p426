using Expansion_Attack_Modifiers_p426.Actions;
using Expansion_Attack_Modifiers_p426.Expansions.Gear;
using Expansion_Attack_Modifiers_p426.Expansions.Vin_Fletcher;
using Expansion_Attack_Modifiers_p426.Expansions.Vin_Fletcher.Actions;

namespace Expansion_Attack_Modifiers_p426.Expansions.Attack_Modifiers
{
    public class CharacterAttackModifierHitChance : CharacterHitChance
    {
        public List<AttackModifierOffensive> AttackModifiersOffensive { get; set; }
        public List<AttackModifierDefensive> AttackModifiersDefensive { get; set; }
        //public CharacterAttackModifierGearInventory(string name, int maxHP, string characterID, Inventory characterInventory, List<AttackModifierOffensive> attackModifiersOffensive, List<AttackModifierDefensive> attackModifiersDefensive) : base(name, maxHP, characterID, characterInventory)
        //{
        //    AttackModifiersOffensive = attackModifiersOffensive;
        //    AttackModifiersDefensive = attackModifiersDefensive;
        //}

        //public CharacterAttackModifierGearInventory(string name, List<AvailableAction> availableActions, int maxHP, string characterID, Inventory characterInventory, List<AttackModifierOffensive> attackModifiersOffensive, List<AttackModifierDefensive> attackModifiersDefensive) : base(name, availableActions, maxHP, characterID, characterInventory)
        //{
        //    AttackModifiersOffensive = attackModifiersOffensive;
        //    AttackModifiersDefensive = attackModifiersDefensive;
        //}

        public CharacterAttackModifierHitChance(string name, List<AvailableActionHitChance> availableActionsHitChances, int maxHP, string characterID, List<AttackModifierOffensive> attackModifiersOffensive, List<AttackModifierDefensive> attackModifiersDefensive) : base(name, availableActionsHitChances, maxHP, characterID)
        {
            AttackModifiersOffensive = attackModifiersOffensive;
            AttackModifiersDefensive = attackModifiersDefensive;
        }

        public static explicit operator CharacterAttackModifierHitChance(CharacterAttackModifier v/*, List<AvailableActionHitChance> availableActionHitChances, List<AttackModifierOffensive> attackModifiersOffensive, List<AttackModifierDefensive> attackModifiersDefensive*/)
        {
            //string name = v.Name;
            //List<AvailableActionHitChance> availableActionHitChances = v.AvailableActions;

            //CharacterAttackModifierHitChance character = new CharacterAttackModifierHitChance(name, );
            return (CharacterAttackModifierHitChance)v;
        }
    }
}