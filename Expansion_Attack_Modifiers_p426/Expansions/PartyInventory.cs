using Expansion_Attack_Modifiers_p426;
using Expansion_Attack_Modifiers_p426.Expansions.Gear;

namespace Expansion_Attack_Modifiers_p426.Expansions
{
    public class PartyInventory : Party
    {
        public Inventory Inventory { get; set; }
        public List<CharacterGearInventory> CharactersGearInventory { get; set; }

        public PartyInventory(List<Character> characters, PartyType partyType, string name, Inventory inventory) : base(characters, partyType, name)
        {
            Inventory = inventory;
        }

        public PartyInventory(List<CharacterGearInventory> characters, PartyType partyType, string name, Inventory inventory) : base(characters, partyType, name)
        {
            CharactersGearInventory = characters;
            PartyType = partyType;
            Name = name;
            Inventory = inventory;
        }

        public PartyInventory(PartyType partyType, string name, Inventory inventory) : base(partyType, name)
        {
            PartyType = partyType;
            Name = name;
            Inventory = inventory;
        }
    }
}
