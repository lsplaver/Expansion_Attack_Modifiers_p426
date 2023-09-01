using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expansion_Attack_Modifiers_p426.Expansions.Attack_Modifiers
{
    public enum AttackModifierDefensiveCategory { DAMAGE_REDUCTION }
    public class AttackModifierDefensive : AttackModifier
    {
        public AttackModifierDefensiveCategory Category { get; set; }
        public AttackModifierDefensive(AttackModifierType modifierType, string name, int amount, AttackModifierDefensiveCategory category) : base(modifierType, name, amount)
        {
            Category = category;
        }
    }
}
