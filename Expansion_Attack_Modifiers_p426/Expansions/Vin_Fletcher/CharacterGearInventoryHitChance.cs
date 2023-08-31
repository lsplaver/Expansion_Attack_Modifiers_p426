using Expansion_Attack_Modifiers_p426.Expansions;
using Expansion_Attack_Modifiers_p426.Expansions.Vin_Fletcher.Actions;
using Expansion_Attack_Modifiers_p426.Actions;
using Expansion_Attack_Modifiers_p426.Expansions.Gear;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expansion_Attack_Modifiers_p426.Expansions.Vin_Fletcher
{
    public class CharacterGearInventoryHitChance : CharacterHitChance
    {
        public Inventory CharacterInventory { get; set; }
        public CharacterGearInventoryHitChance(string name, List<AvailableActionHitChance> availableActionsHitChances, int maxHP, string characterID, Inventory characterInventory) : base(name, availableActionsHitChances, maxHP, characterID)
        {
            CharacterInventory = characterInventory;
        }
    }
}
