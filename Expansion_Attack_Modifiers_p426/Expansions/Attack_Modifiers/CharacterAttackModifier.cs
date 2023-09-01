using Expansion_Attack_Modifiers_p426.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expansion_Attack_Modifiers_p426.Expansions.Attack_Modifiers
{
    public class CharacterAttackModifier : Character
    {
        public List<AttackModifierOffensive> AttackModifiersOffensive { get; set; }
        public List<AttackModifierDefensive> AttackModifiersDefensive { get; set; }
        public CharacterAttackModifier(string name, int maxHP, string characterID, List<AttackModifierOffensive> attackModifiersOffensive, List<AttackModifierDefensive> attackModifiersDefensive) : base(name, maxHP, characterID)
        {
            AttackModifiersOffensive = attackModifiersOffensive;
            AttackModifiersDefensive = attackModifiersDefensive;
        }

        public CharacterAttackModifier(string name, List<AvailableAction> availableActions, int maxHP, string characterID, List<AttackModifierOffensive> attackModifiersOffensive, List<AttackModifierDefensive> attackModifiersDefensive) : base(name, availableActions, maxHP, characterID)
        {
            AttackModifiersOffensive = attackModifiersOffensive;
            AttackModifiersDefensive = attackModifiersDefensive;
        }
    }
}
