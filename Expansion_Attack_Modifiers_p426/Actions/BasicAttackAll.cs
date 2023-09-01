using Expansion_Attack_Modifiers_p426;
using Expansion_Attack_Modifiers_p426.Expansions.Attack_Modifiers;
using Expansion_Attack_Modifiers_p426.Expansions.Stolen_Inventory;
using Expansion_Attack_Modifiers_p426.Expansions.Vin_Fletcher;
using Expansion_Attack_Modifiers_p426.Interfaces;

namespace Expansion_Attack_Modifiers_p426.Actions
{
    public class BasicAttackAll : IAction
    {
        public void Actions(Battle battle, Character currentCharacter, Character targetCharacter, ActionTypes characterAction, string strExpansions)
        {
            string attackName = "";
            int damageDealt = 0;
            for (int i = 0; i < currentCharacter.AvailableActions.Count; i++)
            {
                if (currentCharacter.AvailableActions[i].ActionType.Equals(characterAction))
                {
                    attackName = currentCharacter.AvailableActions[i].Name;
                    Random randomDamage = new Random();
                    if (currentCharacter.AvailableActions[i].MinAmount == currentCharacter.AvailableActions[i].MaxAmount)
                    {
                        damageDealt = randomDamage.Next(currentCharacter.AvailableActions[i].MinAmount, currentCharacter.AvailableActions[i].MaxAmount);
                    }
                    else
                    {
                        damageDealt = randomDamage.Next(currentCharacter.AvailableActions[i].MinAmount, currentCharacter.AvailableActions[i].MaxAmount + 1);
                    }
                }
            }
            DisplayResults(currentCharacter, attackName, targetCharacter, damageDealt);
            DetermineStolenInventory(battle, strExpansions, targetCharacter);
        }

