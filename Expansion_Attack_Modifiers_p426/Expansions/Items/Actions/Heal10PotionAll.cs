using Expansion_Attack_Modifiers_p426;
using Expansion_Attack_Modifiers_p426.Expansions.Items;
using Expansion_Attack_Modifiers_p426.Expansions.Vin_Fletcher;

namespace Expansion_Attack_Modifiers_p426.Expansions.Items.Actions
{
    public class Heal10PotionAll
    {
        public void Actions(Battle battle, Character currentCharacter, Character targetCharacter, ActionTypes characterAction, string strExpansions)
        {
            string healingName = "";
            int totalHealing = 0;
            switch (strExpansions)
            {
                // items and attack modifiers expansions
                case "015":
                // items, stolen inventory and attack modifiers expansions
                case "0135":
                    {
                        for (int i = 0; i < currentCharacter.AvailableActions.Count; i++)
                        {
                            if (currentCharacter.AvailableActions[i].ActionType.Equals(characterAction))
                            {
                                healingName = currentCharacter.AvailableActions[i].Name;
                                Random randomHealing = new Random();
                                if (currentCharacter.AvailableActions[i].MinAmount == currentCharacter.AvailableActions[i].MaxAmount)
                                {
                                    totalHealing = randomHealing.Next(currentCharacter.AvailableActions[i].MinAmount, currentCharacter.AvailableActions[i].MaxAmount);
                                }
                                else
                                {
                                    totalHealing = randomHealing.Next(currentCharacter.AvailableActions[i].MinAmount, currentCharacter.AvailableActions[i].MaxAmount + 1);
                                }
                            }
                        }
                        Console.WriteLine($"It is {currentCharacter.Name}'s turn...");
                        Console.WriteLine($"{currentCharacter.Name} used {healingName} on {targetCharacter.Name}.");
                        Console.WriteLine($"{healingName} heals {totalHealing} to {targetCharacter.Name}.");
                        targetCharacter.CurrentHP = targetCharacter.CurrentHP + totalHealing;
                        if (targetCharacter.CurrentHP > targetCharacter.MaxHP)
                        {
                            targetCharacter.CurrentHP = targetCharacter.MaxHP;
                        }
                        Console.WriteLine($"{targetCharacter.Name} is now at {targetCharacter.CurrentHP}/{targetCharacter.MaxHP} HP.");
                        Console.WriteLine("\n");
                        int potionIndex = battle.CurrentPartyAttackModifierItemInventory.Inventory.Potions.FindIndex(x => x.potionName == PotionName.HEALING_10);
                        battle.CurrentPartyAttackModifierItemInventory.Inventory.Potions.RemoveAt(potionIndex);
                        break;
                    }
                //// gear expansion
                //case "02":
                // items and gear expansions
                case "012":
                // items, gear and stolen inventory expansions
                case "0123":
                    {
                        for (int i = 0; i < battle.CurrentCharacterGearInventory.AvailableActions.Count; i++)
                        {
                            if (battle.CurrentCharacterGearInventory.AvailableActions[i].ActionType.Equals(characterAction))
                            {
                                healingName = battle.CurrentCharacterGearInventory.AvailableActions[i].Name;
                                Random randomHealing = new Random();
                                if (battle.CurrentCharacterGearInventory.AvailableActions[i].MinAmount == battle.CurrentCharacterGearInventory.AvailableActions[i].MaxAmount)
                                {
                                    totalHealing = randomHealing.Next(battle.CurrentCharacterGearInventory.AvailableActions[i].MinAmount, battle.CurrentCharacterGearInventory.AvailableActions[i].MaxAmount);
                                }
                                else
                                {
                                    totalHealing = randomHealing.Next(battle.CurrentCharacterGearInventory.AvailableActions[i].MinAmount, battle.CurrentCharacterGearInventory.AvailableActions[i].MaxAmount + 1);
                                }
                            }
                        }
                        Console.WriteLine($"It is {battle.CurrentCharacterGearInventory.Name}'s turn...");
                        Console.WriteLine($"{battle.CurrentCharacterGearInventory.Name} used {healingName} on {battle.CurrentCharacterGearInventory.Name}.");
                        Console.WriteLine($"{healingName} heals {totalHealing} to {battle.CurrentCharacterGearInventory.Name}.");
                        battle.CurrentCharacterGearInventory.CurrentHP = battle.CurrentCharacterGearInventory.CurrentHP + totalHealing;
                        if (battle.CurrentCharacterGearInventory.MaxHP > 0)
                        {
                            battle.CurrentCharacterGearInventory.CurrentHP = battle.CurrentCharacterGearInventory.MaxHP;
                        }
                        Console.WriteLine($"{battle.CurrentCharacterGearInventory.Name} is now at {battle.CurrentCharacterGearInventory.CurrentHP}/{battle.CurrentCharacterGearInventory.MaxHP} HP.");
                        Console.WriteLine("\n");
                        int potionIndex = battle.CurrentPartyGearInventory.Inventory.Potions.FindIndex(x => x.potionName == PotionName.HEALING_10);
                        battle.CurrentPartyGearInventory.Inventory.Potions.RemoveAt(potionIndex);
                        break;
                    }
                // items, gear and attack modifiers expansions
                case "0125":
                // items, gear, stolen inventory and attack modifiers expansions
                case "01235":
                    {
                        for (int i = 0; i < battle.CurrentCharacterAttackModifierGearInventory.AvailableActions.Count; i++)
                        {
                            if (battle.CurrentCharacterAttackModifierGearInventory.AvailableActions[i].ActionType.Equals(characterAction))
                            {
                                healingName = battle.CurrentCharacterAttackModifierGearInventory.AvailableActions[i].Name;
                                Random randomHealing = new Random();
                                if (battle.CurrentCharacterAttackModifierGearInventory.AvailableActions[i].MinAmount == battle.CurrentCharacterAttackModifierGearInventory.AvailableActions[i].MaxAmount)
                                {
                                    totalHealing = randomHealing.Next(battle.CurrentCharacterAttackModifierGearInventory.AvailableActions[i].MinAmount, battle.CurrentCharacterAttackModifierGearInventory.AvailableActions[i].MaxAmount);
                                }
                                else
                                {
                                    totalHealing = randomHealing.Next(battle.CurrentCharacterAttackModifierGearInventory.AvailableActions[i].MinAmount, battle.CurrentCharacterAttackModifierGearInventory.AvailableActions[i].MaxAmount + 1);
                                }
                            }
                        }
                        Console.WriteLine($"It is {battle.CurrentCharacterAttackModifierGearInventory.Name}'s turn...");
                        Console.WriteLine($"{battle.CurrentCharacterAttackModifierGearInventory.Name} used {healingName} on {battle.CurrentCharacterAttackModifierGearInventory.Name}.");
                        Console.WriteLine($"{healingName} heals {totalHealing} to {battle.CurrentCharacterAttackModifierGearInventory.Name}.");
                        battle.CurrentCharacterAttackModifierGearInventory.CurrentHP = battle.CurrentCharacterAttackModifierGearInventory.CurrentHP + totalHealing;
                        if (battle.CurrentCharacterAttackModifierGearInventory.MaxHP > 0)
                        {
                            battle.CurrentCharacterAttackModifierGearInventory.CurrentHP = battle.CurrentCharacterAttackModifierGearInventory.MaxHP;
                        }
                        Console.WriteLine($"{battle.CurrentCharacterAttackModifierGearInventory.Name} is now at {battle.CurrentCharacterAttackModifierGearInventory.CurrentHP}/{battle.CurrentCharacterAttackModifierGearInventory.MaxHP} HP.");
                        Console.WriteLine("\n");
                        int potionIndex = battle.CurrentPartyAttackModifierGearInventory.Inventory.Potions.FindIndex(x => x.potionName == PotionName.HEALING_10);
                        battle.CurrentPartyAttackModifierGearInventory.Inventory.Potions.RemoveAt(potionIndex);
                        break;
                    }
                // items expansion
                // items and stolen inventory expansions
                default:
                    {
                        for (int i = 0; i < currentCharacter.AvailableActions.Count; i++)
                        {
                            if (currentCharacter.AvailableActions[i].ActionType.Equals(characterAction))
                            {
                                healingName = currentCharacter.AvailableActions[i].Name;
                                Random randomHealing = new Random();
                                if (currentCharacter.AvailableActions[i].MinAmount == currentCharacter.AvailableActions[i].MaxAmount)
                                {
                                    totalHealing = randomHealing.Next(currentCharacter.AvailableActions[i].MinAmount, currentCharacter.AvailableActions[i].MaxAmount);
                                }
                                else
                                {
                                    totalHealing = randomHealing.Next(currentCharacter.AvailableActions[i].MinAmount, currentCharacter.AvailableActions[i].MaxAmount + 1);
                                }
                            }
                        }
                        Console.WriteLine($"It is {currentCharacter.Name}'s turn...");
                        Console.WriteLine($"{currentCharacter.Name} used {healingName} on {targetCharacter.Name}.");
                        Console.WriteLine($"{healingName} heals {totalHealing} to {targetCharacter.Name}.");
                        targetCharacter.CurrentHP = targetCharacter.CurrentHP + totalHealing;
                        if (targetCharacter.CurrentHP > targetCharacter.MaxHP)
                        {
                            targetCharacter.CurrentHP = targetCharacter.MaxHP;
                        }
                        Console.WriteLine($"{targetCharacter.Name} is now at {targetCharacter.CurrentHP}/{targetCharacter.MaxHP} HP.");
                        Console.WriteLine("\n");
                        int potionIndex = battle.CurrentPartyItemInventory.Inventory.Potions.FindIndex(x => x.potionName == PotionName.HEALING_10);
                        battle.CurrentPartyItemInventory.Inventory.Potions.RemoveAt(potionIndex);
                        break;
                    }
            }
        }
        public void Actions(Battle battle, CharacterHitChance currentCharacter, CharacterHitChance targetCharacter, ActionTypes characterAction, string strExpansions)
        {
            string healingName = "";
            int totalHealing = 0;
            switch (strExpansions)
            {
                // items and vin fletcher expansions
                case "014":
                // items, stolen inventory and vin fletcher expansions
                case "0134":
                    {
                        for (int i = 0; i < currentCharacter.AvailableActionHitChances.Count; i++)
                        {
                            if (currentCharacter.AvailableActionHitChances[i].ActionType.Equals(characterAction))
                            {
                                healingName = currentCharacter.AvailableActionHitChances[i].Name;
                                Random randomHealing = new Random();
                                if (currentCharacter.AvailableActionHitChances[i].MinAmount == currentCharacter.AvailableActionHitChances[i].MaxAmount)
                                {
                                    totalHealing = randomHealing.Next(currentCharacter.AvailableActionHitChances[i].MinAmount, currentCharacter.AvailableActionHitChances[i].MaxAmount);
                                }
                                else
                                {
                                    totalHealing = randomHealing.Next(currentCharacter.AvailableActionHitChances[i].MinAmount, currentCharacter.AvailableActionHitChances[i].MaxAmount + 1);
                                }
                            }
                        }
                        Console.WriteLine($"It is {currentCharacter.Name}'s turn...");
                        Console.WriteLine($"{currentCharacter.Name} used {healingName} on {targetCharacter.Name}.");
                        Console.WriteLine($"{healingName} heals {totalHealing} to {targetCharacter.Name}.");
                        targetCharacter.CurrentHP = targetCharacter.CurrentHP + totalHealing;
                        if (targetCharacter.MaxHP > 0)
                        {
                            targetCharacter.CurrentHP = targetCharacter.MaxHP;
                        }
                        Console.WriteLine($"{targetCharacter.Name} is now at {targetCharacter.CurrentHP}/{targetCharacter.MaxHP} HP.");
                        Console.WriteLine("\n");
                        int potionIndex = battle.CurrentPartyItemInventoryHitChance.Inventory.Potions.FindIndex(x => x.potionName == PotionName.HEALING_10);
                        battle.CurrentPartyItemInventoryHitChance.Inventory.Potions.RemoveAt(potionIndex);
                        break;
                    }
                // gear and vin fletcher expansions
                case "024":
                // items, gear and vin fletcher expansions
                case "0124":
                // gear, stolen inventory and vin fletcher expansions
                case "0234":
                // items, gear, stolen inventory and vin fletcher expansions
                case "01234":
                    {
                        for (int i = 0; i < battle.CurrentCharacterGearInventoryHitChance.AvailableActionHitChances.Count; i++)
                        {
                            if (battle.CurrentCharacterGearInventoryHitChance.AvailableActionHitChances[i].ActionType.Equals(characterAction))
                            {
                                healingName = battle.CurrentCharacterGearInventoryHitChance.AvailableActionHitChances[i].Name;
                                Random randomHealing = new Random();
                                if (battle.CurrentCharacterGearInventoryHitChance.AvailableActionHitChances[i].MinAmount == battle.CurrentCharacterGearInventoryHitChance.AvailableActionHitChances[i].MaxAmount)
                                {
                                    totalHealing = randomHealing.Next(battle.CurrentCharacterGearInventoryHitChance.AvailableActionHitChances[i].MinAmount, battle.CurrentCharacterGearInventoryHitChance.AvailableActionHitChances[i].MaxAmount);
                                }
                                else
                                {
                                    totalHealing = randomHealing.Next(battle.CurrentCharacterGearInventoryHitChance.AvailableActionHitChances[i].MinAmount, battle.CurrentCharacterGearInventoryHitChance.AvailableActionHitChances[i].MaxAmount + 1);
                                }
                            }
                        }
                        Console.WriteLine($"It is {battle.CurrentCharacterGearInventoryHitChance.Name}'s turn...");
                        Console.WriteLine($"{battle.CurrentCharacterGearInventoryHitChance.Name} used {healingName} on {battle.CurrentCharacterGearInventoryHitChance.Name}.");
                        Console.WriteLine($"{healingName} heals {totalHealing} to {battle.CurrentCharacterGearInventoryHitChance.Name}.");
                        battle.CurrentCharacterGearInventoryHitChance.CurrentHP = battle.CurrentCharacterGearInventoryHitChance.CurrentHP + totalHealing;
                        if (battle.CurrentCharacterGearInventoryHitChance.MaxHP > 0)
                        {
                            battle.CurrentCharacterGearInventoryHitChance.CurrentHP = battle.CurrentCharacterGearInventoryHitChance.MaxHP;
                        }
                        Console.WriteLine($"{battle.CurrentCharacterGearInventoryHitChance.Name} is now at {battle.CurrentCharacterGearInventoryHitChance.CurrentHP}/{battle.CurrentCharacterGearInventoryHitChance.MaxHP} HP.");
                        Console.WriteLine("\n");
                        int potionIndex = battle.CurrentPartyGearInventoryHitChance.Inventory.Potions.FindIndex(x => x.potionName == PotionName.HEALING_10);
                        battle.CurrentPartyGearInventoryHitChance.Inventory.Potions.RemoveAt(potionIndex);
                        break;
                    }
                // items, vin fletcher and attack modifiers expansions
                case "0145":
                // items, stolen inventory, vin fletcher and attack modifiers expansions
                case "01345":
                    {
                        for (int i = 0; i < currentCharacter.AvailableActionHitChances.Count; i++)
                        {
                            if (currentCharacter.AvailableActionHitChances[i].ActionType.Equals(characterAction))
                            {
                                healingName = currentCharacter.AvailableActionHitChances[i].Name;
                                Random randomHealing = new Random();
                                if (currentCharacter.AvailableActionHitChances[i].MinAmount == currentCharacter.AvailableActionHitChances[i].MaxAmount)
                                {
                                    totalHealing = randomHealing.Next(currentCharacter.AvailableActionHitChances[i].MinAmount, currentCharacter.AvailableActionHitChances[i].MaxAmount);
                                }
                                else
                                {
                                    totalHealing = randomHealing.Next(currentCharacter.AvailableActionHitChances[i].MinAmount, currentCharacter.AvailableActionHitChances[i].MaxAmount + 1);
                                }
                            }
                        }
                        Console.WriteLine($"It is {currentCharacter.Name}'s turn...");
                        Console.WriteLine($"{currentCharacter.Name} used {healingName} on {targetCharacter.Name}.");
                        Console.WriteLine($"{healingName} heals {totalHealing} to {targetCharacter.Name}.");
                        targetCharacter.CurrentHP = targetCharacter.CurrentHP + totalHealing;
                        if (targetCharacter.CurrentHP > targetCharacter.MaxHP)
                        {
                            targetCharacter.CurrentHP = targetCharacter.MaxHP;
                        }
                        Console.WriteLine($"{targetCharacter.Name} is now at {targetCharacter.CurrentHP}/{targetCharacter.MaxHP} HP.");
                        Console.WriteLine("\n");
                        int potionIndex = battle.CurrentPartyItemInventoryHitChance.Inventory.Potions.FindIndex(x => x.potionName == PotionName.HEALING_10);
                        battle.CurrentPartyItemInventoryHitChance.Inventory.Potions.RemoveAt(potionIndex);
                        break;
                    }

            }
        }
    }
}
