using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expansion_Attack_Modifiers_p426.Expansions.Attack_Modifiers
{
    public class Games_StatusAttackModifier
    {
        public void GamesStatus(Battle battle, Party currentMonsterParty)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("================================== BATTLE ==================================");
            foreach (Character c in battle.Heroes.CharactersAttackModifier)
            {
                if (c.Name.Equals(battle.CurrentCharacterAttackModifier.Name))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                Console.WriteLine($"{c.Name} \t{c.CurrentHP}/{c.MaxHP}");
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine("==================================   VS   ==================================");
            foreach (Character c in currentMonsterParty.CharactersAttackModifier)
            {
                if (c.CharacterID.Equals(battle.CurrentCharacterAttackModifier.CharacterID))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                Console.WriteLine($"{c.Name} \t{c.CurrentHP}/{c.MaxHP}");
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine("============================================================================");
        }
    }
}
