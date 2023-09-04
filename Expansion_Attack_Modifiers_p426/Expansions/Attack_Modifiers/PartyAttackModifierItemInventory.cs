using Expansion_Attack_Modifiers_p426.Expansions.Gear;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expansion_Attack_Modifiers_p426.Expansions.Attack_Modifiers
{
    public class PartyAttackModifierItemInventory : PartyInventory
    {
        public List<CharacterAttackModifier> CharacterAttackModifiers { get; set; }
        public PartyAttackModifierItemInventory(List<CharacterAttackModifier> characterAttackModifiers, PartyType partyType, string name, Inventory inventory) : base(partyType, name, inventory)
        {
            CharacterAttackModifiers = characterAttackModifiers;
        }
    }
}
