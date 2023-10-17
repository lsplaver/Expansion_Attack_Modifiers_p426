using Expansion_Attack_Modifiers_p426.Expansions;
using Expansion_Attack_Modifiers_p426.Expansions.Gear;
using Expansion_Attack_Modifiers_p426.Expansions.Vin_Fletcher;

namespace Expansion_Attack_Modifiers_p426.Expansions.Attack_Modifiers
{
    public class PartyAttackModifierGearInventoryHitChance : PartyGearInventoryHitChance
    {
        public List<CharacterAttackModifierGearInventoryHitChance> CharactersAttackModifierGearInventoruyHitChance { get; set; }
        public PartyAttackModifierGearInventoryHitChance(List<CharacterAttackModifierGearInventoryHitChance> charactersAttackModifierGearInventoryHitChance, PartyType partyType, string name, Inventory partyInventory) : base(partyType, name, partyInventory)
        {
            CharactersAttackModifierGearInventoruyHitChance = charactersAttackModifierGearInventoryHitChance;
        }
    }
}