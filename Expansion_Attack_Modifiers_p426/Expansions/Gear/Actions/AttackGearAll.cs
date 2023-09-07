using Expansion_Attack_Modifiers_p426;
using Expansion_Attack_Modifiers_p426.Expansions.Gear;
using Expansion_Attack_Modifiers_p426.Expansions.Stolen_Inventory;
using Expansion_Attack_Modifiers_p426.Expansions.Vin_Fletcher;
using System.Runtime.ConstrainedExecution;

namespace Expansion_Attack_Modifiers_p426.Expansions.Gear.Actions
{
    public class AttackGearAll : IActionGear
    {
        // gear attack action
        public void Actions(Battle battle, CharacterGearInventory currentCharacter, CharacterGearInventory targetCharacter, ActionTypes characterAction, string strExpansions)
        {
            string attackName = "";
            int damageDealt = 0;
            int j = currentCharacter.AvailableActions.FindIndex(x => x.ActionType.Equals(characterAction));
            switch (strExpansions)
            {
                // gear and vin fletcher expansions
                case "024":
                // gear, stolen inventory and vin fletcher expansions
                case "0234":
                // gear, items, stolen inventory and vin fletcher expansions
                case "01234":
                    {
                        Random random = new Random();
                        if (random.NextDouble() > currentCharacter.CharacterInventory.WeaponHitChances[0].HitChance)
                        {
                            if (j >= 0)
                            {
                                attackName = currentCharacter.AvailableActions[j].Name;
                                Random randomDamage = new Random();
                                // if minimum and maximum damage are the same
                                if (currentCharacter.AvailableActions[j].MinAmount == currentCharacter.AvailableActions[j].MaxAmount)
                                {
                                    damageDealt = randomDamage.Next(currentCharacter.AvailableActions[j].MinAmount, currentCharacter.AvailableActions[j].MaxAmount);
                                }
                                // if minimum and maximum damage are different
                                else
                                {
                                    damageDealt = randomDamage.Next(currentCharacter.AvailableActions[j].MinAmount, currentCharacter.AvailableActions[j].MaxAmount + 1);
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine($"{currentCharacter.Name}'s {attackName} missed {targetCharacter.Name}");
                        }
                        break;
                    }
                default:
                    {
                        if (j >= 0)
                        {
                            attackName = currentCharacter.AvailableActions[j].Name;
                            Random randomDamage = new Random();
                            // if minimum and maximum damage are the same
                            if (currentCharacter.AvailableActions[j].MinAmount == currentCharacter.AvailableActions[j].MaxAmount)
                            {
                                damageDealt = randomDamage.Next(currentCharacter.AvailableActions[j].MinAmount, currentCharacter.AvailableActions[j].MaxAmount);
                            }
                            // if minimum and maximum damage are different
                            else
                            {
                                damageDealt = randomDamage.Next(currentCharacter.AvailableActions[j].MinAmount, currentCharacter.AvailableActions[j].MaxAmount + 1);
                            }
                        }
                        break;
                    }
            }
            Console.WriteLine($"It is {currentCharacter.Name}'s turn...");
            Console.WriteLine($"{currentCharacter.Name} used {attackName} on {targetCharacter.Name}.");
            Console.WriteLine($"{attackName} dealt {damageDealt} to {targetCharacter.Name}.");
            targetCharacter.CurrentHP = targetCharacter.CurrentHP - damageDealt;
            // ensures the target's current hit points don't go negative
            if (targetCharacter.CurrentHP < 0)
            {
                targetCharacter.CurrentHP = 0;
            }
            Console.WriteLine($"{targetCharacter.Name} is now at {targetCharacter.CurrentHP}/{targetCharacter.MaxHP} HP.");
            // if the current party type is heroes
            if (battle.CurrentPartyType.Equals(PartyType.Heroes))
            {
                switch (strExpansions)
                {
                    // items expansions
                    case "01":
                    // items and stolen inventory expansions
                    case "013":
                    // item and vin fletcher expansions
                    case "014":
                    // items, stolen inventory and vin fletcher expansions
                    case "0134":
                        {
                            for (int i = 0; i < battle.MonstersItemInventory[battle.CurrentMonsterPartyNumber].Characters.Count; i++)
                            {
                                if (battle.MonstersItemInventory[battle.CurrentMonsterPartyNumber].Characters[i].Name.Equals(targetCharacter.Name) && battle.MonstersItemInventory[battle.CurrentMonsterPartyNumber].Characters[i].CurrentHP == 0)
                                {
                                    Console.WriteLine($"{targetCharacter.Name} has been defeated!");
                                    battle.MonstersItemInventory[battle.CurrentMonsterPartyNumber].Characters.RemoveAt(i);
                                }
                            }
                            break;
                        }
                    // gear expansion
                    case "02":
                    // items and gear expansions
                    case "012":
                    // gear and vin fletcher expansions
                    case "024":
                    // items, gear and vin fletcher expansions
                    case "0124":
                        {
                            for (int i = 0; i < battle.MonstersGearInventory[battle.CurrentMonsterPartyNumber].CharactersGearInventory.Count; i++)
                            {
                                if (battle.MonstersGearInventory[battle.CurrentMonsterPartyNumber].CharactersGearInventory[i].Name.Equals(targetCharacter.Name) && battle.MonstersGearInventory[battle.CurrentMonsterPartyNumber].CharactersGearInventory[i].CurrentHP == 0)
                                {
                                    Console.WriteLine($"{targetCharacter.Name} has been defeated!");
                                    battle.MonstersGearInventory[battle.CurrentMonsterPartyNumber].CharactersGearInventory.RemoveAt(i);
                                }
                            }
                            break;
                        }
                    // gear and stolen inventory expansions
                    case "023":
                    // items, gear and stolen inventory expansions
                    case "0123":
                    // gear, stolen inventory and vin fletcher expansions
                    case "0234":
                    // items, gear, stolen inventory and vin fletcher expansions
                    case "01234":
                        {
                            for (int i = 0; i < battle.MonstersGearInventory[battle.CurrentMonsterPartyNumber].CharactersGearInventory.Count; i++)
                            {
                                if (battle.MonstersGearInventory[battle.CurrentMonsterPartyNumber].CharactersGearInventory[i].Name.Equals(targetCharacter.Name) && battle.MonstersGearInventory[battle.CurrentMonsterPartyNumber].CharactersGearInventory[i].CurrentHP == 0)
                                {
                                    Console.WriteLine($"{targetCharacter.Name} has been defeated!");
                                    StolenInventories stolenInventories = new StolenInventories();
                                    stolenInventories.StolenInventory(battle, targetCharacter, battle.CurrentPartyGearInventory);
                                    battle.MonstersGearInventory[battle.CurrentMonsterPartyNumber].CharactersGearInventory.RemoveAt(i);
                                }
                            }
                            break;
                        }
                    // gear and attack modifiers expansions
                    case "025":
                    // items, gear and attack modifiers expansions
                    case "0125":
                    // gear, vin fletcher and attack modifiers expansions
                    case "0245":
                    // items, gear, vin fletcher and attack modifiers expansions
                    case "01245":
                        {
                            for (int i = 0; i < battle.MonstersPartyAttackModifierGearinventory[battle.CurrentMonsterPartyNumber].CharacterAttackModifiersGearInventory.Count; i++)
                            {
                                if (battle.MonstersPartyAttackModifierGearinventory[battle.CurrentMonsterPartyNumber].CharacterAttackModifiersGearInventory[i].Name.Equals(targetCharacter.Name) && battle.MonstersPartyAttackModifierGearinventory[battle.CurrentMonsterPartyNumber].CharacterAttackModifiersGearInventory[i].CurrentHP == 0)
                                {
                                    Console.WriteLine($"{targetCharacter.Name} has been defeated!");
                                    battle.MonstersPartyAttackModifierGearinventory[battle.CurrentMonsterPartyNumber].CharacterAttackModifiersGearInventory.RemoveAt(i);
                                }
                            }
                            break;
                        }
                    // gear, stolen inventory and attack modifiers expansions
                    case "0235":
                    // items, gear, stolen inventory and attack modifiers expansions
                    case "01235":
                    // gear, stolen inventory, vin fletcher and attack modifiers expansions
                    case "02345":
                    // items, gear, stolen inventory, vin fletcher and attack modifiers expansions
                    case "012345":
                        {
                            for (int i = 0; i < battle.MonstersPartyAttackModifierGearinventory[battle.CurrentMonsterPartyNumber].CharacterAttackModifiersGearInventory.Count; i++)
                            {
                                if (battle.MonstersPartyAttackModifierGearinventory[battle.CurrentMonsterPartyNumber].CharacterAttackModifiersGearInventory[i].Name.Equals(targetCharacter.Name) && battle.MonstersPartyAttackModifierGearinventory[battle.CurrentMonsterPartyNumber].CharacterAttackModifiersGearInventory[i].CurrentHP == 0)
                                {
                                    Console.WriteLine($"{targetCharacter.Name} has been defeated!");
                                    StolenInventories stolenInventories = new StolenInventories();
                                    stolenInventories.StolenInventory(battle, targetCharacter, battle.CurrentPartyAttackModifierGearInventory);
                                    battle.MonstersPartyAttackModifierGearinventory[battle.CurrentMonsterPartyNumber].CharacterAttackModifiersGearInventory.RemoveAt(i);
                                }
                            }
                            break;
                        }
                    // game's status expansion
                    // vin fletcher expansion
                    default:
                        {
                            for (int i = 0; i < battle.Monsters[battle.CurrentMonsterPartyNumber].Characters.Count; i++)
                            {
                                if (battle.Monsters[battle.CurrentMonsterPartyNumber].Characters[i].Name.Equals(targetCharacter.Name) && battle.Monsters[battle.CurrentMonsterPartyNumber].Characters[i].CurrentHP == 0)
                                {
                                    Console.WriteLine($"{targetCharacter.Name} has been defeated!");
                                    battle.Monsters[battle.CurrentMonsterPartyNumber].Characters.RemoveAt(i);
                                }
                            }
                            break;
                        }
                }
            }
            // current party type is monsters
            else
            {
                switch (strExpansions)
                {
                    // items expansion
                    case "01":
                    // items and stolen inventory expansions
                    case "013":
                    // items and vin fletcher expansions
                    case "014":
                    // items, stolen inventory and vin fletcher expansions
                    case "0134":
                        {
                            for (int i = 0; i < battle.HeroesItemInventory.Characters.Count; i++)
                            {
                                if (battle.HeroesItemInventory.Characters[i].Name.Equals(targetCharacter.Name) && battle.HeroesItemInventory.Characters[i].CurrentHP == 0)
                                {
                                    Console.WriteLine($"{targetCharacter.Name} has been defeated!");
                                    battle.HeroesItemInventory.CharactersGearInventory.RemoveAt(i);
                                }
                            }
                            break;
                        }
                    // gear expansion
                    case "02":
                    // itens and gear expansions
                    case "012":
                    // gear and vin fletcher expansions
                    case "024":
                    // items, gear and vin fletcher expansions
                    case "0124":
                        {
                            for (int i = 0; i < battle.HeroesGearInventory.CharactersGearInventory.Count; i++)
                            {
                                if (battle.HeroesGearInventory.CharactersGearInventory[i].Name.Equals(targetCharacter.Name) && battle.HeroesGearInventory.CharactersGearInventory[i].CurrentHP == 0)
                                {
                                    Console.WriteLine($"{targetCharacter.Name} has been defeated!");
                                    battle.HeroesGearInventory.CharactersGearInventory.RemoveAt(i);
                                }
                            }
                            break;
                        }
                    // gear and stolen inventory expansions
                    case "023":
                    // items, gear and stolen inventory expansions
                    case "0123":
                    // gear, stolen inventory and vin fletcher expansions
                    case "0234":
                    // items, gear, stolen inventory and vin fletcher expansions
                    case "01234":
                        {
                            for (int i = 0; i < battle.HeroesGearInventory.CharactersGearInventory.Count; i++)
                            {
                                if (battle.HeroesGearInventory.CharactersGearInventory[i].Name.Equals(targetCharacter.Name) && battle.HeroesGearInventory.CharactersGearInventory[i].CurrentHP == 0)
                                {
                                    Console.WriteLine($"{targetCharacter.Name} has been defeated!");
                                    StolenInventories stolenInventories = new StolenInventories();
                                    stolenInventories.StolenInventory(battle, targetCharacter, battle.CurrentPartyGearInventory);
                                    battle.HeroesGearInventory.CharactersGearInventory.RemoveAt(i);
                                }
                            }
                            break;
                        }
                    // gear and attack modifiers expansions
                    case "025":
                    // items, gear and attack modifiers expansions
                    case "0125":
                    // gear, vin fletcher and attack modifiers expansions
                    case "0245":
                    // items, gear, vin fletcher and attack modifiers expansions
                    case "01245":
                        {
                            for (int i = 0; i < battle.HeroesPartyAttackModifierGearinventory.CharacterAttackModifiersGearInventory.Count; i++)
                            {
                                if (battle.HeroesPartyAttackModifierGearinventory.CharacterAttackModifiersGearInventory[i].Name.Equals(targetCharacter.Name) && battle.HeroesPartyAttackModifierGearinventory.CharacterAttackModifiersGearInventory[i].CurrentHP == 0)
                                {
                                    Console.WriteLine($"{targetCharacter.Name} has been defeated!");
                                    battle.HeroesPartyAttackModifierGearinventory.CharacterAttackModifiersGearInventory.RemoveAt(i);
                                }
                            }
                            break;
                        }
                    // gear, stolen inventory and attack modifiers expansions
                    case "0235":
                    // items, gear, stolen inventory and attack modifiers expansions
                    case "01235":
                    // gear, stolen inventory, vin fletcher and attack modifiers expansions
                    case "02345":
                    // items, gear, stolen inventory, vin fletcher and attack modifiers expansions
                    case "012345":
                        {
                            for (int i = 0; i < battle.HeroesPartyAttackModifierGearinventory.CharacterAttackModifiersGearInventory.Count; i++)
                            {
                                if (battle.HeroesPartyAttackModifierGearinventory.CharacterAttackModifiersGearInventory[i].Name.Equals(targetCharacter.Name) && battle.HeroesPartyAttackModifierGearinventory.CharacterAttackModifiersGearInventory[i].CurrentHP == 0)
                                {
                                    Console.WriteLine($"{targetCharacter.Name} has been defeated!");
                                    StolenInventories stolenInventories = new StolenInventories();
                                    stolenInventories.StolenInventory(battle, targetCharacter, battle.CurrentPartyAttackModifierGearInventory);
                                    battle.HeroesPartyAttackModifierGearinventory.CharacterAttackModifiersGearInventory.RemoveAt(i);
                                }
                            }
                            break;
                        }
                    // game's status expansion
                    // vin fletcher expansion
                    default:
                        {
                            for (int i = 0; i < battle.Heroes.Characters.Count; i++)
                            {
                                if (battle.Heroes.Characters[i].Name.Equals(targetCharacter.Name) && battle.Heroes.Characters[i].CurrentHP == 0)
                                {
                                    Console.WriteLine($"{targetCharacter.Name} has been defeated!");
                                    battle.Heroes.Characters.RemoveAt(i);
                                }
                            }
                            break;
                        }
                }
            }
            Console.WriteLine("\n");
        }

        // gear attack action with vin fletcher expansion
        public void Actions(Battle battle, CharacterGearInventoryHitChance currentCharacter, CharacterGearInventoryHitChance targetCharacter, ActionTypes characterAction, string strExpansions)
        {
            string attackName = "";
            int damageDealt = 0;
            int j = currentCharacter.AvailableActionHitChances.FindIndex(x => x.ActionType.Equals(characterAction));
            bool hit = false;
            switch (strExpansions)
            {
                // gear and vin fletcher expansions
                case "024":
                // gear, items and vin fletcher expansions
                case "0124":
                // gear, stolen inventory and vin fletcher expansions
                case "0234":
                // gear, items, stolen inventory and vin fletcher expansions
                case "01234":
                    {
                        Random random = new Random();
                        double randomHitChance = random.NextDouble();
                        if (/*random.NextDouble()*/ randomHitChance <= currentCharacter.CharacterInventory.WeaponHitChances[0].HitChance)
                        {
                            if (j >= 0)
                            {
                                attackName = currentCharacter.AvailableActionHitChances[j].Name;
                                Random randomDamage = new Random();
                                // if minimum and maximum damage are the same
                                if (currentCharacter.AvailableActionHitChances[j].MinAmount == currentCharacter.AvailableActionHitChances[j].MaxAmount)
                                {
                                    damageDealt = randomDamage.Next(currentCharacter.AvailableActionHitChances[j].MinAmount, currentCharacter.AvailableActionHitChances[j].MaxAmount);
                                }
                                // if minimum and maximum damage are different
                                else
                                {
                                    damageDealt = randomDamage.Next(currentCharacter.AvailableActionHitChances[j].MinAmount, currentCharacter.AvailableActionHitChances[j].MaxAmount + 1);
                                }
                            }
                            hit = true;
                        }
                        else
                        {
                            Console.WriteLine($"{currentCharacter.Name}'s {attackName} missed {targetCharacter.Name}");
                            hit = false;
                        }
                        break;
                    }
                default:
                    {
                        if (j >= 0)
                        {
                            attackName = currentCharacter.AvailableActionHitChances[j].Name;
                            Random randomDamage = new Random();
                            // if minimum and maximum damage are the same
                            if (currentCharacter.AvailableActionHitChances[j].MinAmount == currentCharacter.AvailableActionHitChances[j].MaxAmount)
                            {
                                damageDealt = randomDamage.Next(currentCharacter.AvailableActionHitChances[j].MinAmount, currentCharacter.AvailableActionHitChances[j].MaxAmount);
                            }
                            // if minimum and maximum damage are different
                            else
                            {
                                damageDealt = randomDamage.Next(currentCharacter.AvailableActionHitChances[j].MinAmount, currentCharacter.AvailableActionHitChances[j].MaxAmount + 1);
                            }
                        }
                        break;
                    }
            }
            if (hit)
            {
                Console.WriteLine($"It is {currentCharacter.Name}'s turn...");
                Console.WriteLine($"{currentCharacter.Name} used {attackName} on {targetCharacter.Name}.");
                Console.WriteLine($"{attackName} dealt {damageDealt} to {targetCharacter.Name}.");
                targetCharacter.CurrentHP = targetCharacter.CurrentHP - damageDealt;
                // ensures the target's current hit points don't go negative
                if (targetCharacter.CurrentHP < 0)
                {
                    targetCharacter.CurrentHP = 0;
                }
                Console.WriteLine($"{targetCharacter.Name} is now at {targetCharacter.CurrentHP}/{targetCharacter.MaxHP} HP.");
                // if the current party type is heroes
                if (battle.CurrentPartyType.Equals(PartyType.Heroes))
                {
                    switch (strExpansions)
                    {
                        // item and vin fletcher expansions
                        case "014":
                        // items, stolen inventory and vin fletcher expansions
                        case "0134":
                            {
                                for (int i = 0; i < battle.MonstersItemInventoryHitChance[battle.CurrentMonsterPartyNumber].CharactersHitChance.Count; i++)
                                {
                                    if (battle.MonstersItemInventoryHitChance[battle.CurrentMonsterPartyNumber].CharactersHitChance[i].Name.Equals(targetCharacter.Name) && battle.MonstersItemInventoryHitChance[battle.CurrentMonsterPartyNumber].CharactersHitChance[i].CurrentHP == 0)
                                    {
                                        Console.WriteLine($"{targetCharacter.Name} has been defeated!");
                                        battle.MonstersItemInventoryHitChance[battle.CurrentMonsterPartyNumber].CharactersHitChance.RemoveAt(i);
                                    }
                                }
                                break;
                            }
                        // gear and vin fletcher expansions
                        case "024":
                        // items, gear and vin fletcher expansions
                        case "0124":
                            {
                                for (int i = 0; i < battle.MonstersPartyGearInventoryHitChances[battle.CurrentMonsterPartyNumber].CharacterGearInventoryHitChances.Count; i++)
                                {
                                    if (battle.MonstersPartyGearInventoryHitChances[battle.CurrentMonsterPartyNumber].CharacterGearInventoryHitChances[i].Name.Equals(targetCharacter.Name) && battle.MonstersPartyGearInventoryHitChances[battle.CurrentMonsterPartyNumber].CharacterGearInventoryHitChances[i].CurrentHP == 0)
                                    {
                                        Console.WriteLine($"{targetCharacter.Name} has been defeated!");
                                        battle.MonstersPartyGearInventoryHitChances[battle.CurrentMonsterPartyNumber].CharacterGearInventoryHitChances.RemoveAt(i);
                                    }
                                }
                                break;
                            }
                        // gear, stolen inventory and vin fletcher expansions
                        case "0234":
                        // items, gear, stolen inventory and vin fletcher expansions
                        case "01234":
                            {
                                for (int i = 0; i < battle.MonstersPartyGearInventoryHitChances[battle.CurrentMonsterPartyNumber].CharacterGearInventoryHitChances.Count; i++)
                                {
                                    if (battle.MonstersPartyGearInventoryHitChances[battle.CurrentMonsterPartyNumber].CharacterGearInventoryHitChances[i].Name.Equals(targetCharacter.Name) && battle.MonstersPartyGearInventoryHitChances[battle.CurrentMonsterPartyNumber].CharacterGearInventoryHitChances[i].CurrentHP == 0)
                                    {
                                        Console.WriteLine($"{targetCharacter.Name} has been defeated!");
                                        StolenInventories stolenInventories = new StolenInventories();
                                        stolenInventories.StolenInventory(battle, targetCharacter, battle.CurrentPartyGearInventoryHitChance);
                                        battle.MonstersPartyGearInventoryHitChances[battle.CurrentMonsterPartyNumber].CharacterGearInventoryHitChances.RemoveAt(i);
                                    }
                                }
                                break;
                            }
                        // game's status expansion
                        // vin fletcher expansion
                        default:
                            {
                                for (int i = 0; i < battle.Monsters[battle.CurrentMonsterPartyNumber].CharactersHitChance.Count; i++)
                                {
                                    if (battle.Monsters[battle.CurrentMonsterPartyNumber].CharactersHitChance[i].Name.Equals(targetCharacter.Name) && battle.Monsters[battle.CurrentMonsterPartyNumber].CharactersHitChance[i].CurrentHP == 0)
                                    {
                                        Console.WriteLine($"{targetCharacter.Name} has been defeated!");
                                        battle.Monsters[battle.CurrentMonsterPartyNumber].CharactersHitChance.RemoveAt(i);
                                    }
                                }
                                break;
                            }
                    }
                }
                // current party type is monsters
                else
                {
                    switch (strExpansions)
                    {
                        // items and vin fletcher expansions
                        case "014":
                        // items, stolen inventory and vin fletcher expansions
                        case "0134":
                            {
                                for (int i = 0; i < battle.HeroesItemInventoryHitChance.CharactersHitChance.Count; i++)
                                {
                                    if (battle.HeroesItemInventoryHitChance.CharactersHitChance[i].Name.Equals(targetCharacter.Name) && battle.HeroesItemInventoryHitChance.CharactersHitChance[i].CurrentHP == 0)
                                    {
                                        Console.WriteLine($"{targetCharacter.Name} has been defeated!");
                                        battle.HeroesItemInventoryHitChance.CharactersHitChance.RemoveAt(i);
                                    }
                                }
                                break;
                            }
                        // gear and vin fletcher expansions
                        case "024":
                        // items, gear and vin fletcher expansions
                        case "0124":
                            {
                                for (int i = 0; i < battle.HeroesPartyGearInventoryHitChance.CharacterGearInventoryHitChances.Count; i++)
                                {
                                    if (battle.HeroesPartyGearInventoryHitChance.CharacterGearInventoryHitChances[i].Name.Equals(targetCharacter.Name) && battle.HeroesPartyGearInventoryHitChance.CharacterGearInventoryHitChances[i].CurrentHP == 0)
                                    {
                                        Console.WriteLine($"{targetCharacter.Name} has been defeated!");
                                        battle.HeroesPartyGearInventoryHitChance.CharacterGearInventoryHitChances.RemoveAt(i);
                                    }
                                }
                                break;
                            }
                        // gear, stolen inventory and vin fletcher expansions
                        case "0234":
                        // items, gear, stolen inventory and vin fletcher expansions
                        case "01234":
                            {
                                for (int i = 0; i < battle.HeroesPartyGearInventoryHitChance.CharacterGearInventoryHitChances.Count; i++)
                                {
                                    if (battle.HeroesPartyGearInventoryHitChance.CharacterGearInventoryHitChances[i].Name.Equals(targetCharacter.Name) && battle.HeroesPartyGearInventoryHitChance.CharacterGearInventoryHitChances[i].CurrentHP == 0)
                                    {
                                        Console.WriteLine($"{targetCharacter.Name} has been defeated!");
                                        StolenInventories stolenInventories = new StolenInventories();
                                        stolenInventories.StolenInventory(battle, targetCharacter, battle.CurrentPartyGearInventoryHitChance);
                                        battle.HeroesPartyGearInventoryHitChance.CharacterGearInventoryHitChances.RemoveAt(i);
                                    }
                                }
                                break;
                            }
                        // game's status expansion
                        // vin fletcher expansion
                        default:
                            {
                                for (int i = 0; i < battle.Heroes.Characters.Count; i++)
                                {
                                    if (battle.Heroes.Characters[i].Name.Equals(targetCharacter.Name) && battle.Heroes.Characters[i].CurrentHP == 0)
                                    {
                                        Console.WriteLine($"{targetCharacter.Name} has been defeated!");
                                        battle.Heroes.Characters.RemoveAt(i);
                                    }
                                }
                                break;
                            }
                    }
                }
            }
            Console.WriteLine("\n");
        }
    }
}
