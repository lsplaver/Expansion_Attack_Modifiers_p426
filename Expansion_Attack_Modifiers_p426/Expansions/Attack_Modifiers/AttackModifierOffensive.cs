using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expansion_Attack_Modifiers_p426.Expansions.Attack_Modifiers
{
    public enum AttackModifierOffensiveCategory { DR_OVERRIDE }
    public class AttackModifierOffensive : AttackModifier
    {
        public AttackModifierOffensiveCategory Category { get; set; }
        public double DROverrideChance { get; set; }
        public AttackModifierOffensive(AttackModifierType modifierType, string name, int amount, AttackModifierOffensiveCategory category) : base(modifierType, name, amount)
        {
            Category = category;
        }
        public AttackModifierOffensive(AttackModifierType modifierType, string name, int amount, AttackModifierOffensiveCategory category, double drOverrideChance) : base(modifierType, name, amount)
        {
            Category = category;
            DROverrideChance = drOverrideChance;
        }
    }
}
