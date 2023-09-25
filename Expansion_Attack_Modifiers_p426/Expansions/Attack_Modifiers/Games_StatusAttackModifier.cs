﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expansion_Attack_Modifiers_p426.Expansions.Attack_Modifiers
{
    public class Games_StatusAttackModifier
    {
        // attack modifier expansion
        public void GamesStatus(Battle battle, Party currentMonsterParty, string strExpansion)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("================================== BATTLE ==================================");
            if (strExpansion.Equals("05"))
            {
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
            }
            else if (strExpansion.Equals("045"))
            {
                foreach (Character c in battle.Heroes.CharactersAttackModifierHitChance)
                {
                    if (c.Name.Equals(battle.CurrentCharacterAttackModifierHitChance.Name))
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    Console.WriteLine($"{c.Name} \t{c.CurrentHP}/{c.MaxHP}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine("==================================   VS   ==================================");
                foreach (Character c in currentMonsterParty.CharactersAttackModifierHitChance)
                {
                    if (c.CharacterID.Equals(battle.CurrentCharacterAttackModifierHitChance.CharacterID))
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    Console.WriteLine($"{c.Name} \t{c.CurrentHP}/{c.MaxHP}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            Console.WriteLine("============================================================================");
        }
        // items and attack modifier expansions
        // items, stolen inventory and attack modifier expansions
        public void GamesStatus(Battle battle, PartyAttackModifierItemInventory currentMonsterParty)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("================================== BATTLE ==================================");
            foreach (Character c in battle.HeroesPartyAttackModifierItemInventory.CharacterAttackModifiers)
            {
                if (c.Name.Equals(battle.CurrentCharacterAttackModifier.Name))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                Console.WriteLine($"{c.Name} \t{c.CurrentHP}/{c.MaxHP}");
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine("==================================   VS   ==================================");
            foreach (Character c in currentMonsterParty.CharacterAttackModifiers)
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
        // gear and attack modifier expansions
        // gear, stolen inventory and attack modifier expansions
        public void GamesStatus(Battle battle, PartyAttackModifierGearInventory currentMonsterParty)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("================================== BATTLE ==================================");
            foreach (Character c in battle.HeroesPartyAttackModifierGearInventory.CharacterAttackModifiersGearInventory)
            {
                if (c.Name.Equals(battle.CurrentCharacterAttackModifierGearInventory.Name))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                Console.WriteLine($"{c.Name} \t{c.CurrentHP}/{c.MaxHP}");
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine("==================================   VS   ==================================");
            foreach (Character c in currentMonsterParty.CharacterAttackModifiersGearInventory)
            {
                if (c.CharacterID.Equals(battle.CurrentCharacterAttackModifierGearInventory.CharacterID))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                Console.WriteLine($"{c.Name} \t{c.CurrentHP}/{c.MaxHP}");
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine("============================================================================");
        }
        /*public void GamesStatus(Battle battle, Party currentMonsterParty)
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
        }*/
    }
}
