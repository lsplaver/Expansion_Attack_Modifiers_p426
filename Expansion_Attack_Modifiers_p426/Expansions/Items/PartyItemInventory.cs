using Expansion_Attack_Modifiers_p426;
using Expansion_Attack_Modifiers_p426.Expansions;

namespace Expansion_Attack_Modifiers_p426.Expansions.Items
{
    public class PartyItemInventory : PartyInventory
    {
        public List<Item> Items { get; set; }
        public PartyItemInventory(List<Character> characters, PartyType partyType, string name, Inventory inventory) : base(characters, partyType, name, inventory)
        {
        }

        public PartyItemInventory(PartyType partyType, string name, Inventory inventory) : base(partyType, name, inventory) { }
    }
}
