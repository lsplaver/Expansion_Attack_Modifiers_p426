using Expansion_Attack_Modifiers_p426;
using Expansion_Attack_Modifiers_p426.Expansions.Gear;
using Expansion_Attack_Modifiers_p426.Expansions.Items;

namespace Expansion_Attack_Modifiers_p426.Expansions
{
    public class Games_Status
    {
        public void GamesStatus(Battle battle, Party currentMonsterParty)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("================================== BATTLE ==================================");
            foreach (Character c in battle.Heroes.Characters)
            {
                if (c.Name.Equals(battle.CurrentCharacter.Name))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                Console.WriteLine($"{c.Name} \t{c.CurrentHP}/{c.MaxHP}");
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine("==================================   VS   ==================================");
            foreach (Character c in currentMonsterParty.Characters)
            {
                if (c.CharacterID.Equals(battle.CurrentCharacter.CharacterID))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                Console.WriteLine($"{c.Name} \t{c.CurrentHP}/{c.MaxHP}");
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine("============================================================================");
        }
        public void GamesStatus(Battle battle, PartyItemInventory currentMonsterParty)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("================================== BATTLE ==================================");
            foreach (Character c in battle.HeroesItemInventory.Characters)
            {
                if (c.Name.Equals(battle.CurrentCharacter.Name))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                Console.WriteLine($"{c.Name} \t{c.CurrentHP}/{c.MaxHP}");
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine("==================================   VS   ==================================");
            foreach (Character c in currentMonsterParty.Characters)
            {
                if (c.CharacterID.Equals(battle.CurrentCharacter.CharacterID))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                Console.WriteLine($"{c.Name} \t{c.CurrentHP}/{c.MaxHP}");
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine("============================================================================");
        }
        public void GamesStatus(Battle battle, PartyGearInventory currentMonsterParty)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("================================== BATTLE ==================================");
            foreach (Character c in battle.HeroesGearInventory.CharactersGearInventory)
            {
                if (c.Name.Equals(battle.CurrentCharacterGearInventory.Name))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                Console.WriteLine($"{c.Name} \t{c.CurrentHP}/{c.MaxHP}");
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine("==================================   VS   ==================================");
            foreach (Character c in currentMonsterParty.CharactersGearInventory)
            {
                if (c.CharacterID.Equals(battle.CurrentCharacterGearInventory.CharacterID))
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
