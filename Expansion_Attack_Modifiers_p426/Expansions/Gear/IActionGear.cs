using Expansion_Attack_Modifiers_p426;

namespace Expansion_Attack_Modifiers_p426.Expansions.Gear
{
    public interface IActionGear
    {
        public void Actions(Battle battle, CharacterGearInventory currentCharacterGearInventory, CharacterGearInventory targetCharacterGearInventory, ActionTypes action, string strExpansions);
    }
}
