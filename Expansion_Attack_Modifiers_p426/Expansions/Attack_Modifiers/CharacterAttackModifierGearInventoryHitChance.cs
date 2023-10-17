using Expansion_Attack_Modifiers_p426.Expansions.Vin_Fletcher;
using Expansion_Attack_Modifiers_p426.Expansions.Vin_Fletcher.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expansion_Attack_Modifiers_p426.Expansions.Attack_Modifiers
{
    public class CharacterAttackModifierGearInventoryHitChance : CharacterGearInventoryHitChance
    {
        public List<AttackModifierOffensive> AttackModifiersOffensive { get; set; }
        public List<AttackModifierDefensive> AttackModifiersDefensive { get; set; }
        public CharacterAttackModifierGearInventoryHitChance(string name, List<AvailableActionHitChance> availableActionsHitChances, int maxHP, string characterID, Inventory characterInventory, List<AttackModifierOffensive> attackModifiersOffensive, List<AttackModifierDefensive> attackModifiersDefensive) : base(name, availableActionsHitChances, maxHP, characterID, characterInventory)
        {
            AttackModifiersOffensive = attackModifiersOffensive;
            AttackModifiersDefensive = attackModifiersDefensive;
        }
    }
}
