using Expansion_Attack_Modifiers_p426;

namespace Expansion_Attack_Modifiers_p426.Actions
{
    public class AvailableAction
    {
        public string Name { get; set; }
        public int MinAmount { get; set; }
        public int MaxAmount { get; set; }
        public ActionTypes ActionType { get; set; }
        public AvailableAction()
        {
            Name = "NOTHING";
            ActionType = ActionTypes.NOTHING;
        }
        public AvailableAction(string name, ActionTypes actionType)
        {
            Name = name;
            ActionType = actionType;
        }


        public AvailableAction(string name, int minAmount, int maxAmount, ActionTypes actionType)
        {
            Name = name;
            MinAmount = minAmount;
            MaxAmount = maxAmount;
            ActionType = actionType;
        }
    }
}
