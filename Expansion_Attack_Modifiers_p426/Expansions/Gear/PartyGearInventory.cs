using Expansion_Attack_Modifiers_p426;
using Expansion_Attack_Modifiers_p426.Expansions;

namespace Expansion_Attack_Modifiers_p426.Expansions.Gear
{
    public class PartyGearInventory : PartyInventory
    {
        public List<Gear> Gears { get; set; }
        public PartyGearInventory(List<CharacterGearInventory> charactersGearInventory, PartyType partyType, string name, Inventory inventory) : base(charactersGearInventory, partyType, name, inventory)
        {
        }

        public PartyGearInventory(PartyType partyType, string name, Inventory inventory) : base(partyType, name, inventory)
        {
        }
    }
}
