using Expansion_Attack_Modifiers_p426;
using Expansion_Attack_Modifiers_p426.Expansions.Gear;
using Expansion_Attack_Modifiers_p426.Expansions.Vin_Fletcher;

namespace Expansion_Attack_Modifiers_p426.Expansions.Gear.Actions
{
    public class EquipAll : IActionGear
    {
        public void Actions(Battle battle, CharacterGearInventory currentCharacter, CharacterGearInventory targetCharacter, ActionTypes characterAction, string strExpansions)
        {
            int x = -1, y = -1, z = -1;
            int k = 0;
            string name = "";
            switch (strExpansions)
            {
                // gear and attack modifiers expansions
                case "025":
                // gear, items and attack modifiers expansions
                case "0125":
                // gear, stolen inventory and attack modifiers expansions
                case "0235":
                // gear, items, stolen inventory and attack modifiers expansions
                case "01235":
                    {
                        for (int i = 0; i < currentCharacter.AvailableActions.Count; i++)
                        {
                            if (currentCharacter.AvailableActions[i].ActionType.Equals(characterAction))
                            {
                                for (int j = 0; j < battle.CurrentPartyAttackModifierGearInventory.CharacterAttackModifiersGearInventory.Count; j++)
                                {
                                    if (battle.CurrentPartyAttackModifierGearInventory.CharacterAttackModifiersGearInventory[j].CharacterID.Equals(currentCharacter.CharacterID))
                                    {
                                        x = j;
                                    }
                                }
                            }
                        }
                        Console.WriteLine("Please select a weapon from the following list to equip.");
                        foreach (Weapon w in battle.CurrentPartyAttackModifierGearInventory.Inventory.Weapons)
                        {
                            Console.WriteLine($"{k}: {w.Name}");
                            k++;
                        }
                        break;
                    }
                default:
                    {
                        for (int i = 0; i < currentCharacter.AvailableActions.Count; i++)
                        {
                            if (currentCharacter.AvailableActions[i].ActionType.Equals(characterAction))
                            {
                                for (int j = 0; j < battle.CurrentPartyGearInventory.CharactersGearInventory.Count; j++)
                                {
                                    if (battle.CurrentPartyGearInventory.CharactersGearInventory[j].CharacterID.Equals(currentCharacter.CharacterID))
                                    {
                                        x = j;
                                    }
                                }
                            }
                        }
                        Console.WriteLine("Please select a weapon from the following list to equip.");
                        foreach (Weapon w in battle.CurrentPartyGearInventory.Inventory.Weapons)
                        {
                            Console.WriteLine($"{k}: {w.Name}");
                            k++;
                        }
                        break;
                    }
            }
            if (battle.CurrentPlayer.PlayerType.Equals(PlayerType.Human))
            {
                bool isValid = false;
                while (isValid == false)
                {
                    try
                    {
                        y = Convert.ToInt32(Console.ReadLine());
                        switch (strExpansions)
                        {
                            // gear and attack modifiers expansions
                            case "025":
                            // gear, items and attack modifiers expanasions
                            case "0125":
                            // gear, stolen inventory and attack modifiers espansions
                            case "0235":
                            // gear, items, stolen inventory and attack modifiers expansions
                            case "01235":
                                {
                                    if (y >= 0 && y <= battle.CurrentPartyAttackModifierGearInventory.Inventory.Weapons.Count)
                                    {
                                        isValid = true;
                                    }
                                    break;
                                }
                            default:
                                {
                                    if (y >= 0 && y <= battle.CurrentPartyGearInventory.Inventory.Weapons.Count)
                                    {
                                        isValid = true;
                                    }
                                    break;
                                }
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
            else
            {
                int maxDamage = 0;
                int minDamage = 0;
                switch (strExpansions)
                {
                    // gear and attack modifiers expansions
                    case "025":
                    // gear, items and attack modifiers expansions
                    case "0125":
                    // gear, stolen inventory and attack modifiers expansions
                    case "0235":
                    // gear, items, stolen inventory and attack modifiers expansions
                    case "01235":
                        {
                            for (int i = 0; i < battle.CurrentPartyAttackModifierGearInventory.Inventory.Weapons.Count; i++)
                            {
                                if (battle.CurrentPartyAttackModifierGearInventory.Inventory.Weapons[i].MaxDamage > maxDamage)
                                {
                                    name = battle.CurrentPartyAttackModifierGearInventory.Inventory.Weapons[i].Name;
                                    maxDamage = battle.CurrentPartyAttackModifierGearInventory.Inventory.Weapons[i].MaxDamage;
                                    minDamage = battle.CurrentPartyAttackModifierGearInventory.Inventory.Weapons[i].MinDamage;
                                }
                                else if (battle.CurrentPartyAttackModifierGearInventory.Inventory.Weapons[i].MaxDamage == maxDamage)
                                {
                                    if (battle.CurrentPartyAttackModifierGearInventory.Inventory.Weapons[i].MinDamage > minDamage)
                                    {
                                        name = battle.CurrentPartyAttackModifierGearInventory.Inventory.Weapons[i].Name;
                                        maxDamage = battle.CurrentPartyAttackModifierGearInventory.Inventory.Weapons[i].MaxDamage;
                                        minDamage = battle.CurrentPartyAttackModifierGearInventory.Inventory.Weapons[i].MinDamage;
                                    }
                                }
                            }
                            y = battle.CurrentPartyAttackModifierGearInventory.Inventory.Weapons.FindIndex(x => x.Name == name);
                            break;
                        }
                    default:
                        {
                            for (int i = 0; i < battle.CurrentPartyGearInventory.Inventory.Weapons.Count; i++)
                            {
                                if (battle.CurrentPartyGearInventory.Inventory.Weapons[i].MaxDamage > maxDamage)
                                {
                                    name = battle.CurrentPartyGearInventory.Inventory.Weapons[i].Name;
                                    maxDamage = battle.CurrentPartyGearInventory.Inventory.Weapons[i].MaxDamage;
                                    minDamage = battle.CurrentPartyGearInventory.Inventory.Weapons[i].MinDamage;
                                }
                                else if (battle.CurrentPartyGearInventory.Inventory.Weapons[i].MaxDamage == maxDamage)
                                {
                                    if (battle.CurrentPartyGearInventory.Inventory.Weapons[i].MinDamage > minDamage)
                                    {
                                        name = battle.CurrentPartyGearInventory.Inventory.Weapons[i].Name;
                                        maxDamage = battle.CurrentPartyGearInventory.Inventory.Weapons[i].MaxDamage;
                                        minDamage = battle.CurrentPartyGearInventory.Inventory.Weapons[i].MinDamage;
                                    }
                                }
                            }
                            y = battle.CurrentPartyGearInventory.Inventory.Weapons.FindIndex(x => x.Name == name);
                            break;
                        }
                }    
            }
            Console.WriteLine($"It is {currentCharacter.Name}'s turn...");
            if (y >= 0)
            {
                Console.WriteLine($"{currentCharacter.Name} equipped {/*battle.CurrentPartyGearInventory.Inventory.Weapons[y].Name*/ name}.");
            }
            if (currentCharacter.CharacterInventory.Weapons.Count > 0)
            {
                Weapon tempWeapon = currentCharacter.CharacterInventory.Weapons[0];
                int a = currentCharacter.AvailableActions.FindIndex(x => x.ActionType == ActionTypes.GEAR_ATTACK);
                currentCharacter.AvailableActions.RemoveAt(a);
                currentCharacter.CharacterInventory.Weapons.RemoveAt(0);
                switch (strExpansions)
                {
                    // gear and attakc modifiers expansions
                    case "025":
                    // gear, items and attack modifiers expansions
                    case "0125":
                    // gear, stolen inventory and attack modifiers expansions
                    case "0235":
                    // gear, items, stolen inventory and attack modifiers expansions
                    case "01235":
                        {
                            currentCharacter.CharacterInventory.Weapons.Add(battle.CurrentPartyAttackModifierGearInventory.Inventory.Weapons[y]);
                            break;
                        }
                    default:
                        {
                            currentCharacter.CharacterInventory.Weapons.Add(battle.CurrentPartyGearInventory.Inventory.Weapons[y]);
                            break;
                        }
                }
                currentCharacter.AvailableActions.Add(currentCharacter.CharacterInventory.Weapons[0].AvailableAction);
                battle.CurrentPartyGearInventory.Inventory.Weapons.RemoveAt(y);
                battle.CurrentPartyGearInventory.Inventory.Weapons.Add(tempWeapon);
            }
            else
            {
                switch (strExpansions)
                {
                    // gear and attakc modifiers expansions
                    case "025":
                    // gear, items and attack modifiers expansions
                    case "0125":
                    // gear, stolen inventory and attack modifiers expansions
                    case "0235":
                    // gear, items, stolen inventory and attack modifiers expansions
                    case "01235":
                        {
                            currentCharacter.CharacterInventory.Weapons.Add(battle.CurrentPartyAttackModifierGearInventory.Inventory.Weapons[y]);
                            currentCharacter.AvailableActions.Add(currentCharacter.CharacterInventory.Weapons[0].AvailableAction);
                            battle.CurrentPartyAttackModifierGearInventory.Inventory.Weapons.RemoveAt(y);
                            break;
                        }
                    default:
                        {
                            currentCharacter.CharacterInventory.Weapons.Add(battle.CurrentPartyGearInventory.Inventory.Weapons[y]);
                            currentCharacter.AvailableActions.Add(currentCharacter.CharacterInventory.Weapons[0].AvailableAction);
                            battle.CurrentPartyGearInventory.Inventory.Weapons.RemoveAt(y);
                            break;
                        }
                }
            }
            Console.WriteLine("\n");
        }

        public void Actions(Battle battle, CharacterGearInventoryHitChance currentCharacterGearInventoryHitChance, CharacterGearInventoryHitChance targetCharacter, ActionTypes characterAction, string strExpansions)
        {
            int x = -1, y = -1, z = -1;
            for (int i = 0; i < currentCharacterGearInventoryHitChance.AvailableActionHitChances.Count; i++)
            {
                if (currentCharacterGearInventoryHitChance.AvailableActionHitChances[i].ActionType.Equals(characterAction))
                {
                    for (int j = 0; j < battle.CurrentPartyGearInventoryHitChance.CharacterGearInventoryHitChances.Count; j++)
                    {
                        if (battle.CurrentPartyGearInventoryHitChance.CharacterGearInventoryHitChances[j].CharacterID.Equals(currentCharacterGearInventoryHitChance.CharacterID))
                        {
                            x = j;
                        }
                    }
                }
            }
            int k = 0;
            Console.WriteLine("Please select a weapon from the following list to equip.");
            foreach (Weapon w in battle.CurrentPartyGearInventoryHitChance.Inventory.WeaponHitChances)
            {
                Console.WriteLine($"{k}: {w.Name}");
                k++;
            }
            if (battle.CurrentPlayer.PlayerType.Equals(PlayerType.Human))
            {
                bool isValid = false;
                while (isValid == false)
                {
                    try
                    {
                        y = Convert.ToInt32(Console.ReadLine());
                        if (y >= 0 && y <= battle.CurrentPartyGearInventoryHitChance.Inventory.WeaponHitChances.Count)
                        {
                            isValid = true;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
            else
            {
                string name = "";
                int maxDamage = 0;
                int minDamage = 0;
                for (int i = 0; i < battle.CurrentPartyGearInventoryHitChance.Inventory.WeaponHitChances.Count; i++)
                {
                    if (battle.CurrentPartyGearInventoryHitChance.Inventory.WeaponHitChances[i].MaxDamage > maxDamage)
                    {
                        name = battle.CurrentPartyGearInventoryHitChance.Inventory.WeaponHitChances[i].Name;
                        maxDamage = battle.CurrentPartyGearInventoryHitChance.Inventory.WeaponHitChances[i].MaxDamage;
                        minDamage = battle.CurrentPartyGearInventoryHitChance.Inventory.WeaponHitChances[i].MinDamage;
                    }
                    else if (battle.CurrentPartyGearInventoryHitChance.Inventory.WeaponHitChances[i].MaxDamage == maxDamage)
                    {
                        if (battle.CurrentPartyGearInventoryHitChance.Inventory.WeaponHitChances[i].MinDamage > minDamage)
                        {
                            name = battle.CurrentPartyGearInventoryHitChance.Inventory.WeaponHitChances[i].Name;
                            maxDamage = battle.CurrentPartyGearInventoryHitChance.Inventory.WeaponHitChances[i].MaxDamage;
                            minDamage = battle.CurrentPartyGearInventoryHitChance.Inventory.WeaponHitChances[i].MinDamage;
                        }
                    }
                }
                y = battle.CurrentPartyGearInventoryHitChance.Inventory.WeaponHitChances.FindIndex(x => x.Name == name);
            }
            Console.WriteLine($"It is {currentCharacterGearInventoryHitChance.Name}'s turn...");
            Console.WriteLine($"{currentCharacterGearInventoryHitChance.Name} equipped {battle.CurrentPartyGearInventoryHitChance.Inventory.WeaponHitChances[y].Name}.");
            if (currentCharacterGearInventoryHitChance.CharacterInventory.WeaponHitChances/*I.Weapons*/.Count > 0)
            {
                WeaponHitChance tempWeapon = currentCharacterGearInventoryHitChance.CharacterInventory.WeaponHitChances[0];
                int a = currentCharacterGearInventoryHitChance.AvailableActionHitChances.FindIndex(x => x.ActionType == ActionTypes.GEAR_ATTACK);
                currentCharacterGearInventoryHitChance.AvailableActionHitChances.RemoveAt(a);
                currentCharacterGearInventoryHitChance.CharacterInventory.WeaponHitChances.RemoveAt(0);
                currentCharacterGearInventoryHitChance.CharacterInventory.WeaponHitChances.Add(battle.CurrentPartyGearInventoryHitChance.Inventory.WeaponHitChances[y]);
                currentCharacterGearInventoryHitChance.AvailableActionHitChances.Add(currentCharacterGearInventoryHitChance.CharacterInventory.WeaponHitChances[0].AvailableActionHitChance);
                battle.CurrentPartyGearInventoryHitChance.Inventory.WeaponHitChances.RemoveAt(y);
                battle.CurrentPartyGearInventoryHitChance.Inventory.WeaponHitChances.Add(tempWeapon);
            }
            else
            {
                currentCharacterGearInventoryHitChance.CharacterInventory.WeaponHitChances.Add(battle.CurrentPartyGearInventoryHitChance.Inventory.WeaponHitChances[y]);
                currentCharacterGearInventoryHitChance.AvailableActionHitChances.Add(currentCharacterGearInventoryHitChance.CharacterInventory.WeaponHitChances[0].AvailableActionHitChance);
                battle.CurrentPartyGearInventoryHitChance.Inventory.WeaponHitChances.RemoveAt(y);
            }
            Console.WriteLine("\n");
        }
    }
}
