using Expansion_Attack_Modifiers_p426;
using Expansion_Attack_Modifiers_p426.Actions;
using Expansion_Attack_Modifiers_p426.Expansions;

namespace Expansion_Attack_Modifiers_p426.Expansions.Gear
{
    public class CharacterGearInventory : Character
    {
        public Inventory CharacterInventory { get; set; }

        public CharacterGearInventory(string name, List<AvailableAction> availableActions, int maxHP, string characterID, Inventory characterInventory) : base(name, availableActions, maxHP, characterID)
        {
            CharacterInventory = characterInventory;
        }

        public CharacterGearInventory(string name, int maxHP, string characterID, Inventory characterInventory) : base(name, maxHP, characterID)
        {
            CharacterInventory = characterInventory;
        }
    }
}
