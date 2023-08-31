using Expansion_Attack_Modifiers_p426;
using Expansion_Attack_Modifiers_p426.Actions;

namespace Expansion_Attack_Modifiers_p426.Expansions.Gear.Actions
{
    public class AvailableActionEquip : AvailableAction
    {
        public AvailableActionEquip() : base()
        {
            Name = "EQUIP";
            ActionType = ActionTypes.GEAR_EQUIP;
        }
    }
}
