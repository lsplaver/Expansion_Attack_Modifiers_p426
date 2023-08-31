using Expansion_Attack_Modifiers_p426;
using Expansion_Attack_Modifiers_p426.Expansions.Vin_Fletcher;

namespace Expansion_Attack_Modifiers_p426.Interfaces
{
    internal interface IAction
    {
        public void Actions(Battle battle, Character currentCharacter, Character targetCharacter, ActionTypes action, string strExpansions);
        public void Actions(Battle battle, CharacterHitChance currentCharacter, CharacterHitChance targetCharacter, ActionTypes action, string strExpansions);
    }
}
