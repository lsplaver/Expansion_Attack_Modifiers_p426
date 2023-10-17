using Expansion_Attack_Modifiers_p426;
using Expansion_Attack_Modifiers_p426.Expansions;
using Expansion_Attack_Modifiers_p426.Expansions.Gear;

namespace Expansion_Attack_Modifiers_p426.Expansions.Vin_Fletcher
{
    public class PartyGearInventoryHitChance : PartyGearInventory
    {
        public List<CharacterGearInventoryHitChance> CharacterGearInventoryHitChances { get; set; }
        public PartyGearInventoryHitChance(List<CharacterGearInventoryHitChance> charactersGearInventoryHitChances, PartyType partyType, string name, Inventory inventory) : base(partyType, name, inventory)
        {
            CharacterGearInventoryHitChances = charactersGearInventoryHitChances;
        }
        public PartyGearInventoryHitChance(PartyType partyType, string name, Inventory inventory) : base(partyType, name, inventory) { }
    }
}