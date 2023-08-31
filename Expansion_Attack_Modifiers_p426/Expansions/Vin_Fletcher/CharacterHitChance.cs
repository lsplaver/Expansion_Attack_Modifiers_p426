using Expansion_Attack_Modifiers_p426;
using Expansion_Attack_Modifiers_p426.Expansions.Vin_Fletcher.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expansion_Attack_Modifiers_p426.Expansions.Vin_Fletcher
{
    public class CharacterHitChance : Character
    {
        public List<AvailableActionHitChance> AvailableActionHitChances { get; set; }
        public CharacterHitChance(string name, List<AvailableActionHitChance> availableActionsHitChances, int maxHP, string characterID) : base(name, maxHP, characterID)
        {
            Name = name;
            AvailableActionHitChances = availableActionsHitChances;
            MaxHP = maxHP;
            CurrentHP = MaxHP;
            CharacterID = characterID;
        }
    }
}
