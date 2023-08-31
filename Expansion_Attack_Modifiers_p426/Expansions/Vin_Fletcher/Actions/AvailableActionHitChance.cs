using Expansion_Attack_Modifiers_p426;
using Expansion_Attack_Modifiers_p426.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expansion_Attack_Modifiers_p426.Expansions.Vin_Fletcher.Actions
{
    public class AvailableActionHitChance : AvailableAction
    {
        public double? HitChance { get; set; }
        public AvailableActionHitChance(double? hitChance) : base()
        {
            Name = "NOTHING";
            ActionType = ActionTypes.NOTHING;
        }
        public AvailableActionHitChance(string name, int minAmount, int maxAmount, ActionTypes actionType, double? hitChance) : base(name, minAmount, maxAmount, actionType)
        {
            HitChance = hitChance;
        }
    }
}
