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
                            currentCharacter.AvailableActions.Add(currentCharacter.CharacterInventory.Weapons[0].AvailableAction);
                            battle.CurrentPartyAttackModifierGearInventory.Inventory.Weapons.RemoveAt(y);
                            battle.CurrentPartyAttackModifierGearInventory.Inventory.Weapons.Add(tempWeapon);
                            break;
                        }
                    default:
                        {
                            currentCharacter.CharacterInventory.Weapons.Add(battle.CurrentPartyGearInventory.Inventory.Weapons[y]);
                            currentCharacter.AvailableActions.Add(currentCharacter.CharacterInventory.Weapons[0].AvailableAction);
                            battle.CurrentPartyGearInventory.Inventory.Weapons.RemoveAt(y);
                            battle.CurrentPartyGearInventory.Inventory.Weapons.Add(tempWeapon);
                            break;
                        }
                }
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

        public void Actions(Battle battle, CharacterGearInventoryHitChance currentCharacter, CharacterGearInventoryHitChance targetCharacter, ActionTypes characterAction, string strExpansions)
        {
            int x = -1, y = -1, z = -1;
            string name = "";
            switch (strExpansions)
            {
                // gear, vin fletcher and attack modifiers expansions
                case "0245":
                // gear, items, vin fletcher and attack modifiers expansions
                case "01245":
                // gear, stolen inventory, vin fletcher and attack modifiers expansions
                case "02345":
                // gear, items, stolen inventory, vin fletcher and attack modifiers expansions
                case "012345":
                    {
                        int k = 0, i = currentCharacter.AvailableActionHitChances.FindIndex(a => a.ActionType == characterAction);
                        if (i >= 0)
                        {
                            x = battle.CurrentPartyAttackModifierGearInventoryHitChance.CharactersAttackModifierGearInventoruyHitChance.FindIndex(a => a.CharacterID.Equals(currentCharacter.CharacterID));
                        }
                        Console.WriteLine("Please select a weapon from the following list to equip.");
                        foreach (WeaponHitChance w in battle.CurrentPartyAttackModifierGearInventoryHitChance.Inventory.WeaponHitChances)
                        {
                            Console.WriteLine($"{k}: {w.Name}");
                            k++;
                        }
                        break;
                    }
                // gear and vin fletcher expansions
                // gear, items and vin fletcher expansions
                // gear, stolen inventory and vin fletcher expansions
                // gear, items, stolen inventory and vin fletcher expansions
                default:
                    {
                        for (int i = 0; i < currentCharacter.AvailableActionHitChances.Count; i++)
                        {
                            if (currentCharacter.AvailableActionHitChances[i].ActionType.Equals(characterAction))
                            {
                                for (int j = 0; j < battle.CurrentPartyGearInventoryHitChance.CharacterGearInventoryHitChances.Count; j++)
                                {
                                    if (battle.CurrentPartyGearInventoryHitChance.CharacterGearInventoryHitChances[j].CharacterID.Equals(currentCharacter.CharacterID))
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
                            // gear, vin fletcher and attack modifiers expansions
                            case "0245":
                            // gear, items, vin fletcher and attack modifiers expansions
                            case "01245":
                            // gear, stolen inventory, vin fletcher and attack modifiers expansions
                            case "02345":
                            // gear, items, stolen inventory, vin fletcher and attack modifiers expansions
                            case "012345":
                                {
                                    if (y >= 0 && y <= battle.CurrentPartyAttackModifierGearInventoryHitChance.Inventory.WeaponHitChances.Count)
                                    {
                                        isValid = true;
                                    }
                                    break;
                                }
                            // gear and vin fletcher expansions
                            // gear, items, and vin fletcher expansions
                            // gear, stolen inventory and vin fletcher expansions
                            // gear, items, stolen inventory and vin fletcher expansions
                            default:
                                {
                                    if (y >= 0 && y <= battle.CurrentPartyGearInventoryHitChance.Inventory.WeaponHitChances.Count)
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
                    // gear, vin fletcher and attack modifiers expansions
                    case "0245":
                    // gear, items, vin fletcher and attack modifiers expansions
                    case "01245":
                    // gear, stolen inventory, vin fletcher and attack modifiers expansions
                    case "02345":
                    // gear, items, stolen inventory, vin fletcher and attack modifiers expansions
                    case "012345":
                        {
                            for (int i = 0; i < battle.CurrentPartyAttackModifierGearInventoryHitChance.Inventory.WeaponHitChances.Count; i++)
                            {
                                if (battle.CurrentPartyAttackModifierGearInventoryHitChance.Inventory.WeaponHitChances[i].MaxDamage > maxDamage)
                                {
                                    name = battle.CurrentPartyAttackModifierGearInventoryHitChance.Inventory.WeaponHitChances[i].Name;
                                    maxDamage = battle.CurrentPartyAttackModifierGearInventoryHitChance.Inventory.WeaponHitChances[i].MaxDamage;
                                    minDamage = battle.CurrentPartyAttackModifierGearInventoryHitChance.Inventory.WeaponHitChances[i].MinDamage;
                                }
                                else if (battle.CurrentPartyAttackModifierGearInventoryHitChance.Inventory.WeaponHitChances[i].MaxDamage == maxDamage)
                                {
                                    if (battle.CurrentPartyAttackModifierGearInventoryHitChance.Inventory.WeaponHitChances[i].MinDamage > minDamage)
                                    {
                                        name = battle.CurrentPartyAttackModifierGearInventoryHitChance.Inventory.WeaponHitChances[i].Name;
                                        maxDamage = battle.CurrentPartyAttackModifierGearInventoryHitChance.Inventory.WeaponHitChances[i].MaxDamage;
                                        minDamage = battle.CurrentPartyAttackModifierGearInventoryHitChance.Inventory.WeaponHitChances[i].MinDamage;
                                    }
                                }
                            }
                            y = battle.CurrentPartyAttackModifierGearInventoryHitChance.Inventory.WeaponHitChances.FindIndex(x => x.Name == name);
                            break;
                        }
                    // gear and vin fletcher expansions
                    // gear, items and vin fletcher expansions
                    // gear, stolen inventory and vin fletcher expansions
                    // gear, items, stolen inventory and vin fletcher expansions
                    default:
                        {
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
                            break;
                        }
                }
            }
            Console.WriteLine($"It is {currentCharacter.Name}'s turn...");
            if (y >= 0)
            {
                Console.WriteLine($"{currentCharacter.Name} equipped {/*battle.CurrentPartyGearInventoryHitChance.Inventory.WeaponHitChances[y].N*/name}.");
            }
            if (currentCharacter.CharacterInventory.WeaponHitChances/*I.Weapons*/.Count > 0)
            {
                WeaponHitChance tempWeapon = currentCharacter.CharacterInventory.WeaponHitChances[0];
                int a = currentCharacter.AvailableActionHitChances.FindIndex(x => x.ActionType == ActionTypes.GEAR_ATTACK);
                currentCharacter.AvailableActionHitChances.RemoveAt(a);
                currentCharacter.CharacterInventory.WeaponHitChances.RemoveAt(0);
                switch (strExpansions)
                {
                    // gear, vin fletcher and attack modifiers expansions
                    case "0245":
                    // gear, items, vin fletcher and attack modifiers expansions
                    case "01245":
                    // gear, stolen inventory, vin fletcher and attack modifiers expansions
                    case "02345":
                    // gear, items, stolen inventory, vin fletcher and attack modifiers expansions
                    case "012345":
                        {
                            currentCharacter.CharacterInventory.WeaponHitChances.Add(battle.CurrentPartyAttackModifierGearInventoryHitChance.Inventory.WeaponHitChances[y]);
                            currentCharacter.AvailableActionHitChances.Add(currentCharacter.CharacterInventory.WeaponHitChances[0].AvailableActionHitChance);
                            battle.CurrentPartyAttackModifierGearInventoryHitChance.Inventory.WeaponHitChances.RemoveAt(y);
                            battle.CurrentPartyAttackModifierGearInventoryHitChance.Inventory.WeaponHitChances.Add(tempWeapon);
                            break;
                        }
                    // gear and vin fletcher expansions
                    // gear, items and vin fletcher expansions
                    // gear, stolen inventory and vin fletcher expansions
                    // gear, items, stolen inventory and vin fletcher expansions
                    default:
                        {
                            currentCharacter.CharacterInventory.WeaponHitChances.Add(battle.CurrentPartyGearInventoryHitChance.Inventory.WeaponHitChances[y]);
                            currentCharacter.AvailableActionHitChances.Add(currentCharacter.CharacterInventory.WeaponHitChances[0].AvailableActionHitChance);
                            battle.CurrentPartyGearInventoryHitChance.Inventory.WeaponHitChances.RemoveAt(y);
                            battle.CurrentPartyGearInventoryHitChance.Inventory.WeaponHitChances.Add(tempWeapon);
                            break;
                        }
                }
            }
            else
            {
                switch (strExpansions)
                {
                    // gear, vin fletcher and attack modifiers expansions
                    case "0245":
                    // gear, items, vin fletcher and attack modifiers expansions
                    case "01245":
                    // gear, stolen inventory, vin fletcher and attack modifiers expansions
                    case "02345":
                    // gear, items, stolen inventory, vin fletcher and attack modifiers expansions
                    case "012345":
                        {
                            currentCharacter.CharacterInventory.WeaponHitChances.Add(battle.CurrentPartyAttackModifierGearInventoryHitChance.Inventory.WeaponHitChances[y]);
                            currentCharacter.AvailableActionHitChances.Add(currentCharacter.CharacterInventory.WeaponHitChances[0].AvailableActionHitChance);
                            battle.CurrentPartyAttackModifierGearInventoryHitChance.Inventory.WeaponHitChances.RemoveAt(y);
                            break;
                        }
                    // gear and vin fletcher expansions
                    // gear, items and vin fletcher expansions
                    // gear, stolen inventory and vin fletcher expansions
                    // gear, items, stolen inventory and vin fletcher expansions
                    default:
                        {
                            currentCharacter.CharacterInventory.WeaponHitChances.Add(battle.CurrentPartyGearInventoryHitChance.Inventory.WeaponHitChances[y]);
                            currentCharacter.AvailableActionHitChances.Add(currentCharacter.CharacterInventory.WeaponHitChances[0].AvailableActionHitChance);
                            battle.CurrentPartyGearInventoryHitChance.Inventory.WeaponHitChances.RemoveAt(y);
                            break;
                        }
                }
            }
            Console.WriteLine("\n");
        }
    }
}
