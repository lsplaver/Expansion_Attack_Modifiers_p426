using Expansion_Attack_Modifiers_p426;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expansion_Attack_Modifiers_p426.Expansions.Vin_Fletcher
{
    public class Games_StatusHitChance
    {
        public void GamesStatusHitChance(Battle battle, Party currentMonsterParty)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("================================== BATTLE ==================================");
            foreach (Character c in battle.Heroes.CharactersHitChance)
            {
                if (c.Name.Equals(battle.CurrentCharacterHitChance.Name))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                Console.WriteLine($"{c.Name} \t{c.CurrentHP}/{c.MaxHP}");
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine("==================================   VS   ==================================");
            foreach (Character c in currentMonsterParty.CharactersHitChance)
            {
                if (c.CharacterID.Equals(battle.CurrentCharacterHitChance.CharacterID))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                Console.WriteLine($"{c.Name} \t{c.CurrentHP}/{c.MaxHP}");
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine("============================================================================");
        }
        public void GamesStatusHitChance(Battle battle, PartyItemInventoryHitChance currentMonsterPartyHitChance)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("================================== BATTLE ==================================");
            foreach (Character c in battle.HeroesItemInventoryHitChance.CharactersHitChance)
            {
                if (c.Name.Equals(battle.CurrentCharacterHitChance.Name))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                Console.WriteLine($"{c.Name} \t{c.CurrentHP}/{c.MaxHP}");
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine("==================================   VS   ==================================");
            foreach (Character c in currentMonsterPartyHitChance.CharactersHitChance)
            {
                if (c.CharacterID.Equals(battle.CurrentCharacterHitChance.CharacterID))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                Console.WriteLine($"{c.Name} \t{c.CurrentHP}/{c.MaxHP}");
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine("============================================================================");
        }
        public void GamesStatusHitChance(Battle battle, PartyGearInventoryHitChance currentMonsterPartyGearInventoryHitChance)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("================================== BATTLE ==================================");
            foreach (Character c in battle.HeroesPartyGearInventoryHitChance.CharacterGearInventoryHitChances)
            {
                if (c.Name.Equals(battle.CurrentCharacterGearInventoryHitChance.Name))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                Console.WriteLine($"{c.Name} \t{c.CurrentHP}/{c.MaxHP}");
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine("==================================   VS   ==================================");
            foreach (Character c in currentMonsterPartyGearInventoryHitChance.CharacterGearInventoryHitChances)
            {
                if (c.CharacterID.Equals(battle.CurrentCharacterGearInventoryHitChance.CharacterID))
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