        private void DetermineStolenInventory(Battle battle, string strExpansions, Character targetCharacter)
        {
            if (battle.CurrentPartyType.Equals(PartyType.Heroes))
            {
                switch (strExpansions)
                {
                    // items expansion
                    case "01":
                    // items and stolen inventory expansions
                    case "013":
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
                    // items and vin fletcher expansions
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
                    // gear expansion
                    case "02":
                    // items and gear expansions
                    case "012":
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
                    // gear and stolen inventory expansions
                    case "023":
                    // items, gear and stolen inventory expansions
                    case "0123":
                        {
                            for (int i = 0; i < battle.MonstersGearInventory[battle.CurrentMonsterPartyNumber].CharactersGearInventory.Count; i++)
                            {
                                if (battle.MonstersGearInventory[battle.CurrentMonsterPartyNumber].CharactersGearInventory[i].Name.Equals(targetCharacter.Name) && battle.MonstersGearInventory[battle.CurrentMonsterPartyNumber].CharactersGearInventory[i].CurrentHP == 0)
                                {
                                    Console.WriteLine($"{targetCharacter.Name} has been defeated!");
                                    StolenInventories stolenInventories = new StolenInventories();
                                    stolenInventories.StolenInventory(battle, battle.MonstersItemInventory[battle.CurrentMonsterPartyNumber].CharactersGearInventory[i], battle.CurrentPartyGearInventory);
                                    battle.MonstersGearInventory[battle.CurrentMonsterPartyNumber].CharactersGearInventory.RemoveAt(i);
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
                                    stolenInventories.StolenInventory(battle, battle.MonstersPartyGearInventoryHitChances[battle.CurrentMonsterPartyNumber].CharacterGearInventoryHitChances[i], battle.CurrentPartyGearInventoryHitChance);
                                    battle.MonstersPartyGearInventoryHitChances[battle.CurrentMonsterPartyNumber].CharacterGearInventoryHitChances.RemoveAt(i);
                                }
                            }
                            break;
                        }
                    // vin fletcher expansion
                    case "04":
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
                    // attack modifier expansion
                    case "05":
                        {
                            for (int i = 0; i < battle.Monsters[battle.CurrentMonsterPartyNumber].CharactersAttackModifier.Count; i++)
                            {
                                if (battle.Monsters[battle.CurrentMonsterPartyNumber].CharactersAttackModifier[i].Name.Equals(targetCharacter.Name) && battle.Monsters[battle.CurrentMonsterPartyNumber].CharactersAttackModifier[i].CurrentHP == 0)
                                {
                                    Console.WriteLine($"{targetCharacter.Name} has been defeated!");
                                    battle.Monsters[battle.CurrentMonsterPartyNumber].CharactersAttackModifier.RemoveAt(i);
                                }
                            }
                            break;
                        }
                    // game's status expansion
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
            else
            {
                switch (strExpansions)
                {
                    // items expansion
                    case "01":
                    // items and stolen inventory expansions
                    case "013":
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
                    // items, vin fletcher expansions
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
                    // gear expansion
                    case "02":
                    // items and gear expansions
                    case "012":
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
                    // gear and vin fletcher expansions
                    case "024":
                    // items, gear, and vin fletcher expansions
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
                    // gear and stolen inventory expansions
                    case "023":
                    // items, gear and stolen inventory expansions
                    case "0123":
                        {
                            for (int i = 0; i < battle.HeroesGearInventory.CharactersGearInventory.Count; i++)
                            {
                                if (battle.HeroesGearInventory.CharactersGearInventory[i].Name.Equals(targetCharacter.Name) && battle.HeroesGearInventory.CharactersGearInventory[i].CurrentHP == 0)
                                {
                                    Console.WriteLine($"{targetCharacter.Name} has been defeated!");
                                    StolenInventories stolenInventories = new StolenInventories();
                                    stolenInventories.StolenInventory(battle, battle.HeroesGearInventory.CharactersGearInventory[i], battle.CurrentPartyGearInventory);
                                    battle.HeroesGearInventory.CharactersGearInventory.RemoveAt(i);
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
                                    stolenInventories.StolenInventory(battle, battle.HeroesPartyGearInventoryHitChance.CharacterGearInventoryHitChances[i], battle.CurrentPartyGearInventoryHitChance);
                                    battle.HeroesPartyGearInventoryHitChance.CharacterGearInventoryHitChances.RemoveAt(i);
                                }
                            }
                            break;
                        }
                    // vin fletcher expansion
                    case "04":
                        {
                            for (int i = 0; i < battle.Heroes.CharactersHitChance.Count; i++)
                            {
                                if (battle.Heroes.CharactersHitChance[i].Name.Equals(targetCharacter.Name) && battle.Heroes.CharactersHitChance[i].CurrentHP == 0)
                                {
                                    Console.WriteLine($"{targetCharacter.Name} has been defeated!");
                                    battle.Heroes.CharactersHitChance.RemoveAt(i);
                                }
                            }
                            break;
                        }
                    // attack modifier expansion
                    case "05":
                        {
                            for (int i = 0; i < battle.Heroes.CharactersAttackModifier.Count; i++)
                            {
                                if (battle.Heroes.CharactersAttackModifier[i].Name.Equals(targetCharacter.Name) && battle.Heroes.CharactersAttackModifier[i].CurrentHP == 0)
                                {
                                    Console.WriteLine($"{targetCharacter.Name} has been defeated!");
                                    battle.Heroes.CharactersAttackModifier.RemoveAt(i);
                                }
                            }
                            break;
                        }
                    // game's status expansion
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

        private void DisplayResults(Character currentCharacter, string attackName, Character targetCharacter, int damageDealt)
        {
            Console.WriteLine($"It is {currentCharacter.Name}'s turn...");
            Console.WriteLine($"{currentCharacter.Name} used {attackName} on {targetCharacter.Name}.");
            Console.WriteLine($"{attackName} dealt {damageDealt} to {targetCharacter.Name}.");
            targetCharacter.CurrentHP = targetCharacter.CurrentHP - damageDealt;
            if (targetCharacter.CurrentHP < 0)
            {
                targetCharacter.CurrentHP = 0;
            }
            Console.WriteLine($"{targetCharacter.Name} is now at {targetCharacter.CurrentHP}/{targetCharacter.MaxHP} HP.");
        }

        public void Actions(Battle battle, CharacterHitChance currentCharacter, CharacterHitChance targetCharacter, ActionTypes characterAction, string strExpansions)
        {
            string attackName = "";
            int damageDealt = 0;
            for (int i = 0; i < currentCharacter.AvailableActionHitChances.Count; i++)
            {
                if (currentCharacter.AvailableActionHitChances[i].ActionType.Equals(characterAction))
                {
                    attackName = currentCharacter.AvailableActionHitChances[i].Name;
                    Random hitAttempt = new Random();
                    Random randomDamage = new Random();
                    double hit = randomDamage.NextDouble();
                    if (hit <= currentCharacter.AvailableActionHitChances[i].HitChance)
                    {
                        if (currentCharacter.AvailableActionHitChances[i].MinAmount == currentCharacter.AvailableActionHitChances[i].MaxAmount)
                        {
                            damageDealt = randomDamage.Next(currentCharacter.AvailableActionHitChances[i].MinAmount, currentCharacter.AvailableActionHitChances[i].MaxAmount);
                        }
                        else
                        {
                            damageDealt = randomDamage.Next(currentCharacter.AvailableActionHitChances[i].MinAmount, currentCharacter.AvailableActionHitChances[i].MaxAmount + 1);
                        }
                        DisplayResults(currentCharacter, attackName, targetCharacter, damageDealt);
                        DetermineStolenInventory(battle, strExpansions, targetCharacter);
                    }
                    else
                    {
                        Console.WriteLine($"{currentCharacter.Name}'s {attackName} missed {targetCharacter.Name}");
                        Console.WriteLine("\n");
                    }
                }
            }
        }
        public void Actions(Battle battle, CharacterAttackModifier currentCharacter, CharacterAttackModifier targetCharacter, ActionTypes characterAction, string strExpansions)
        {
            string attackName = "";
            int damageDealt = 0;
            for (int i = 0; i < currentCharacter.AvailableActions.Count; i++)
            {
                if (currentCharacter.AvailableActions[i].ActionType.Equals(characterAction))
                {
                    attackName = currentCharacter.AvailableActions[i].Name;
                    Random randomDamage = new Random();
                    double hit = randomDamage.NextDouble();
                    if (currentCharacter.AvailableActions[i].MinAmount == currentCharacter.AvailableActions[i].MaxAmount)
                    {
                        damageDealt = randomDamage.Next(currentCharacter.AvailableActions[i].MinAmount, currentCharacter.AvailableActions[i].MaxAmount);
                    }
                    else
                    {
                        damageDealt = randomDamage.Next(currentCharacter.AvailableActions[i].MinAmount, currentCharacter.AvailableActions[i].MaxAmount + 1);
                    }
                }
            }
            int j = -1;
            int reducedDamageDealt = 0;
            int increasedDamageDealt = 0;
            bool increasedDamage = false, reducedDamage = false;
            List<AttackModifierOffensive> attackModifierOffensives = new List<AttackModifierOffensive>();
            List<AttackModifierDefensive> attackModifierDefensives = new List<AttackModifierDefensive>();
            if ((currentCharacter.AttackModifiersOffensive.Count > 0) || (targetCharacter.AttackModifiersDefensive.Count > 0))
            {
                if (currentCharacter.AttackModifiersOffensive.Count > 0)
                {
                    for (int i = 0; i < currentCharacter.AttackModifiersOffensive.Count; i++)
                    {
                        if (currentCharacter.AttackModifiersOffensive[i].Category.Equals(AttackModifierOffensiveCategory.DR_OVERRIDE))
                        {
                            Random random = new Random();
                            double drOverride = random.NextDouble();
                            if (targetCharacter.AttackModifiersDefensive.Exists(x => x.Category == AttackModifierDefensiveCategory.DAMAGE_REDUCTION) && (drOverride <= currentCharacter.AttackModifiersOffensive[i].DROverrideChance))
                            {
                                increasedDamageDealt += (damageDealt + currentCharacter.AttackModifiersOffensive[i].Amount);
                                increasedDamage = true;
                                attackModifierOffensives.Add(currentCharacter.AttackModifiersOffensive[i]);
                            }
                        }
                        else
                        {
                            increasedDamageDealt += (damageDealt + currentCharacter.AttackModifiersOffensive[i].Amount);
                            increasedDamage = true;
                            attackModifierOffensives.Add(currentCharacter.AttackModifiersOffensive[i]);
                        }
                    }
                }
                if (targetCharacter.AttackModifiersDefensive.Count > 0)
                {
                    for (int i = 0; i < targetCharacter.AttackModifiersDefensive.Count; i++)
                    {
                        reducedDamageDealt += reducedDamageDealt + targetCharacter.AttackModifiersDefensive[i].Amount;
                        reducedDamage = true;
                        attackModifierDefensives.Add(targetCharacter.AttackModifiersDefensive[i]);
                    }
                }
            }
            else
            {
                reducedDamageDealt = damageDealt;

            }
            int adjustedDamageDealt = reducedDamageDealt + increasedDamageDealt;
            if (adjustedDamageDealt < 0)
            {
                adjustedDamageDealt = 0;
            }
            if (increasedDamage || reducedDamage)
            {
                DisplayResultsAttackModified(currentCharacter, attackName, targetCharacter, adjustedDamageDealt, attackModifierOffensives, attackModifierDefensives);
            }
            else
            {
                DisplayResults(currentCharacter, attackName, targetCharacter, damageDealt);
            }
            DetermineStolenInventory(battle, strExpansions, targetCharacter);
        }

        private void DisplayResultsAttackModified(CharacterAttackModifier currentCharacter, string attackName, CharacterAttackModifier targetCharacter, int adjustedDamageDealt, List<AttackModifierOffensive> attackModifierOffensives, List<AttackModifierDefensive> attackModifierDefensives)
        {
            Console.WriteLine($"It is {currentCharacter.Name}'s turn...");
            Console.WriteLine($"{currentCharacter.Name} used {attackName} on {targetCharacter.Name}.");
            Console.WriteLine($"{attackName} dealt {adjustedDamageDealt} to {targetCharacter.Name}.");
            if (attackModifierOffensives.Count > 0)
            {
                foreach (AttackModifierOffensive a in attackModifierOffensives)
                {
                    Console.WriteLine($"{a.Name} changed the damage by {a.Amount} point.");
                }
            }
            if (attackModifierDefensives.Count > 0)
            {
                foreach (AttackModifierDefensive a in attackModifierDefensives)
                {
                    Console.WriteLine($"{a.Name} changed the damage by {a.Amount} point.");
                }
            }
            targetCharacter.CurrentHP = targetCharacter.CurrentHP - adjustedDamageDealt;
            if (targetCharacter.CurrentHP < 0)
            {
                targetCharacter.CurrentHP = 0;
            }
            Console.WriteLine($"{targetCharacter.Name} is now at {targetCharacter.CurrentHP}/{targetCharacter.MaxHP} HP.");
        }
    }
}