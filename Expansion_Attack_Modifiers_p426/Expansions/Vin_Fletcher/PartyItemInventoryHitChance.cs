using Expansion_Attack_Modifiers_p426;
using Expansion_Attack_Modifiers_p426.Expansions;
using Expansion_Attack_Modifiers_p426.Expansions.Attack_Modifiers;
using Expansion_Attack_Modifiers_p426.Expansions.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expansion_Attack_Modifiers_p426.Expansions.Vin_Fletcher
{
    public class PartyItemInventoryHitChance : PartyItemInventory
    {
        public List<CharacterHitChance> CharactersHitChance { get; set; }
        public List<CharacterAttackModifierHitChance> CharactersAttackModifierHitChance { get; }

        public PartyItemInventoryHitChance(List<CharacterHitChance> charactersHitChance, PartyType partyType, string name, Inventory inventory) : base(partyType, name, inventory)
        {
            CharactersHitChance = charactersHitChance;
        }

        public PartyItemInventoryHitChance(List<CharacterAttackModifierHitChance> charactersAttackModifierHitChance, PartyType partyType, string name, Inventory inventory) : base(partyType, name, inventory)
        {
            CharactersAttackModifierHitChance = charactersAttackModifierHitChance;
        }
    }
}
