using System;
using System.Xml.Linq;
using Expansion_Attack_Modifiers_p426.Expansions;
using Expansion_Attack_Modifiers_p426.Expansions.Vin_Fletcher;
using Expansion_Attack_Modifiers_p426.Expansions.Vin_Fletcher.Actions;
using Expansion_Attack_Modifiers_p426.Expansions.Stolen_Inventory;
using Expansion_Attack_Modifiers_p426.Expansions.Items;
using Expansion_Attack_Modifiers_p426.Expansions.Items.Actions;
using Expansion_Attack_Modifiers_p426.Expansions.Gear;
using Expansion_Attack_Modifiers_p426.Expansions.Gear.Actions;
using Expansion_Attack_Modifiers_p426.Actions;
using Expansion_Attack_Modifiers_p426.Expansions.Attack_Modifiers;
using System.Runtime;

namespace Expansion_Attack_Modifiers_p426
{
    public static class Program
    {
        public static void Main()
        {
            // bool values for whether expansion are present
            bool expansionItemPresent = false, expansionGamesStatusPresent = false, expansionGearPresent = false, expansionStolenPresent = false, expansionVinFletcherPresent = false, expansionsAttackModifiersPresent = false;
            // checks if the expansion files are present
            expansionItemPresent = File.Exists("..\\..\\..\\Expansions\\Items\\Item.cs");
            expansionGamesStatusPresent = File.Exists("..\\..\\..\\Expansions\\Games_Status.cs");
            expansionGearPresent = File.Exists("..\\..\\..\\Expansions\\Gear\\Gear.cs");
            expansionStolenPresent = File.Exists("..\\..\\..\\Expansions\\Stolen_Inventory\\StolenInventories.cs");
            expansionVinFletcherPresent = File.Exists("..\\..\\..\\Expansions\\Vin_Fletcher\\WeaponHitChance.cs");
            expansionsAttackModifiersPresent = File.Exists("..\\..\\..\\Expansions\\Attack_Modifiers\\CharacterAttackModifier.cs");
            // bool if given expansion is selected
            bool expansionItemSelected = false, expansionGearSelected = false, expansionStolenSelected = false, expansionVinFletcherSelected = false, expansionsAttackModifiersSelected = false;
            int expansionInput = -1;
            // list of currently active expansions or "none" if none selected
            List<OptionalExpansions> expansions = new List<OptionalExpansions>();
            // loop for selecting which expansions are active
            while (expansionInput != 0)
            {
                int menuOptionNumber = 0;
                // if at least one expansion is present
                if (expansionGamesStatusPresent || expansionItemPresent || expansionGearPresent || ((expansionItemPresent || expansionGearPresent) && expansionStolenPresent) || expansionVinFletcherPresent || expansionsAttackModifiersPresent)
                {
                    Console.WriteLine("Please select from the following list which expansions to use with the corresponsding number");
                    Console.WriteLine($"{menuOptionNumber}: Quit ");
                    menuOptionNumber++;
                    if (expansionGamesStatusPresent)
                    {
                        Console.WriteLine($"{menuOptionNumber}: None");
                        menuOptionNumber++;
                    }
                    if (expansionGamesStatusPresent && expansionItemPresent)
                    {
                        if (expansionItemSelected)
                        {
                            Console.WriteLine($"{menuOptionNumber}: Items *ACTIVE*");
                        }
                        else
                        {
                            Console.WriteLine($"{menuOptionNumber}: Items *DISABLED*");
                        }
                        menuOptionNumber++;
                    }
                    if (expansionGamesStatusPresent && expansionGearPresent)
                    {
                        if (expansionGearSelected)
                        {
                            Console.WriteLine($"{menuOptionNumber}: Gear *ACTIVE*");
                        }
                        else
                        {
                            Console.WriteLine($"{menuOptionNumber}: Gear *DISABLED*");
                        }
                        menuOptionNumber++;
                    }
                    if (expansionGamesStatusPresent && expansionStolenPresent)
                    {
                        if (expansionStolenSelected && (expansionItemSelected || expansionStolenSelected))
                        {
                            Console.WriteLine($"{menuOptionNumber}: Stolen Inventory *ACTIVE*");
                        }
                        else if (expansionStolenSelected && expansionItemSelected == false && expansionGearSelected == false)
                        {
                            Console.WriteLine($"{menuOptionNumber}: Stolen Inventory *DISABLED*");
                            Console.WriteLine("You must have either Items and/or Gear selected to use Stolen Inventory");
                        }
                        else
                        {
                            Console.WriteLine($"{menuOptionNumber}: Stolen Inventory *DISABLED*");
                        }
                    menuOptionNumber++;
                    }
                    if (expansionGamesStatusPresent && expansionVinFletcherPresent)
                    {
                        if (expansionVinFletcherSelected)
                        {
                            Console.WriteLine($"{menuOptionNumber}: Vin Fletcher *ACTIVE*");
                        }
                        else
                        {
                            Console.WriteLine($"{menuOptionNumber}: Vin Fletcher *DISABLED*");
                        }
                        menuOptionNumber++;
                    }
                    if (expansionGamesStatusPresent && expansionsAttackModifiersPresent)
                    {
                        if (expansionsAttackModifiersSelected)
                        {
                            Console.WriteLine($"{menuOptionNumber}: Attack Modifiers *ACTIVE*");
                        }
                        else
                        {
                            Console.WriteLine($"{menuOptionNumber}: Attack Modifiers *DISABLED*");
                        }
                        menuOptionNumber++;
                    }
                    if (expansionGamesStatusPresent && expansionItemPresent && expansionGearPresent && expansionStolenPresent && expansionVinFletcherPresent && expansionsAttackModifiersPresent)
                    {
                        Console.WriteLine($"{menuOptionNumber}: All");
                    }
                    bool validInput = false;
                    // while loop for determining valid input
                    while (validInput == false)
                    {
                        try
                        {
                            expansionInput = Convert.ToInt32(Console.ReadLine());
                            // switch to redirect after valid input
                            switch (expansionInput)
                            {
                                // leave expansion selection menu
                                case 0:
                                    {
                                        Console.WriteLine("Leaving the expansions selection menu.");
                                        validInput = true;
                                        break;
                                    }
                                // set selected expansions to none
                                case 1:
                                    {
                                        Console.WriteLine("You have selected to not use any expansion other than Game's Status which is required.");
                                        expansionItemSelected = false;
                                        expansionGearSelected = false;
                                        expansionStolenSelected = false;
                                        expansionVinFletcherSelected = false;
                                        expansionsAttackModifiersSelected = false;
                                        expansions.Clear();
                                        expansions.Add(OptionalExpansions.NONE);
                                        validInput = true;
                                        break;
                                    }
                                // toggle items expansion
                                case 2:
                                    {
                                        // toggles item expansion off
                                        if (expansionItemSelected)
                                        {
                                            expansionItemSelected = false;
                                            expansions.Remove(OptionalExpansions.ITEMS);
                                            // disables stolen inventory expansion if both items and gear expansions are disabled
                                            if (expansionStolenSelected && expansionGearSelected == false)
                                            {
                                                expansions.Remove(OptionalExpansions.STOLEN_INVENTORY);
                                                expansionStolenSelected = false;
                                            }
                                            if (expansions.Count == 0)
                                            {
                                                expansions.Add(OptionalExpansions.NONE);
                                            }
                                        }
                                        // toggles item expansion on
                                        else
                                        {
                                            expansionItemSelected = true;
                                            expansions.Add(OptionalExpansions.ITEMS);
                                            if (expansions.Exists(x => x.Equals(OptionalExpansions.NONE)))
                                            {
                                                expansions.Remove(OptionalExpansions.NONE);
                                            }
                                        }
                                        validInput = true;
                                        break;
                                    }
                                // toggle gear expansion
                                case 3:
                                    {
                                        // toggles gear expansion off
                                        if (expansionGearSelected)
                                        {
                                            expansionGearSelected = false;
                                            expansions.Remove(OptionalExpansions.GEAR);
                                            // disables stolen inventory expansion if both items and gear expansions are disabled
                                            if (expansionStolenSelected && expansionItemSelected == false)
                                            {
                                                expansions.Remove(OptionalExpansions.STOLEN_INVENTORY);
                                                expansionStolenSelected = false;
                                            }
                                            if (expansions.Count == 0)
                                            {
                                                expansions.Add(OptionalExpansions.NONE);
                                            }
                                        }
                                        // toggles gear expansion on
                                        else
                                        {
                                            expansionGearSelected = true;
                                            expansions.Add(OptionalExpansions.GEAR);
                                            if (expansions.Exists(x => x.Equals(OptionalExpansions.NONE)))
                                            {
                                                expansions.Remove(OptionalExpansions.NONE);
                                            }
                                        }
                                        validInput = true;
                                        break;
                                    }
                                // toggle stolen inventory expansion
                                case 4:
                                    {
                                        // toggle stolen inventory expansion off
                                        if (expansionStolenSelected)
                                        {
                                            expansionStolenSelected = false;
                                            expansions.Remove(OptionalExpansions.STOLEN_INVENTORY);
                                            if (expansions.Count == 0)
                                            {
                                                expansions.Add(OptionalExpansions.NONE);
                                            }
                                        }
                                        // toggles stolen inventory expansion on
                                        else if (expansionStolenSelected == false && (expansionItemSelected || expansionGearSelected))
                                        {
                                            expansionStolenSelected = true;
                                            expansions.Add(OptionalExpansions.STOLEN_INVENTORY);
                                            if (expansions.Exists(x => x.Equals(OptionalExpansions.NONE)))
                                            {
                                                expansions.Remove(OptionalExpansions.NONE);
                                            }
                                        }
                                        // returns error message if both items and gear expansions are disabled
                                        if (expansionStolenSelected == false && expansionItemSelected == false && expansionGearSelected == false)
                                        {
                                            Console.WriteLine("You must have either Items or Gear expansions selected to use the Stolen Inventory expansion");
                                        }
                                        validInput = true;
                                        break;
                                    }
                                // toggle vin fletcher expansion
                                case 5:
                                    {
                                        // toggles vin fletcher expansion off
                                        if (expansionVinFletcherSelected)
                                        {
                                            expansionVinFletcherSelected = false;
                                            expansions.Remove(OptionalExpansions.VIN_FLETCHER);
                                            if (expansions.Count == 0)
                                            {
                                                expansions.Add(OptionalExpansions.NONE);
                                            }

                                        }
                                        // toggles vin fletcher expansion on
                                        else
                                        {
                                            expansionVinFletcherSelected = true;
                                            expansions.Add(OptionalExpansions.VIN_FLETCHER);
                                            if (expansions.Exists(x => x.Equals(OptionalExpansions.NONE)))
                                            {
                                                expansions.Remove(OptionalExpansions.NONE);
                                            }
                                        }
                                        validInput = true;
                                        break;
                                    }
                                // toggle attack modifiers expansion
                                case 6:
                                    {
                                        // toggles attack modifier expansion off
                                        if (expansionsAttackModifiersSelected)
                                        {
                                            expansionsAttackModifiersSelected = false;
                                            expansions.Remove(OptionalExpansions.ATTACK_MODIFIERS);
                                            if (expansions.Count == 0)
                                            {
                                                expansions.Add(OptionalExpansions.NONE);
                                            }
                                        }
                                        // toggles attack modifiers expansion on
                                        else
                                        {
                                            expansionsAttackModifiersSelected = true;
                                            expansions.Add(OptionalExpansions.ATTACK_MODIFIERS);
                                            if (expansions.Exists(x => x.Equals (OptionalExpansions.NONE)))
                                            {
                                                expansions.Remove(OptionalExpansions.NONE);
                                            }
                                        }
                                        validInput = true;
                                        break;
                                    }
                                // toggles all expansions on
                                case 7:
                                    {
                                        expansions.Clear();
                                        expansionItemSelected = true;
                                        expansions.Add(OptionalExpansions.ITEMS);
                                        expansionGearSelected = true;
                                        expansions.Add(OptionalExpansions.GEAR);
                                        expansionStolenSelected = true;
                                        expansions.Add(OptionalExpansions.STOLEN_INVENTORY);
                                        expansionVinFletcherSelected = true;
                                        expansions.Add(OptionalExpansions.VIN_FLETCHER);
                                        expansionsAttackModifiersSelected = true;
                                        expansions.Add(OptionalExpansions.ATTACK_MODIFIERS);
                                        validInput = true;
                                        break;
                                    }
                                default:
                                    {
                                        validInput = false;
                                        Console.WriteLine($"Please enter a number between 0 and {menuOptionNumber}.");
                                        break;
                                    }
                            }
                        }
                        catch (FormatException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                }
            }
            // string variable holding active expansions
            string strExpansions = "0";
            if (expansions.Exists(x => x.Equals(OptionalExpansions.ITEMS)))
            {
                strExpansions += "1";
            }
            if (expansions.Exists(x => x.Equals(OptionalExpansions.GEAR)))
            {
                strExpansions += "2";
            }
            if (expansions.Exists(x => x.Equals(OptionalExpansions.STOLEN_INVENTORY)))
            {
                strExpansions += "3";
            }
            if (expansions.Exists(x => x.Equals(OptionalExpansions.VIN_FLETCHER)))
            {
                strExpansions += "4";
            }
            if (expansions.Exists(x => x.Equals(OptionalExpansions.ATTACK_MODIFIERS)))
            {
                strExpansions += "5";
            }
            // switch to redirect to correct code for current set of active expansions
            switch (strExpansions)
            {
                // ..\\..\\..\\Expansions\\Games_Status.cs
                // ..\\..\\..\\Expansions\\Items
                case "01":
                // ..\\..\\..\\Expansions\\Games_Status.cs
                // ..\\..\\..\\Expansions\\Items
                // ..\\..\\..\\Expansions\\Stolen_Inventory
                case "013":
                    {
                        // creates player list
                        List<Player> playerList = SetPlayers();
                        // creates hero character
                        List<Character> characters = CreateHeroCharacters(strExpansions);
                        List<Potion?> heroItems = GetHeroPartyItems();
                        Inventory heroPartyInventory = new Inventory(heroItems);
                        PartyItemInventory heroes = new PartyItemInventory(characters, PartyType.Heroes, "Heroes", heroPartyInventory);
                        List<Character> monsterCharacters = CreateMonsterCharacters(strExpansions);
                        List<Character> monsterCharacters1 = new List<Character> { monsterCharacters[0] };
                        List<Character> monsterCharacters2 = new List<Character> { monsterCharacters[1], monsterCharacters[2] };
                        List<Character> monsterCharacters3 = new List<Character> { monsterCharacters[3] };
                        List<Potion?> monsterItems1 = new List<Potion?> { GetHealing10HPPotion() };
                        List<Potion?> monsterItems2 = new List<Potion?> { GetHealing10HPPotion() };
                        List<Potion?> monsterItems3 = new List<Potion?> { GetHealing10HPPotion() };
                        Inventory monsterPartyInventory1 = new Inventory(monsterItems1);
                        Inventory monsterPartyInventory2 = new Inventory(monsterItems2);
                        Inventory monsterPartyInventory3 = new Inventory(monsterItems3);
                        PartyItemInventory monsters1 = new PartyItemInventory(monsterCharacters1, PartyType.Monsters, "monsters1", monsterPartyInventory1);
                        PartyItemInventory monsters2 = new PartyItemInventory(monsterCharacters2, PartyType.Monsters, "monsters1", monsterPartyInventory2);
                        PartyItemInventory monsters3 = new PartyItemInventory(monsterCharacters3, PartyType.Monsters, "monsters1", monsterPartyInventory3);
                        List<PartyItemInventory> monsters = new List<PartyItemInventory> { monsters1, monsters2, monsters3 };
                        Battle battle = new Battle(heroes, monsters, characters[0], PartyType.Heroes, playerList, playerList[0], heroes, strExpansions);
                        GameStart(battle);
                        break;
                    }
                // ..\\..\\..\\Expansions\\Games_Status.cs
                // ..\\..\\..\\Expansions\\Items
                // ..\\..\\..\\Expansions\\Vin_Fletcher
                case "014":
                // ..\\..\\..\\Expansions\\Games_Status.cs
                // ..\\..\\..\\Expansions\\Items
                // ..\\..\\..\\Expansions\\Stolen_Inventory
                // ..\\..\\..\\Expansions\\Vin_Fletcher
                case "0134":
                    {
                        // creates player list
                        List<Player> playerList = SetPlayers();
                        // creates hero character
                        List<CharacterHitChance> characters = CreateHeroCharactersHitChance(strExpansions);
                        List<Potion?> heroItems = GetHeroPartyItems();
                        Inventory heroPartyInventory = new Inventory(heroItems);
                        PartyItemInventoryHitChance heroes = new PartyItemInventoryHitChance(characters, PartyType.Heroes, "Heroes", heroPartyInventory);
                        List<CharacterHitChance> monsterCharacters = CreateMonsterCharactersHitChance(strExpansions);
                        List<CharacterHitChance> monsterCharacters1 = new List<CharacterHitChance> { monsterCharacters[0] };
                        List<CharacterHitChance> monsterCharacters2 = new List<CharacterHitChance> { monsterCharacters[1], monsterCharacters[2] };
                        List<CharacterHitChance> monsterCharacters3 = new List<CharacterHitChance> { monsterCharacters[3] };
                        List<Potion?> monsterItems1 = new List<Potion?> { GetHealing10HPPotion() };
                        List<Potion?> monsterItems2 = new List<Potion?> { GetHealing10HPPotion() };
                        List<Potion?> monsterItems3 = new List<Potion?> { GetHealing10HPPotion() };
                        Inventory monsterPartyInventory1 = new Inventory(monsterItems1);
                        Inventory monsterPartyInventory2 = new Inventory(monsterItems2);
                        Inventory monsterPartyInventory3 = new Inventory(monsterItems3);
                        PartyItemInventoryHitChance monsters1 = new PartyItemInventoryHitChance(monsterCharacters1, PartyType.Monsters, "monsters1", monsterPartyInventory1);
                        PartyItemInventoryHitChance monsters2 = new PartyItemInventoryHitChance(monsterCharacters2, PartyType.Monsters, "monsters1", monsterPartyInventory2);
                        PartyItemInventoryHitChance monsters3 = new PartyItemInventoryHitChance(monsterCharacters3, PartyType.Monsters, "monsters1", monsterPartyInventory3);
                        List<PartyItemInventoryHitChance> monsters = new List<PartyItemInventoryHitChance> { monsters1, monsters2, monsters3 };
                        Battle battle = new Battle(heroes, monsters, characters[0], PartyType.Heroes, playerList, playerList[0], heroes, strExpansions);
                        GameStart(battle);
                        break;
                    }
                // ..\\..\\..\\Expansions\\Games_Status.cs
                // ..\\..\\..\\Expansions\\Gear
                case "02":
                // ..\\..\\..\\Expansions\\Games_Status.cs
                // ..\\..\\..\\Expansions\\Gear
                // ..\\..\\..\\Expansions\\Stolen_Inventory
                case "023":
                    {
                        // creates player list
                        List<Player> playerList = SetPlayers();
                        // creates hero character
                        CharacterGearInventory trueProgrammer = (CharacterGearInventory)CreateHeroCharacter(strExpansions, "trueProgrammer");
                        //CharacterGearInventory vinFletcher = (CharacterGearInventory)CreateHeroCharacter(strExpansions, "vinFletcher");
                        List<CharacterGearInventory> characters = new List<CharacterGearInventory> { trueProgrammer/*, vinFletcher*/ };
                        List<Weapon?> heroGear = new List<Weapon?>();
                        Inventory heroPartyInventory = new Inventory();
                        heroPartyInventory.Weapons = heroGear;
                        PartyGearInventory heroes = new PartyGearInventory(characters, PartyType.Heroes, "Heroes", heroPartyInventory);
                        List<CharacterGearInventory> monsterCharacters = CreateMonsterCharactersGearInventory(strExpansions);
                        List<CharacterGearInventory> monsterCharacters1 = new List<CharacterGearInventory> { monsterCharacters[0] };
                        List<CharacterGearInventory> monsterCharacters2 = new List<CharacterGearInventory> { monsterCharacters[1], monsterCharacters[2] };
                        List<CharacterGearInventory> monsterCharacters3 = new List<CharacterGearInventory> { monsterCharacters[3] };
                        List<Weapon?> monsterGear1 = new List<Weapon?>();
                        Inventory monsterPartyInventory1 = new Inventory(monsterGear1);
                        AvailableAction stab = new AvailableAction("stab", 1, 1, ActionTypes.GEAR_ATTACK);
                        Weapon dagger2 = new Weapon(GearTypes.WEAPON, "dagger2", WeaponTypes.DAGGER, 1, 1, stab, "dagger2");
                        Weapon dagger3 = new Weapon(GearTypes.WEAPON, "dagger3", WeaponTypes.DAGGER, 1, 1, stab, "dagger3");
                        List<Weapon?> monsterGear2 = new List<Weapon?>();
                        monsterGear2.Add(dagger2);
                        monsterGear2.Add(dagger3);
                        Inventory monsterPartyInventory2 = new Inventory(monsterGear2);
                        List<Weapon?> monsterGear3 = new List<Weapon?>();
                        Inventory monsterPartyInventory3 = new Inventory(monsterGear3);
                        PartyGearInventory monsters1 = new PartyGearInventory(monsterCharacters1, PartyType.Monsters, "monsters1", monsterPartyInventory1);
                        PartyGearInventory monsters2 = new PartyGearInventory(monsterCharacters2, PartyType.Monsters, "monsters2", monsterPartyInventory2);
                        PartyGearInventory monsters3 = new PartyGearInventory(monsterCharacters3, PartyType.Monsters, "monsters3", monsterPartyInventory3);
                        List<PartyGearInventory> monsters = new List<PartyGearInventory> { monsters1, monsters2, monsters3 };
                        Battle battle = new Battle(heroes, monsters, trueProgrammer, PartyType.Heroes, playerList, playerList[0], heroes, strExpansions);
                        GameStart(battle);
                        break;
                    }
                // ..\\..\\..\\Expansions\\Games_Status.cs
                // ..\\..\\..\\Expansions\\Gear
                // ..\\..\\..\\Expansions\\Vin_Fletcher
                case "024":
                // ..\\..\\..\\Expansions\\Games_Status.cs
                // ..\\..\\..\\Expansions\\Gear
                // ..\\..\\..\\Expansions\\Stolen_Inventory
                // ..\\..\\..\\Expansions\\Vin_Fletcher
                case "0234":
                    {
                        // creates player list
                        List<Player> playerList = SetPlayers();
                        // creates hero character
                        CharacterGearInventoryHitChance trueProgrammer = (CharacterGearInventoryHitChance)CreateHeroCharacterHitChance(strExpansions, "trueProgrammer");
                        CharacterGearInventoryHitChance vinFletcher = (CharacterGearInventoryHitChance)CreateHeroCharacterHitChance(strExpansions, "vinFletcher");
                        List<CharacterGearInventoryHitChance> characters = new List<CharacterGearInventoryHitChance> { trueProgrammer, vinFletcher };
                        List<WeaponHitChance> heroGear = new List<WeaponHitChance>();
                        Inventory heroPartyInventory = new Inventory();
                        heroPartyInventory.WeaponHitChances = heroGear;
                        PartyGearInventoryHitChance heroes = new PartyGearInventoryHitChance(characters, PartyType.Heroes, "Heroes", heroPartyInventory);
                        List<CharacterGearInventoryHitChance> monsterCharacters = CreateMonsterCharactersGearInventoryHitChance(strExpansions);
                        List<CharacterGearInventoryHitChance> monsterCharacters1 = new List<CharacterGearInventoryHitChance> { monsterCharacters[0] };
                        List<CharacterGearInventoryHitChance> monsterCharacters2 = new List<CharacterGearInventoryHitChance> { monsterCharacters[1], monsterCharacters[2] };
                        List<CharacterGearInventoryHitChance> monsterCharacters3 = new List<CharacterGearInventoryHitChance> { monsterCharacters[3] };
                        List<WeaponHitChance> monsterGear1 = new List<WeaponHitChance>();
                        Inventory monsterPartyInventory1 = new Inventory(monsterGear1);
                        AvailableActionHitChance stab = new AvailableActionHitChance("STAB", 1, 1, ActionTypes.GEAR_ATTACK, 0.5);
                        WeaponHitChance dagger2 = new WeaponHitChance(GearTypes.WEAPON, "dagger2", WeaponTypes.DAGGER, 1, 1, stab, "dagger2", 0.5);
                        WeaponHitChance dagger3 = new WeaponHitChance(GearTypes.WEAPON, "dagger3", WeaponTypes.DAGGER, 1, 1, stab, "dagger3", 0.5);
                        List<WeaponHitChance> monsterGear2 = new List<WeaponHitChance>();
                        monsterGear2.Add(dagger2);
                        monsterGear2.Add(dagger3);
                        Inventory monsterPartyInventory2 = new Inventory(monsterGear2);
                        List<WeaponHitChance> monsterGear3 = new List<WeaponHitChance>();
                        Inventory monsterPartyInventory3 = new Inventory(monsterGear3);
                        PartyGearInventoryHitChance monsters1 = new PartyGearInventoryHitChance(monsterCharacters1, PartyType.Monsters, "monsters1", monsterPartyInventory1);
                        PartyGearInventoryHitChance monsters2 = new PartyGearInventoryHitChance(monsterCharacters2, PartyType.Monsters, "monsters2", monsterPartyInventory2);
                        PartyGearInventoryHitChance monsters3 = new PartyGearInventoryHitChance(monsterCharacters3, PartyType.Monsters, "monsters3", monsterPartyInventory3);
                        List<PartyGearInventoryHitChance> monsters = new List<PartyGearInventoryHitChance> { monsters1, monsters2, monsters3 };
                        Battle battle = new Battle(heroes, monsters, trueProgrammer, PartyType.Heroes, playerList, playerList[0], heroes, strExpansions);
                        GameStart(battle);
                        break;
                    }
                // ..\\..\\..\\Expansions\\Games_Status.cs
                // ..\\..\\..\\Expansions\\Items
                // ..\\..\\..\\Expansions\\Gear
                case "012":
                // ..\\..\\..\\Expansions\\Games_Status.cs
                // ..\\..\\..\\Expansions\\Items
                // ..\\..\\..\\Expansions\\Gear
                // ..\\..\\..\\Expansions\\Stolen_Inventory
                case "0123":
                    {
                        // creates player list
                        List<Player> playerList = SetPlayers();
                        // creates hero character
                        CharacterGearInventory trueProgrammer = (CharacterGearInventory)CreateHeroCharacter(strExpansions, "trueProgrammer");
                        //CharacterGearInventory vinFletcher = (CharacterGearInventory)CreateHeroCharacter(strExpansions, "vinFletcher");
                        List<CharacterGearInventory> characters = new List<CharacterGearInventory> { trueProgrammer/*, vinFletcher*/ };
                        List<Weapon?> heroGear = new List<Weapon?>();
                        Inventory heroPartyInventory = new Inventory();
                        heroPartyInventory.Weapons = heroGear;
                        heroPartyInventory.Potions = GetHeroPartyItems();
                        PartyGearInventory heroes = new PartyGearInventory(characters, PartyType.Heroes, "Heroes", heroPartyInventory);
                        List<CharacterGearInventory> monsterCharacters = CreateMonsterCharactersGearInventory(strExpansions);
                        List<CharacterGearInventory> monsterCharacters1 = new List<CharacterGearInventory> { monsterCharacters[0] };
                        List<CharacterGearInventory> monsterCharacters2 = new List<CharacterGearInventory> { monsterCharacters[1], monsterCharacters[2] };
                        List<CharacterGearInventory> monsterCharacters3 = new List<CharacterGearInventory> { monsterCharacters[3] };
                        List<Potion?> monsterItems1 = new List<Potion?> { GetHealing10HPPotion() };
                        List<Weapon?> monsterGear1 = new List<Weapon?>();
                        Inventory monsterPartyInventory1 = new Inventory();
                        monsterPartyInventory1.Potions = monsterItems1;
                        monsterPartyInventory1.Weapons = monsterGear1;
                        List<Potion?> monsterItems2 = new List<Potion?> { GetHealing10HPPotion() };
                        AvailableAction stab = new AvailableAction("STAB", 1, 1, ActionTypes.GEAR_ATTACK);
                        Weapon dagger2 = new Weapon(GearTypes.WEAPON, "dagger2", WeaponTypes.DAGGER, 1, 1, stab, "dagger2");
                        Weapon dagger3 = new Weapon(GearTypes.WEAPON, "dagger3", WeaponTypes.DAGGER, 1, 1, stab, "dagger3");
                        List<Weapon?> monsterGear2 = new List<Weapon?>();
                        monsterGear2.Add(dagger2);
                        monsterGear2.Add(dagger3);
                        Inventory monsterPartyInventory2 = new Inventory();
                        monsterPartyInventory2.Potions = monsterItems2;
                        monsterPartyInventory2.Weapons = monsterGear2;
                        List<Potion?> monsterItems3 = new List<Potion?> { GetHealing10HPPotion() };
                        List<Weapon?> monsterGear3 = new List<Weapon?>();
                        Inventory monsterPartyInventory3 = new Inventory();
                        monsterPartyInventory3.Potions = monsterItems3;
                        monsterPartyInventory3.Weapons = monsterGear3;
                        PartyGearInventory monsters1 = new PartyGearInventory(monsterCharacters1, PartyType.Monsters, "monsters1", monsterPartyInventory1);
                        PartyGearInventory monsters2 = new PartyGearInventory(monsterCharacters2, PartyType.Monsters, "monsters2", monsterPartyInventory2);
                        PartyGearInventory monsters3 = new PartyGearInventory(monsterCharacters3, PartyType.Monsters, "monsters3", monsterPartyInventory3);
                        List<PartyGearInventory> monsters = new List<PartyGearInventory> { monsters1, monsters2, monsters3 };
                        Battle battle = new Battle(heroes, monsters, trueProgrammer, PartyType.Heroes, playerList, playerList[0], heroes, strExpansions);
                        GameStart(battle);
                        break;
                    }
                // ..\\..\\..\\Expansions\\Games_Status.cs
                // ..\\..\\..\\Expansions\\Items
                // ..\\..\\..\\Expansions\\Gear
                // ..\\..\\..\\Expansions\\Vin_Fletcher
                case "0124":
                // ..\\..\\..\\Expansions\\Games_Status.cs
                // ..\\..\\..\\Expansions\\Items
                // ..\\..\\..\\Expansions\\Gear
                // ..\\..\\..\\Expansions\\Stolen_Inventory
                // ..\\..\\..\\Expansions\\Vin_Fletcher
                case "01234":
                    {
                        // creates player list
                        List<Player> playerList = SetPlayers();
                        // creates hero character
                        CharacterGearInventoryHitChance trueProgrammer = (CharacterGearInventoryHitChance)CreateHeroCharacterHitChance(strExpansions, "trueProgrammer");
                        CharacterGearInventoryHitChance vinFletcher = (CharacterGearInventoryHitChance)CreateHeroCharacterHitChance(strExpansions, "vinFletcher");
                        List<CharacterGearInventoryHitChance> characters = new List<CharacterGearInventoryHitChance> { trueProgrammer, vinFletcher };
                        List<WeaponHitChance> heroGear = new List<WeaponHitChance>();
                        Inventory heroPartyInventory = new Inventory();
                        heroPartyInventory.WeaponHitChances = heroGear;
                        heroPartyInventory.Potions = GetHeroPartyItems();
                        PartyGearInventoryHitChance heroes = new PartyGearInventoryHitChance(characters, PartyType.Heroes, "Heroes", heroPartyInventory);
                        List<CharacterGearInventoryHitChance> monsterCharacters = CreateMonsterCharactersGearInventoryHitChance(strExpansions);
                        List<CharacterGearInventoryHitChance> monsterCharacters1 = new List<CharacterGearInventoryHitChance> { monsterCharacters[0] };
                        List<CharacterGearInventoryHitChance> monsterCharacters2 = new List<CharacterGearInventoryHitChance> { monsterCharacters[1], monsterCharacters[2] };
                        List<CharacterGearInventoryHitChance> monsterCharacters3 = new List<CharacterGearInventoryHitChance> { monsterCharacters[3] };
                        List<Potion?> monsterItems1 = new List<Potion?> { GetHealing10HPPotion() };
                        List<WeaponHitChance> monsterGear1 = new List<WeaponHitChance>();
                        Inventory monsterPartyInventory1 = new Inventory();
                        monsterPartyInventory1.Potions = monsterItems1;
                        monsterPartyInventory1.WeaponHitChances = monsterGear1;
                        List<Potion?> monsterItems2 = new List<Potion?> { GetHealing10HPPotion() };
                        AvailableActionHitChance stab = new AvailableActionHitChance("STAB", 1, 1, ActionTypes.GEAR_ATTACK, 0.5);
                        WeaponHitChance dagger2 = new WeaponHitChance(GearTypes.WEAPON, "dagger2", WeaponTypes.DAGGER, 1, 1, stab, "dagger2", 0.5);
                        WeaponHitChance dagger3 = new WeaponHitChance(GearTypes.WEAPON, "dagger3", WeaponTypes.DAGGER, 1, 1, stab, "dagger3", 0.5);
                        List<WeaponHitChance> monsterGear2 = new List<WeaponHitChance>();
                        monsterGear2.Add(dagger2);
                        monsterGear2.Add(dagger3);
                        Inventory monsterPartyInventory2 = new Inventory();
                        monsterPartyInventory2.Potions = monsterItems2;
                        monsterPartyInventory2.WeaponHitChances = monsterGear2;
                        List<Potion?> monsterItems3 = new List<Potion?> { GetHealing10HPPotion() };
                        List<WeaponHitChance> monsterGear3 = new List<WeaponHitChance>();
                        Inventory monsterPartyInventory3 = new Inventory();
                        monsterPartyInventory3.Potions = monsterItems3;
                        monsterPartyInventory3.WeaponHitChances = monsterGear3;
                        PartyGearInventoryHitChance monsters1 = new PartyGearInventoryHitChance(monsterCharacters1, PartyType.Monsters, "monsters1", monsterPartyInventory1);
                        PartyGearInventoryHitChance monsters2 = new PartyGearInventoryHitChance(monsterCharacters2, PartyType.Monsters, "monsters2", monsterPartyInventory2);
                        PartyGearInventoryHitChance monsters3 = new PartyGearInventoryHitChance(monsterCharacters3, PartyType.Monsters, "monsters3", monsterPartyInventory3);
                        List<PartyGearInventoryHitChance> monsters = new List<PartyGearInventoryHitChance> { monsters1, monsters2, monsters3 };
                        Battle battle = new Battle(heroes, monsters, trueProgrammer, PartyType.Heroes, playerList, playerList[0], heroes, strExpansions);
                        GameStart(battle);
                        break;
                    }
                // ..\\..\\..\\Expansions\\Vin_Fletcher
                case "04":
                    {
                        // creates player list
                        List<Player> playerList = SetPlayers();
                        // creates hero character
                        List<CharacterHitChance> characters = CreateHeroCharactersHitChance(strExpansions);
                        Party heroes = new Party(characters, PartyType.Heroes, "heroes");
                        List<CharacterHitChance> monsterCharacters = CreateMonsterCharactersHitChance(strExpansions);
                        List<CharacterHitChance> monsterCharacters1 = new List<CharacterHitChance> { monsterCharacters[0] };
                        List<CharacterHitChance> monsterCharacters2 = new List<CharacterHitChance> { monsterCharacters[1], monsterCharacters[2] };
                        List<CharacterHitChance> monsterCharacters3 = new List<CharacterHitChance> { monsterCharacters[3] };
                        Party monsters1 = new Party(monsterCharacters1, PartyType.Monsters, "monsters1");
                        Party monsters2 = new Party(monsterCharacters2, PartyType.Monsters, "monsters2");
                        Party monsters3 = new Party(monsterCharacters3, PartyType.Monsters, "monsters3");
                        List<Party> monsters = new List<Party> { monsters1, monsters2, monsters3 };
                        Battle battle = new Battle(heroes, monsters, characters[0], PartyType.Heroes, playerList, playerList[0], heroes, strExpansions);
                        GameStart(battle);
                        break;
                    }
                // ..\\..\\..\\Expansions\\Attack_Modifiers
                case "05":
                    {
                        // creates player list
                        List<Player> playerList = SetPlayers();
                        // creates hero character
                        List<CharacterAttackModifier> characters = CreateHeroCharactersAttackModifier(strExpansions);
                        Party heroes = new Party(characters, PartyType.Heroes, "heroes");
                        List<CharacterAttackModifier> monsterCharacters = CreateMonsterCharactersAttackModifiers(strExpansions);
                        List<CharacterAttackModifier> monsterCharacters1 = new List<CharacterAttackModifier> { monsterCharacters[0] };
                        List<CharacterAttackModifier> monsterCharacters2 = new List<CharacterAttackModifier> { monsterCharacters[1], monsterCharacters[2] };
                        List<CharacterAttackModifier> monsterCharacters3 = new List<CharacterAttackModifier> { monsterCharacters[3], monsterCharacters[4] };
                        List<CharacterAttackModifier> monsterCharacters4 = new List<CharacterAttackModifier> { monsterCharacters[5] };
                        Party monsters1 = new Party(monsterCharacters1, PartyType.Monsters, "monsters1");
                        Party monsters2 = new Party(monsterCharacters2, PartyType.Monsters, "monsters2");
                        Party monsters3 = new Party(monsterCharacters3, PartyType.Monsters, "monsters3");
                        Party monsters4 = new Party(monsterCharacters4, PartyType.Monsters, "monsters4");
                        List<Party> monsters = new List<Party> { monsters1, monsters2, monsters3, monsters4 };
                        Battle battle = new Battle(heroes, monsters, characters[0], PartyType.Heroes, playerList, playerList[0], heroes, strExpansions);
                        GameStart(battle);
                        break;
                    }
                // ..\\..\\..\\Expansions\\Games_Status.cs
                // ..\\..\\..\\Expansions\\Items
                // ..\\..\\..\\Expansions\\Attack_Modifiers
                case "015":
                // ..\\..\\..\\Expansions\\Games_Status.cs
                // ..\\..\\..\\Expansions\\Items
                // ..\\..\\..\\Expansions\\Stolen_Inventory
                // ..\\..\\..\\Expansions\\Attack_Modifiers
                case "0135":
                    {
                        // creates player list
                        List<Player> playerList = SetPlayers();
                        // creates hero character
                        List<CharacterAttackModifier> characters = CreateHeroCharactersAttackModifier(strExpansions);
                        List<Potion?> heroItems = GetHeroPartyItems();
                        Inventory heroPartyInventory = new Inventory(heroItems);
                        PartyAttackModifierItemInventory heroes = new PartyAttackModifierItemInventory(characters, PartyType.Heroes, "Heroes", heroPartyInventory);
                        List<CharacterAttackModifier> monsterCharacters = CreateMonsterCharactersAttackModifiers(strExpansions);
                        List<CharacterAttackModifier> monsterCharacters1 = new List<CharacterAttackModifier> { monsterCharacters[0] };
                        List<CharacterAttackModifier> monsterCharacters2 = new List<CharacterAttackModifier> { monsterCharacters[1], monsterCharacters[2] };
                        List<CharacterAttackModifier> monsterCharacters3 = new List<CharacterAttackModifier> { monsterCharacters[3], monsterCharacters[4] };
                        List<CharacterAttackModifier> monsterCharacters4 = new List<CharacterAttackModifier> { monsterCharacters[5] };
                        List<Potion?> monsterItems1 = new List<Potion?> { GetHealing10HPPotion() };
                        List<Potion?> monsterItems2 = new List<Potion?> { GetHealing10HPPotion() };
                        List<Potion?> monsterItems3 = new List<Potion?> { GetHealing10HPPotion() };
                        List<Potion?> monsterItems4 = new List<Potion?> { GetHealing10HPPotion() };
                        Inventory monsterPartyInventory1 = new Inventory(monsterItems1);
                        Inventory monsterPartyInventory2 = new Inventory(monsterItems2);
                        Inventory monsterPartyInventory3 = new Inventory(monsterItems3);
                        Inventory monsterPartyinventory4 = new Inventory(monsterItems4);
                        PartyAttackModifierItemInventory monsters1 = new PartyAttackModifierItemInventory(monsterCharacters1, PartyType.Monsters, "monsters1", monsterPartyInventory1);
                        PartyAttackModifierItemInventory monsters2 = new PartyAttackModifierItemInventory(monsterCharacters2, PartyType.Monsters, "monsters2", monsterPartyInventory2);
                        PartyAttackModifierItemInventory monsters3 = new PartyAttackModifierItemInventory(monsterCharacters3, PartyType.Monsters, "monsters3", monsterPartyInventory3);
                        PartyAttackModifierItemInventory monsters4 = new PartyAttackModifierItemInventory(monsterCharacters4, PartyType.Monsters, "monsters4", monsterPartyinventory4);
                        List<PartyAttackModifierItemInventory> monsters = new List<PartyAttackModifierItemInventory> { monsters1, monsters2, monsters3, monsters4 };
                        Battle battle = new Battle(heroes, monsters, characters[0], PartyType.Heroes, playerList, playerList[0], heroes, strExpansions);
                        GameStart(battle);
                        break;
                    }
                // ..\\..\\..\\Expansions\\Games_Status.cs
                // ..\\..\\..\\Expansions\\Gear
                // ..\\..\\..\\Expansions\\Attack_Modifier
                case "025":
                // ..\\..\\..\\Expansions\\Games_Status.cs
                // ..\\..\\..\\Expansions\\Gear
                // ..\\..\\..\\Expansions\\Stolen_Inventory
                // ..\\..\\..\\Expansions\\Attack_Modifier
                case "0235":
                    {
                        // creates player list
                        List<Player> playerList = SetPlayers();
                        // creates hero character
                        CharacterAttackModifierGearInventory trueProgrammer = (CharacterAttackModifierGearInventory)CreateHeroCharacter(strExpansions, "trueProgrammer");
                        //CharacterAttackModifierGearInventory vinFletcher = (CharacterAttackModifierGearInventory)CreateHeroCharacter(strExpansions, "vinFletcher");
                        List<CharacterAttackModifierGearInventory> characters = new List<CharacterAttackModifierGearInventory> { trueProgrammer/*, vinFletcher*/ };
                        //List<CharacterAttackModifierGearinventory> characters = CreateHeroCharactersAttackModifier(strExpansions);
                        List<Weapon?> heroGear = new List<Weapon?>();
                        Inventory heroPartyInventory = new Inventory();
                        heroPartyInventory.Weapons = heroGear;
                        PartyAttackModifierGearInventory heroes = new PartyAttackModifierGearInventory(characters, PartyType.Heroes, "Heroes", heroPartyInventory);
                        List<CharacterAttackModifierGearInventory> monsterCharacters = CreateMonsterCharactersAttackModifierGearInventory(strExpansions);
                        List<CharacterAttackModifierGearInventory> monsterCharacters1 = new List<CharacterAttackModifierGearInventory> { monsterCharacters[0] };
                        List<CharacterAttackModifierGearInventory> monsterCharacters2 = new List<CharacterAttackModifierGearInventory> { monsterCharacters[1], monsterCharacters[2] };
                        List<CharacterAttackModifierGearInventory> monsterCharacters3 = new List<CharacterAttackModifierGearInventory> { monsterCharacters[3], monsterCharacters[4] };
                        List<CharacterAttackModifierGearInventory> monsterCharacters4 = new List<CharacterAttackModifierGearInventory> { monsterCharacters[5] };
                        List<Weapon?> monsterGear1 = new List<Weapon?>();
                        Inventory monsterPartyInventory1 = new Inventory(monsterGear1);
                        AvailableAction stab = new AvailableAction("stab", 1, 1, ActionTypes.GEAR_ATTACK);
                        Weapon dagger2 = new Weapon(GearTypes.WEAPON, "dagger2", WeaponTypes.DAGGER, 1, 1, stab, "dagger2");
                        Weapon dagger3 = new Weapon(GearTypes.WEAPON, "dagger3", WeaponTypes.DAGGER, 1, 1, stab, "dagger3");
                        List<Weapon?> monsterGear2 = new List<Weapon?>();
                        monsterGear2.Add(dagger2);
                        monsterGear2.Add(dagger3);
                        Inventory monsterPartyInventory2 = new Inventory(monsterGear2);
                        List<Weapon?> monsterGear3 = new List<Weapon?>();
                        Inventory monsterPartyInventory3 = new Inventory(monsterGear3);
                        List<Weapon?> monstergear4 = new List<Weapon?>();
                        Inventory monsterPartyinventory4 = new Inventory(monstergear4);
                        PartyAttackModifierGearInventory monsters1 = new PartyAttackModifierGearInventory(monsterCharacters1, PartyType.Monsters, "monsters1", monsterPartyInventory1);
                        PartyAttackModifierGearInventory monsters2 = new PartyAttackModifierGearInventory(monsterCharacters2, PartyType.Monsters, "monsters2", monsterPartyInventory2);
                        PartyAttackModifierGearInventory monsters3 = new PartyAttackModifierGearInventory(monsterCharacters3, PartyType.Monsters, "monsters3", monsterPartyInventory3);
                        PartyAttackModifierGearInventory monsters4 = new PartyAttackModifierGearInventory(monsterCharacters4, PartyType.Monsters, "monsters4", monsterPartyinventory4);
                        List<PartyAttackModifierGearInventory> monsters = new List<PartyAttackModifierGearInventory> { monsters1, monsters2, monsters3, monsters4 };
                        Battle battle = new Battle(heroes, monsters, trueProgrammer, PartyType.Heroes, playerList, playerList[0], heroes, strExpansions);
                        GameStart(battle);
                        break;
                    }
                // ..\\..\\..\\Expansions\\Game_Status.cs
                // ..\\..\\..\\Expansions\\Items
                // ..\\..\\..\\Expansions\\Gear
                // ..\\..\\..\\Expansions\\Attack_Modifiers
                case "0125":
                // ..\\..\\..\\Expansions\\Games_Status.cs
                // ..\\..\\..\\Expansions\\Items
                // ..\\..\\..\\Expansions\\Gear
                // ..\\..\\..\\Expansions\\Stolen_inventory
                // ..\\..\\..\\Expansions\\Attack_Modifiers
                case "01235":
                    {
                        // creates player list
                        List<Player> playerList = SetPlayers();
                        // creates hero character
                        CharacterAttackModifierGearInventory trueProgrammer = (CharacterAttackModifierGearInventory)CreateHeroCharacter(strExpansions, "trueProgrammer");
                        List<CharacterAttackModifierGearInventory> characters = new List<CharacterAttackModifierGearInventory> { trueProgrammer };
                        List<Weapon?> heroGear = new List<Weapon?>();
                        Inventory heroPartyInventory = new Inventory();
                        heroPartyInventory.Weapons = heroGear;
                        heroPartyInventory.Potions = GetHeroPartyItems();
                        PartyAttackModifierGearInventory heroes = new PartyAttackModifierGearInventory(characters, PartyType.Heroes, "Heroes", heroPartyInventory);
                        List<CharacterAttackModifierGearInventory> monsterCharacters = CreateMonsterCharactersAttackModifierGearInventory(strExpansions);
                        List<CharacterAttackModifierGearInventory> monsterCharacters1 = new List<CharacterAttackModifierGearInventory> { monsterCharacters[0] };
                        List<CharacterAttackModifierGearInventory> monsterCharacters2 = new List<CharacterAttackModifierGearInventory> { monsterCharacters[1], monsterCharacters[2] };
                        List<CharacterAttackModifierGearInventory> monsterCharacters3 = new List<CharacterAttackModifierGearInventory> { monsterCharacters[3], monsterCharacters[4] };
                        List<CharacterAttackModifierGearInventory> monsterCharacters4 = new List<CharacterAttackModifierGearInventory> { monsterCharacters[5] };
                        List<Potion?> monsterItems1 = new List<Potion?> { GetHealing10HPPotion() };
                        List<Weapon?> monsterGear1 = new List<Weapon?>();
                        Inventory monsterPartyInventory1 = new Inventory();
                        monsterPartyInventory1.Potions = monsterItems1;
                        monsterPartyInventory1.Weapons = monsterGear1;
                        List<Potion?> monsterItems2 = new List<Potion?> { GetHealing10HPPotion() };
                        AvailableAction stab = new AvailableAction("stab", 1, 1, ActionTypes.GEAR_ATTACK);
                        Weapon dagger2 = new Weapon(GearTypes.WEAPON, "dagger2", WeaponTypes.DAGGER, 1, 1, stab, "dagger2");
                        Weapon dagger3 = new Weapon(GearTypes.WEAPON, "dagger3", WeaponTypes.DAGGER, 1, 1, stab, "dagger3");
                        List<Weapon?> monsterGear2 = new List<Weapon?>();
                        monsterGear2.Add(dagger2);
                        monsterGear2.Add(dagger3);
                        Inventory monsterPartyInventory2 = new Inventory();
                        monsterPartyInventory2.Potions = monsterItems2;
                        monsterPartyInventory2.Weapons = monsterGear2;
                        List<Potion?> monsterItems3 = new List<Potion?> { GetHealing10HPPotion() };
                        List<Weapon?> monsterGear3 = new List<Weapon?>();
                        Inventory monsterPartyInventory3 = new Inventory();
                        monsterPartyInventory3.Potions = monsterItems3;
                        monsterPartyInventory3.Weapons = monsterGear3;
                        List<Potion?> monsterItems4 = new List<Potion?> { GetHealing10HPPotion() };
                        List<Weapon?> monsterGear4 = new List<Weapon?>();
                        Inventory monsterPartyInventory4 = new Inventory();
                        monsterPartyInventory4.Potions = monsterItems4;
                        monsterPartyInventory4.Weapons = monsterGear4;
                        PartyAttackModifierGearInventory monsters1 = new PartyAttackModifierGearInventory(monsterCharacters1, PartyType.Monsters, "monsters1", monsterPartyInventory1);
                        PartyAttackModifierGearInventory monsters2 = new PartyAttackModifierGearInventory(monsterCharacters2, PartyType.Monsters, "monsters2", monsterPartyInventory2);
                        PartyAttackModifierGearInventory monsters3 = new PartyAttackModifierGearInventory(monsterCharacters3, PartyType.Monsters, "monsters3", monsterPartyInventory3);
                        PartyAttackModifierGearInventory monsters4 = new PartyAttackModifierGearInventory(monsterCharacters4, PartyType.Monsters, "monsters4", monsterPartyInventory4);
                        List<PartyAttackModifierGearInventory> monsters = new List<PartyAttackModifierGearInventory> { monsters1, monsters2, monsters3, monsters4 };
                        Battle battle = new Battle(heroes, monsters, trueProgrammer, PartyType.Heroes, playerList, playerList[0], heroes, strExpansions);
                        GameStart(battle);
                        break;
                    }
                // ..\\..\\..\\Expansions\\Games_Status.cs
                // ..\\..\\..\\Expansions\\Vin_Fletcher
                // ..\\..\\..\\Expansions\\Attack_Modifiers
                case "045":
                    {
                        // creates player list
                        List<Player> playerList = SetPlayers();
                        // creates hero character
                        List<CharacterAttackModifierHitChance> characters = CreateHeroCharactersAttackModifierHitChance(strExpansions);
                        Party heroes = new Party(characters, PartyType.Heroes, "heroes");
                        List<CharacterAttackModifierHitChance> monsterCharacters = CreateMonsterCharactersAttackModifiersHitChance(strExpansions);
                        List<CharacterAttackModifierHitChance> monsterCharacters1 = new List<CharacterAttackModifierHitChance> { monsterCharacters[0] };
                        List<CharacterAttackModifierHitChance> monsterCharacters2 = new List<CharacterAttackModifierHitChance> { monsterCharacters[1], monsterCharacters[2] };
                        List<CharacterAttackModifierHitChance> monsterCharacters3 = new List<CharacterAttackModifierHitChance> { monsterCharacters[3], monsterCharacters[4] };
                        List<CharacterAttackModifierHitChance> monsterCharacters4 = new List<CharacterAttackModifierHitChance> { monsterCharacters[5] };
                        Party monsters1 = new Party(monsterCharacters1, PartyType.Monsters, "monsters1");
                        Party monsters2 = new Party(monsterCharacters2, PartyType.Monsters, "monsters2");
                        Party monsters3 = new Party(monsterCharacters3, PartyType.Monsters, "monsters3");
                        Party monsters4 = new Party(monsterCharacters4, PartyType.Monsters, "monsters4");
                        List<Party> monsters = new List<Party> { monsters1, monsters2, monsters3, monsters4 };
                        Battle battle = new Battle(heroes, monsters, characters[0], PartyType.Heroes, playerList, playerList[0], heroes, strExpansions);
                        GameStart(battle);
                        break;
                    }
                // ..\\..\\..\\Expansions\\Games_Status.cs
                // ..\\..\\..\\Expansions\\Items
                // ..\\..\\..\\Expansions\\Vin_Fletcher
                // ..\\..\\..\\Expansions\\Attack_Modifiers
                case "0145":
                // ..\\..\\..\\Expansions\\Games_Status.cs
                // ..\\..\\..\\Expansions\\Items
                // ..\\..\\..\\Expansions\\Stolen_Inventory
                // ..\\..\\..\\Expansions\\Vin_Fletcher
                // ..\\..\\..\\Expansions\\AttackModifiers
                case "01345":
                    {
                        // creates player list
                        List<Player> playerList = SetPlayers();
                        // creates hero character
                        List<CharacterAttackModifierHitChance> characters = CreateHeroCharactersAttackModifierHitChance(strExpansions);
                        List<Potion?> heroItems = GetHeroPartyItems();
                        Inventory heroPartyInventory = new Inventory(heroItems);
                        PartyItemInventoryHitChance heroes = new PartyItemInventoryHitChance(characters, PartyType.Heroes, "Heroes", heroPartyInventory);
                        List<CharacterAttackModifierHitChance> monsterCharacters = CreateMonsterCharactersAttackModifiersHitChance(strExpansions);
                        List<CharacterAttackModifierHitChance> monsterCharacters1 = new List<CharacterAttackModifierHitChance> { monsterCharacters[0] };
                        List<CharacterAttackModifierHitChance> monsterCharacters2 = new List<CharacterAttackModifierHitChance> { monsterCharacters[1], monsterCharacters[2] };
                        List<CharacterAttackModifierHitChance> monsterCharacters3 = new List<CharacterAttackModifierHitChance> { monsterCharacters[3], monsterCharacters[4] };
                        List<CharacterAttackModifierHitChance> monsterCharacters4 = new List<CharacterAttackModifierHitChance> { monsterCharacters[5] };
                        List<Potion?> monsterItems1 = new List<Potion?> { GetHealing10HPPotion() };
                        List<Potion?> monsterItems2 = new List<Potion?> { GetHealing10HPPotion() };
                        List<Potion?> monsterItems3 = new List<Potion?> { GetHealing10HPPotion() };
                        List<Potion?> monsterItems4 = new List<Potion?> { GetHealing10HPPotion() };
                        Inventory monsterPartyInventory1 = new Inventory(monsterItems1);
                        Inventory monsterPartyInventory2 = new Inventory(monsterItems2);
                        Inventory monsterPartyInventory3 = new Inventory(monsterItems3);
                        Inventory monsterPartyInventory4 = new Inventory(monsterItems4);
                        PartyItemInventoryHitChance monsters1 = new PartyItemInventoryHitChance(monsterCharacters1, PartyType.Monsters, "monsters1", monsterPartyInventory1);
                        PartyItemInventoryHitChance monsters2 = new PartyItemInventoryHitChance(monsterCharacters2, PartyType.Monsters, "monsters1", monsterPartyInventory2);
                        PartyItemInventoryHitChance monsters3 = new PartyItemInventoryHitChance(monsterCharacters3, PartyType.Monsters, "monsters1", monsterPartyInventory3);
                        PartyItemInventoryHitChance monsters4 = new PartyItemInventoryHitChance(monsterCharacters4, PartyType.Monsters, "monsters4", monsterPartyInventory4);
                        List<PartyItemInventoryHitChance> monsters = new List<PartyItemInventoryHitChance> { monsters1, monsters2, monsters3, monsters4 };
                        Battle battle = new Battle(heroes, monsters, characters[0], PartyType.Heroes, playerList, playerList[0], heroes, strExpansions);
                        GameStart(battle);
                        break;
                    }
                // ..\\..\\..\\Expansions\\Games_Status.cs
                default:
                    {
                        // creates player list
                        List<Player> playerList = SetPlayers();
                        // creates hero character
                        List<Character> characters = CreateHeroCharacters(strExpansions);
                        Party heroes = new Party(characters, PartyType.Heroes, "heroes");
                        List<Character> monsterCharacters = CreateMonsterCharacters(strExpansions);
                        List<Character> monsterCharacters1 = new List<Character> { monsterCharacters[0] };
                        List<Character> monsterCharacters2 = new List<Character> { monsterCharacters[1], monsterCharacters[2] };
                        List<Character> monsterCharacters3 = new List<Character> { monsterCharacters[3] };
                        Party monsters1 = new Party(monsterCharacters1, PartyType.Monsters, "monsters1");
                        Party monsters2 = new Party(monsterCharacters2, PartyType.Monsters, "monsters2");
                        Party monsters3 = new Party(monsterCharacters3, PartyType.Monsters, "monsters3");
                        List<Party> monsters = new List<Party> { monsters1, monsters2, monsters3 };
                        Battle battle = new Battle(heroes, monsters, characters[0], PartyType.Heroes, playerList, playerList[0], heroes, strExpansions);
                        GameStart(battle);
                        break;
                    }
            }
        }

        private static List<CharacterAttackModifier> CreateMonsterCharactersAttackModifiers(string strExpansions)
        {
            int skeletonID = 1, stoneAmarokID = 1;
            CharacterAttackModifier skeleton1 = (CharacterAttackModifier)CreateSkeletonMonsterCharacter(skeletonID, strExpansions);
            skeletonID++;
            List<CharacterAttackModifier> monsterCharacters = new List<CharacterAttackModifier>();
            monsterCharacters.Add(skeleton1);
            CharacterAttackModifier skeleton2 = (CharacterAttackModifier)CreateSkeletonMonsterCharacter(skeletonID, strExpansions);
            skeletonID++;
            CharacterAttackModifier skeleton3 = (CharacterAttackModifier)CreateSkeletonMonsterCharacter(skeletonID, strExpansions);
            skeletonID++;
            monsterCharacters.Add(skeleton2);
            monsterCharacters.Add(skeleton3);
            CharacterAttackModifier stoneAmarok1 = CreateStoneAmarokMonsterCharacter(stoneAmarokID, strExpansions);
            stoneAmarokID++;
            CharacterAttackModifier stoneAmarok2 = CreateStoneAmarokMonsterCharacter(stoneAmarokID, strExpansions);
            monsterCharacters.Add(stoneAmarok1);
            monsterCharacters.Add(stoneAmarok2);
            CharacterAttackModifier unCodedOne = (CharacterAttackModifier)CreateUnCodedOne(strExpansions);
            monsterCharacters.Add(unCodedOne);
            return monsterCharacters;
        }

        private static List<CharacterAttackModifierHitChance> CreateMonsterCharactersAttackModifiersHitChance(string strExpansions)
        {
            int skeletonID = 1, stoneAmarokID = 1;
            CharacterAttackModifierHitChance skeleton1 = (CharacterAttackModifierHitChance)CreateSkeletonMonsterCharacterHitChance(skeletonID, strExpansions);
            skeletonID++;
            List<CharacterAttackModifierHitChance> monsterCharacters = new List<CharacterAttackModifierHitChance>();
            monsterCharacters.Add(skeleton1);
            CharacterAttackModifierHitChance skeleton2 = (CharacterAttackModifierHitChance)CreateSkeletonMonsterCharacterHitChance(skeletonID, strExpansions);
            skeletonID++;
            CharacterAttackModifierHitChance skeleton3 = (CharacterAttackModifierHitChance)CreateSkeletonMonsterCharacterHitChance(skeletonID, strExpansions);
            skeletonID++;
            monsterCharacters.Add(skeleton2);
            monsterCharacters.Add(skeleton3);
            CharacterAttackModifierHitChance stoneAmarok1 = (CharacterAttackModifierHitChance)CreateStoneAmarokMonsterCharacterHitChance(stoneAmarokID, strExpansions);
            stoneAmarokID++;
            CharacterAttackModifierHitChance stoneAmarok2 = (CharacterAttackModifierHitChance)CreateStoneAmarokMonsterCharacterHitChance(stoneAmarokID, strExpansions);
            monsterCharacters.Add(stoneAmarok1);
            monsterCharacters.Add(stoneAmarok2);
            CharacterAttackModifierHitChance unCodedOne = (CharacterAttackModifierHitChance)CreateUnCodedOneHitChance(strExpansions);
            monsterCharacters.Add(unCodedOne);
            return monsterCharacters;
        }

        private static CharacterAttackModifierHitChance CreateStoneAmarokMonsterCharacterHitChance(int stoneAmarokID, string strExpansions)
        {
            List<AvailableActionHitChance> stoneAmarokCharacterActionTypes = new List<AvailableActionHitChance>();
            AvailableActionHitChance bite = new AvailableActionHitChance("BITE", 1, 1, ActionTypes.ATTACK, 0.5);
            AvailableActionHitChance nothing = new AvailableActionHitChance();
            stoneAmarokCharacterActionTypes.Insert(0, nothing);
            stoneAmarokCharacterActionTypes.Insert(1, bite);
            AttackModifierDefensive stoneArmor = new AttackModifierDefensive(AttackModifierType.DEFENSIVE, "STONE ARMOR", -1, AttackModifierDefensiveCategory.DAMAGE_REDUCTION);
            List<AttackModifierDefensive> stoneAmarokAttackModifiersDefensive = new List<AttackModifierDefensive> { stoneArmor };
            //AttackModifierOffensive emptyOffensive = new AttackModifierOffensive();
            List<AttackModifierOffensive> stoneAmarokAttackModifiersOffensive = new List<AttackModifierOffensive>();
            switch (strExpansions)
            {
                // items, vin fletcher and attack modifier expansions
                case "0145":
                // items, stolen inventory expansions, vin fletcher and attack modifier expansions
                case "01345":
                    {
                        stoneAmarokCharacterActionTypes = AddHeal10Action(2, stoneAmarokCharacterActionTypes);
                        CharacterAttackModifierHitChance stoneAmarok = new CharacterAttackModifierHitChance("STONE AMAROK", stoneAmarokCharacterActionTypes, 5, $"stoneAmarok{stoneAmarokID}", stoneAmarokAttackModifiersOffensive, stoneAmarokAttackModifiersDefensive);
                        return stoneAmarok;
                    }
            //    //// gear expansion
            //    //case "02":
            //    //// gear and stolen inventory expansions
            //    //case "023":
            //    //    {
            //    //        skeletonCharacterActionTypes = AddEquipAction(2, skeletonCharacterActionTypes);
            //    //        Inventory monsterCharacterInventory = EmptyWeaponInventory();
            //    //        CharacterGearInventory skeleton = new CharacterGearInventory("SKELETON", skeletonCharacterActionTypes, 5, $"skeleton{skeletonID}", monsterCharacterInventory);
            //    //        return skeleton;
            //    //    }
            //    //// gear and items expansions
            //    //case "012":
            //    //// gear, items and stolen inventory expansions
            //    //case "0123":
            //    //    {
            //    //        skeletonCharacterActionTypes = AddHeal10Action(2, skeletonCharacterActionTypes);
            //    //        skeletonCharacterActionTypes = AddEquipAction(3, skeletonCharacterActionTypes);
            //    //        Inventory monsterCharacterInventory = EmptyWeaponInventory();
            //    //        CharacterGearInventory skeleton = new CharacterGearInventory("SKELETON", skeletonCharacterActionTypes, 5, $"skeleton{skeletonID}", monsterCharacterInventory);
            //    //        return skeleton;
            //    //    }
                // game's status expansion
                // attack modifiers expansion
                default:
                    {
                        CharacterAttackModifierHitChance stoneAmarok = new CharacterAttackModifierHitChance("STONE AMAROK", stoneAmarokCharacterActionTypes, 4, $"stoneAmarok{stoneAmarokID}", stoneAmarokAttackModifiersOffensive, stoneAmarokAttackModifiersDefensive);
                        return stoneAmarok;
                    }
            }
        }

        private static CharacterAttackModifierGearInventory CreateStoneAmarokMonsterCharacterGearinventory(int stoneAmarokID, string strExpansions)
        {
            List<AvailableAction> stoneAmarokCharacterActionTypes = new List<AvailableAction>();
            AvailableAction bite = new AvailableAction("BITE", 1, 1, ActionTypes.ATTACK);
            AvailableAction nothing = new AvailableAction();
            stoneAmarokCharacterActionTypes.Insert(0, nothing);
            stoneAmarokCharacterActionTypes.Insert(1, bite);
            AttackModifierDefensive stoneArmor = new AttackModifierDefensive(AttackModifierType.DEFENSIVE, "STONE ARMOR", -1, AttackModifierDefensiveCategory.DAMAGE_REDUCTION);
            List<AttackModifierDefensive> stoneAmarokAttackModifiersDefensive = new List<AttackModifierDefensive> { stoneArmor };
            //AttackModifierOffensive emptyOffensive = new AttackModifierOffensive();
            List<AttackModifierOffensive> stoneAmarokAttackModifiersOffensive = new List<AttackModifierOffensive>();
            switch (strExpansions)
            {
                //// items and attack modifier expansions
                //case "015":
                //// items, stolen inventory expansions and attack modifier expansions
                //case "0135":
                //    {
                //        stoneAmarokCharacterActionTypes = AddHeal10Action(2, stoneAmarokCharacterActionTypes);
                //        CharacterAttackModifier stoneAmarok = new CharacterAttackModifier("STONE AMAROK", stoneAmarokCharacterActionTypes, 5, $"stoneAmarok{stoneAmarokID}", stoneAmarokAttackModifiersOffensive, stoneAmarokAttackModifiersDefensive);
                //        return stoneAmarok;
                //    }
                // gear, items and attack modifiers expansions
                case "0125":
                // gear, items, stolen inventory and attack modifiers expansions
                case "01235":
                    {
                        stoneAmarokCharacterActionTypes = AddHeal10Action(2, stoneAmarokCharacterActionTypes);
                        stoneAmarokCharacterActionTypes = AddEquipAction(3, stoneAmarokCharacterActionTypes);
                        Inventory monsterCharacterInventory = EmptyWeaponInventory();
                        CharacterAttackModifierGearInventory skeleton = new CharacterAttackModifierGearInventory("STONE AMAROK", stoneAmarokCharacterActionTypes, 5, $"stoneAmarok{stoneAmarokID}", monsterCharacterInventory, stoneAmarokAttackModifiersOffensive, stoneAmarokAttackModifiersDefensive);
                        return skeleton;
                    }
                // gear and attack modifiers expansions 
                //case "025":
                // gear, stolen inventory  and attack modifiers expansions
                //case "023":
                default:
                    {

                        stoneAmarokCharacterActionTypes = AddEquipAction(2, stoneAmarokCharacterActionTypes);
                        Inventory monsterCharacterInventory = EmptyWeaponInventory();
                        CharacterAttackModifierGearInventory stoneAmarok = new CharacterAttackModifierGearInventory("STONE AMAROK", stoneAmarokCharacterActionTypes, 5, $"stoneAmarok{stoneAmarokID}", monsterCharacterInventory, stoneAmarokAttackModifiersOffensive, stoneAmarokAttackModifiersDefensive);
                        return stoneAmarok;
                    }
            //    // game's status expansion
            //    // attack modifiers expansion
            //    //default:
            //    //    {
            //    //        CharacterAttackModifier stoneAmarok = new CharacterAttackModifier("STONE AMAROK", stoneAmarokCharacterActionTypes, 4, $"stoneAmarok{stoneAmarokID}", stoneAmarokAttackModifiersOffensive, stoneAmarokAttackModifiersDefensive);
            //    //        return stoneAmarok;
            //    //    }
            }
        }
        private static CharacterAttackModifier CreateStoneAmarokMonsterCharacter(int stoneAmarokID, string strExpansions)
        {
            List<AvailableAction> stoneAmarokCharacterActionTypes = new List<AvailableAction>();
            AvailableAction bite = new AvailableAction("BITE", 1, 1, ActionTypes.ATTACK);
            AvailableAction nothing = new AvailableAction();
            stoneAmarokCharacterActionTypes.Insert(0, nothing);
            stoneAmarokCharacterActionTypes.Insert(1, bite);
            AttackModifierDefensive stoneArmor = new AttackModifierDefensive(AttackModifierType.DEFENSIVE, "STONE ARMOR", -1, AttackModifierDefensiveCategory.DAMAGE_REDUCTION);
            List<AttackModifierDefensive> stoneAmarokAttackModifiersDefensive = new List<AttackModifierDefensive> { stoneArmor };
            //AttackModifierOffensive emptyOffensive = new AttackModifierOffensive();
            List<AttackModifierOffensive> stoneAmarokAttackModifiersOffensive = new List<AttackModifierOffensive>();
            switch (strExpansions)
            {
                // items and attack modifier expansions
                case "015":
                // items, stolen inventory expansions and attack modifier expansions
                case "0135":
                    {
                        stoneAmarokCharacterActionTypes = AddHeal10Action(2, stoneAmarokCharacterActionTypes);
                        CharacterAttackModifier stoneAmarok = new CharacterAttackModifier("STONE AMAROK", stoneAmarokCharacterActionTypes, 5, $"stoneAmarok{stoneAmarokID}", stoneAmarokAttackModifiersOffensive, stoneAmarokAttackModifiersDefensive);
                        return stoneAmarok;
                    }
                //// gear expansion
                //case "02":
                //// gear and stolen inventory expansions
                //case "023":
                //    {
                //        skeletonCharacterActionTypes = AddEquipAction(2, skeletonCharacterActionTypes);
                //        Inventory monsterCharacterInventory = EmptyWeaponInventory();
                //        CharacterGearInventory skeleton = new CharacterGearInventory("SKELETON", skeletonCharacterActionTypes, 5, $"skeleton{skeletonID}", monsterCharacterInventory);
                //        return skeleton;
                //    }
                //// gear and items expansions
                //case "012":
                //// gear, items and stolen inventory expansions
                //case "0123":
                //    {
                //        skeletonCharacterActionTypes = AddHeal10Action(2, skeletonCharacterActionTypes);
                //        skeletonCharacterActionTypes = AddEquipAction(3, skeletonCharacterActionTypes);
                //        Inventory monsterCharacterInventory = EmptyWeaponInventory();
                //        CharacterGearInventory skeleton = new CharacterGearInventory("SKELETON", skeletonCharacterActionTypes, 5, $"skeleton{skeletonID}", monsterCharacterInventory);
                //        return skeleton;
                //    }
                // game's status expansion
                // attack modifiers expansion
                default:
                    {
                        CharacterAttackModifier stoneAmarok = new CharacterAttackModifier("STONE AMAROK", stoneAmarokCharacterActionTypes, 4, $"stoneAmarok{stoneAmarokID}", stoneAmarokAttackModifiersOffensive, stoneAmarokAttackModifiersDefensive);
                        return stoneAmarok;
                    }
            }
        }

        private static List<CharacterAttackModifier> CreateHeroCharactersAttackModifier(string strExpansions)
        {
            List<CharacterAttackModifier> characters = new List<CharacterAttackModifier>();
            CharacterAttackModifier trueProgrammer = (CharacterAttackModifier)CreateHeroCharacter(strExpansions, "trueProgrammer");
            characters.Insert(0, trueProgrammer);
            return characters;
        }

        private static List<CharacterAttackModifierHitChance> CreateHeroCharactersAttackModifierHitChance(string strExpansions)
        {
            List<CharacterAttackModifierHitChance> characters = new List<CharacterAttackModifierHitChance>();
            CharacterAttackModifierHitChance trueProgrammer = (CharacterAttackModifierHitChance)CreateHeroCharacterHitChance(strExpansions, "trueProgrammer");
            characters.Add(trueProgrammer);
            CharacterAttackModifierHitChance vinFletcher = (CharacterAttackModifierHitChance)CreateHeroCharacterHitChance(strExpansions, "vinFletcher");
            characters.Add(vinFletcher);
            return characters;
        }

        private static List<CharacterGearInventoryHitChance> CreateMonsterCharactersGearInventoryHitChance(string strExpansions)
        {
            int skeletonID = 1;
            CharacterGearInventoryHitChance skeleton1 = (CharacterGearInventoryHitChance)CreateSkeletonMonsterCharacterHitChance(skeletonID, strExpansions);
            AvailableActionHitChance stab = new AvailableActionHitChance("STAB", 1, 1, ActionTypes.GEAR_ATTACK, 0.5);
            WeaponHitChance dagger1 = new WeaponHitChance(GearTypes.WEAPON, $"dagger{skeletonID}", WeaponTypes.DAGGER, 1, 1, stab, $"dagger{skeletonID}", 0.5);
            List<WeaponHitChance> monsterWeapons = new List<WeaponHitChance> { dagger1 };
            skeleton1.CharacterInventory.WeaponHitChances.Add(dagger1);
            skeleton1.AvailableActionHitChances.Insert(3, skeleton1.CharacterInventory.WeaponHitChances[0].AvailableActionHitChance);
            skeletonID++;
            List<CharacterGearInventoryHitChance> monsterCharacters = new List<CharacterGearInventoryHitChance>();
            monsterCharacters.Add(skeleton1);
            CharacterGearInventoryHitChance skeleton2 = (CharacterGearInventoryHitChance)CreateSkeletonMonsterCharacterHitChance(skeletonID, strExpansions);
            skeletonID++;
            CharacterGearInventoryHitChance skeleton3 = (CharacterGearInventoryHitChance)CreateSkeletonMonsterCharacterHitChance(skeletonID, strExpansions);
            skeletonID++;
            monsterCharacters.Add(skeleton2);
            monsterCharacters.Add(skeleton3);
            CharacterGearInventoryHitChance unCodedOne = (CharacterGearInventoryHitChance)CreateUnCodedOneHitChance(strExpansions);
            monsterCharacters.Add(unCodedOne);
            return monsterCharacters;
        }

        private static List<CharacterHitChance> CreateMonsterCharactersHitChance(string strExpansions)
        {
            int skeletonID = 1;
            CharacterHitChance skeleton1 = CreateSkeletonMonsterCharacterHitChance(skeletonID, strExpansions);
            skeletonID++;
            List<CharacterHitChance> monsterCharacters = new List<CharacterHitChance>();
            monsterCharacters.Add(skeleton1);
            CharacterHitChance skeleton2 = CreateSkeletonMonsterCharacterHitChance(skeletonID, strExpansions);
            skeletonID++;
            CharacterHitChance skeleton3 = CreateSkeletonMonsterCharacterHitChance(skeletonID, strExpansions);
            skeletonID++;
            monsterCharacters.Add(skeleton2);
            monsterCharacters.Add(skeleton3);
            CharacterHitChance unCodedOne = CreateUnCodedOneHitChance(strExpansions);
            monsterCharacters.Add(unCodedOne);
            return monsterCharacters;
        }

        private static CharacterHitChance CreateUnCodedOneHitChance(string strExpansions)
        {
            List<AvailableActionHitChance> unCodedOneCharacterActionTypes = new List<AvailableActionHitChance>();
            AvailableActionHitChance unraveling = new AvailableActionHitChance("UNRAVELING", 0, 2, ActionTypes.ATTACK, 0.5);
            AvailableActionHitChance nothing = new AvailableActionHitChance(/*null*/);
            unCodedOneCharacterActionTypes.Add(nothing);
            unCodedOneCharacterActionTypes.Add(unraveling);
            List<AttackModifierOffensive> attackModifiersOffensive = new List<AttackModifierOffensive>();
            List<AttackModifierDefensive> attackModifiersDefensive = new List<AttackModifierDefensive>();
            switch (strExpansions)
            {
                // items and vin fletcher expansions
                case "014":
                // items, stolen inventory and vin fletcher expansions
                case "0134":
                    {
                        unCodedOneCharacterActionTypes = AddHeal10Action(2, unCodedOneCharacterActionTypes);
                        CharacterHitChance unCodedOne = new CharacterHitChance("THE UNCODED ONE", unCodedOneCharacterActionTypes, 15, "unCodedOne");
                        return unCodedOne;
                    }
                // gear and vin fletcher expansions
                case "024":
                // gear, stolen inventory and vin fletcher expansions
                case "0234":
                    {
                        unCodedOneCharacterActionTypes = AddEquipAction(2, unCodedOneCharacterActionTypes);
                        Inventory unCodedOneInventory = EmptyWeaponInventoryHitChance();
                        CharacterGearInventoryHitChance unCodedOne = new CharacterGearInventoryHitChance("THE UNCODED ONE", unCodedOneCharacterActionTypes, 15, "unCodedOne", unCodedOneInventory);
                        return unCodedOne;
                    }
                // gear, items and vin fletcher expansions
                case "0124":
                // gear, items, stolen inventory and vin fletcher expansions
                case "01234":
                    {
                        unCodedOneCharacterActionTypes = AddHeal10Action(2, unCodedOneCharacterActionTypes);
                        unCodedOneCharacterActionTypes = AddEquipAction(3, unCodedOneCharacterActionTypes);
                        Inventory unCodedOneInventory = EmptyWeaponInventoryHitChance();
                        CharacterGearInventoryHitChance unCodedOne = new CharacterGearInventoryHitChance("THE UNCODED ONE", unCodedOneCharacterActionTypes, 15, "unCodedOne", unCodedOneInventory);
                        return unCodedOne;
                    }
                // vin fletcher and attack modifiers expansions
                case "045":
                    {
                        CharacterAttackModifierHitChance unCodedOne = new CharacterAttackModifierHitChance("THE UNCODED ONE", unCodedOneCharacterActionTypes, 15, "unCodedOne", attackModifiersOffensive, attackModifiersDefensive);
                        return unCodedOne;
                    }
                // items, in fletcher and attack modifiers expansions
                case "0145":
                // items, stolen inventory, vin fletcher and attack modifiers expansions
                case "01345":
                    {
                        unCodedOneCharacterActionTypes = AddHeal10Action(2, unCodedOneCharacterActionTypes);
                        CharacterAttackModifierHitChance unCodedOne = new CharacterAttackModifierHitChance("THE UNCODED ONE", unCodedOneCharacterActionTypes, 15, "unCodedOne", attackModifiersOffensive, attackModifiersDefensive);
                        return unCodedOne;
                    }
                // game's status expansion
                // vin fletcher expansion
                default:
                    {
                        CharacterHitChance unCodedOne = new CharacterHitChance("THE UNCODED ONE", unCodedOneCharacterActionTypes, 15, "unCodedOne");
                        return unCodedOne;
                    }
            }
        }

        private static CharacterHitChance CreateSkeletonMonsterCharacterHitChance(int skeletonID, string strExpansions)
        {
            List<AvailableActionHitChance> skeletonCharacterActionTypes = new List<AvailableActionHitChance>();
            AvailableActionHitChance boneCrunch = new AvailableActionHitChance("BONE CRUNCH", 0, 1, ActionTypes.ATTACK, 0.5);
            AvailableActionHitChance nothing = new AvailableActionHitChance(/*null*/);
            skeletonCharacterActionTypes.Insert(0, nothing);
            skeletonCharacterActionTypes.Insert(1, boneCrunch);
            List<AttackModifierOffensive> attackModifiersOffensive = new List<AttackModifierOffensive>();
            List<AttackModifierDefensive> attackModifiersDefensive = new List<AttackModifierDefensive>();
            switch (strExpansions)
            {
                // items and vin fletcher expansions
                case "014":
                // items, stolen inventory and vin fletcher expansions
                case "0134":
                    {
                        skeletonCharacterActionTypes = AddHeal10Action(2, skeletonCharacterActionTypes);
                        CharacterHitChance skeleton = new CharacterHitChance("SKELETON", skeletonCharacterActionTypes, 5, $"skeleton{skeletonID}");
                        return skeleton;
                    }
                // gear and vin fletcher expansions
                case "024":
                // gear, stolen inventory and vin fletcher expansions
                case "0234":
                    {
                        skeletonCharacterActionTypes = AddEquipAction(2, skeletonCharacterActionTypes);
                        Inventory monsterCharacterInventory = EmptyWeaponInventoryHitChance();
                        CharacterGearInventoryHitChance skeleton = new CharacterGearInventoryHitChance("SKELETON", skeletonCharacterActionTypes, 5, $"skeleton{skeletonID}", monsterCharacterInventory);
                        return skeleton;
                    }
                // gear, items and vin fletcher expansions
                case "0124":
                // gear, items, stolen inventory and vin fletcher expansions
                case "01234":
                    {
                        skeletonCharacterActionTypes = AddHeal10Action(2, skeletonCharacterActionTypes);
                        skeletonCharacterActionTypes = AddEquipAction(3, skeletonCharacterActionTypes);
                        Inventory monsterCharacterInventory = EmptyWeaponInventoryHitChance();
                        CharacterGearInventoryHitChance skeleton = new CharacterGearInventoryHitChance("SKELETON", skeletonCharacterActionTypes, 5, $"skeleton{skeletonID}", monsterCharacterInventory);
                        return skeleton;
                    }
                // game's status expansion
                // vin fletcher expansion
                case "045":
                    {
                        CharacterAttackModifierHitChance skeleton = new CharacterAttackModifierHitChance("SKELETON", skeletonCharacterActionTypes, 5, $"skeleton{skeletonID}", attackModifiersOffensive, attackModifiersDefensive);
                        return skeleton;
                    }
                // items, vin fletcher and attack modifiers expansions
                case "0145":
                // items, stolen inventory, vin fletcher and attack modifiers expansions
                case "01345":
                    {
                        skeletonCharacterActionTypes = AddHeal10Action(2, skeletonCharacterActionTypes);
                        CharacterAttackModifierHitChance skeleton = new CharacterAttackModifierHitChance("SKELETON", skeletonCharacterActionTypes, 5, $"skeleton{skeletonID}", attackModifiersOffensive, attackModifiersDefensive);
                        return skeleton;
                    }
                // game's status expansion
                // vin fletcher expansion
                default:
                    {
                        CharacterHitChance skeleton = new CharacterHitChance("SKELETON", skeletonCharacterActionTypes, 5, $"skeleton{skeletonID}");
                        return skeleton;
                    }
            }
        }

        private static Inventory EmptyWeaponInventoryHitChance()
        {
            List<WeaponHitChance> weapons = new List<WeaponHitChance>();
            Inventory inventory = new Inventory();
            inventory.WeaponHitChances = weapons;
            return inventory;
        }

        private static void GameStart(Battle battle)
        {
            object obj = battle;
            Thread thread = new Thread(Combat);
            thread.Start(obj);
            thread.Join();
        }

        private static List<CharacterHitChance> CreateHeroCharactersHitChance(string strExpansions)
        {
            List<CharacterHitChance> characters = new List<CharacterHitChance>();
            switch (strExpansions)
            {
                case "04":
                case "014":
                case "0134":
                    {
                        CharacterHitChance vinFletcher = (CharacterHitChance)CreateHeroCharacterHitChance(strExpansions, "vinFletcher");
                        characters.Add(vinFletcher);
                        break;
                    }
                default:
                    break;
            }
            CharacterHitChance trueProgrammer = (CharacterHitChance)CreateHeroCharacterHitChance(strExpansions, "trueProgrammer");
            characters.Insert(0, trueProgrammer);
            return characters;
        }

        private static List<CharacterGearInventoryHitChance> CreateHeroCharacterHitChanceGearInventory(string strExpansions, string characterID)
        {
            List<CharacterGearInventoryHitChance> characters = new List<CharacterGearInventoryHitChance>();
            switch (strExpansions)
            {
                case "04":
                case "014":
                case "0134":
                    {
                        CharacterGearInventoryHitChance vinFletcher = (CharacterGearInventoryHitChance)CreateHeroCharacterHitChance(strExpansions, "vinFletcher");
                        characters.Add(vinFletcher);
                        break;
                    }
                default:
                    break;
            }
            CharacterGearInventoryHitChance trueProgrammer = (CharacterGearInventoryHitChance)CreateHeroCharacterHitChance(strExpansions, "trueProgrammer");
            characters.Insert(0, trueProgrammer);
            return characters;
        }

        private static Character CreateHeroCharacterHitChance(string strExpansions, string characterID)
        {
            List<AvailableActionHitChance> heroCharacterActionTypesHitChance = new List<AvailableActionHitChance>();
            AvailableActionHitChance nothing = new AvailableActionHitChance(/*null*/);
            AvailableActionHitChance punch = new AvailableActionHitChance("PUNCH", 1, 1, ActionTypes.ATTACK, 0.5);
            heroCharacterActionTypesHitChance.Insert(0, nothing);
            heroCharacterActionTypesHitChance.Insert(1, punch);
            AttackModifierOffensive powerAttack = new AttackModifierOffensive(AttackModifierType.OFFENSIVE, "POWER ATTACK", 1, AttackModifierOffensiveCategory.DR_OVERRIDE, 0.5);
            List<AttackModifierOffensive> attackModifiersOffensive = new List<AttackModifierOffensive>();
            List<AttackModifierDefensive> attackModifiersDefensive = new List<AttackModifierDefensive>();
            string name = "";
            if (characterID.Equals("trueProgrammer"))
            {
                Console.WriteLine("Please enter the True Programmer's name.");
                name = Console.ReadLine().ToUpper();
            }
            else if (characterID.Equals("vinFletcher"))
            {
                name = "Vin Fletcher";
            }
            string characterType = "hero";
            switch (strExpansions)
            {
                // items and vin fletcher expansions
                case "014":
                // items, stolen inventory and vin fletcher expansions
                case "0134":
                    {
                        if (characterID.Equals("vinFletcher"))
                        {
                            heroCharacterActionTypesHitChance = AddQuickShotAttack(1, heroCharacterActionTypesHitChance);
                            heroCharacterActionTypesHitChance = AddHeal10Action(2, heroCharacterActionTypesHitChance);
                            CharacterHitChance vinFletcher = new CharacterHitChance(name, heroCharacterActionTypesHitChance, 15, characterID);
                            return vinFletcher;
                        }
                        else
                        {
                            heroCharacterActionTypesHitChance = AddHeal10Action(2, heroCharacterActionTypesHitChance);
                            CharacterHitChance trueProgrammer = new CharacterHitChance(name, heroCharacterActionTypesHitChance, 25, characterID);
                            return trueProgrammer;
                        }
                    }
                // gear and vin fletcher expansions
                case "024":
                // gear, stolen inventory and vin fletcher expansions
                case "0234":
                    {
                        heroCharacterActionTypesHitChance = AddEquipAction(2, heroCharacterActionTypesHitChance);
                        Inventory heroCharacterInventory = new Inventory();
                        List<object> heroWeaponAndActionHitChance = AddHeroWeaponAndAction(3, heroCharacterActionTypesHitChance, heroCharacterInventory, characterID, strExpansions);
                        heroCharacterActionTypesHitChance = (List<AvailableActionHitChance>)heroWeaponAndActionHitChance[1];
                        heroCharacterInventory = (Inventory)heroWeaponAndActionHitChance[0];
                        CharacterGearInventoryHitChance character = new CharacterGearInventoryHitChance(name, heroCharacterActionTypesHitChance, 25, characterID, heroCharacterInventory);
                        return character;
                    }
                // gear, items and vin fletcher expansions
                case "0124":
                // gear, items, stolen inventory and vin fletcher expansions
                case "01234":
                    {
                        heroCharacterActionTypesHitChance = AddHeal10Action(2, heroCharacterActionTypesHitChance);
                        heroCharacterActionTypesHitChance = AddEquipAction(3, heroCharacterActionTypesHitChance);
                        Inventory heroCharacterInventory = new Inventory();
                        List<object> heroWeaponAndAction = AddHeroWeaponAndAction(4, heroCharacterActionTypesHitChance, heroCharacterInventory, characterID, strExpansions);
                        heroCharacterActionTypesHitChance = (List<AvailableActionHitChance>)heroWeaponAndAction[1];
                        heroCharacterInventory = (Inventory)heroWeaponAndAction[0];
                        CharacterGearInventoryHitChance trueProgrammer = new CharacterGearInventoryHitChance(name, heroCharacterActionTypesHitChance, 25, characterID, heroCharacterInventory);
                        return trueProgrammer;
                    }
                // vin fletcher expansion
                case "04":
                    {
                        if (characterID.Equals("vinFletcher"))
                        {
                            heroCharacterActionTypesHitChance = AddQuickShotAttack(1, heroCharacterActionTypesHitChance);
                            CharacterHitChance vinFletcher = new CharacterHitChance(name, heroCharacterActionTypesHitChance, 15, characterID);
                            return vinFletcher;
                        }
                        else
                        {
                            CharacterHitChance trueProgrammer = new CharacterHitChance(name, heroCharacterActionTypesHitChance, 25, characterID);
                            return trueProgrammer;
                        }
                    }
                // vin fletcher and attack modifier expansions
                case "045":
                    {
                        if (characterID.Equals("vinFletcher"))
                        {
                            heroCharacterActionTypesHitChance = AddQuickShotAttack(1, heroCharacterActionTypesHitChance);
                            CharacterAttackModifierHitChance vinFletcher = new CharacterAttackModifierHitChance(name, heroCharacterActionTypesHitChance, 15, characterID, attackModifiersOffensive, attackModifiersDefensive);
                            return vinFletcher;
                        }
                        else
                        {
                            attackModifiersOffensive.Add(powerAttack);
                            CharacterAttackModifierHitChance trueProgrammer = new CharacterAttackModifierHitChance(name, heroCharacterActionTypesHitChance, 25, characterID, attackModifiersOffensive, attackModifiersDefensive);
                            return trueProgrammer;
                        }
                    }
                // items, vin fletcher and attack modifiers expansions
                case "0145":
                // items, stolen inventory, vin fletcher and attack modifiers expansions
                case "01345":
                    {
                        if (characterID.Equals("vinFletcher"))
                        {
                            heroCharacterActionTypesHitChance = AddQuickShotAttack(1, heroCharacterActionTypesHitChance);
                            heroCharacterActionTypesHitChance = AddHeal10Action(2, heroCharacterActionTypesHitChance);
                            CharacterAttackModifierHitChance vinFletcher = new CharacterAttackModifierHitChance(name, heroCharacterActionTypesHitChance, 15, characterID, attackModifiersOffensive, attackModifiersDefensive);
                            return vinFletcher;
                        }
                        else
                        {
                            attackModifiersOffensive.Add(powerAttack);
                            heroCharacterActionTypesHitChance = AddHeal10Action(2, heroCharacterActionTypesHitChance);
                            CharacterAttackModifierHitChance trueProgrammer = new CharacterAttackModifierHitChance(name, heroCharacterActionTypesHitChance, 25, characterID, attackModifiersOffensive, attackModifiersDefensive);
                            return trueProgrammer;
                        }
                    }
                // game's status expansion
                default:
                    {
                        CharacterHitChance trueProgrammer = new CharacterHitChance(name, heroCharacterActionTypesHitChance, 25, characterID);
                        return trueProgrammer;
                    }
            }
        }

        private static List<object> AddHeroWeaponAndAction(int listPosition, List<AvailableActionHitChance> characterActionTypesHitChance, Inventory characterInventory, string name, string strExpansions)
        {
            List<object> obj = new List<object>();
            if (name.Equals("trueProgrammer"))
            {
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
                            characterInventory.WeaponHitChances = AddSwordHitChance();
                            characterActionTypesHitChance.Insert(listPosition, characterInventory.WeaponHitChances[0].AvailableActionHitChance);
                            break;
                        }
                    // gear expansions
                    // gear and items expansions
                    // gear, items and stolen inventory expansions
                    default:
                        {
                            characterInventory.Weapons = AddSword();
                            characterActionTypesHitChance.Insert(listPosition, (AvailableActionHitChance)characterInventory.WeaponHitChances[0].AvailableAction);
                            break;
                        }
                }
                obj = new List<object> { characterInventory, characterActionTypesHitChance };
            }
            else if (name.Equals("vinFletcher"))
            {
                characterInventory.WeaponHitChances = AddBow();
                characterActionTypesHitChance.Insert(listPosition, characterInventory.WeaponHitChances[0].AvailableActionHitChance);
                obj = new List<object> { characterInventory, characterActionTypesHitChance };
            }
            return obj;
        }

        private static List<AvailableActionHitChance> AddEquipAction(int listPosition, List<AvailableActionHitChance> characterActionTypesHitChance)
        {
            AvailableActionHitChance equip = new AvailableActionHitChance("EQUIP", 0, 0, ActionTypes.GEAR_EQUIP,  null);
            characterActionTypesHitChance.Insert(listPosition, equip);
            return characterActionTypesHitChance;
        }

        private static List<Character> CreateHeroCharacters(string strExpansions)
        {
            List<Character> characters = new List<Character>();
            Character trueProgrammer = CreateHeroCharacter(strExpansions, "trueProgrammer");
            characters.Insert(0, trueProgrammer);
            return characters;
        }

        private static List<Potion?> GetHeroPartyItems()
        {
            Potion healing10HP = GetHealing10HPPotion();
            List<Potion?> heroItems = new List<Potion?>
            {
                healing10HP,
                healing10HP,
                healing10HP
            };
            return heroItems;
        }

        private static Potion GetHealing10HPPotion()
        {
            Potion healing10HP = new Potion(PotionName.HEALING_10.ToString(), ItemTypes.POTION, PotionTypes.POTION_HEALING, "+10 HP", PotionEffectTypes.HEALING, 10);
            return healing10HP;
        }

        // method that creates the hero character returns a Character or CharacterGearInventory object depending on the active expansions
        private static Character CreateHeroCharacter(string strExpansions, string characterID)
        {
            List<AvailableActionHitChance> heroCharacterActionTypesHitChance = new List<AvailableActionHitChance>();
            List<AvailableAction> heroCharacterActionTypes = new List<AvailableAction>();
            AvailableAction nothing = new AvailableAction();
            AvailableAction punch = new AvailableAction("PUNCH", 1, 1, ActionTypes.ATTACK);
            heroCharacterActionTypes.Insert(0, nothing);
            heroCharacterActionTypes.Insert(1, punch);
            string name = "";
            Console.WriteLine("Please enter the True Programmer's name.");
            name = Console.ReadLine().ToUpper();
            string characterType = "hero";
            AttackModifierOffensive powerAttack = new AttackModifierOffensive(AttackModifierType.OFFENSIVE, "POWER ATTACK", 1, AttackModifierOffensiveCategory.DR_OVERRIDE, 0.5);
            List<AttackModifierOffensive> trueProgrammerAttackModifiersOffensive = new List<AttackModifierOffensive> { powerAttack };
            List<AttackModifierDefensive> attackModifiersDefensive = new List<AttackModifierDefensive>();
            switch (strExpansions)
            {
                // items expansion
                case "01":
                // items and stolen inventory expansions
                case "013":
                    {
                        heroCharacterActionTypes = AddHeal10Action(2, heroCharacterActionTypes);
                        Character trueProgrammer = new Character(name, heroCharacterActionTypes, 25, characterID);
                        return trueProgrammer;
                    }
                // gear expansion
                case "02":
                // gear and stolen inventory expansions
                case "023":
                    {
                        heroCharacterActionTypes = AddEquipAction(2, heroCharacterActionTypes);
                        Inventory heroCharacterInventory = new Inventory();
                        List<object> heroWeaponAndAction = AddHeroWeaponAndAction(3, heroCharacterActionTypes, heroCharacterInventory, characterID, strExpansions);
                        heroCharacterActionTypes = (List<AvailableAction>)heroWeaponAndAction[1];
                        heroCharacterInventory = (Inventory)heroWeaponAndAction[0];
                        CharacterGearInventory trueProgrammer = new CharacterGearInventory(name, heroCharacterActionTypes, 25, characterID, heroCharacterInventory);
                        return trueProgrammer;
                    }
                // gear and items expansions
                case "012":
                // gear, items and stolen inventory expansions
                case "0123":
                    {
                        heroCharacterActionTypes = AddHeal10Action(2, heroCharacterActionTypes);
                        heroCharacterActionTypes = AddEquipAction(3, heroCharacterActionTypes);
                        Inventory heroCharacterInventory = new Inventory();
                        List<object> heroWeaponAndAction = AddHeroWeaponAndAction(4, heroCharacterActionTypes, heroCharacterInventory, characterID, strExpansions);
                        heroCharacterActionTypes = (List<AvailableAction>)heroWeaponAndAction[1];
                        heroCharacterInventory = (Inventory)heroWeaponAndAction[0];
                        CharacterGearInventory trueProgrammer = new CharacterGearInventory(name, heroCharacterActionTypes, 25, characterID, heroCharacterInventory);
                        return trueProgrammer;
                    }
                // attack modifier expansion
                case "05":
                    {

                        CharacterAttackModifier trueProgrammer = new CharacterAttackModifier(name, heroCharacterActionTypes, 25, characterID, trueProgrammerAttackModifiersOffensive, attackModifiersDefensive);
                        return trueProgrammer;
                    }
                // items and attack modifier expansions
                case "015":
                // items, stolen inventory and attack modifier expansions
                case "0135":
                    {

                        heroCharacterActionTypes = AddHeal10Action(2, heroCharacterActionTypes);
                        CharacterAttackModifier trueProgrammer = new CharacterAttackModifier(name, heroCharacterActionTypes, 25, characterID, trueProgrammerAttackModifiersOffensive, attackModifiersDefensive);
                        return trueProgrammer;
                    }
                // gear and attack modifiers expansions
                case "025":
                // gear, stolen inventory and attack modifiers expansions
                case "0235":
                    {
                        heroCharacterActionTypes = AddEquipAction(2, heroCharacterActionTypes);
                        Inventory heroCharacterInventory = new Inventory();
                        List<object> heroWeaponAndAction = AddHeroWeaponAndAction(3, heroCharacterActionTypes, heroCharacterInventory, characterID, strExpansions);
                        heroCharacterActionTypes = (List<AvailableAction>)heroWeaponAndAction[1];
                        heroCharacterInventory = (Inventory)heroWeaponAndAction[0];
                        CharacterAttackModifierGearInventory trueProgrammer = new CharacterAttackModifierGearInventory(name, heroCharacterActionTypes, 25, characterID, heroCharacterInventory, trueProgrammerAttackModifiersOffensive, attackModifiersDefensive);
                        return trueProgrammer;
                    }
                // items, gear and attack modifiers expansions
                case "0125":
                // items, gear, stolen inventory and attack modifiers expansions
                case "01235":
                    {
                        heroCharacterActionTypes = AddHeal10Action(2, heroCharacterActionTypes);
                        heroCharacterActionTypes = AddEquipAction(3, heroCharacterActionTypes);
                        Inventory heroCharacterInventory = new Inventory();
                        List<object> heroWeaponAndAction = AddHeroWeaponAndAction(4, heroCharacterActionTypes, heroCharacterInventory, characterID, strExpansions);
                        heroCharacterActionTypes = (List<AvailableAction>)heroWeaponAndAction[1];
                        heroCharacterInventory = (Inventory)heroWeaponAndAction[0];
                        CharacterAttackModifierGearInventory trueProgrammer = new CharacterAttackModifierGearInventory(name, heroCharacterActionTypes, 25, characterID, heroCharacterInventory, trueProgrammerAttackModifiersOffensive, attackModifiersDefensive);
                        return trueProgrammer;
                    }
                // game's status expansion
                // vin fletcher expansion
                default:
                    {
                        Character trueProgrammer = new Character(name, heroCharacterActionTypes, 25, characterID);
                        return trueProgrammer;
                    }
            }
        }

        private static List<AvailableActionHitChance> AddHeal10Action(int listPosition, List<AvailableActionHitChance> characterActionTypes)
        {
            AvailableActionHitChance heal10 = new AvailableActionHitChance("Heal10", 10, 10, ActionTypes.HEAL, null);
            characterActionTypes.Insert(listPosition, heal10);
            return characterActionTypes;
        }

        private static List<AvailableActionHitChance> AddQuickShotAttack(int listPosition, List<AvailableActionHitChance> characterActionTypes)
        {
            AvailableActionHitChance quickShot = new AvailableActionHitChance("QuickShot", 3, 3, ActionTypes.ATTACK, 0.5);
            characterActionTypes[listPosition] = quickShot;
            return characterActionTypes;
        }

        private static List<object> AddHeroWeaponAndAction(int listPosition, List<AvailableAction> characterActionTypes, Inventory characterInventory, string name, string strExpansions)
        {
            List<object> obj = new List<object>();
            switch (strExpansions)
            {
                // vin fletcher expansion
                case "04":
                // gear and vin fletcher expansions
                case "024":
                // gear, items and vin fletcher expansions
                case "0124":
                // gear, stolen inventory and vin fletcher expansions
                case "0234":
                // gear, items, stolen inventory and vin fletcher expansions
                case "01234":
                    {
                        if (name.Equals("trueProgrammer"))
                        {
                            characterInventory.WeaponHitChances = AddSwordHitChance();
                            characterActionTypes.Insert(listPosition, characterInventory.WeaponHitChances[0].AvailableAction);
                            obj = new List<object> { characterInventory, characterActionTypes };
                        }
                        else if (name.Equals("vinFletcher"))
                        {
                            characterInventory.WeaponHitChances = AddBow();
                            characterActionTypes.Insert(listPosition, characterInventory.WeaponHitChances[0].AvailableAction);
                            obj = new List<object> { characterInventory, characterActionTypes };
                        }
                        break;
                    }
                // gear expansion
                // gear and items expansion
                // gear and stolen inventory expansions
                // gear, items and stolen inventory expansions
                default:
                    {
                        if (name.Equals("trueProgrammer"))
                        {
                            characterInventory.Weapons = AddSword();
                            characterActionTypes.Insert(listPosition, characterInventory.Weapons[0].AvailableAction);
                            obj = new List<object> { characterInventory, characterActionTypes };
                        }
                        break;
                    }
            }
            return obj;
        }

        public static List<WeaponHitChance> AddBow()
        {
            AvailableActionHitChance quickShot = new AvailableActionHitChance("QUICK SHOT", 3, 3, ActionTypes.GEAR_ATTACK, 0.5);
            WeaponHitChance bow = new WeaponHitChance(GearTypes.WEAPON, "bow", WeaponTypes.BOW, 3, 3, quickShot, "bow1", 0.5);
            List<WeaponHitChance> weaponHitChances = new List<WeaponHitChance> { bow };
            return weaponHitChances;
        }

        public static List<Weapon?> AddSword()
        {
            AvailableAction slash = new AvailableAction("SLASH", 2, 2, ActionTypes.GEAR_ATTACK);
            Weapon sword = new Weapon(GearTypes.WEAPON, "sword", WeaponTypes.SWORD, 2, 2, slash, "sword1");
            List<Weapon?> heroWeapons = new List<Weapon?> { sword };
            return heroWeapons;
        }

        public static List<WeaponHitChance> AddSwordHitChance()
        {
            AvailableActionHitChance slash = new AvailableActionHitChance("SLASH", 2, 2, ActionTypes.GEAR_ATTACK, 0.75);
            WeaponHitChance sword = new WeaponHitChance(GearTypes.WEAPON, "sword", WeaponTypes.SWORD, 2, 2, slash, "sword1", 0.75);
            List<WeaponHitChance> heroWeapons = new List<WeaponHitChance> { sword };
            return heroWeapons;
        }

        private static List<AvailableAction> AddEquipAction(int listPosition, List<AvailableAction> characterActionTypes)
        {
            AvailableAction equip = new AvailableAction("EQUIP", ActionTypes.GEAR_EQUIP);
            characterActionTypes.Insert(listPosition, equip);
            return characterActionTypes;
        }

        private static List<AvailableAction> AddHeal10Action(int listPosition, List<AvailableAction> characterActionTypes)
        {
            AvailableAction heal10 = new AvailableAction("Heal10", 10, 10, ActionTypes.HEAL);
            characterActionTypes.Insert(listPosition, heal10);
            return characterActionTypes;
        }

        // method to create the hero party as a Party object when no expansions are active
        private static Party CreateHeroParty(Character trueProgrammer)
        {
            List<Character> heroCharacters = new List<Character>();
            heroCharacters.Add(trueProgrammer);
            Party heroes = new Party(heroCharacters, PartyType.Heroes, "heroes");
            return heroes;
        }

        public static Character CreateSkeletonMonsterCharacter(int skeletonID, string strExpansions)
        {
            List<AttackModifier> attackModifiers = new List<AttackModifier>();
            List<AvailableAction> skeletonCharacterActionTypes = new List<AvailableAction>();
            AvailableAction boneCrunch = new AvailableAction("BONE CRUNCH", 0, 1, ActionTypes.ATTACK);
            AvailableAction nothing = new AvailableAction();
            skeletonCharacterActionTypes.Insert(0, nothing);
            skeletonCharacterActionTypes.Insert(1, boneCrunch);
            List<AttackModifierOffensive> attackModifiersOffensive = new List<AttackModifierOffensive>();
            List<AttackModifierDefensive> attackModifiersDefensive = new List<AttackModifierDefensive>();
            switch (strExpansions)
            {
                // items expansion
                case "01":
                // items and stolen inventory expansions
                case "013":
                    {
                        skeletonCharacterActionTypes = AddHeal10Action(2, skeletonCharacterActionTypes);
                        Character skeleton = new Character("SKELETON", skeletonCharacterActionTypes, 5, $"skeleton{skeletonID}");
                        return skeleton;
                    }
                // gear expansion
                case "02":
                // gear and stolen inventory expansions
                case "023":
                    {
                        skeletonCharacterActionTypes = AddEquipAction(2, skeletonCharacterActionTypes);
                        Inventory monsterCharacterInventory = EmptyWeaponInventory();
                        CharacterGearInventory skeleton = new CharacterGearInventory("SKELETON", skeletonCharacterActionTypes, 5, $"skeleton{skeletonID}", monsterCharacterInventory);
                        return skeleton;
                    }
                // gear and items expansions
                case "012":
                // gear, items and stolen inventory expansions
                case "0123":
                    {
                        skeletonCharacterActionTypes = AddHeal10Action(2, skeletonCharacterActionTypes);
                        skeletonCharacterActionTypes = AddEquipAction(3, skeletonCharacterActionTypes);
                        Inventory monsterCharacterInventory = EmptyWeaponInventory();
                        CharacterGearInventory skeleton = new CharacterGearInventory("SKELETON", skeletonCharacterActionTypes, 5, $"skeleton{skeletonID}", monsterCharacterInventory);
                        return skeleton;
                    }
                // attack modifier expansion
                case "05":
                    {
                        CharacterAttackModifier skeleton = new CharacterAttackModifier("SKELETON", skeletonCharacterActionTypes, 5, $"skeleton{skeletonID}", attackModifiersOffensive, attackModifiersDefensive);
                        return skeleton;
                    }
                // items and attack modifier expansions
                case "015":
                // items, stolen inventory and attack modifer expansions
                case "0135":
                    {
                        skeletonCharacterActionTypes = AddHeal10Action(2, skeletonCharacterActionTypes);
                        CharacterAttackModifier skeleton = new CharacterAttackModifier("SKELETON", skeletonCharacterActionTypes, 5, $"skeleton{skeletonID}", attackModifiersOffensive, attackModifiersDefensive);
                        return skeleton;
                    }
                // gear and attack modifiers expansions
                case "025":
                // gear, stolen inventory and attack modifiers expansions
                case "0235":
                    {
                        skeletonCharacterActionTypes = AddEquipAction(2, skeletonCharacterActionTypes);
                        Inventory monsterCharacterInventory = EmptyWeaponInventory();
                        CharacterAttackModifierGearInventory skeleton = new CharacterAttackModifierGearInventory("SKELETON", skeletonCharacterActionTypes, 5, $"skeleton{skeletonID}", monsterCharacterInventory, attackModifiersOffensive, attackModifiersDefensive);
                        return skeleton;
                    }
                // items, gear and attack modifiers expansions
                case "0125":
                // items, gear, stolen inventory and attack modifiers expansions
                case "01235":
                    {
                        skeletonCharacterActionTypes = AddHeal10Action(2, skeletonCharacterActionTypes);
                        skeletonCharacterActionTypes = AddEquipAction(3, skeletonCharacterActionTypes);
                        Inventory monsterCharacterInventory = EmptyWeaponInventory();
                        CharacterAttackModifierGearInventory skeleton = new CharacterAttackModifierGearInventory("SKELETON", skeletonCharacterActionTypes, 5, $"skeleton{skeletonID}", monsterCharacterInventory, attackModifiersOffensive, attackModifiersDefensive);
                        return skeleton;
                    }
                // game's status expansion
                default:
                    {
                        Character skeleton = new Character("SKELETON", skeletonCharacterActionTypes, 5, $"skeleton{skeletonID}");
                        return skeleton;
                    }
            }
        }

        private static List<CharacterAttackModifierGearInventory> CreateMonsterCharactersAttackModifierGearInventory(string strExpansions)
        {
            int skeletonID = 1, stoneAmarokID = 1;
            CharacterAttackModifierGearInventory skeleton1 = (CharacterAttackModifierGearInventory)CreateSkeletonMonsterCharacter(skeletonID, strExpansions);
            AvailableAction stab = new AvailableAction("STAB", 1, 1, ActionTypes.GEAR_ATTACK);
            Weapon dagger1 = new Weapon(GearTypes.WEAPON, $"dagger{skeletonID}", WeaponTypes.DAGGER, 1, 1, stab, $"dagger{skeletonID}");
            List<Weapon?> monsterWeapons = new List<Weapon?> { dagger1 };
            skeleton1.CharacterInventory.Weapons.Add(dagger1);
            skeleton1.AvailableActions.Insert(3, skeleton1.CharacterInventory.Weapons[0].AvailableAction);
            skeletonID++;
            List<CharacterAttackModifierGearInventory> monsterCharacters = new List<CharacterAttackModifierGearInventory>();
            monsterCharacters.Add(skeleton1);
            CharacterAttackModifierGearInventory skeleton2 = (CharacterAttackModifierGearInventory)CreateSkeletonMonsterCharacter(skeletonID, strExpansions);
            skeletonID++;
            CharacterAttackModifierGearInventory skeleton3 = (CharacterAttackModifierGearInventory)CreateSkeletonMonsterCharacter(skeletonID, strExpansions);
            skeletonID++;
            monsterCharacters.Add(skeleton2);
            monsterCharacters.Add(skeleton3);
            CharacterAttackModifierGearInventory stoneAmarok1 = CreateStoneAmarokMonsterCharacterGearinventory(stoneAmarokID, strExpansions);
            stoneAmarokID++;
            CharacterAttackModifierGearInventory stoneAmarok2 = CreateStoneAmarokMonsterCharacterGearinventory(stoneAmarokID, strExpansions);
            monsterCharacters.Add(stoneAmarok1);
            monsterCharacters.Add(stoneAmarok2);
            CharacterAttackModifierGearInventory unCodedOne = (CharacterAttackModifierGearInventory)CreateUnCodedOne(strExpansions);
            monsterCharacters.Add(unCodedOne);
            return monsterCharacters;

        }
        private static List<CharacterGearInventory> CreateMonsterCharactersGearInventory(string strExpansions)
        {
            int skeletonID = 1;
            CharacterGearInventory skeleton1 = (CharacterGearInventory)CreateSkeletonMonsterCharacter(skeletonID, strExpansions);
            AvailableAction stab = new AvailableAction("STAB", 1, 1, ActionTypes.GEAR_ATTACK);
            Weapon dagger1 = new Weapon(GearTypes.WEAPON, $"dagger{skeletonID}", WeaponTypes.DAGGER, 1, 1, stab, $"dagger{skeletonID}");
            List<Weapon?> monsterWeapons = new List<Weapon?> { dagger1 };
            skeleton1.CharacterInventory.Weapons.Add(dagger1);
            skeleton1.AvailableActions.Insert(3, skeleton1.CharacterInventory.Weapons[0].AvailableAction);
            skeletonID++;
            List<CharacterGearInventory> monsterCharacters = new List<CharacterGearInventory>();
            monsterCharacters.Add(skeleton1);
            CharacterGearInventory skeleton2 = (CharacterGearInventory)CreateSkeletonMonsterCharacter(skeletonID, strExpansions);
            skeletonID++;
            CharacterGearInventory skeleton3 = (CharacterGearInventory)CreateSkeletonMonsterCharacter(skeletonID, strExpansions);
            skeletonID++;
            monsterCharacters.Add(skeleton2);
            monsterCharacters.Add(skeleton3);
            CharacterGearInventory unCodedOne = (CharacterGearInventory)CreateUnCodedOne(strExpansions);
            monsterCharacters.Add(unCodedOne);
            return monsterCharacters;
        }
        private static List<Character> CreateMonsterCharacters(string strExpansions)
        {
            int skeletonID = 1;
            Character skeleton1 = CreateSkeletonMonsterCharacter(skeletonID, strExpansions);
            skeletonID++;
            List<Character> monsterCharacters = new List<Character>();
            monsterCharacters.Add(skeleton1);
            Character skeleton2 = CreateSkeletonMonsterCharacter(skeletonID, strExpansions);
            skeletonID++;
            Character skeleton3 = CreateSkeletonMonsterCharacter(skeletonID, strExpansions);
            skeletonID++;
            monsterCharacters.Add(skeleton2);
            monsterCharacters.Add(skeleton3);
            Character unCodedOne = CreateUnCodedOne(strExpansions);
            monsterCharacters.Add(unCodedOne);
            return monsterCharacters;
        }

        // creates the UnCoded One's character
        private static Character CreateUnCodedOne(string strExpansions)
        {
            List<AttackModifier> attackModifiers = new List<AttackModifier>();
            List<AvailableAction> unCodedOneCharacterActionTypes = new List<AvailableAction>();
            AvailableAction unraveling = new AvailableAction("UNRAVELING", 0, 2, ActionTypes.ATTACK);
            AvailableAction nothing = new AvailableAction();
            unCodedOneCharacterActionTypes.Add(nothing);
            unCodedOneCharacterActionTypes.Add(unraveling);
            List<AttackModifierOffensive> attackModifiersOffensive = new List<AttackModifierOffensive>();
            List<AttackModifierDefensive> attackModifiersDefensive = new List<AttackModifierDefensive>();
            switch (strExpansions)
            {
                // items expansion
                case "01":
                // items and stolen inventory expansions
                case "013":
                    {
                        unCodedOneCharacterActionTypes = AddHeal10Action(2, unCodedOneCharacterActionTypes);
                        Character unCodedOne = new Character("THE UNCODED ONE", unCodedOneCharacterActionTypes, 15, "unCodedOne");
                        return unCodedOne;
                    }
                // gear expansion
                case "02":
                // gear and stolen inventory expansions
                case "023":
                    {
                        unCodedOneCharacterActionTypes = AddEquipAction(2, unCodedOneCharacterActionTypes);
                        Inventory unCodedOneInventory = EmptyWeaponInventory();
                        CharacterGearInventory unCodedOne = new CharacterGearInventory("THE UNCODED ONE", unCodedOneCharacterActionTypes, 15, "unCodedOne", unCodedOneInventory);
                        return unCodedOne;
                    }
                // items and gear expansions
                case "012":
                // items, gear and stolen inventory expansions
                case "0123":
                    {
                        unCodedOneCharacterActionTypes = AddHeal10Action(2, unCodedOneCharacterActionTypes);
                        unCodedOneCharacterActionTypes = AddEquipAction(3, unCodedOneCharacterActionTypes);
                        Inventory unCodedOneInventory = EmptyWeaponInventory();
                        CharacterGearInventory unCodedOne = new CharacterGearInventory("THE UNCODED ONE", unCodedOneCharacterActionTypes, 15, "unCodedOne", unCodedOneInventory);
                        return unCodedOne;
                    }
                // attack modifiers expansion
                case "05":
                    {
                        CharacterAttackModifier unCodedOne = new CharacterAttackModifier("THE UNCODED ONE", unCodedOneCharacterActionTypes, 15, "unCodedOne", attackModifiersOffensive, attackModifiersDefensive);
                        return unCodedOne;
                    }
                // items and attack modifiers expansions
                case "015":
                // items, stolen inventory and attack modifier expansions
                case "0135":
                    {
                        unCodedOneCharacterActionTypes = AddHeal10Action(2, unCodedOneCharacterActionTypes);
                        CharacterAttackModifier unCodedOne = new CharacterAttackModifier("THE UNCODED ONE", unCodedOneCharacterActionTypes, 15, "unCodedOne", attackModifiersOffensive, attackModifiersDefensive);
                        return unCodedOne;
                    }
                // gear and attack modifiers expansions
                case "025":
                // gear, stolen inventory and attack modifiers expansions
                case "0235":
                    {
                        unCodedOneCharacterActionTypes = AddEquipAction(2, unCodedOneCharacterActionTypes);
                        Inventory unCodedOneInventory = EmptyWeaponInventory();
                        CharacterAttackModifierGearInventory unCodedOne = new CharacterAttackModifierGearInventory("THE UNCODED ONE", unCodedOneCharacterActionTypes, 15, "unCodedOne", unCodedOneInventory, attackModifiersOffensive, attackModifiersDefensive);
                        return unCodedOne;
                    }
                // items, gear and attack modifiers expansions
                case "0125":
                // items, gear, stolen inventory and attack modifiers expansions
                case "01235":
                    {
                        unCodedOneCharacterActionTypes = AddHeal10Action(2, unCodedOneCharacterActionTypes);
                        unCodedOneCharacterActionTypes = AddEquipAction(3, unCodedOneCharacterActionTypes);
                        Inventory unCodedOneInventory = EmptyWeaponInventory();
                        CharacterAttackModifierGearInventory unCodedOne = new CharacterAttackModifierGearInventory("THE UNCODED ONE", unCodedOneCharacterActionTypes, 15, "unCodedOne", unCodedOneInventory, attackModifiersOffensive, attackModifiersDefensive);
                        return unCodedOne;
                    }
                // game's status expansion
                default:
                    {
                        Character unCodedOne = new Character("THE UNCODED ONE", unCodedOneCharacterActionTypes, 15, "unCodedOne");
                        return unCodedOne;
                    }
            }
        }

        private static Inventory EmptyWeaponInventory()
        {
            List<Weapon> weapons = new List<Weapon>();
            Inventory inventory = new Inventory();
            inventory.Weapons = weapons;
            return inventory;
        }

        // creates the players
        private static List<Player> SetPlayers()
        {
            Console.WriteLine($"Please select from the following list of game modes using the corresponding number:" +
                $"\n1. {GameMode.ComputerVsComputer}" +
                $"\n2: {GameMode.HumanVsComputer}" +
                $"\n3: {GameMode.HumanVsHuman}");
            bool isValid = false;
            string input = "";
            List<Player> playerList = new List<Player>();
            while (isValid == false)
            {
                input = Console.ReadLine();
                switch (input)
                {
                    // computer vs computer
                    case "1":
                        {
                            while (isValid == false)
                            {
                                object[] validPlayer = (object[])GetPlayerName();
                                input = (string)validPlayer[0];
                                isValid = (bool)validPlayer[1];
                            }
                            isValid = false;
                            Player computerHeroes = new Player(input, PlayerType.Computer, 1, PartyType.Heroes);
                            playerList.Add(computerHeroes);
                            while (isValid == false)
                            {
                                object[] validPlayer = (object[])GetPlayerName();
                                input = (string)validPlayer[0];
                                isValid = (bool)validPlayer[1];
                            }
                            Player computerMonsters = new Player(input, PlayerType.Computer, 2, PartyType.Monsters);
                            playerList.Add(computerMonsters);
                            break;
                        }
                    // human (player 1) vs computer (player 2)
                    case "2":
                        {
                            while (isValid == false)
                            {
                                object[] validPlayer = (object[])GetPlayerName();
                                input = (string)validPlayer[0];
                                isValid = (bool)validPlayer[1];
                            }
                            isValid = false;
                            Player humanHeroes = new Player(input, PlayerType.Human, 1, PartyType.Heroes);
                            playerList.Add(humanHeroes);
                            while (isValid == false)
                            {
                                object[] validPlayer = (object[])GetPlayerName();
                                input = (string)validPlayer[0];
                                isValid = (bool)validPlayer[1];
                            }
                            Player computerMonsters = new Player(input, PlayerType.Computer, 2, PartyType.Monsters);
                            playerList.Add(computerMonsters);
                            break;
                        }
                    // human vs human
                    case "3":
                        {
                            while (isValid == false)
                            {
                                object[] validPlayer = (object[])GetPlayerName();
                                input = (string)validPlayer[0];
                                isValid = (bool)validPlayer[1];
                            }
                            isValid = false;
                            Player humanHeroes = new Player(input, PlayerType.Human, 1, PartyType.Heroes);
                            playerList.Add(humanHeroes);
                            while (isValid == false)
                            {
                                object[] validPlayer = (object[])GetPlayerName();
                                input = (string)validPlayer[0];
                                isValid = (bool)validPlayer[1];
                            }
                            Player humanMonsters = new Player(input, PlayerType.Human, 2, PartyType.Monsters);
                            playerList.Add(humanMonsters);
                            break;
                        }
                    default:
                        {
                            isValid = false;
                            break;
                        }
                }
            }
            return playerList;
        }

        // gets the player's name
        private static object GetPlayerName()
        {
            Console.WriteLine("Please enter the player's name");
            string input = Console.ReadLine();
            bool isValid = IsValidPlayerName(input);
            object[] ValidPlayerName = { input, isValid };
            return ValidPlayerName;
        }

        // verifies that there is some valid input for player name
        private static bool IsValidPlayerName(string? input)
        {
            if (!input.Equals(null) || !input.Equals(""))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // method sets the current player, party type, and party
        public static void SetCurrent(Battle battle, int playerID, int monsterPartyID, string strExpansions)
        {
            // set current player
            battle.CurrentPlayer = battle.Players[playerID];
            switch (playerID)
            {
                // heroes
                case 0:
                    {
                        switch (strExpansions)
                        {
                            // items expansion
                            case "01":
                            // items and stolen inventory expansions
                            case "013":
                                {
                                    // set current party type
                                    battle.CurrentPartyType = PartyType.Heroes;
                                    // set current party using item expansion
                                    battle.CurrentPartyItemInventory = battle.HeroesItemInventory;
                                    break;
                                }
                            // items and vin fletcher expansions
                            case "014":
                            // items, stolen inventory and vin fletcher expansions
                            case "0134":
                            // items, vin fletcher and attack modifiers expansions
                            case "0145":
                            // items, stolen inventory, vin fletcher and attack modifiers expansions
                            case "01345":
                                {
                                    // set current party type
                                    battle.CurrentPartyType = PartyType.Heroes;
                                    // set current party using item expansion
                                    battle.CurrentPartyItemInventoryHitChance = battle.HeroesItemInventoryHitChance;
                                    break;
                                }
                            // gear expansion
                            case "02":
                            // gear and stolen inventory expansions
                            case "023":
                            // gear and items expansions
                            case "012":
                            // gear, items, and stolen inventory expansions
                            case "0123":
                                {
                                    // set current party type
                                    battle.CurrentPartyType = PartyType.Heroes;
                                    // set current party using gear expansion
                                    battle.CurrentPartyGearInventory = battle.HeroesGearInventory;
                                    break;
                                }
                            // gear and vin fletcher expansions
                            case "024":
                            // gear, stolen inventory and vin fletcher expansions
                            case "0234":
                            // gear, items and vin fletcher expansions
                            case "0124":
                            // gear, items, stolen inventory and vin fletcher expansions
                            case "01234":
                                {
                                    // set current party type
                                    battle.CurrentPartyType = PartyType.Heroes;
                                    // set current party using gear expansion
                                    battle.CurrentPartyGearInventoryHitChance = battle.HeroesPartyGearInventoryHitChance;
                                    break;
                                }
                            // items and attack modifiers expansions
                            case "015":
                            // items, stolen inventory and attack modifiers expansions
                            case "0135":
                                {
                                    // set current party type
                                    battle.CurrentPartyType = PartyType.Heroes;
                                    // set current party
                                    battle.CurrentPartyAttackModifierItemInventory = battle.HeroesPartyAttackModifierItemInventory;
                                    break;
                                }
                            // gear and attack modifiers expansions
                            case "025":
                            // gear, stolen inventory and attack modifiers expansions
                            case "0235":
                            // gear, items and attack modifiers expansions
                            case "0125":
                            // gear, items, stolen inventory and attack modifiers expansions
                            case "01235":
                                {
                                    // set current party type
                                    battle.CurrentPartyType = PartyType.Heroes;
                                    // set current party
                                    battle.CurrentPartyAttackModifierGearInventory = battle.HeroesPartyAttackModifierGearInventory;
                                    break;
                                }
                            // game's status expansion only
                            // vin fletcher expansion
                            // attack modifiers expansions
                            default:
                                {
                                    // set current party type
                                    battle.CurrentPartyType = PartyType.Heroes;
                                    // set current party
                                    battle.CurrentParty = battle.Heroes;
                                    break;
                                }
                        }
                        break;
                    }
                // monsters
                case 1:
                    {
                        switch (strExpansions)
                        {
                            // items expansion
                            case "01":
                            // items and stolen inventory expansions
                            case "013":
                                {
                                    // set current party type
                                    battle.CurrentPartyType = PartyType.Monsters;
                                    // set current party using item expansion
                                    battle.CurrentPartyItemInventory = battle.MonstersItemInventory[monsterPartyID];
                                    break;
                                }
                            // items, and vin fletcher expansions
                            case "014":
                            // items, stolen inventory and vin fletcher expansions
                            case "0134":
                            // items, vin fletcher and attack modifiers expansions
                            case "0145":
                            // items, stolen inventory, vin fletcher and attack modifiers expansions
                            case "01345":
                                {
                                    // set current party type
                                    battle.CurrentPartyType = PartyType.Monsters;
                                    // set current party using item expansion
                                    battle.CurrentPartyItemInventoryHitChance = battle.MonstersItemInventoryHitChance[monsterPartyID];
                                    break;
                                }
                            // gear expansion
                            case "02":
                            // gear and stolen inventory expansions
                            case "023":
                            // gear and items expansions
                            case "012":
                            // gear, items, and stolen inventory expansions
                            case "0123":
                                {
                                    // set current party type
                                    battle.CurrentPartyType = PartyType.Monsters;
                                    // set current party using gear expansion
                                    battle.CurrentPartyGearInventory = battle.MonstersGearInventory[monsterPartyID];
                                    break;
                                }
                            // gear and vin fletcher expansions
                            case "024":
                            // gear, stolen inventory and vin fletcher expansions
                            case "0234":
                            // items, gear amd vin fletcher expansions
                            case "0124":
                            // items, gear, stolen inventory and vin fletcher expansions
                            case "01234":
                                {
                                    // set current party type
                                    battle.CurrentPartyType = PartyType.Monsters;
                                    // set current party using gear expansion
                                    battle.CurrentPartyGearInventoryHitChance = battle.MonstersPartyGearInventoryHitChances[monsterPartyID];
                                    break;
                                }
                            // items and attack modifiers expansions
                            case "015":
                            // items, stolen inventory and attack modifiers expansions
                            case "0135":
                                {
                                    // set curremt party type
                                    battle.CurrentPartyType = PartyType.Monsters;
                                    // set current party
                                    battle.CurrentPartyAttackModifierItemInventory = battle.MonstersPartyAttackModifierItemInventory[monsterPartyID];
                                    break;
                                }
                            // gear and attack modifiers expansions
                            case "025":
                            // gear, stolen inventory and attack modifiers expansions
                            case "0235":
                            // gear, items and attack modifiers expansions
                            case "0125":
                            // gear, items, stolen inventory and attack modifiers expansions
                            case "01235":
                                {
                                    // set current party type
                                    battle.CurrentPartyType = PartyType.Monsters;
                                    // set current party
                                    battle.CurrentPartyAttackModifierGearInventory = battle.MonstersPartyAttackModifierGearInventory[monsterPartyID];
                                    break;
                                }
                            // game's status expansion only
                            // vin fletcher expansion
                            // attack modifiers expansion
                            default:
                                {
                                    // set current party type
                                    battle.CurrentPartyType = PartyType.Monsters;
                                    // set current party
                                    battle.CurrentParty = battle.Monsters[monsterPartyID];
                                    break;
                                }
                        }
                        break;
                    }
            }
        }
        public static void Combat(object? obj)
        {
            Battle battle = (Battle)obj;
            Games_Status gamesStatus = new Games_Status();
            Games_StatusHitChance gamesStatusHitChance = new Games_StatusHitChance();
            Games_StatusAttackModifier gamesStatusAttackModifier = new Games_StatusAttackModifier();
            StolenInventories stolenInventories = new StolenInventories();
            switch (battle.Expansions)
            {
                // items expansion
                case "01":
                // items and stolen inventory expansions
                case "013":
                    {
                        for (int j = 0; j < battle.MonstersItemInventory.Count; j++)
                        {
                            battle.CurrentMonsterPartyNumber = j;
                            while (battle.MonstersItemInventory[j].Characters.Count > 0 && battle.HeroesItemInventory.Characters.Count > 0)
                            {
                                bool availableTargets = true;
                                Thread.Sleep(500);
                                SetCurrent(battle, 0, j, battle.Expansions);
                                for (int i = 0; i < battle.HeroesItemInventory.Characters.Count; i++)
                                {
                                    Thread.Sleep(500);
                                    battle.CurrentCharacter = battle.HeroesItemInventory.Characters[i];
                                    gamesStatus.GamesStatus(battle, battle.MonstersItemInventory[j]);
                                    Console.WriteLine($"Player {battle.CurrentPlayer.Name} please select {battle.CurrentCharacter.Name}'s action");
                                    if (battle.CurrentPlayer.PlayerType.Equals(PlayerType.Human))
                                    {
                                        CurrentHumanTurn(battle, battle.Expansions);
                                    }
                                    else
                                    {
                                        CurrentTurn(battle, battle.Expansions);
                                    }
                                    if (battle.MonstersItemInventory[j].Characters.Count == 0)
                                    {
                                        availableTargets = false;
                                        i = battle.HeroesItemInventory.Characters.Count;
                                    }
                                }
                                if (availableTargets == false)
                                {
                                    if (battle.Expansions.Equals("013"))
                                    {
                                        stolenInventories.StolenInventory(battle, battle.MonstersItemInventory[j], battle.CurrentPartyItemInventory);
                                    }
                                    battle.MonstersItemInventory.RemoveAt(j);
                                    j--;
                                    break;
                                }
                                Thread.Sleep(500);
                                SetCurrent(battle, 1, j, battle.Expansions);
                                for (int i = 0; i < battle.MonstersItemInventory[battle.CurrentMonsterPartyNumber].Characters.Count; i++)
                                {
                                    Thread.Sleep(500);
                                    battle.CurrentCharacter = battle.MonstersItemInventory[battle.CurrentMonsterPartyNumber].Characters[i];
                                    gamesStatus.GamesStatus(battle, battle.MonstersItemInventory[j]);
                                    Console.WriteLine($"Player {battle.CurrentPlayer.Name} please select {battle.CurrentCharacter.Name}'s action");
                                    if (battle.CurrentPlayer.PlayerType.Equals(PlayerType.Human))
                                    {
                                        CurrentHumanTurn(battle, battle.Expansions);
                                    }
                                    else
                                    {
                                        CurrentTurn(battle, battle.Expansions);
                                    }
                                    if (battle.HeroesItemInventory.Characters.Count == 0)
                                    {
                                        availableTargets = false;
                                        i = battle.MonstersItemInventory[j].CharactersGearInventory.Count;
                                    }
                                }
                                if (availableTargets == false)
                                {
                                    break;
                                }
                            }
                        }
                        if (battle.MonstersItemInventory.Count == 0)
                        {
                            Console.WriteLine("The Heroes won! The Uncoded One has been defeated!");
                        }
                        else if (battle.HeroesItemInventory.CharactersGearInventory.Count == 0)
                        {
                            Console.WriteLine("The Heros lost! The Uncoded One prevailed!");
                        }
                        break;
                    }
                // items and vin fletcher expansions
                case "014":
                // items, stolen inventory and vin fletcher expansions
                case "0134":
                    {
                        for (int j = 0; j < battle.MonstersItemInventoryHitChance.Count; j++)
                        {
                            battle.CurrentMonsterPartyNumber = j;
                            while (battle.MonstersItemInventoryHitChance[j].CharactersHitChance.Count > 0 && battle.HeroesItemInventoryHitChance.CharactersHitChance.Count > 0)
                            {
                                bool availableTargets = true;
                                Thread.Sleep(500);
                                SetCurrent(battle, 0, j, battle.Expansions);
                                for (int i = 0; i < battle.HeroesItemInventoryHitChance.CharactersHitChance.Count; i++)
                                {
                                    Thread.Sleep(500);
                                    battle.CurrentCharacterHitChance = battle.HeroesItemInventoryHitChance.CharactersHitChance[i];
                                    gamesStatusHitChance.GamesStatusHitChance(battle, battle.MonstersItemInventoryHitChance[j]);
                                    Console.WriteLine($"Player {battle.CurrentPlayer.Name} please select {battle.CurrentCharacterHitChance.Name}'s action");
                                    if (battle.CurrentPlayer.PlayerType.Equals(PlayerType.Human))
                                    {
                                        CurrentHumanTurn(battle, battle.Expansions);
                                    }
                                    else
                                    {
                                        CurrentTurn(battle, battle.Expansions);
                                    }
                                    if (battle.MonstersItemInventoryHitChance[j].CharactersHitChance.Count == 0)
                                    {
                                        availableTargets = false;
                                        i = battle.HeroesItemInventoryHitChance.CharactersHitChance.Count;
                                    }
                                }
                                if (availableTargets == false)
                                {
                                    if (battle.Expansions.Equals("0134"))
                                    {
                                        stolenInventories.StolenInventory(battle, battle.MonstersItemInventoryHitChance[j], battle.CurrentPartyItemInventoryHitChance);
                                    }
                                    battle.MonstersItemInventoryHitChance.RemoveAt(j);
                                    j--;
                                    break;
                                }
                                Thread.Sleep(500);
                                SetCurrent(battle, 1, j, battle.Expansions);
                                for (int i = 0; i < battle.MonstersItemInventoryHitChance[battle.CurrentMonsterPartyNumber].CharactersHitChance.Count; i++)
                                {
                                    Thread.Sleep(500);
                                    battle.CurrentCharacterHitChance = battle.MonstersItemInventoryHitChance[battle.CurrentMonsterPartyNumber].CharactersHitChance[i];
                                    gamesStatusHitChance.GamesStatusHitChance(battle, battle.MonstersItemInventoryHitChance[j]);
                                    Console.WriteLine($"Player {battle.CurrentPlayer.Name} please select {battle.CurrentCharacterHitChance.Name}'s action");
                                    if (battle.CurrentPlayer.PlayerType.Equals(PlayerType.Human))
                                    {
                                        CurrentHumanTurn(battle, battle.Expansions);
                                    }
                                    else
                                    {
                                        CurrentTurn(battle, battle.Expansions);
                                    }
                                    if (battle.HeroesItemInventoryHitChance.CharactersHitChance.Count == 0)
                                    {
                                        availableTargets = false;
                                        i = battle.MonstersItemInventoryHitChance[j].CharactersHitChance.Count;
                                    }
                                }
                                if (availableTargets == false)
                                {
                                    break;
                                }
                            }
                        }
                        if (battle.MonstersItemInventoryHitChance.Count == 0)
                        {
                            Console.WriteLine("The Heroes won! The Uncoded One has been defeated!");
                        }
                        else if (battle.HeroesItemInventoryHitChance.CharactersHitChance.Count == 0)
                        {
                            Console.WriteLine("The Heros lost! The Uncoded One prevailed!");
                        }
                        break;
                    }
                // gear expansion
                case "02":
                // gear and stolen inventory expansions
                case "023":
                // gear and items expansions
                case "012":
                // gear, items, and stolen inventory expansions
                case "0123":
                    {
                        for (int j = 0; j < battle.MonstersGearInventory.Count; j++)
                        {
                            battle.CurrentMonsterPartyNumber = j;
                            while (battle.MonstersGearInventory[j].CharactersGearInventory.Count > 0 && battle.HeroesGearInventory.CharactersGearInventory.Count > 0)
                            {
                                bool availableTargets = true;
                                Thread.Sleep(500);
                                SetCurrent(battle, 0, j, battle.Expansions);
                                for (int i = 0; i < battle.HeroesGearInventory.CharactersGearInventory.Count; i++)
                                {
                                    Thread.Sleep(500);
                                    battle.CurrentCharacterGearInventory = battle.HeroesGearInventory.CharactersGearInventory[i];
                                    gamesStatus.GamesStatus(battle, battle.MonstersGearInventory[j]);
                                    Console.WriteLine($"Player {battle.CurrentPlayer.Name} please select {battle.CurrentCharacterGearInventory.Name}'s action");
                                    if (battle.CurrentPlayer.PlayerType.Equals(PlayerType.Human))
                                    {
                                        CurrentHumanTurn(battle, battle.Expansions);
                                    }
                                    else
                                    {
                                        CurrentTurn(battle, battle.Expansions);
                                    }
                                    if (battle.MonstersGearInventory[j].CharactersGearInventory.Count == 0)
                                    {
                                        availableTargets = false;
                                        i = battle.HeroesGearInventory.CharactersGearInventory.Count;
                                    }
                                }
                                if (availableTargets == false)
                                {
                                    if (battle.Expansions.Equals("023") || battle.Expansions.Equals("0123") || battle.Expansions.Equals("0234") || battle.Expansions.Equals("01234"))
                                    {
                                        stolenInventories.StolenInventory(battle, battle.MonstersGearInventory[j], battle.CurrentPartyGearInventory);
                                    }
                                    battle.MonstersGearInventory.RemoveAt(j);
                                    j--;
                                    break;
                                }
                                Thread.Sleep(500);
                                SetCurrent(battle, 1, j, battle.Expansions);
                                for (int i = 0; i < battle.MonstersGearInventory[battle.CurrentMonsterPartyNumber].CharactersGearInventory.Count; i++)
                                {
                                    Thread.Sleep(500);
                                    battle.CurrentCharacterGearInventory = battle.MonstersGearInventory[battle.CurrentMonsterPartyNumber].CharactersGearInventory[i];
                                    gamesStatus.GamesStatus(battle, battle.MonstersGearInventory[j]);
                                    Console.WriteLine($"Player {battle.CurrentPlayer.Name} please select {battle.CurrentCharacterGearInventory.Name}'s action");
                                    if (battle.CurrentPlayer.PlayerType.Equals(PlayerType.Human))
                                    {
                                        CurrentHumanTurn(battle, battle.Expansions);
                                    }
                                    else
                                    {
                                        CurrentTurn(battle, battle.Expansions);
                                    }
                                    if (battle.HeroesGearInventory.CharactersGearInventory.Count == 0)
                                    {
                                        availableTargets = false;
                                        i = battle.MonstersGearInventory[j].CharactersGearInventory.Count;
                                    }
                                }
                                if (availableTargets == false)
                                {
                                    break;
                                }
                            }
                        }
                        if (battle.MonstersGearInventory.Count == 0)
                        {
                            Console.WriteLine("The Heroes won! The Uncoded One has been defeated!");
                        }
                        else if (battle.HeroesGearInventory.CharactersGearInventory.Count == 0)
                        {
                            Console.WriteLine("The Heros lost! The Uncoded One prevailed!");
                        }
                        break;
                    }
                // gear and vin fletcher expansions
                case "024":
                // gear, stolen inventory and vin fletcher expansions
                case "0234":
                // items, gear and vin fletcher expansions
                case "0124":
                // items, gear, stolen inventory and vin fletcher expansions
                case "01234":
                    {
                        for (int j = 0; j < battle.MonstersPartyGearInventoryHitChances.Count; j++)
                        {
                            battle.CurrentMonsterPartyNumber = j;
                            while (battle.MonstersPartyGearInventoryHitChances[j].CharacterGearInventoryHitChances.Count > 0 && battle.HeroesPartyGearInventoryHitChance.CharacterGearInventoryHitChances.Count > 0)
                            {
                                bool availableTargets = true;
                                Thread.Sleep(500);
                                SetCurrent(battle, 0, j, battle.Expansions);
                                for (int i = 0; i < battle.HeroesPartyGearInventoryHitChance.CharacterGearInventoryHitChances.Count; i++)
                                {
                                    Thread.Sleep(500);
                                    battle.CurrentCharacterGearInventoryHitChance = battle.HeroesPartyGearInventoryHitChance.CharacterGearInventoryHitChances[i];
                                    gamesStatusHitChance.GamesStatusHitChance(battle, battle.MonstersPartyGearInventoryHitChances[j]);
                                    Console.WriteLine($"Player {battle.CurrentPlayer.Name} please select {battle.CurrentCharacterGearInventoryHitChance.Name}'s action");
                                    if (battle.CurrentPlayer.PlayerType.Equals(PlayerType.Human))
                                    {
                                        CurrentHumanTurn(battle, battle.Expansions);
                                    }
                                    else
                                    {
                                        CurrentTurn(battle, battle.Expansions);
                                    }
                                    if (battle.MonstersPartyGearInventoryHitChances[j].CharacterGearInventoryHitChances.Count == 0)
                                    {
                                        availableTargets = false;
                                        i = battle.HeroesPartyGearInventoryHitChance.CharacterGearInventoryHitChances.Count;
                                    }
                                }
                                if (availableTargets == false)
                                {
                                    if (battle.Expansions.Equals("0234") || battle.Expansions.Equals("01234"))
                                    {
                                        stolenInventories.StolenInventory(battle, battle.MonstersPartyGearInventoryHitChances[j], battle.CurrentPartyGearInventoryHitChance);
                                    }
                                    battle.MonstersPartyGearInventoryHitChances.RemoveAt(j);
                                    j--;
                                    break;
                                }
                                Thread.Sleep(500);
                                SetCurrent(battle, 1, j, battle.Expansions);
                                for (int i = 0; i < battle.MonstersPartyGearInventoryHitChances[battle.CurrentMonsterPartyNumber].CharacterGearInventoryHitChances.Count; i++)
                                {
                                    Thread.Sleep(500);
                                    battle.CurrentCharacterGearInventoryHitChance = battle.MonstersPartyGearInventoryHitChances[battle.CurrentMonsterPartyNumber].CharacterGearInventoryHitChances[i];
                                    gamesStatusHitChance.GamesStatusHitChance(battle, battle.MonstersPartyGearInventoryHitChances[j]);
                                    Console.WriteLine($"Player {battle.CurrentPlayer.Name} please select {battle.CurrentCharacterGearInventoryHitChance.Name}'s action");
                                    if (battle.CurrentPlayer.PlayerType.Equals(PlayerType.Human))
                                    {
                                        CurrentHumanTurn(battle, battle.Expansions);
                                    }
                                    else
                                    {
                                        CurrentTurn(battle, battle.Expansions);
                                    }
                                    if (battle.HeroesPartyGearInventoryHitChance.CharacterGearInventoryHitChances.Count == 0)
                                    {
                                        availableTargets = false;
                                        i = battle.MonstersPartyGearInventoryHitChances[j].CharacterGearInventoryHitChances.Count;
                                    }
                                }
                                if (availableTargets == false)
                                {
                                    break;
                                }
                            }
                        }
                        if (battle.MonstersPartyGearInventoryHitChances.Count == 0)
                        {
                            Console.WriteLine("The Heroes won! The Uncoded One has been defeated!");
                        }
                        else if (battle.HeroesPartyGearInventoryHitChance.CharacterGearInventoryHitChances.Count == 0)
                        {
                            Console.WriteLine("The Heros lost! The Uncoded One prevailed!");
                        }
                        break;
                    }
                // vin fletcher expansion
                case "04":
                    {
                        for (int j = 0; j < battle.Monsters.Count; j++)
                        {
                            battle.CurrentMonsterPartyNumber = j;
                            while (battle.Monsters[j].CharactersHitChance.Count > 0 && battle.Heroes.CharactersHitChance.Count > 0)
                            {
                                bool availableTargets = true;
                                Thread.Sleep(500);
                                SetCurrent(battle, 0, j, battle.Expansions);
                                for (int i = 0; i < battle.Heroes.CharactersHitChance.Count; i++)
                                {
                                    Thread.Sleep(500);
                                    battle.CurrentCharacterHitChance = battle.Heroes.CharactersHitChance[i];
                                    gamesStatusHitChance.GamesStatusHitChance(battle, battle.Monsters[j]);
                                    Console.WriteLine($"Player {battle.CurrentPlayer.Name} please select {battle.CurrentCharacterHitChance.Name}'s action");
                                    if (battle.CurrentPlayer.PlayerType.Equals(PlayerType.Human))
                                    {
                                        CurrentHumanTurn(battle, battle.Expansions);
                                    }
                                    else
                                    {
                                        CurrentTurn(battle, battle.Expansions);
                                    }
                                    if (battle.Monsters[j].CharactersHitChance.Count == 0)
                                    {
                                        availableTargets = false;
                                        i = battle.Heroes.CharactersHitChance.Count;
                                    }
                                }
                                if (availableTargets == false)
                                {
                                    battle.Monsters.RemoveAt(j);
                                    j--;
                                    break;
                                }
                                Thread.Sleep(500);
                                SetCurrent(battle, 1, j, battle.Expansions);
                                for (int i = 0; i < battle.Monsters[battle.CurrentMonsterPartyNumber].CharactersHitChance.Count; i++)
                                {
                                    Thread.Sleep(500);
                                    battle.CurrentCharacterHitChance = battle.Monsters[battle.CurrentMonsterPartyNumber].CharactersHitChance[i];
                                    gamesStatusHitChance.GamesStatusHitChance(battle, battle.Monsters[j]);
                                    Console.WriteLine($"Player {battle.CurrentPlayer.Name} please select {battle.CurrentCharacterHitChance.Name}'s action");
                                    if (battle.CurrentPlayer.PlayerType.Equals(PlayerType.Human))
                                    {
                                        CurrentHumanTurn(battle, battle.Expansions);
                                    }
                                    else
                                    {
                                        CurrentTurn(battle, battle.Expansions);
                                    }
                                    if (battle.Heroes.CharactersHitChance.Count == 0)
                                    {
                                        availableTargets = false;
                                        i = battle.Monsters[j].CharactersHitChance.Count;
                                    }
                                }
                                if (availableTargets == false)
                                {
                                    break;
                                }
                            }
                        }
                        if (battle.Monsters.Count == 0)
                        {
                            Console.WriteLine("The Heroes won! The Uncoded One has been defeated!");
                        }
                        else if (battle.Heroes.CharactersHitChance.Count == 0)
                        {
                            Console.WriteLine("The Heros lost! The Uncoded One prevailed!");
                        }
                        break;
                    }
                // attack modifiers expansion
                case "05":
                    {
                        for (int j = 0; j < battle.Monsters.Count; j++)
                        {
                            battle.CurrentMonsterPartyNumber = j;
                            while (battle.Monsters[j].CharactersAttackModifier.Count > 0 && battle.Heroes.CharactersAttackModifier.Count > 0)
                            {
                                bool availableTargets = true;
                                Thread.Sleep(500);
                                SetCurrent(battle, 0, j, battle.Expansions);
                                for (int i = 0; i < battle.Heroes.CharactersAttackModifier.Count; i++)
                                {
                                    Thread.Sleep(500);
                                    battle.CurrentCharacterAttackModifier = battle.Heroes.CharactersAttackModifier[i];
                                    gamesStatusAttackModifier.GamesStatus(battle, battle.Monsters[j], battle.Expansions);
                                    Console.WriteLine($"Player {battle.CurrentPlayer.Name} please select {battle.CurrentCharacterAttackModifier.Name}'s action");
                                    if (battle.CurrentPlayer.PlayerType.Equals(PlayerType.Human))
                                    {
                                        CurrentHumanTurn(battle, battle.Expansions);
                                    }
                                    else
                                    {
                                        CurrentTurn(battle, battle.Expansions);
                                    }
                                    if (battle.Monsters[j].CharactersAttackModifier.Count == 0)
                                    {
                                        availableTargets = false;
                                        i = battle.Heroes.CharactersAttackModifier.Count;
                                    }
                                }
                                if (availableTargets == false)
                                {
                                    battle.Monsters.RemoveAt(j);
                                    j--;
                                    break;
                                }
                                Thread.Sleep(500);
                                SetCurrent(battle, 1, j, battle.Expansions);
                                for (int i = 0; i < battle.Monsters[battle.CurrentMonsterPartyNumber].CharactersAttackModifier.Count; i++)
                                {
                                    Thread.Sleep(500);
                                    battle.CurrentCharacterAttackModifier = battle.Monsters[battle.CurrentMonsterPartyNumber].CharactersAttackModifier[i];
                                    gamesStatusAttackModifier.GamesStatus(battle, battle.Monsters[j], battle.Expansions);
                                    Console.WriteLine($"Player {battle.CurrentPlayer.Name} please select {battle.CurrentCharacterAttackModifier.Name}'s action");
                                    if (battle.CurrentPlayer.PlayerType.Equals(PlayerType.Human))
                                    {
                                        CurrentHumanTurn(battle, battle.Expansions);
                                    }
                                    else
                                    {
                                        CurrentTurn(battle, battle.Expansions);
                                    }
                                    if (battle.Heroes.CharactersAttackModifier.Count == 0)
                                    {
                                        availableTargets = false;
                                        i = battle.Monsters[j].CharactersAttackModifier.Count;
                                    }
                                }
                                if (availableTargets == false)
                                {
                                    break;
                                }
                            }
                        }
                        if (battle.Monsters.Count == 0)
                        {
                            Console.WriteLine("The Heroes won! The Uncoded One has been defeated!");
                        }
                        else if (battle.Heroes.CharactersAttackModifier.Count == 0)
                        {
                            Console.WriteLine("The Heros lost! The Uncoded One prevailed!");
                        }
                        break;
                    }
                // items and attack modifiers expansions
                case "015":
                // items, stolen inventory and attack modifiers expansions
                case "0135":
                    {
                        for (int j = 0; j < battle.MonstersPartyAttackModifierItemInventory.Count; j++)
                        {
                            battle.CurrentMonsterPartyNumber = j;
                            while (battle.MonstersPartyAttackModifierItemInventory[j].CharacterAttackModifiers.Count > 0 && battle.HeroesPartyAttackModifierItemInventory.CharacterAttackModifiers.Count > 0)
                            {
                                bool availableTargets = true;
                                Thread.Sleep(500);
                                SetCurrent(battle, 0, j, battle.Expansions);
                                for (int i = 0; i < battle.HeroesPartyAttackModifierItemInventory.CharacterAttackModifiers.Count; i++)
                                {
                                    Thread.Sleep(500);
                                    battle.CurrentCharacterAttackModifier = battle.HeroesPartyAttackModifierItemInventory.CharacterAttackModifiers[i];
                                    gamesStatusAttackModifier.GamesStatus(battle, battle.MonstersPartyAttackModifierItemInventory[j]);
                                    Console.WriteLine($"Player {battle.CurrentPlayer.Name} please select {battle.CurrentCharacterAttackModifier.Name}'s action");
                                    if (battle.CurrentPlayer.PlayerType.Equals(PlayerType.Human))
                                    {
                                        CurrentHumanTurn(battle, battle.Expansions);
                                    }
                                    else
                                    {
                                        CurrentTurn(battle, battle.Expansions);
                                    }
                                    if (battle.MonstersPartyAttackModifierItemInventory[j].CharacterAttackModifiers.Count == 0)
                                    {
                                        availableTargets = false;
                                        i = battle.HeroesPartyAttackModifierItemInventory.CharacterAttackModifiers.Count;
                                    }
                                }
                                if (availableTargets == false)
                                {
                                    battle.MonstersPartyAttackModifierItemInventory.RemoveAt(j);
                                    j--;
                                    break;
                                }
                                Thread.Sleep(500);
                                SetCurrent(battle, 1, j, battle.Expansions);
                                for (int i = 0; i < battle.MonstersPartyAttackModifierItemInventory[battle.CurrentMonsterPartyNumber].CharacterAttackModifiers.Count; i++)
                                {
                                    Thread.Sleep(500);
                                    battle.CurrentCharacterAttackModifier = battle.MonstersPartyAttackModifierItemInventory[battle.CurrentMonsterPartyNumber].CharacterAttackModifiers[i];
                                    gamesStatusAttackModifier.GamesStatus(battle, battle.MonstersPartyAttackModifierItemInventory[j]);
                                    Console.WriteLine($"Player {battle.CurrentPlayer.Name} please select {battle.CurrentCharacterAttackModifier.Name}'s action");
                                    if (battle.CurrentPlayer.PlayerType.Equals(PlayerType.Human))
                                    {
                                        CurrentHumanTurn(battle, battle.Expansions);
                                    }
                                    else
                                    {
                                        CurrentTurn(battle, battle.Expansions);
                                    }
                                    if (battle.HeroesPartyAttackModifierItemInventory.CharacterAttackModifiers.Count == 0)
                                    {
                                        availableTargets = false;
                                        i = battle.MonstersPartyAttackModifierItemInventory[j].CharacterAttackModifiers.Count;
                                    }
                                }
                                if (availableTargets == false)
                                {
                                    break;
                                }
                            }
                        }
                        if (battle.MonstersPartyAttackModifierItemInventory.Count == 0)
                        {
                            Console.WriteLine("The Heroes won! The Uncoded One has been defeated!");
                        }
                        else if (battle.HeroesPartyAttackModifierItemInventory.CharacterAttackModifiers.Count == 0)
                        {
                            Console.WriteLine("The Heros lost! The Uncoded One prevailed!");
                        }
                        break;
                    }
                // gear and attack modifier expansions
                case "025":
                // gear, stolen inventory and attack modifier expansions
                case "0235":
                // gear, items and attack modifier expansions
                case "0125":
                // gear, items, stolen inventory and attack modifier expansions
                case "01235":
                    {
                        for (int j = 0; j < battle.MonstersPartyAttackModifierGearInventory.Count; j++)
                        {
                            battle.CurrentMonsterPartyNumber = j;
                            while (battle.MonstersPartyAttackModifierGearInventory[j].CharacterAttackModifiersGearInventory.Count > 0 && battle.HeroesPartyAttackModifierGearInventory.CharacterAttackModifiersGearInventory.Count > 0)
                            {
                                bool availableTargets = true;
                                Thread.Sleep(500);
                                SetCurrent(battle, 0, j, battle.Expansions);
                                for (int i = 0; i < battle.HeroesPartyAttackModifierGearInventory.CharacterAttackModifiersGearInventory.Count; i++)
                                {
                                    Thread.Sleep(500);
                                    battle.CurrentCharacterAttackModifierGearInventory = battle.HeroesPartyAttackModifierGearInventory.CharacterAttackModifiersGearInventory[i];
                                    gamesStatusAttackModifier.GamesStatus(battle, battle.MonstersPartyAttackModifierGearInventory[j]);
                                    Console.WriteLine($"Player {battle.CurrentPlayer.Name} please select {battle.CurrentCharacterAttackModifierGearInventory.Name}'s action");
                                    if (battle.CurrentPlayer.PlayerType.Equals(PlayerType.Human))
                                    {
                                        CurrentHumanTurn(battle, battle.Expansions);
                                    }
                                    else
                                    {
                                        CurrentTurn(battle, battle.Expansions);
                                    }
                                    if (battle.MonstersPartyAttackModifierGearInventory[j].CharacterAttackModifiersGearInventory.Count == 0)
                                    {
                                        availableTargets = false;
                                        i = battle.HeroesPartyAttackModifierGearInventory.CharacterAttackModifiersGearInventory.Count;
                                    }
                                }
                                if (availableTargets == false)
                                {
                                    if (battle.Expansions.Equals("0235") || battle.Expansions.Equals("01235")/* || battle.Expansions.Equals("0234") || battle.Expansions.Equals("01234")*/)
                                    {
                                        stolenInventories.StolenInventory(battle, battle.MonstersPartyAttackModifierGearInventory[j], battle.CurrentPartyAttackModifierGearInventory);
                                    }
                                    battle.MonstersPartyAttackModifierGearInventory.RemoveAt(j);
                                    j--;
                                    break;
                                }
                                Thread.Sleep(500);
                                SetCurrent(battle, 1, j, battle.Expansions);
                                for (int i = 0; i < battle.MonstersPartyAttackModifierGearInventory[battle.CurrentMonsterPartyNumber].CharacterAttackModifiersGearInventory.Count; i++)
                                {
                                    Thread.Sleep(500);
                                    battle.CurrentCharacterAttackModifierGearInventory = battle.MonstersPartyAttackModifierGearInventory[battle.CurrentMonsterPartyNumber].CharacterAttackModifiersGearInventory[i];
                                    gamesStatusAttackModifier.GamesStatus(battle, battle.MonstersPartyAttackModifierGearInventory[j]);
                                    Console.WriteLine($"Player {battle.CurrentPlayer.Name} please select {battle.CurrentPartyAttackModifierGearInventory.Name}'s action");
                                    if (battle.CurrentPlayer.PlayerType.Equals(PlayerType.Human))
                                    {
                                        CurrentHumanTurn(battle, battle.Expansions);
                                    }
                                    else
                                    {
                                        CurrentTurn(battle, battle.Expansions);
                                    }
                                    if (battle.HeroesPartyAttackModifierGearInventory.CharacterAttackModifiersGearInventory.Count == 0)
                                    {
                                        availableTargets = false;
                                        i = battle.MonstersPartyAttackModifierGearInventory[j].CharacterAttackModifiersGearInventory.Count;
                                    }
                                }
                                if (availableTargets == false)
                                {
                                    if (battle.Expansions.Equals("0235") || battle.Expansions.Equals("01235")/* || battle.Expansions.Equals("0234") || battle.Expansions.Equals("01234")*/)
                                    {
                                        stolenInventories.StolenInventory(battle, battle.HeroesPartyAttackModifierGearInventory, battle.CurrentPartyAttackModifierGearInventory);
                                    }
                                    //battle.MonstersPartyAttackModifierGearInventory.RemoveAt(j);
                                    //j--;
                                    break;
                                }
                            }
                        }
                        if (battle.MonstersPartyAttackModifierGearInventory.Count == 0)
                        {
                            Console.WriteLine("The Heroes won! The Uncoded One has been defeated!");
                        }
                        else if (battle.HeroesPartyAttackModifierGearInventory.CharacterAttackModifiersGearInventory.Count == 0)
                        {
                            Console.WriteLine("The Heros lost! The Uncoded One prevailed!");
                        }
                        break;
                    }
                // vin flecther and attack modifiers expansions
                case "045":
                    {
                        for (int j = 0; j < battle.Monsters.Count; j++)
                        {
                            battle.CurrentMonsterPartyNumber = j;
                            while (battle.Monsters[j].CharactersAttackModifierHitChance.Count > 0 && battle.Heroes.CharactersAttackModifierHitChance.Count > 0)
                            {
                                bool availableTargets = true;
                                Thread.Sleep(500);
                                SetCurrent(battle, 0, j, battle.Expansions);
                                for (int i = 0; i < battle.Heroes.CharactersAttackModifierHitChance.Count; i++)
                                {
                                    Thread.Sleep(500);
                                    battle.CurrentCharacterAttackModifierHitChance = battle.Heroes.CharactersAttackModifierHitChance[i];
                                    gamesStatusAttackModifier.GamesStatus(battle, battle.Monsters[j], battle.Expansions);
                                    Console.WriteLine($"Player {battle.CurrentPlayer.Name} please select {battle.CurrentCharacterAttackModifierHitChance.Name}'s action");
                                    if (battle.CurrentPlayer.PlayerType.Equals(PlayerType.Human))
                                    {
                                        CurrentHumanTurn(battle, battle.Expansions);
                                    }
                                    else
                                    {
                                        CurrentTurn(battle, battle.Expansions);
                                    }
                                    if (battle.Monsters[j].CharactersAttackModifierHitChance.Count == 0)
                                    {
                                        availableTargets = false;
                                        i = battle.Heroes.CharactersAttackModifierHitChance.Count;
                                    }
                                }
                                if (availableTargets == false)
                                {
                                    battle.Monsters.RemoveAt(j);
                                    j--;
                                    break;
                                }
                                Thread.Sleep(500);
                                SetCurrent(battle, 1, j, battle.Expansions);
                                for (int i = 0; i < battle.Monsters[battle.CurrentMonsterPartyNumber].CharactersAttackModifierHitChance.Count; i++)
                                {
                                    Thread.Sleep(500);
                                    battle.CurrentCharacterAttackModifierHitChance = battle.Monsters[battle.CurrentMonsterPartyNumber].CharactersAttackModifierHitChance[i];
                                    gamesStatusAttackModifier.GamesStatus(battle, battle.Monsters[j], battle.Expansions);
                                    Console.WriteLine($"Player {battle.CurrentPlayer.Name} please select {battle.CurrentCharacterAttackModifierHitChance.Name}'s action");
                                    if (battle.CurrentPlayer.PlayerType.Equals(PlayerType.Human))
                                    {
                                        CurrentHumanTurn(battle, battle.Expansions);
                                    }
                                    else
                                    {
                                        CurrentTurn(battle, battle.Expansions);
                                    }
                                    if (battle.Heroes.CharactersAttackModifierHitChance.Count == 0)
                                    {
                                        availableTargets = false;
                                        i = battle.Monsters[j].CharactersAttackModifierHitChance.Count;
                                    }
                                }
                                if (availableTargets == false)
                                {
                                    break;
                                }
                            }
                        }
                        if (battle.Monsters.Count == 0)
                        {
                            Console.WriteLine("The Heroes won! The Uncoded One has been defeated!");
                        }
                        else if (battle.Heroes.CharactersAttackModifierHitChance.Count == 0)
                        {
                            Console.WriteLine("The Heros lost! The Uncoded One prevailed!");
                        }
                        break;
                    }
                // items, vin flecther and attack modifiers expansions
                case "0145":
                // items, stolen inventory, vin fletcher and attack modifiers expansions
                case "01345":
                    {
                        for (int j = 0; j < battle.MonstersItemInventoryHitChance.Count; j++)
                        {
                            battle.CurrentMonsterPartyNumber = j;
                            while (battle.MonstersItemInventoryHitChance[j].CharactersAttackModifierHitChance.Count > 0 && battle.HeroesItemInventoryHitChance.CharactersAttackModifierHitChance.Count > 0)
                            {
                                bool availableTargets = true;
                                Thread.Sleep(500);
                                SetCurrent(battle, 0, j, battle.Expansions);
                                for (int i = 0; i < battle.HeroesItemInventoryHitChance.CharactersAttackModifierHitChance.Count; i++)
                                {
                                    Thread.Sleep(500);
                                    battle.CurrentCharacterAttackModifierHitChance = battle.HeroesItemInventoryHitChance.CharactersAttackModifierHitChance[i];
                                    gamesStatusAttackModifier.GamesStatusHitChance(battle, battle.MonstersItemInventoryHitChance[j]);
                                    Console.WriteLine($"Player {battle.CurrentPlayer.Name} please select {battle.CurrentCharacterAttackModifierHitChance.Name}'s action");
                                    if (battle.CurrentPlayer.PlayerType.Equals(PlayerType.Human))
                                    {
                                        CurrentHumanTurn(battle, battle.Expansions);
                                    }
                                    else
                                    {
                                        CurrentTurn(battle, battle.Expansions);
                                    }
                                    if (battle.MonstersItemInventoryHitChance[j].CharactersAttackModifierHitChance.Count == 0)
                                    {
                                        availableTargets = false;
                                        i = battle.HeroesItemInventoryHitChance.CharactersAttackModifierHitChance.Count;
                                    }
                                }
                                if (availableTargets == false)
                                {
                                    if (battle.Expansions.Equals("01345"))
                                    {
                                        stolenInventories.StolenInventory(battle, battle.MonstersItemInventoryHitChance[j], battle.CurrentPartyItemInventoryHitChance);
                                    }
                                    battle.MonstersItemInventoryHitChance.RemoveAt(j);
                                    j--;
                                    break;
                                }
                                Thread.Sleep(500);
                                SetCurrent(battle, 1, j, battle.Expansions);
                                for (int i = 0; i < battle.MonstersItemInventoryHitChance[battle.CurrentMonsterPartyNumber].CharactersAttackModifierHitChance.Count; i++)
                                {
                                    Thread.Sleep(500);
                                    battle.CurrentCharacterAttackModifierHitChance = battle.MonstersItemInventoryHitChance[battle.CurrentMonsterPartyNumber].CharactersAttackModifierHitChance[i];
                                    gamesStatusAttackModifier.GamesStatusHitChance(battle, battle.MonstersItemInventoryHitChance[j]);
                                    Console.WriteLine($"Player {battle.CurrentPlayer.Name} please select {battle.CurrentCharacterAttackModifierHitChance.Name}'s action");
                                    if (battle.CurrentPlayer.PlayerType.Equals(PlayerType.Human))
                                    {
                                        CurrentHumanTurn(battle, battle.Expansions);
                                    }
                                    else
                                    {
                                        CurrentTurn(battle, battle.Expansions);
                                    }
                                    if (battle.HeroesItemInventoryHitChance.CharactersAttackModifierHitChance.Count == 0)
                                    {
                                        availableTargets = false;
                                        i = battle.MonstersItemInventoryHitChance[j].CharactersAttackModifierHitChance.Count;
                                    }
                                }
                                if (availableTargets == false)
                                {
                                    break;
                                }
                            }
                        }
                        if (battle.MonstersItemInventoryHitChance.Count == 0)
                        {
                            Console.WriteLine("The Heroes won! The Uncoded One has been defeated!");
                        }
                        else if (battle.HeroesItemInventoryHitChance.CharactersAttackModifierHitChance.Count == 0)
                        {
                            Console.WriteLine("The Heros lost! The Uncoded One prevailed!");
                        }
                        break;
                    }
                // game's status expansion
                default:
                    {
                        for (int j = 0; j < battle.Monsters.Count; j++)
                        {
                            battle.CurrentMonsterPartyNumber = j;
                            while (battle.Monsters[j].Characters.Count > 0 && battle.Heroes.Characters.Count > 0)
                            {
                                bool availableTargets = true;
                                Thread.Sleep(500);
                                SetCurrent(battle, 0, j, battle.Expansions);
                                for (int i = 0; i < battle.Heroes.Characters.Count; i++)
                                {
                                    Thread.Sleep(500);
                                    battle.CurrentCharacter = battle.Heroes.Characters[i];
                                    gamesStatus.GamesStatus(battle, battle.Monsters[j]);
                                    Console.WriteLine($"Player {battle.CurrentPlayer.Name} please select {battle.CurrentCharacter.Name}'s action");
                                    if (battle.CurrentPlayer.PlayerType.Equals(PlayerType.Human))
                                    {
                                        CurrentHumanTurn(battle, battle.Expansions);
                                    }
                                    else
                                    {
                                        CurrentTurn(battle, battle.Expansions);
                                    }
                                    if (battle.Monsters[j].Characters.Count == 0)
                                    {
                                        availableTargets = false;
                                        i = battle.Heroes.Characters.Count;
                                    }
                                }
                                if (availableTargets == false)
                                {
                                    battle.Monsters.RemoveAt(j);
                                    j--;
                                    break;
                                }
                                Thread.Sleep(500);
                                SetCurrent(battle, 1, j, battle.Expansions);
                                for (int i = 0; i < battle.Monsters[battle.CurrentMonsterPartyNumber].Characters.Count; i++)
                                {
                                    Thread.Sleep(500);
                                    battle.CurrentCharacter = battle.Monsters[battle.CurrentMonsterPartyNumber].Characters[i];
                                    gamesStatus.GamesStatus(battle, battle.Monsters[j]);
                                    Console.WriteLine($"Player {battle.CurrentPlayer.Name} please select {battle.CurrentCharacter.Name}'s action");
                                    if (battle.CurrentPlayer.PlayerType.Equals(PlayerType.Human))
                                    {
                                        CurrentHumanTurn(battle, battle.Expansions);
                                    }
                                    else
                                    {
                                        CurrentTurn(battle, battle.Expansions);
                                    }
                                    if (battle.Heroes.Characters.Count == 0)
                                    {
                                        availableTargets = false;
                                        i = battle.Monsters[j].Characters.Count;
                                    }
                                }
                                if (availableTargets == false)
                                {
                                    break;
                                }
                            }
                        }
                        if (battle.Monsters.Count == 0)
                        {
                            Console.WriteLine("The Heroes won! The Uncoded One has been defeated!");
                        }
                        else if (battle.Heroes.Characters.Count == 0)
                        {
                            Console.WriteLine("The Heros lost! The Uncoded One prevailed!");
                        }
                        break;
                    }
            }
        }

        public static void CurrentHumanTurn(Battle battle, string strExpansions)
        {
            DoNothingAll doNothingAll = new DoNothingAll();
            BasicAttackAll basicAttackAll = new BasicAttackAll();
            Heal10PotionAll heal10PotionAll = new Heal10PotionAll();
            AttackGearAll gearAttack = new AttackGearAll();
            EquipAll equipAll = new EquipAll();
            string name = "";
            //int selectedAction = -1;
            ActionTypes selectedAction = ActionTypes.NOTHING;
            switch (strExpansions)
            {
                // items expansion
                case "01":
                // items and stolen inventory expansions
                case "013":
                    {
                        name = battle.CurrentCharacter.Name;
                        selectedAction = GetSelectedAction(battle.CurrentCharacter);
                        break;
                    }
                // vin fletcher expansion
                case "04":
                // items and vin fletcher expansions
                case "014":
                // items, stolen inventory and vin fletcher expansions
                case "0134":
                    {
                        name = battle.CurrentCharacterHitChance.Name;
                        selectedAction = GetSelectedAction(battle.CurrentCharacterHitChance);
                        break;
                    }
                // gear expansion
                case "02":
                // gear and stolen inventory expansions
                case "023":
                // items and gear expansions
                case "012":
                // items, gear and stolen inventory expansions
                case "0123":
                    {
                        name = battle.CurrentCharacterGearInventory.Name;
                        Character currentCharacter = battle.CurrentCharacterGearInventory;
                        selectedAction = GetSelectedAction(currentCharacter);
                        break;
                    }
                // gear and vin fletcher expansions
                case "024":
                // gear, stolen inventory and vin fletcher expansions
                case "0234":
                // items, gear and vin fletcher expansions
                case "0124":
                // items, gear, stolen inventory and vin fletcher expansions
                case "01234":
                    {
                        name = battle.CurrentCharacterGearInventoryHitChance.Name;
                        CharacterHitChance currentCharacter = battle.CurrentCharacterGearInventoryHitChance;
                        selectedAction = GetSelectedAction(currentCharacter);
                        break;
                    }
                // gear and attack modifiers expansions
                case "025":
                // gear, stolen inventory and attack modifiers expansions
                case "0235":
                // items, gear and attack modifiers expansions
                case "0125":
                // items, gear, stolen inventory and attack modifiers expansions
                case "01235":
                    {
                        name = battle.CurrentCharacterAttackModifierGearInventory.Name;
                        Character currentCharacter = battle.CurrentCharacterAttackModifierGearInventory;
                        selectedAction = GetSelectedAction(currentCharacter);
                        break;
                    }
                // vin fletcher and attack modifiers expansions
                case "045":
                // items, vin fletcher and attack modifiers expansions
                case "0145":
                // items, stolen inventory, vin fletcher and attack modifiers expansions
                case "01345":
                    {
                        name = battle.CurrentCharacterAttackModifierHitChance.Name;
                        selectedAction = GetSelectedAction(battle.CurrentCharacterAttackModifierHitChance);
                        break;
                    }
                // game's status only expansion
                // attack modifiers expansion
                default:
                    {
                        name = battle.CurrentCharacter.Name;
                        selectedAction = GetSelectedAction(battle.CurrentCharacter);
                        break;
                    }
            }
            switch (selectedAction)
            {
                case ActionTypes.NOTHING:
                    {
                        switch (strExpansions)
                        {
                            // gear expansion
                            case "02":
                            // gear and stolen inventory expansions
                            case "023":
                            // items and gear expansions
                            case "012":
                            // items, gear and stolen inventory expansions
                            case "0123":
                                {
                                    int i = battle.CurrentCharacterGearInventory.AvailableActions.FindIndex(x => x.ActionType == selectedAction);
                                    doNothingAll.Actions(battle, name, battle.CurrentCharacterGearInventory.AvailableActions[i].ActionType, battle.Expansions);
                                    break;
                                }
                            // gear and vin fletcher expansions
                            case "024":
                            // gear, stolen inventory and vin fletcher expansions
                            case "0234":
                            // items, gear and vin fletcher expansions
                            case "0124":
                            // items, gear, stolen inventory and vin fletcher expansions
                            case "01234":
                                {
                                    int i = battle.CurrentCharacterGearInventoryHitChance.AvailableActionHitChances.FindIndex(x => x.ActionType == selectedAction);
                                    doNothingAll.Actions(battle, name, battle.CurrentCharacterGearInventoryHitChance.AvailableActionHitChances[i].ActionType, battle.Expansions);
                                    break;
                                }
                            // vin fletcher expansion
                            case "04":
                            // items and vin fletcher expansions
                            case "014":
                            // items, stolen inventory and vin fletcher expansions
                            case "0134":
                                {
                                    int i = battle.CurrentCharacterHitChance.AvailableActionHitChances.FindIndex(x => x.ActionType == selectedAction);
                                    doNothingAll.Actions(battle, name, battle.CurrentCharacterHitChance.AvailableActionHitChances[i].ActionType, battle.Expansions);
                                    break;
                                }
                            // gear and attack modifiers expansions
                            case "025":
                            // gear, stolen inventory and attack modifiers expansions
                            case "0235":
                            // items, gear and attack modifiers expansions
                            case "0125":
                            // items, gear, stolen inventory and attack modifiers expansions
                            case "01235":
                                {
                                    int i = battle.CurrentCharacterAttackModifierGearInventory.AvailableActions.FindIndex(x => x.ActionType == selectedAction);
                                    doNothingAll.Actions(battle, name, battle.CurrentCharacterAttackModifierGearInventory.AvailableActions[i].ActionType, battle.Expansions);
                                    break;
                                }
                            // vin fletcher and attack modifiers expansions
                            case "045":
                            // items, vin fletcher and attack modifiers expansions
                            case "0145":
                            // items, stolen inventory, vin fletcher and attack modifiers expansions
                            case "01345":
                                {
                                    int i = battle.CurrentCharacterAttackModifierHitChance.AvailableActionHitChances.FindIndex(x => x.ActionType == selectedAction);
                                    doNothingAll.Actions(battle, name, battle.CurrentCharacterAttackModifierHitChance.AvailableActionHitChances[i].ActionType, battle.Expansions);
                                    break;
                                }
                            // game's status only expansion
                            // items expansion
                            // items and stolen inventory expansions
                            // attack modifiers expansion
                            default:
                                {
                                    int i = battle.CurrentCharacter.AvailableActions.FindIndex(x => x.ActionType == selectedAction);
                                    doNothingAll.Actions(battle, name, battle.CurrentCharacter.AvailableActions[i].ActionType, battle.Expansions);
                                    break;
                                }
                        }
                        break;
                    }
                case ActionTypes.ATTACK:
                    {
                        switch (strExpansions)
                        {
                            // vin fletcher expansion
                            case "04":
                                {
                                    Party p = GetOtherParty(battle, strExpansions);
                                    Console.WriteLine("Please select the tatget character from the following list of characters:");
                                    for (int j = 0; j < p.CharactersHitChance.Count; j++)
                                    {
                                        Console.WriteLine($"{j}: {p.CharactersHitChance[j].Name}");
                                    }
                                    int selectedTarget = -1;
                                    while (selectedTarget < 0 || selectedTarget >= p.CharactersHitChance.Count)
                                    {
                                        try
                                        {
                                            selectedTarget = Convert.ToInt32(Console.ReadLine());
                                            if (selectedTarget < 0 || selectedTarget >= p.CharactersHitChance.Count)
                                            {
                                                Console.WriteLine($"You must select a number between 0 and {p.CharactersHitChance.Count - 1}");
                                            }
                                        }
                                        catch (Exception e)
                                        {
                                            Console.WriteLine(e.Message);
                                        }
                                    }
                                    int i = battle.CurrentCharacterHitChance.AvailableActionHitChances.FindIndex(x => x.ActionType == selectedAction);
                                    basicAttackAll.Actions(battle, battle.CurrentCharacterHitChance, p.CharactersHitChance[selectedTarget], battle.CurrentCharacterHitChance.AvailableActionHitChances[i].ActionType, strExpansions);
                                    break;
                                }
                            // items and vin fletcher expansions
                            case "014":
                            // items, stolen inventory and vin fletcher expansions
                            case "0134":
                                {
                                    PartyItemInventoryHitChance p = (PartyItemInventoryHitChance)GetOtherParty(battle, strExpansions);
                                    Console.WriteLine("Please select the tatget character from the following list of characters:");
                                    for (int j = 0; j < p.CharactersHitChance.Count; j++)
                                    {
                                        Console.WriteLine($"{j}: {p.CharactersHitChance[j].Name}");
                                    }
                                    int selectedTarget = -1;
                                    while (selectedTarget < 0 || selectedTarget >= p.CharactersHitChance.Count)
                                    {
                                        try
                                        {
                                            selectedTarget = Convert.ToInt32(Console.ReadLine());
                                            if (selectedTarget < 0 || selectedTarget >= p.CharactersHitChance.Count)
                                            {
                                                Console.WriteLine($"You must select a number between 0 and {p.CharactersHitChance.Count - 1}");
                                            }
                                        }
                                        catch (Exception e)
                                        {
                                            Console.WriteLine(e.Message);
                                        }
                                    }
                                    int i = battle.CurrentCharacterHitChance.AvailableActionHitChances.FindIndex(x => x.ActionType == selectedAction);
                                    basicAttackAll.Actions(battle, battle.CurrentCharacterHitChance, p.CharactersHitChance[selectedTarget], battle.CurrentCharacterHitChance.AvailableActionHitChances[i].ActionType, strExpansions);
                                    break;
                                }
                            // gear expansion
                            case "02":
                            // gear and stolen inventory expansions
                            case "023":
                            // items and gear expansions
                            case "012":
                            // items, gear and stolen inventory expansions
                            case "0123":
                                {
                                    object[] obj = GetAttackTarget(battle, strExpansions);
                                    PartyGearInventory p = (PartyGearInventory)obj[0];
                                    int selectedTarget = (int)obj[1];
                                    int i = battle.CurrentCharacterGearInventory.AvailableActions.FindIndex(x => x.ActionType == selectedAction);
                                    basicAttackAll.Actions(battle, battle.CurrentCharacterGearInventory, p.CharactersGearInventory[selectedTarget], battle.CurrentCharacterGearInventory.AvailableActions[i].ActionType, strExpansions);
                                    break;
                                }
                            // gear and vin fletcher expansions
                            case "024":
                            // gear, stolen inventory and vin fletcher expansions
                            case "0234":
                            // items, gear and vin fletcher expansions
                            case "0124":
                            // items, gear, stolen inventory and vin fletcher expansions
                            case "01234":
                                {
                                    object[] obj = GetAttackTarget(battle, strExpansions);
                                    PartyGearInventoryHitChance p = (PartyGearInventoryHitChance)obj[0];
                                    int selectedTarget = (int)obj[1];
                                    int i = battle.CurrentCharacterGearInventoryHitChance.AvailableActionHitChances.FindIndex(x => x.ActionType == selectedAction);
                                    basicAttackAll.Actions(battle, battle.CurrentCharacterGearInventoryHitChance, p.CharacterGearInventoryHitChances[selectedTarget], battle.CurrentCharacterGearInventoryHitChance.AvailableActionHitChances[i].ActionType, strExpansions);
                                    break;
                                }
                            // attack modifier expansion
                            case "05":
                                {
                                    Party p = GetOtherParty(battle, strExpansions);
                                    Console.WriteLine("Please select the tatget character from the following list of characters:");
                                    for (int j = 0; j < p.CharactersAttackModifier.Count; j++)
                                    {
                                        Console.WriteLine($"{j}: {p.CharactersAttackModifier[j].Name}");
                                    }
                                    int selectedTarget = -1;
                                    while (selectedTarget < 0 || selectedTarget >= p.CharactersAttackModifier.Count)
                                    {
                                        try
                                        {
                                            selectedTarget = Convert.ToInt32(Console.ReadLine());
                                            if (selectedTarget < 0 || selectedTarget >= p.CharactersAttackModifier.Count)
                                            {
                                                Console.WriteLine($"You must select a number between 0 and {p.CharactersAttackModifier.Count - 1}");
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine(ex.Message);
                                        }
                                    }
                                    int i = battle.CurrentCharacterAttackModifier.AvailableActions.FindIndex(x => x.ActionType == selectedAction);
                                    basicAttackAll.Actions(battle, battle.CurrentCharacterAttackModifier, p.CharactersAttackModifier[selectedTarget], battle.CurrentCharacterAttackModifier.AvailableActions[i].ActionType, strExpansions);
                                    break;
                                }
                            // items and attack modifiers expansions
                            case "015":
                            // items, stolen inventory and attack modifiers expansions
                            case "0135":
                                {
                                    PartyAttackModifierItemInventory p = (PartyAttackModifierItemInventory)GetOtherParty(battle, strExpansions);
                                    Console.WriteLine("Please select the tatget character from the following list of characters:");
                                    for (int j = 0; j < p.CharacterAttackModifiers.Count; j++)
                                    {
                                        Console.WriteLine($"{j}: {p.CharacterAttackModifiers[j].Name}");
                                    }
                                    int selectedTarget = -1;
                                    while (selectedTarget < 0 || selectedTarget >= p.CharacterAttackModifiers.Count)
                                    {
                                        try
                                        {
                                            selectedTarget = Convert.ToInt32(Console.ReadLine());
                                            if (selectedTarget < 0 || selectedTarget >= p.CharacterAttackModifiers.Count)
                                            {
                                                Console.WriteLine($"You must select a number between 0 and {p.CharacterAttackModifiers.Count - 1}");
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine(ex.Message);
                                        }
                                    }
                                    int i = battle.CurrentCharacter.AvailableActions.FindIndex(x => x.ActionType == selectedAction);
                                    basicAttackAll.Actions(battle, battle.CurrentCharacter, p.CharacterAttackModifiers[selectedTarget], battle.CurrentCharacter.AvailableActions[i].ActionType, strExpansions);
                                    break;
                                }
                            // gear and attack modifiers expansions
                            case "025":
                            // gear, stolen inventory and attack modifiers expansions
                            case "0235":
                            // items, gear and attack modifiers expansions
                            case "0125":
                            // items, gear, stolen inventory and attack modifiers expansions
                            case "01235":
                                {
                                    object[] obj = GetAttackTarget(battle, strExpansions);
                                    PartyAttackModifierGearInventory p = (PartyAttackModifierGearInventory)obj[0];
                                    int selectedTarget = (int)obj[1];
                                    int i = battle.CurrentCharacterAttackModifierGearInventory.AvailableActions.FindIndex(x => x.ActionType == selectedAction);
                                    basicAttackAll.Actions(battle, battle.CurrentCharacterAttackModifierGearInventory, p.CharacterAttackModifiersGearInventory[selectedTarget], battle.CurrentCharacterAttackModifierGearInventory.AvailableActions[i].ActionType, strExpansions);
                                    break;
                                }
                            // vin fletcher and attack modifiers expansions
                            case "045":
                                {
                                    Party p = GetOtherParty(battle, strExpansions);
                                    Console.WriteLine("Please select the tatget character from the following list of characters:");
                                    for (int j = 0; j < p.CharactersAttackModifierHitChance.Count; j++)
                                    {
                                        Console.WriteLine($"{j}: {p.CharactersAttackModifierHitChance[j].Name}");
                                    }
                                    int selectedTarget = -1;
                                    while (selectedTarget < 0 || selectedTarget >= p.CharactersAttackModifierHitChance.Count)
                                    {
                                        try
                                        {
                                            selectedTarget = Convert.ToInt32(Console.ReadLine());
                                            if (selectedTarget < 0 || selectedTarget >= p.CharactersAttackModifierHitChance.Count)
                                            {
                                                Console.WriteLine($"You must select a number between 0 and {p.CharactersAttackModifierHitChance.Count - 1}");
                                            }
                                        }
                                        catch (Exception e)
                                        {
                                            Console.WriteLine(e.Message);
                                        }
                                    }
                                    int i = battle.CurrentCharacterAttackModifierHitChance.AvailableActionHitChances.FindIndex(x => x.ActionType == selectedAction);
                                    basicAttackAll.Actions(battle, battle.CurrentCharacterAttackModifierHitChance, p.CharactersAttackModifierHitChance[selectedTarget], battle.CurrentCharacterAttackModifierHitChance.AvailableActionHitChances[i].ActionType, strExpansions);
                                    break;
                                }
                            // items, vin fletcher and attack modifiers expansions
                            case "0145":
                            // items, stolen inventory, vin fletcher and attack modifiers expansions
                            case "01345":
                                {
                                    PartyItemInventoryHitChance p = (PartyItemInventoryHitChance)GetOtherParty(battle, strExpansions);
                                    Console.WriteLine("Please select the tatget character from the following list of characters:");
                                    for (int j = 0; j < p.CharactersAttackModifierHitChance.Count; j++)
                                    {
                                        Console.WriteLine($"{j}: {p.CharactersAttackModifierHitChance[j].Name}");
                                    }
                                    int selectedTarget = -1;
                                    while (selectedTarget < 0 || selectedTarget >= p.CharactersAttackModifierHitChance.Count)
                                    {
                                        try
                                        {
                                            selectedTarget = Convert.ToInt32(Console.ReadLine());
                                            if (selectedTarget < 0 || selectedTarget >= p.CharactersAttackModifierHitChance.Count)
                                            {
                                                Console.WriteLine($"You must select a number between 0 and {p.CharactersAttackModifierHitChance.Count - 1}");
                                            }
                                        }
                                        catch (Exception e)
                                        {
                                            Console.WriteLine(e.Message);
                                        }
                                    }
                                    int i = battle.CurrentCharacterAttackModifierHitChance.AvailableActionHitChances.FindIndex(x => x.ActionType == selectedAction);
                                    basicAttackAll.Actions(battle, battle.CurrentCharacterAttackModifierHitChance, p.CharactersAttackModifierHitChance[selectedTarget], battle.CurrentCharacterAttackModifierHitChance.AvailableActionHitChances[i].ActionType, strExpansions);
                                    break;
                                }
                            // game's status expansion
                            // items expansion
                            // items and stolen inventory expansions
                            // items and vin fletcher expansions
                            // items, stolen inventory and vin fletcher expansions
                            default:
                                {
                                    Party p = GetOtherParty(battle, strExpansions);
                                    Console.WriteLine("Please select the tatget character from the following list of characters:");
                                    for (int j = 0; j < p.Characters.Count; j++)
                                    {
                                        Console.WriteLine($"{j}: {p.Characters[j].Name}");
                                    }
                                    int selectedTarget = -1;
                                    while (selectedTarget < 0 || selectedTarget >= p.Characters.Count)
                                    {
                                        try
                                        {
                                            selectedTarget = Convert.ToInt32(Console.ReadLine());
                                            if (selectedTarget < 0 || selectedTarget >= p.Characters.Count)
                                            {
                                                Console.WriteLine($"You must select a number between 0 and {p.Characters.Count - 1}");
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine(ex.Message);
                                        }
                                    }
                                    int i = battle.CurrentCharacter.AvailableActions.FindIndex(x => x.ActionType == selectedAction);
                                    basicAttackAll.Actions(battle, battle.CurrentCharacter, p.Characters[selectedTarget], battle.CurrentCharacter.AvailableActions[i].ActionType, strExpansions);
                                    break;
                                }
                        }
                        break;
                    }
                case ActionTypes.HEAL:
                    {
                        switch (strExpansions)
                        {
                            // items and vin fletcher expansions
                            case "014":
                            // items, stolen inventory and vin fletcher expansions
                            case "0134":
                                {
                                    if (battle.CurrentPartyItemInventoryHitChance.Inventory.Potions.Count > 0)
                                    {
                                        int i = battle.CurrentCharacterHitChance.AvailableActionHitChances.FindIndex(x => x.ActionType == selectedAction);
                                        heal10PotionAll.Actions(battle, battle.CurrentCharacterHitChance, battle.CurrentCharacterHitChance, battle.CurrentCharacterHitChance.AvailableActionHitChances[i].ActionType, strExpansions);
                                    }
                                    else
                                    {
                                        Console.WriteLine("There is no heal potion available, please select again.");
                                        CurrentHumanTurn(battle, strExpansions);
                                    }
                                    break;
                                }
                            // items and gear expansions
                            case "012":
                            // items, gear and stolen inventory expansions
                            case "0123":
                                {
                                    if (battle.CurrentPartyGearInventory.Inventory.Potions.Count > 0)
                                    {
                                        int i = battle.CurrentCharacterGearInventory.AvailableActions.FindIndex(x => x.ActionType == selectedAction);
                                        heal10PotionAll.Actions(battle, battle.CurrentCharacterGearInventory, battle.CurrentCharacterGearInventory, battle.CurrentCharacterGearInventory.AvailableActions[i].ActionType, strExpansions);
                                    }
                                    else
                                    {
                                        Console.WriteLine("There is no heal potion available, please select again.");
                                        CurrentHumanTurn(battle, strExpansions);
                                    }
                                    break;
                                }
                            // items, gear and vin fletcher expansions
                            case "0124":
                            // items, gear, stolen inventory and vin fletcher expansions
                            case "01234":
                                {
                                    if (battle.CurrentPartyGearInventoryHitChance.Inventory.Potions.Count > 0)
                                    {
                                        int i = battle.CurrentCharacterGearInventoryHitChance.AvailableActionHitChances.FindIndex(x => x.ActionType == selectedAction);
                                        heal10PotionAll.Actions(battle, battle.CurrentCharacterGearInventoryHitChance, battle.CurrentCharacterGearInventoryHitChance, battle.CurrentCharacterGearInventoryHitChance.AvailableActionHitChances[i].ActionType, strExpansions);
                                    }
                                    else
                                    {
                                        Console.WriteLine("There is no heal potion available, please select again.");
                                        CurrentHumanTurn(battle, strExpansions);
                                    }
                                    break;
                                }
                            // items and attack modifiers expansions
                            case "015":
                            // items, stolen inventory and attack modifiers expansions
                            case "0135":
                                {
                                    if (battle.CurrentPartyAttackModifierItemInventory.Inventory.Potions.Count > 0)
                                    {
                                        int i = battle.CurrentCharacterAttackModifier.AvailableActions.FindIndex(x => x.ActionType == selectedAction);
                                        heal10PotionAll.Actions(battle, battle.CurrentCharacterAttackModifier, battle.CurrentCharacterAttackModifier, battle.CurrentCharacterAttackModifier.AvailableActions[i].ActionType, strExpansions);
                                    }
                                    else
                                    {
                                        Console.WriteLine("There is no heal potion available, please select again.");
                                        CurrentHumanTurn(battle, strExpansions);
                                    }
                                    break;
                                }
                            // items, gear and attack modifiers expansions
                            case "0125":
                            // items, gear, stolen inventory and attack modifiers expansions
                            case "01235":
                                {
                                    if (battle.CurrentPartyAttackModifierGearInventory.Inventory.Potions.Count > 0)
                                    {
                                        int i = battle.CurrentCharacterAttackModifierGearInventory.AvailableActions.FindIndex(x => x.ActionType == selectedAction);
                                        heal10PotionAll.Actions(battle, battle.CurrentCharacterAttackModifierGearInventory, battle.CurrentCharacterAttackModifierGearInventory, battle.CurrentCharacterAttackModifierGearInventory.AvailableActions[i].ActionType, strExpansions);
                                    }
                                    else
                                    {
                                        Console.WriteLine("There is no heal potion available, please select again.");
                                        CurrentHumanTurn(battle, strExpansions);
                                    }
                                    break;
                                }
                            // items, vin fletcher and attack modifiers expansions
                            case "0145":
                            // items, stolen inventory, vin fletcher and attack modifiers expansions
                            case "01345":
                                {
                                    if (battle.CurrentPartyItemInventoryHitChance.Inventory.Potions.Count > 0)
                                    {
                                        int i = battle.CurrentCharacterAttackModifierHitChance.AvailableActionHitChances.FindIndex(x => x.ActionType == selectedAction);
                                        heal10PotionAll.Actions(battle, battle.CurrentCharacterAttackModifierHitChance, battle.CurrentCharacterAttackModifierHitChance, battle.CurrentCharacterAttackModifierHitChance.AvailableActionHitChances[i].ActionType, strExpansions);
                                    }
                                    else
                                    {
                                        Console.WriteLine("There is no heal potion available, please select again.");
                                        CurrentHumanTurn(battle, strExpansions);
                                    }
                                    break;
                                }
                            // items expansion
                            default:
                                {
                                    if (battle.CurrentPartyItemInventory.Inventory.Potions.Count > 0)
                                    {
                                        int i = battle.CurrentCharacter.AvailableActions.FindIndex(x => x.ActionType == selectedAction);
                                        heal10PotionAll.Actions(battle, battle.CurrentCharacter, battle.CurrentCharacter, battle.CurrentCharacter.AvailableActions[i].ActionType, strExpansions);
                                    }
                                    else
                                    {
                                        Console.WriteLine("There is no heal potion available, please select again.");
                                        CurrentHumanTurn(battle, strExpansions);
                                    }
                                    break;
                                }
                        }
                        break;
                    }
                case ActionTypes.GEAR_EQUIP:
                    {
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
                                    if (battle.CurrentPartyGearInventoryHitChance.Inventory.WeaponHitChances.Count > 0)
                                    {
                                        int i = battle.CurrentCharacterGearInventoryHitChance.AvailableActionHitChances.FindIndex(x => x.ActionType == selectedAction);
                                        equipAll.Actions(battle, battle.CurrentCharacterGearInventoryHitChance, battle.CurrentCharacterGearInventoryHitChance, battle.CurrentCharacterGearInventoryHitChance.AvailableActionHitChances[i].ActionType, strExpansions);
                                    }
                                    else
                                    {
                                        Console.WriteLine("There is no gear available to equip, please select again.");
                                        CurrentHumanTurn(battle, strExpansions);
                                    }
                                    break;
                                }
                            // gear and attack modifiers expansions
                            case "025":
                            // gear, items and attack modifiers expansions
                            case "0125":
                            // gear, stolen inventory and attack modifiers expansions
                            case "0235":
                            // gear, items, stolen inventory and attack modifiers expansions
                            case "01235":
                                {
                                    if (battle.CurrentPartyAttackModifierGearInventory.Inventory.Weapons.Count > 0)
                                    {
                                        int i = battle.CurrentCharacterAttackModifierGearInventory.AvailableActions.FindIndex(x => x.ActionType == selectedAction);
                                        equipAll.Actions(battle, battle.CurrentCharacterAttackModifierGearInventory, battle.CurrentCharacterAttackModifierGearInventory, battle.CurrentCharacterAttackModifierGearInventory.AvailableActions[i].ActionType, strExpansions);
                                    }
                                    else
                                    {
                                        Console.WriteLine("There is no gear available to equip, please select again.");
                                        CurrentHumanTurn(battle, strExpansions);
                                    }
                                    break;
                                }
                            // gear expansion
                            // gear and items expansions
                            // gear ans stolen inventory expansions
                            // gear, items and stolen inventory expansions
                            default:
                                {
                                    if (battle.CurrentPartyGearInventory.Inventory.Weapons.Count > 0)
                                    {
                                        int i = battle.CurrentCharacter.AvailableActions.FindIndex(x => x.ActionType == selectedAction);
                                        equipAll.Actions(battle, battle.CurrentCharacterGearInventory, battle.CurrentCharacterGearInventory, battle.CurrentCharacterGearInventory.AvailableActions[i].ActionType, strExpansions);
                                    }
                                    else
                                    {
                                        Console.WriteLine("There is no gear available to equip, please select again.");
                                        CurrentHumanTurn(battle, strExpansions);
                                    }
                                    break;
                                }
                        }
                        break;
                    }
                case ActionTypes.GEAR_ATTACK:
                    {
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
                                    object[] obj = GetAttackTarget(battle, strExpansions);
                                    PartyGearInventoryHitChance p = (PartyGearInventoryHitChance)obj[0];
                                    int selectedTarget = (int)obj[1];
                                    int i = battle.CurrentCharacterGearInventoryHitChance.AvailableActionHitChances.FindIndex(x => x.ActionType == selectedAction);
                                    gearAttack.Actions(battle, battle.CurrentCharacterGearInventoryHitChance, p.CharacterGearInventoryHitChances[selectedTarget], battle.CurrentCharacterGearInventoryHitChance.AvailableActionHitChances[i].ActionType, strExpansions);
                                    break;
                                }
                            // gear and attack modifiers expansions
                            case "025":
                            // gear, items and attack modifiers expansions
                            case "0125":
                            // gear, stolen inventory and attack modifiers expansions
                            case "0235":
                            // gear, items, stolen inventory and attack modifiers expansions
                            case "01235":
                                {
                                    object[] obj = GetAttackTarget(battle, strExpansions);
                                    PartyAttackModifierGearInventory p = (PartyAttackModifierGearInventory)obj[0];
                                    int selectedTarget = (int)obj[1];
                                    int i = battle.CurrentCharacterAttackModifierGearInventory.AvailableActions.FindIndex(x => x.ActionType == selectedAction);
                                    gearAttack.Actions(battle, battle.CurrentCharacterAttackModifierGearInventory, p.CharacterAttackModifiersGearInventory[selectedTarget], battle.CurrentCharacterAttackModifierGearInventory.AvailableActions[i].ActionType, strExpansions);
                                    break;
                                }
                            // gear expansion
                            // gear and items expansions
                            // gear and stolen inventory expansions
                            // gear, items and stolen inventory expansions
                            default:
                                {
                                    object[] obj = GetAttackTarget(battle, strExpansions);
                                    PartyGearInventory p = (PartyGearInventory)obj[0];
                                    int selectedTarget = (int)obj[1];
                                    int i = battle.CurrentCharacterGearInventory.AvailableActions.FindIndex(x => x.ActionType == selectedAction);
                                    gearAttack.Actions(battle, battle.CurrentCharacterGearInventory, p.CharactersGearInventory[selectedTarget], battle.CurrentCharacterGearInventory.AvailableActions[i].ActionType, strExpansions);
                                    break;
                                }
                        }
                        break;
                    }
                default:
                    break;
            }
        }

        private static object[] GetAttackTarget(Battle battle, string strExpansions)
        {
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
                        PartyGearInventoryHitChance p = (PartyGearInventoryHitChance)GetOtherParty(battle, strExpansions);
                        Console.WriteLine("Please select the target character from the following list of characters:");
                        for (int j = 0; j < p.CharacterGearInventoryHitChances.Count; j++)
                        {
                            Console.WriteLine($"{j}: {p.CharacterGearInventoryHitChances[j].Name}");
                        }
                        int selectedTarget = -1;
                        while (selectedTarget < 0 || selectedTarget >= p.CharacterGearInventoryHitChances.Count)
                        {
                            try
                            {
                                selectedTarget = Convert.ToInt32(Console.ReadLine());
                                if (selectedTarget < 0 || selectedTarget >= p.CharacterGearInventoryHitChances.Count)
                                {
                                    Console.WriteLine($"You must select a number between 0 and {p.CharacterGearInventoryHitChances.Count - 1}");
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                                Console.WriteLine($"You must select a number between 0 and {p.CharacterGearInventoryHitChances.Count - 1}");
                            }
                        }
                        object[] obj = { p, selectedTarget };
                        return obj;
                    }
                // gear and attack modifiers expansions
                case "025":
                // gear, items and attack modifiers expansions
                case "0125":
                // gear, stolen inventory and attack modifiers expansions
                case "0235":
                // gear, items, stolen inventory and attack modifiers expansions
                case "01235":
                    {
                        PartyAttackModifierGearInventory p = (PartyAttackModifierGearInventory)GetOtherParty(battle, strExpansions);
                        Console.WriteLine("Please select the target character from the following list of characters:");
                        for (int j = 0; j < p.CharacterAttackModifiersGearInventory.Count; j++)
                        {
                            Console.WriteLine($"{j}: {p.CharacterAttackModifiersGearInventory[j].Name}");
                        }
                        int selectedTarget = -1;
                        while (selectedTarget < 0 || selectedTarget >= p.CharacterAttackModifiersGearInventory.Count)
                        {
                            try
                            {
                                selectedTarget = Convert.ToInt32(Console.ReadLine());
                                if (selectedTarget < 0 || selectedTarget >= p.CharacterAttackModifiersGearInventory.Count)
                                {
                                    Console.WriteLine($"You must select a number between 0 and {p.CharacterAttackModifiersGearInventory.Count - 1}");
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                                Console.WriteLine($"You must select a number between 0 and {p.CharacterAttackModifiersGearInventory.Count - 1}");
                            }
                        }
                        object[] obj = { p, selectedTarget };
                        return obj;
                    }
                // gear expansion
                // gear and items expansions
                // gear, items and stolen inventory expansions
                default:
                    {
                        PartyGearInventory p = (PartyGearInventory)GetOtherParty(battle, strExpansions);
                        Console.WriteLine("Please select the target character from the following list of characters:");
                        for (int j = 0; j < p.CharactersGearInventory.Count; j++)
                        {
                            Console.WriteLine($"{j}: {p.CharactersGearInventory[j].Name}");
                        }
                        int selectedTarget = -1;
                        while (selectedTarget < 0 || selectedTarget >= p.CharactersGearInventory.Count)
                        {
                            try
                            {
                                selectedTarget = Convert.ToInt32(Console.ReadLine());
                                if (selectedTarget < 0 || selectedTarget >= p.CharactersGearInventory.Count)
                                {
                                    Console.WriteLine($"You must select a number between 0 and {p.CharactersGearInventory.Count - 1}");
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                                Console.WriteLine($"You must select a number between 0 and {p.CharactersGearInventory.Count - 1}");
                            }
                        }
                        object[] obj = { p, selectedTarget };
                        return obj;
                    }
            }
        }

        private static ActionTypes GetSelectedAction(CharacterHitChance currentCharacter)
        {
            Console.WriteLine($"Please select the action type corresponding to an action from the following list:");
            Console.WriteLine("#: <action name> as <action type>");
            for (int i = 0; i < currentCharacter.AvailableActionHitChances.Count; i++)
            {
                Console.WriteLine($"{i}: {currentCharacter.AvailableActionHitChances[i].Name} as {currentCharacter.AvailableActionHitChances[i].ActionType}");
            }
            bool isValid = false;
            ActionTypes selectedAction = ActionTypes.NOTHING;
            while (isValid == false)
            {
                selectedAction = GetAction();
                if (currentCharacter.AvailableActionHitChances.Exists(x => x.ActionType == selectedAction))
                {
                    isValid = true;
                }
                else
                {
                    isValid = false;
                    Console.WriteLine("The action you have selected is not currently available for this character");
                }
            }
            return selectedAction;
        }

        private static ActionTypes GetAction()
        {
            ActionTypes selectedAction = ActionTypes.NOTHING;
            string temp = "";
            bool isValid = false;
            while (isValid == false)
            {
                try
                {
                    temp = Console.ReadLine().ToLower();
                    if (temp.Equals(ActionTypes.NOTHING.ToString().ToLower()) || temp.Equals(ActionTypes.ATTACK.ToString().ToLower()) || temp.Equals(ActionTypes.GEAR_ATTACK.ToString().ToLower()) || temp.Equals(ActionTypes.GEAR_EQUIP.ToString().ToLower()) || temp.Equals(ActionTypes.HEAL.ToString().ToLower()))
                    {
                        isValid = true;
                    }
                    else
                    {
                        Console.WriteLine("You must enter one of the selections by action type as displayed.");
                    }
                }
                catch
                {
                    Console.WriteLine("You must enter one of the selections by action type as displayed.");
                }
            }
            switch (temp.ToLower())
            {
                case "nothing":
                    {
                        selectedAction = ActionTypes.NOTHING;
                        break;
                    }
                case "attack":
                    {
                        selectedAction = ActionTypes.ATTACK;
                        break;
                    }
                case "gear_attack":
                    {
                        selectedAction = ActionTypes.GEAR_ATTACK;
                        break;
                    }
                case "gear_equip":
                    {
                        selectedAction = ActionTypes.GEAR_EQUIP;
                        break;
                    }
                case "heal":
                    {
                        selectedAction = ActionTypes.HEAL;
                        break;
                    }
            }
            return selectedAction;
        }

        private static ActionTypes GetSelectedAction(Character currentCharacter)
        {
            Console.WriteLine($"Please select the action type corresponding to an action from the following list:");
            Console.WriteLine("#: <action name> as <action type>");
            for (int i = 0; i < currentCharacter.AvailableActions.Count; i++)
            {
                Console.WriteLine($"{i}: {currentCharacter.AvailableActions[i].Name} as {currentCharacter.AvailableActions[i].ActionType}");
            }
            ActionTypes selectedAction = ActionTypes.NOTHING;
            bool isValid = false;
            while (isValid == false)
            {
                selectedAction = GetAction();
                if (currentCharacter.AvailableActions.Exists(x => x.ActionType == selectedAction))
                {
                    isValid = true;
                }
                else
                {
                    isValid = false;
                    Console.WriteLine("The action you have selected is not currently available for this character");
                }
            }
            return selectedAction;
        }

        // computer turn
        public static void CurrentTurn(Battle battle, string strExpansions)
        {
            // initialize actions
            DoNothingAll doNothingAll = new DoNothingAll();
            BasicAttackAll attackAll = new BasicAttackAll();
            Heal10PotionAll heal10PotionAll = new Heal10PotionAll();
            AttackGearAll gearAttack = new AttackGearAll();
            EquipAll equipAll = new EquipAll();
            string name = "";
            switch (strExpansions)
            {
                // gear expansion
                case "02":
                // gear and stolen inventory expansions
                case "023":
                // items and gear expansioons
                case "012":
                // items, gear and stolen inventory expansions
                case "0123":
                    {
                        name = battle.CurrentCharacterGearInventory.Name;
                        break;
                    }
                // gear and vin fletcher expansions
                case "024":
                // gear, stolen inventory and vin fletcher expansions
                case "0234":
                // items, gear and vin fletcher expansions
                case "0124":
                // items, gear, stolen inventory and vin fletcher expansions
                case "01234":
                    {
                        name = battle.CurrentCharacterGearInventoryHitChance.Name;
                        break;
                    }
                // vin fletcher expansion
                case "04":
                // items and vinf fletcher expansions
                case "014":
                // items, stolen inventory and vin fletcher expansions
                case "0134":
                    {
                        name = battle.CurrentCharacterHitChance.Name;
                        break;
                    }
                // gear and attack modifier expansions
                case "025":
                // gear, stolen inventory and attack modifier expansions
                case "0235":
                // items, gear and attack modifiers expansions
                case "0125":
                // items, gear, stolen inventory and attack modifiers expansions
                case "01235":
                    {
                        name = battle.CurrentCharacterAttackModifierGearInventory.Name;
                        break;
                    }
                // vin fletcher and attack modifiers expansions
                case "045":
                // items, vin fletcher and attack modifiers expansions
                case "0145":
                // items, stolen inventory, vin fletcher and attack modifiers expansions
                case "01345":
                    {
                        name = battle.CurrentCharacterAttackModifierHitChance.Name;
                        break;
                    }
                // game's status only  expansion
                // items expansion
                // items and stolen inventory expansions
                // attack modifier expansions
                // items and attack modifiers expansions
                // items, stolen inventory and attack modifiers expansions
                default:
                    {
                        name = battle.CurrentCharacter.Name;
                        break;
                    }
            }
            ActionTypes action = ActionTypes.NOTHING;
            Random random = new Random();
            double randDouble = random.NextDouble();
            // if either items or items and gear expansions are active and the current character is below half health
            if (((strExpansions.Equals("01") || strExpansions.Equals("013")) && ((battle.CurrentCharacter.CurrentHP / (double)battle.CurrentCharacter.MaxHP) < 0.5)) ||
                ((strExpansions.Equals("012") || strExpansions.Equals("0123") && ((battle.CurrentCharacterGearInventory.CurrentHP / (double)battle.CurrentCharacterGearInventory.MaxHP) < 0.5))))
            {
                // if items expansion is active and the current character is below half health and the chance is less than 25%
                if ((strExpansions.Equals("01") || strExpansions.Equals("013")) && (battle.CurrentPartyItemInventory.Inventory.Potions.Count > 0) && ((battle.CurrentCharacter.CurrentHP / (double)battle.CurrentCharacter.MaxHP) < 0.5) && (randDouble <= 0.25))
                {
                    action = ActionTypes.HEAL;
                }
                // if items and gear expansions are active and the current character is below half health and the chance is less than 25%
                else if ((strExpansions.Equals("012") || strExpansions.Equals("0123")) && (battle.CurrentPartyGearInventory.Inventory.Potions.Count > 0) && ((battle.CurrentCharacterGearInventory.CurrentHP / (double)battle.CurrentCharacterGearInventory.MaxHP) < 0.5) && (randDouble <= 0.25))
                {
                    action = ActionTypes.HEAL;
                }
                // if items and gear expansions are active and the current character has a gear attack action
                else if ((strExpansions.Equals("012") || strExpansions.Equals("0123")) && battle.CurrentCharacterGearInventory.AvailableActions.Exists(x => x.ActionType == ActionTypes.GEAR_ATTACK))
                {
                    action = FindAction(battle.CurrentCharacterGearInventory, ActionTypes.GEAR_ATTACK);
                }
                // if items and gear expansions are active
                else if (strExpansions.Equals("012") || strExpansions.Equals("0123"))
                {
                    action = FindAction(battle.CurrentCharacterGearInventory, ActionTypes.ATTACK);
                }
                // if items expansion is active
                else if (strExpansions.Equals("01") || strExpansions.Equals("013") || strExpansions.Equals("014") || strExpansions.Equals("0134"))
                {
                    action = FindAction(battle.CurrentCharacter, ActionTypes.ATTACK);
                }
            }
            // items, gear and vin flether expansions
            // items, gear, stolen inventory and vin fletcher expansions
            else if ((strExpansions.Equals("0124") || strExpansions.Equals("01234")) && ((battle.CurrentCharacterGearInventoryHitChance.CurrentHP / (double)battle.CurrentCharacterGearInventoryHitChance.MaxHP) < 0.5))
            {
                // if items expansion is active and the current character is below half health and the chance is less than 25%
                if ((strExpansions.Equals("0124") || strExpansions.Equals("01234")) && (battle.CurrentPartyGearInventoryHitChance.Inventory.Potions.Count > 0) && ((battle.CurrentCharacterGearInventoryHitChance.CurrentHP / (double)battle.CurrentCharacterGearInventoryHitChance.MaxHP) < 0.5) && (randDouble <= 0.25))
                {
                    action = ActionTypes.HEAL;
                }
                // if items and gear expansions are active and the current character has a gear attack action
                else if ((strExpansions.Equals("0124") || strExpansions.Equals("01234")) && battle.CurrentCharacterGearInventoryHitChance.AvailableActionHitChances.Exists(x => x.ActionType == ActionTypes.GEAR_ATTACK))
                {
                    action = FindAction(battle.CurrentCharacterGearInventoryHitChance, ActionTypes.GEAR_ATTACK);
                }
                // if items and gear expansions are active
                else if (strExpansions.Equals("0124") || strExpansions.Equals("01234"))
                {
                    action = FindAction(battle.CurrentCharacterGearInventoryHitChance, ActionTypes.ATTACK);
                }
                // if items expansion is active
                else if (strExpansions.Equals("01") || strExpansions.Equals("013") || strExpansions.Equals("014") || strExpansions.Equals("0134"))
                {
                    action = FindAction(battle.CurrentCharacter, ActionTypes.ATTACK);
                }
            }
            // items and vin fletcher expansions are active and the current character is below half health
            // items, stolen inventory and vin fletcher expansions are active and the current character is below half health
            else if ((strExpansions.Equals("014") || strExpansions.Equals("0134")) && ((battle.CurrentCharacterHitChance.CurrentHP / (double)battle.CurrentCharacterHitChance.MaxHP) < 0.5))
            {
                // if items expansion is active and the current character is below half health and the chance is less than 25%
                if ((strExpansions.Equals("014") || strExpansions.Equals("0134")) && (battle.CurrentPartyItemInventoryHitChance.Inventory.Potions.Count > 0) && (randDouble <= 0.25))
                {
                    action = ActionTypes.HEAL;
                }
                // items and vin fletcher expansions are active
                // items, stolen inventory and vin fletcher expansions are active
                else
                {
                    action = FindAction(battle.CurrentCharacterHitChance, ActionTypes.ATTACK);
                }
            }
            // items and attack modifiers expansions
            // items, stolen inventory and attack modifiers expansions
            else if (((strExpansions.Equals("015") || strExpansions.Equals("0135")) && ((battle.CurrentCharacterAttackModifier.CurrentHP / (double)battle.CurrentCharacterAttackModifier.MaxHP) < 0.5)) || ((strExpansions.Equals("0125") || strExpansions.Equals("01235")) && ((battle.CurrentCharacterAttackModifierGearInventory.CurrentHP / (double)battle.CurrentCharacterAttackModifierGearInventory.MaxHP) < 0.5)))
            {
                // if items and attack modifiers expansions are active and the current character is below half health and the chance is less than 25%
                // if items, stolen inventory and attack modifiers expansions are active and the current character is below half health and the chance is less than 25%
                if ((strExpansions.Equals("015") || strExpansions.Equals("0135")) && (battle.CurrentPartyAttackModifierItemInventory.Inventory.Potions.Count > 0) && ((battle.CurrentCharacterAttackModifier.CurrentHP / (double)battle.CurrentCharacterAttackModifier.MaxHP) < 0.5) && (randDouble <= 0.25))
                {
                    action = ActionTypes.HEAL;
                }
                // if items, gear and attack modifiers expansions are active and the current character is below half health and the chance is less than 25%
                // if items, gear, stolen inventory and attack modifiers expansions are active and the current character is below half health and the chance is less than 25%
                else if ((strExpansions.Equals("0125") || strExpansions.Equals("01235")) && (battle.CurrentPartyAttackModifierGearInventory.Inventory.Potions.Count > 0) && ((battle.CurrentCharacterAttackModifierGearInventory.CurrentHP / (double)battle.CurrentCharacterAttackModifierGearInventory.MaxHP) < 0.5) && (randDouble <= 0.25))
                {
                    action = ActionTypes.HEAL;
                }
                // if items, gear and attack modifiers expansions are active and the current character has a gear attack action
                // if items, gear, stolen inventory and attack modifiers expansions are active and the current character has a gear attack action
                else if ((strExpansions.Equals("0125") || strExpansions.Equals("01235")) && battle.CurrentCharacterAttackModifierGearInventory.AvailableActions.Exists(x => x.ActionType == ActionTypes.GEAR_ATTACK))
                {
                    action = FindAction(battle.CurrentCharacterAttackModifierGearInventory, ActionTypes.GEAR_ATTACK);
                }
                // if items, gear and attack modifiers expansions are active
                // if items, gear, stolen inventory and attack modifiers expansions are active
                else if (strExpansions.Equals("0125") || strExpansions.Equals("01235"))
                {
                    action = FindAction(battle.CurrentCharacterAttackModifierGearInventory, ActionTypes.ATTACK);
                }
                // if items and attack modifiers expansions are active
                // if items, stolen inventory and attack modifiers expansions are active
                else if (strExpansions.Equals("015") || strExpansions.Equals("0135"))// || strExpansions.Equals("014") || strExpansions.Equals("0134"))
                {
                    action = FindAction(battle.CurrentCharacterAttackModifier, ActionTypes.ATTACK);
                }
            }
            // items, vin fletcher and attack modifiers expansions
            // items, stolen inventory, vin fletcher and attack modifiers expansions
            else if ((strExpansions.Equals("0145") || strExpansions.Equals("01345")) && ((battle.CurrentCharacterAttackModifierHitChance.CurrentHP / (double)battle.CurrentCharacterAttackModifierHitChance.MaxHP) < 0.5))
            {
                // if items expansion is active and the current character is below half health and the chance is less than 25%
                if ((strExpansions.Equals("0145") || strExpansions.Equals("01345")) && (battle.CurrentPartyItemInventoryHitChance.Inventory.Potions.Count > 0) && (randDouble <= 0.25))
                {
                    action = ActionTypes.HEAL;
                }
                // items and vin fletcher expansions are active
                // items, stolen inventory and vin fletcher expansions are active
                else
                {
                    action = FindAction(battle.CurrentCharacterAttackModifierHitChance, ActionTypes.ATTACK);
                }
            }
            // if either gear OR gear and items expansions are active
            else if (strExpansions.Equals("02") || strExpansions.Equals("012") || strExpansions.Equals("023") || strExpansions.Equals("0123"))
            {
                // if current party weapon inventory is not null
                if (battle.CurrentPartyGearInventory.Inventory.Weapons != null)
                {
                    // if the party weapon inventory count is at least 1 and tha chance is greater than 50%
                    if (battle.CurrentPartyGearInventory.Inventory.Weapons.Count > 0 && randDouble >= 0.5)
                    {
                        // if the current character's weapon inventory count is at least 1
                        if (battle.CurrentCharacterGearInventory.CharacterInventory.Weapons.Count > 0)
                        {
                            for (int i = 0; i < battle.CurrentPartyGearInventory.Inventory.Weapons.Count; i++)
                            {
                                // checks if current equiped weapon has less max damage than weapons in the party inventory
                                if (battle.CurrentCharacterGearInventory.CharacterInventory.Weapons[0].MaxDamage < battle.CurrentPartyGearInventory.Inventory.Weapons[i].MaxDamage)
                                {
                                    // calls the method to find the action with type GEAR_EQUIP
                                    action = FindAction(battle.CurrentCharacterGearInventory, ActionTypes.GEAR_EQUIP);
                                }
                                else
                                {
                                    // calls the method to find the action with type ATTACK
                                    action = FindAction(battle.CurrentCharacterGearInventory, ActionTypes.ATTACK);
                                }
                            }
                        }
                        // if the current character's weapon inventory count is 0
                        // if the character has the action GEAR_EQUIP they use that action
                        else if (battle.CurrentCharacterGearInventory.AvailableActions.Exists(x => x.ActionType == ActionTypes.GEAR_EQUIP))
                        {
                            action = FindAction(battle.CurrentCharacterGearInventory, ActionTypes.GEAR_EQUIP);
                        }
                        // otherwise the current character uses an attack
                        else
                        {
                            action = FindAction(battle.CurrentCharacterGearInventory, ActionTypes.ATTACK);
                        }
                    }
                    // if the party wepon inventory is not at least 1 AND the chance is not greater than 50%, the current character attacks
                    else if (battle.CurrentCharacterGearInventory.AvailableActions.Exists(x => x.ActionType == ActionTypes.ATTACK))
                    {
                        action = FindAction(battle.CurrentCharacterGearInventory, ActionTypes.ATTACK);
                    }
                }
                // if the parrty weapon inventory is null the current character attacks
                else if (battle.CurrentCharacterGearInventory.AvailableActions.Exists(x => x.ActionType == ActionTypes.ATTACK))
                {
                    action = FindAction(battle.CurrentCharacterGearInventory, ActionTypes.ATTACK);
                }
            }
            // if either gear and vin fletcher OR gear, items  and vin fletcher OR gear, items, stolen inventory and vin fletcher expansions are active
            else if (strExpansions.Equals("024") || strExpansions.Equals("0124") || strExpansions.Equals("0234") || strExpansions.Equals("01234"))
            {
                // if current party weapon inventory is not null
                if (battle.CurrentPartyGearInventoryHitChance.Inventory.WeaponHitChances != null)
                {
                    // if the party weapon inventory count is at least 1 and tha chance is greater than 50%
                    if (battle.CurrentPartyGearInventoryHitChance.Inventory.WeaponHitChances.Count > 0 && randDouble >= 0.5)
                    {
                        // if the current character's weapon inventory count is at least 1
                        if (battle.CurrentCharacterGearInventoryHitChance.CharacterInventory.WeaponHitChances.Count > 0)
                        {
                            for (int i = 0; i < battle.CurrentPartyGearInventoryHitChance.Inventory.WeaponHitChances.Count; i++)
                            {
                                // checks if current equiped weapon has less max damage than weapons in the party inventory
                                if (battle.CurrentCharacterGearInventoryHitChance.CharacterInventory.WeaponHitChances[0].MaxDamage < battle.CurrentPartyGearInventoryHitChance.Inventory.WeaponHitChances[i].MaxDamage)
                                {
                                    // calls the method to find the action with type GEAR_EQUIP
                                    action = FindAction(battle.CurrentCharacterGearInventoryHitChance, ActionTypes.GEAR_EQUIP);
                                }
                                else
                                {
                                    // calls the method to find the action with type ATTACK
                                    action = FindAction(battle.CurrentCharacterGearInventoryHitChance, ActionTypes.ATTACK);
                                }
                            }
                        }
                        // if the current character's weapon inventory count is 0
                        // if the character has the action GEAR_EQUIP they use that action
                        else if (battle.CurrentCharacterGearInventoryHitChance.AvailableActionHitChances.Exists(x => x.ActionType == ActionTypes.GEAR_EQUIP))
                        {
                            action = FindAction(battle.CurrentCharacterGearInventoryHitChance, ActionTypes.GEAR_EQUIP);
                        }
                        // otherwise the current character uses an attack
                        else
                        {
                            action = FindAction(battle.CurrentCharacterGearInventoryHitChance, ActionTypes.ATTACK);
                        }
                    }
                    // if the party wepon inventory is not at least 1 AND the chance is not greater than 50%, the current character attacks
                    else if (battle.CurrentCharacterGearInventoryHitChance.AvailableActionHitChances.Exists(x => x.ActionType == ActionTypes.ATTACK))
                    {
                        action = FindAction(battle.CurrentCharacterGearInventoryHitChance, ActionTypes.ATTACK);
                    }
                }
                // if the parrty weapon inventory is null the current character attacks
                else if (battle.CurrentCharacterGearInventoryHitChance.AvailableActionHitChances.Exists(x => x.ActionType == ActionTypes.ATTACK))
                {
                    action = FindAction(battle.CurrentCharacterGearInventoryHitChance, ActionTypes.ATTACK);
                }
            }
            // if gear expansion is active
            // gear and items expansions are active
            else if (strExpansions.Equals("025") || strExpansions.Equals("0125") || strExpansions.Equals("0235") || strExpansions.Equals("01235"))
            {
                // if current party weapon inventory is not null
                if (battle.CurrentPartyAttackModifierGearInventory.Inventory.Weapons != null)
                {
                    // if the party weapon inventory count is at least 1 and tha chance is greater than 50%
                    if (battle.CurrentPartyAttackModifierGearInventory.Inventory.Weapons.Count > 0 && randDouble >= 0.5)
                    {
                        // if the current character's weapon inventory count is at least 1
                        if (battle.CurrentCharacterAttackModifierGearInventory.CharacterInventory.Weapons.Count > 0)
                        {
                            for (int i = 0; i < battle.CurrentPartyAttackModifierGearInventory.Inventory.Weapons.Count; i++)
                            {
                                // checks if current equiped weapon has less max damage than weapons in the party inventory
                                if (battle.CurrentCharacterAttackModifierGearInventory.CharacterInventory.Weapons[0].MaxDamage < battle.CurrentPartyAttackModifierGearInventory.Inventory.Weapons[i].MaxDamage)
                                {
                                    // calls the method to find the action with type GEAR_EQUIP
                                    action = FindAction(battle.CurrentCharacterAttackModifierGearInventory, ActionTypes.GEAR_EQUIP);
                                }
                                else
                                {
                                    // calls the method to find the action with type ATTACK
                                    action = FindAction(battle.CurrentCharacterAttackModifierGearInventory, ActionTypes.ATTACK);
                                }
                            }
                        }
                        // if the current character's weapon inventory count is 0
                        // if the character has the action GEAR_EQUIP they use that action
                        else if (battle.CurrentCharacterAttackModifierGearInventory.AvailableActions.Exists(x => x.ActionType == ActionTypes.GEAR_EQUIP))
                        {
                            action = FindAction(battle.CurrentCharacterAttackModifierGearInventory, ActionTypes.GEAR_EQUIP);
                        }
                        // otherwise the current character uses an attack
                        else
                        {
                            action = FindAction(battle.CurrentCharacterAttackModifierGearInventory, ActionTypes.ATTACK);
                        }
                    }
                    // if the party wepon inventory is not at least 1 AND the chance is not greater than 50%, the current character attacks
                    else if (battle.CurrentCharacterAttackModifierGearInventory.AvailableActions.Exists(x => x.ActionType == ActionTypes.ATTACK))
                    {
                        action = FindAction(battle.CurrentCharacterAttackModifierGearInventory, ActionTypes.ATTACK);
                    }
                }
                // if the parrty weapon inventory is null the current character attacks
                else if (battle.CurrentCharacterAttackModifierGearInventory.AvailableActions.Exists(x => x.ActionType == ActionTypes.ATTACK))
                {
                    action = FindAction(battle.CurrentCharacterAttackModifierGearInventory, ActionTypes.ATTACK);
                }
            }
            // if neither gear or items expansions are active, the current character attacks
            else
            {
                if (strExpansions.Equals("04") || strExpansions.Equals("014") || strExpansions.Equals("0134"))
                {
                    if (battle.CurrentCharacterHitChance.AvailableActionHitChances.Exists(x => x.ActionType == ActionTypes.ATTACK))
                    {
                        action = FindAction(battle.CurrentCharacterHitChance, ActionTypes.ATTACK);
                    }
                }
                else if (strExpansions.Equals("024") || strExpansions.Equals("0124") || strExpansions.Equals("0234") || strExpansions.Equals("01234"))
                {
                    if (battle.CurrentCharacterGearInventoryHitChance.AvailableActionHitChances.Exists(x => x.ActionType == ActionTypes.ATTACK))
                    {
                        action = FindAction(battle.CurrentCharacterGearInventoryHitChance, ActionTypes.ATTACK);
                    }
                }
                else if (strExpansions.Equals("045") || strExpansions.Equals("0145") || strExpansions.Equals("01345"))
                {
                    if (battle.CurrentCharacterAttackModifierHitChance.AvailableActionHitChances.Exists(x => x.ActionType == ActionTypes.ATTACK))
                    {
                        action = FindAction(battle.CurrentCharacterAttackModifierHitChance, ActionTypes.ATTACK);
                    }
                }
                else
                {
                    if (battle.CurrentCharacter.AvailableActions.Exists(x => x.ActionType == ActionTypes.ATTACK))
                    {
                        action = FindAction(battle.CurrentCharacter, ActionTypes.ATTACK);
                    }
                }
            }
            // directs code to call corresponing action for the current character
            switch (action)
            {
                case ActionTypes.NOTHING:
                    doNothingAll.Actions(battle, name, action, strExpansions);
                    break;
                case ActionTypes.ATTACK:
                    {
                        switch (strExpansions)
                        {
                            // gear expansion
                            case "02":
                            // gear and stolen inventory expansions
                            case "023":
                            // items and gear expansions
                            case "012":
                            // items, gear and stolen inventory expansions
                            case "0123":
                                {
                                    PartyGearInventory p = (PartyGearInventory)GetOtherParty(battle, strExpansions);
                                    int randomCharacter = DetermineAttackTarget(battle, p, action, strExpansions);
                                    attackAll.Actions(battle, battle.CurrentCharacterGearInventory, p.CharactersGearInventory[randomCharacter], action, strExpansions);
                                    break;
                                }
                            // gear and vin fletcher expansions
                            case "024":
                            // gear, stolen inventory and vin fletcher expansions
                            case "0234":
                            // items, stolen inventory and vin fletcher expansions
                            case "0124":
                            // items, gear, stolen inventory and vin fletcher expansions
                            case "01234":
                                {
                                    PartyGearInventoryHitChance p = (PartyGearInventoryHitChance)GetOtherParty(battle, strExpansions);
                                    int randomCharacter = DetermineAttackTarget(battle, p, action, strExpansions);
                                    attackAll.Actions(battle, battle.CurrentCharacterGearInventoryHitChance, p.CharacterGearInventoryHitChances[randomCharacter], action, strExpansions);
                                    break;
                                }
                            // vin fletcher expansion
                            case "04":
                                {
                                    Party p = GetOtherParty(battle, strExpansions);
                                    int randomCharacter = DetermineAttackTarget(battle, p, action, strExpansions);
                                    attackAll.Actions(battle, battle.CurrentCharacterHitChance, p.CharactersHitChance[randomCharacter], action, strExpansions);
                                    break;
                                }
                            // items and vin fletcher expansions
                            // items, stolen inventory and vin fletcher expansions
                            case "014":
                            case "0134":
                                {
                                    PartyItemInventoryHitChance p = (PartyItemInventoryHitChance)GetOtherParty(battle, strExpansions);
                                    int randomCharacter = DetermineAttackTarget(battle, p, action, strExpansions);
                                    attackAll.Actions(battle, battle.CurrentCharacterHitChance, p.CharactersHitChance[randomCharacter], action, strExpansions);
                                    break;
                                }
                            // attack modifier expansion
                            case "05":
                                {
                                    Party p = GetOtherParty(battle, strExpansions);
                                    int randomCharacter = DetermineAttackTarget(battle, p, action, strExpansions);
                                    attackAll.Actions(battle, battle.CurrentCharacterAttackModifier, p.CharactersAttackModifier[randomCharacter], action, strExpansions);
                                    break;
                                }
                            // items and attack modifier expansions
                            case "015":
                            // items, stolen inventory and attack modifiers expansions
                            case "0135":
                                {
                                    PartyAttackModifierItemInventory p = (PartyAttackModifierItemInventory)GetOtherParty(battle, strExpansions);
                                    int randomCharacter = DetermineAttackTarget(battle, p, action, strExpansions);
                                    attackAll.Actions(battle, battle.CurrentCharacterAttackModifier, p.CharacterAttackModifiers[randomCharacter], action, strExpansions);
                                    break;
                                }
                            // gear and attack modifier expansions
                            case "025":
                            // gear, stolen inventory and attack modifiers expansions
                            case "0235":
                            // items, gear and attack modifiers expansions
                            case "0125":
                            // items, gear, stolen inventory and attack modifiers expansions
                            case "01235":
                                {
                                    PartyAttackModifierGearInventory p = (PartyAttackModifierGearInventory)GetOtherParty(battle, strExpansions);
                                    int randomCharacter = DetermineAttackTarget(battle, p, action, strExpansions);
                                    attackAll.Actions(battle, battle.CurrentCharacterAttackModifierGearInventory, p.CharacterAttackModifiersGearInventory[randomCharacter], action, strExpansions);
                                    break;
                                }
                            // vin fletcher and attack modifier expansions
                            case "045":
                                {
                                    Party p = GetOtherParty(battle, strExpansions);
                                    int randomCharacter = DetermineAttackTarget(battle, p, action, strExpansions);
                                    attackAll.Actions(battle, battle.CurrentCharacterAttackModifierHitChance, p.CharactersAttackModifierHitChance[randomCharacter], action, strExpansions);
                                    break;
                                }
                            // items, vin fletcher and attack modifiers expansions
                            case "0145":
                            // items, stolen inventory, vin fletcher and attack modifiers expansions
                            case "01345":
                                {
                                    PartyItemInventoryHitChance p = (PartyItemInventoryHitChance)GetOtherParty(battle, strExpansions);
                                    int randomCharacter = DetermineAttackTarget(battle, p, action, strExpansions);
                                    attackAll.Actions(battle, battle.CurrentCharacterAttackModifierHitChance, p.CharactersAttackModifierHitChance[randomCharacter], action, strExpansions);
                                    break;
                                }
                            // only game's status expansion
                            // items expansion
                            // items and stolen inventory expansions
                            default:
                                {
                                    Party p = GetOtherParty(battle, strExpansions);
                                    int randomCharacter = DetermineAttackTarget(battle, p, action, strExpansions);
                                    attackAll.Actions(battle, battle.CurrentCharacter, p.Characters[randomCharacter], action, strExpansions);
                                    break;
                                }
                        }
                        break;
                    }
                case ActionTypes.HEAL:
                    {
                        switch (strExpansions)
                        {
                            // items and vin fletcher expansions
                            case "014":
                            // items, stolen inventory and vin fletcher expansions
                            case "0134":
                                {
                                    heal10PotionAll.Actions(battle, battle.CurrentCharacterHitChance, battle.CurrentCharacterHitChance, action, strExpansions);
                                    break;
                                }
                            // items and gear expansions
                            case "012":
                            // items, gear and stolen inventory expansions
                            case "0123":
                                {
                                    heal10PotionAll.Actions(battle, battle.CurrentCharacterGearInventory, battle.CurrentCharacterGearInventory, action, strExpansions);
                                    break;
                                }
                            // items, gear and vin fletcher expansions
                            case "0124":
                            // items, gear, stolen inventory and vin fletcher expansions
                            case "01234":
                                {
                                    heal10PotionAll.Actions(battle, battle.CurrentCharacterGearInventoryHitChance, battle.CurrentCharacterGearInventoryHitChance, action, strExpansions);
                                    break;
                                }
                            // items and attack modifiers expansions
                            case "015":
                            // items, stolen inventory and attack modifiers expansions
                            case "0135":
                                {
                                    heal10PotionAll.Actions(battle, battle.CurrentCharacterAttackModifier, battle.CurrentCharacterAttackModifier, action, strExpansions);
                                    break;
                                }
                            // items, vin fletcher and attack modifiers expansions
                            case "0145":
                            // items, stolen inventory, vin fletcher and attack modifiers expansions
                            case "01345":
                                {
                                    heal10PotionAll.Actions(battle, battle.CurrentCharacterAttackModifierHitChance, battle.CurrentCharacterAttackModifierHitChance, action, strExpansions);
                                    break;
                                }
                            // items expansion
                            default:
                                {
                                    heal10PotionAll.Actions(battle, battle.CurrentCharacter, battle.CurrentCharacter, action, strExpansions);
                                    break;
                                }
                        }
                        break;
                    }
                case ActionTypes.GEAR_EQUIP:
                    {
                        switch (strExpansions)
                        {
                            // gear and vin fletcher expansions
                            case "024":
                            // gear, items and vin fletcher
                            case "0124":
                            // gear, stolen inventory and vin fletcher expansions
                            case "0234":
                            // gear, items, stolen inventory and vin fletcher expansions
                            case "01234":
                                {
                                    equipAll.Actions(battle, battle.CurrentCharacterGearInventoryHitChance, battle.CurrentCharacterGearInventoryHitChance, action, strExpansions);
                                    break;
                                }
                            // gear and attack modifiers expansions
                            case "025":
                            // gear, items and attack modifiers expansions
                            case "0125":
                            // gear, stolen inventory and attack modifiers expansions
                            case "0235":
                            // gear, items, stolen inventory and attack modifiers expansions
                            case "01235":
                                {
                                    equipAll.Actions(battle, battle.CurrentCharacterAttackModifierGearInventory, battle.CurrentCharacterAttackModifierGearInventory, action, strExpansions);
                                    break;
                                }
                            // gear expansion
                            // gear and items expansions
                            // gear, items and stolen inventory expansions
                            default:
                                {
                                    equipAll.Actions(battle, battle.CurrentCharacterGearInventory, battle.CurrentCharacterGearInventory, action, strExpansions);
                                    break;
                                }
                        }
                        break;
                    }
                case ActionTypes.GEAR_ATTACK:
                    {
                        switch (strExpansions)
                        {
                            // gear and vin fletcher expansions
                            case "024":
                            // gear, items, and vin fletcher expansions
                            case "0124":
                            // gear, stolen inventory and vin fletcher expansions
                            case "0234":
                            // gear, items, stolen inventory and vin fletcher
                            case "01234":
                                {
                                    PartyGearInventoryHitChance p = (PartyGearInventoryHitChance)GetOtherParty(battle, strExpansions);
                                    int randomCharacter = DetermineAttackTarget(battle, p, action, strExpansions);
                                    gearAttack.Actions(battle, battle.CurrentCharacterGearInventoryHitChance, p.CharacterGearInventoryHitChances[randomCharacter], action, strExpansions);
                                    break;
                                }
                            // gear and attack modifiers expansions
                            case "025":
                            // gear, stolen inventory and attack modifiers expansions
                            case "0235":
                            // gear, items and attack modifiers expansions
                            case "0125":
                            // gear, items, stolen inventory and attack modifiers expansions
                            case "01235":
                                {
                                    PartyAttackModifierGearInventory p = (PartyAttackModifierGearInventory)GetOtherParty(battle, strExpansions);
                                    int randomCharacter = DetermineAttackTarget(battle, p, action, strExpansions);
                                    gearAttack.Actions(battle, battle.CurrentCharacterAttackModifierGearInventory, p.CharacterAttackModifiersGearInventory[randomCharacter], action, strExpansions);
                                    break;
                                }
                            // gear expansion
                            // gear and items expansions
                            // gear, items and stolen inventory expansions
                            default:
                                {
                                    PartyGearInventory p = (PartyGearInventory)GetOtherParty(battle, strExpansions);
                                    int randomCharacter = DetermineAttackTarget(battle, p, action, strExpansions);
                                    gearAttack.Actions(battle, battle.CurrentCharacterGearInventory, p.CharactersGearInventory[randomCharacter], action, strExpansions);
                                    break;
                                }
                        }
                        break;
                    }
                default:
                    break;
            }
        }

        // determines attack when party is a Party object
        private static int DetermineAttackTarget(Battle battle, Party p, ActionTypes action, string strExpansions)
        {
            Console.WriteLine("Please select the tatget character from the following list of characters:");
            switch (strExpansions)
            {
                // vin fletcher expansion
                case "04":
                    {
                        for (int j = 0; j < p.CharactersHitChance.Count; j++)
                        {
                            Console.WriteLine($"{j}: {p.CharactersHitChance[j].Name}");
                        }
                        Random random = new Random();
                        int randomCharacter = random.Next(p.CharactersHitChance.Count);
                        return randomCharacter;
                    }
                // attack modifier expansion
                case "05":
                    {
                        for (int j = 0; j < p.CharactersAttackModifier.Count; j++)
                        {
                            Console.WriteLine($"{j}: {p.CharactersAttackModifier[j].Name}");
                        }
                        Random random = new Random();
                        int randomCharacter = random.Next(p.CharactersAttackModifier.Count);
                        return randomCharacter;
                    }
                // vin fletcher and attack modifiers expansions
                case "045":
                    {
                        for (int j = 0; j < p.CharactersAttackModifierHitChance.Count; j++)
                        {
                            Console.WriteLine($"{j}: {p.CharactersAttackModifierHitChance[j].Name}");
                        }
                        Random random = new Random();
                        int randomCharacter = random.Next(p.CharactersAttackModifierHitChance.Count);
                        return randomCharacter;
                    }
                default:
                    {
                        for (int j = 0; j < p.Characters.Count; j++)
                        {
                            Console.WriteLine($"{j}: {p.Characters[j].Name}");
                        }
                        Random random = new Random();
                        int randomCharacter = random.Next(p.Characters.Count);
                        return randomCharacter;
                    }
            }
        }

        // determines attack when party is a PartyItemInventoryHitChance object
        private static int DetermineAttackTarget(Battle battle, PartyItemInventoryHitChance p, ActionTypes action, string strExpansions)
        {
            Console.WriteLine("Please select the tatget character from the following list of characters:");
            int randomCharacter = -1;
            switch (strExpansions)
            {
                // items, vin fletcher and attack modifiers expansions
                case "0145":
                // items, stolen inventory, vin fletcher and attack modifiers expansions
                case "01345":
                    {
                        for (int j = 0; j < p.CharactersAttackModifierHitChance.Count; j++)
                        {
                            Console.WriteLine($"{j}: {p.CharactersAttackModifierHitChance[j].Name}");
                        }
                        Random random = new Random();
                        randomCharacter = random.Next(p.CharactersAttackModifierHitChance.Count);
                        break;
                    }
                // items and vin fletcher expansions
                // items, stolen inventory and vin fletcher expansions
                default:
                    {
                        for (int j = 0; j < p.CharactersHitChance.Count; j++)
                        {
                            Console.WriteLine($"{j}: {p.CharactersHitChance[j].Name}");
                        }
                        Random random = new Random();
                        randomCharacter = random.Next(p.CharactersHitChance.Count);
                        break;
                    }
            }
            return randomCharacter;
        }

        // determines attack when party is a PartyAttackModifierGearInventory object
        public static int DetermineAttackTarget(Battle battle, PartyAttackModifierGearInventory p, ActionTypes action, string strExpansions)
        {
            Console.WriteLine("Please select the tatget character from the following list of characters:");
            for (int j = 0; j < p.CharacterAttackModifiersGearInventory.Count; j++)
            {
                Console.WriteLine($"{j}: {p.CharacterAttackModifiersGearInventory[j].Name}");
            }
            Random random = new Random();
            int randomCharacter = random.Next(p.CharacterAttackModifiersGearInventory.Count);
            return randomCharacter;
        }

        // determines attack when party is a PartyGearInventory object
        public static int DetermineAttackTarget(Battle battle, PartyGearInventory p, ActionTypes action, string strExpansions)
        {
            Console.WriteLine("Please select the tatget character from the following list of characters:");
            for (int j = 0; j < p.CharactersGearInventory.Count; j++)
            {
                Console.WriteLine($"{j}: {p.CharactersGearInventory[j].Name}");
            }
            Random random = new Random();
            int randomCharacter = random.Next(p.CharactersGearInventory.Count);
            return randomCharacter;
        }

        // determines attack when party is a PartyGearInventoryHitChance object
        public static int DetermineAttackTarget(Battle battle, PartyGearInventoryHitChance p, ActionTypes action, string strExpansions)
        {
            Console.WriteLine("Please select the tatget character from the following list of characters:");
            for (int j = 0; j < p.CharacterGearInventoryHitChances.Count; j++)
            {
                Console.WriteLine($"{j}: {p.CharacterGearInventoryHitChances[j].Name}");
            }
            Random random = new Random();
            int randomCharacter = random.Next(p.CharacterGearInventoryHitChances.Count);
            return randomCharacter;
        }

        // determines attack when party is a PartyGearInventoryHitChance object
        public static int DetermineAttackTarget(Battle battle, PartyAttackModifierItemInventory p, ActionTypes action, string strExpansions)
        {
            Console.WriteLine("Please select the tatget character from the following list of characters:");
            for (int j = 0; j < p.CharacterAttackModifiers.Count; j++)
            {
                Console.WriteLine($"{j}: {p.CharacterAttackModifiers[j].Name}");
            }
            Random random = new Random();
            int randomCharacter = random.Next(p.CharacterAttackModifiers.Count);
            return randomCharacter;
        }

        // method to find and return the action correspond to the action type parameter
        public static ActionTypes FindAction(Character currentCharacter, ActionTypes actionType)
        {
            string name = "";
            // list to hold all available attack actions for the current character
            List<AvailableAction> attackActions = new List<AvailableAction>();
            // if the action type is either ATTACK or GEAR_ATTACK
            if (actionType.Equals(ActionTypes.ATTACK) || actionType.Equals(ActionTypes.GEAR_ATTACK))
            {
                // gathers all currently available attack actions and adds them to the list
                List<AvailableAction> temp = currentCharacter.AvailableActions.FindAll(x => x.ActionType == ActionTypes.ATTACK);
                foreach (AvailableAction a in temp)
                {
                    attackActions.Add(a);
                }
                temp = currentCharacter.AvailableActions.FindAll(x => x.ActionType == ActionTypes.GEAR_ATTACK);
                foreach (AvailableAction a in temp)
                {
                    attackActions.Add(a);
                }
                int maxDamage = 0;
                int minDamage = 0;
                // loop to check each attack action for which does the most damage and return the action name
                for (int i = 0; i < attackActions.Count; i++)
                {
                    if (attackActions[i].MaxAmount > maxDamage)
                    {
                        name = attackActions[i].Name;
                        maxDamage = attackActions[i].MaxAmount;
                        minDamage = attackActions[i].MinAmount;
                    }
                    else if (attackActions[i].MaxAmount == maxDamage)
                    {
                        if (attackActions[i].MinAmount > minDamage)
                        {
                            name = attackActions[i].Name;
                            maxDamage = attackActions[i].MaxAmount;
                            minDamage = attackActions[i].MinAmount;
                        }
                    }
                }
            }
            // if action type is not an attack it finds the index based on action name
            else
            {
                name = currentCharacter.AvailableActions.Find(x => x.ActionType == actionType).Name;
            }
            // finds selected action's index based on its name
            int j = currentCharacter.AvailableActions.FindIndex(x => x.Name.Equals(name));
            // returns the actiontype of the selected action
            ActionTypes action = currentCharacter.AvailableActions[j].ActionType;
            return action;
        }

        // method to find and return the action correspond to the action type parameter
        public static ActionTypes FindAction(CharacterHitChance currentCharacter, ActionTypes actionType)
        {
            string name = "";
            // list to hold all available attack actions for the current character
            List<AvailableActionHitChance> attackActions = new List<AvailableActionHitChance>();
            // if the action type is either ATTACK or GEAR_ATTACK
            if (actionType.Equals(ActionTypes.ATTACK) || actionType.Equals(ActionTypes.GEAR_ATTACK))
            {
                // gathers all currently available attack actions and adds them to the list
                List<AvailableActionHitChance> temp = currentCharacter.AvailableActionHitChances.FindAll(x => x.ActionType == ActionTypes.ATTACK);
                foreach (AvailableActionHitChance a in temp)
                {
                    attackActions.Add(a);
                }
                temp = currentCharacter.AvailableActionHitChances.FindAll(x => x.ActionType == ActionTypes.GEAR_ATTACK);
                foreach (AvailableActionHitChance a in temp)
                {
                    attackActions.Add(a);
                }
                int maxDamage = 0;
                int minDamage = 0;
                // loop to check each attack action for which does the most damage and return the action name
                for (int i = 0; i < attackActions.Count; i++)
                {
                    if (attackActions[i].MaxAmount > maxDamage)
                    {
                        name = attackActions[i].Name;
                        maxDamage = attackActions[i].MaxAmount;
                        minDamage = attackActions[i].MinAmount;
                    }
                    else if (attackActions[i].MaxAmount == maxDamage)
                    {
                        if (attackActions[i].MinAmount > minDamage)
                        {
                            name = attackActions[i].Name;
                            maxDamage = attackActions[i].MaxAmount;
                            minDamage = attackActions[i].MinAmount;
                        }
                    }
                }
            }
            // if action type is not an attack it finds the index based on action name
            else
            {
                name = currentCharacter.AvailableActionHitChances.Find(x => x.ActionType == actionType).Name;
            }
            // finds selected action's index based on its name
            int j = currentCharacter.AvailableActionHitChances.FindIndex(x => x.Name.Equals(name));
            // returns the actiontype of the selected action
            ActionTypes action = currentCharacter.AvailableActionHitChances[j].ActionType;
            return action;
        }

        public static ActionTypes FindAction(CharacterGearInventoryHitChance currentCharacter, ActionTypes actionType)
        {
            string name = "";
            // list to hold all available attack actions for the current character
            List<AvailableActionHitChance> attackActions = new List<AvailableActionHitChance>();
            // if the action type is either ATTACK or GEAR_ATTACK
            if (actionType.Equals(ActionTypes.ATTACK) || actionType.Equals(ActionTypes.GEAR_ATTACK))
            {
                // gathers all currently available attack actions and adds them to the list
                List<AvailableActionHitChance> temp = currentCharacter.AvailableActionHitChances.FindAll(x => x.ActionType == ActionTypes.ATTACK);
                foreach (AvailableActionHitChance a in temp)
                {
                    attackActions.Add(a);
                }
                temp = currentCharacter.AvailableActionHitChances.FindAll(x => x.ActionType == ActionTypes.GEAR_ATTACK);
                foreach (AvailableActionHitChance a in temp)
                {
                    attackActions.Add(a);
                }
                int maxDamage = 0;
                int minDamage = 0;
                // loop to check each attack action for which does the most damage and return the action name
                for (int i = 0; i < attackActions.Count; i++)
                {
                    if (attackActions[i].MaxAmount > maxDamage)
                    {
                        name = attackActions[i].Name;
                        maxDamage = attackActions[i].MaxAmount;
                        minDamage = attackActions[i].MinAmount;
                    }
                    else if (attackActions[i].MaxAmount == maxDamage)
                    {
                        if (attackActions[i].MinAmount > minDamage)
                        {
                            name = attackActions[i].Name;
                            maxDamage = attackActions[i].MaxAmount;
                            minDamage = attackActions[i].MinAmount;
                        }
                    }
                }
            }
            // if action type is not an attack it finds the index based on action name
            else
            {
                name = currentCharacter.AvailableActionHitChances.Find(x => x.ActionType == actionType).Name;
            }
            // finds selected action's index based on its name
            int j = currentCharacter.AvailableActionHitChances.FindIndex(x => x.Name.Equals(name));
            // returns the actiontype of the selected action
            ActionTypes action = currentCharacter.AvailableActionHitChances[j].ActionType;
            return action;
        }

        // method to determine and return oppossing party based on current party type
        public static Party GetOtherParty(Battle battle, string strExpansions)
        {
            // if current party type is heroes
            if (battle.CurrentPartyType.Equals(PartyType.Heroes))
            {
                switch (strExpansions)
                {
                    // items expansion
                    case "01":
                    // items and stolen inventory expansions
                    case "013":
                        {
                            Party p = battle.MonstersItemInventory[battle.CurrentMonsterPartyNumber];
                            return p;
                        }
                    // items and vin fletcher expansions
                    case "014":
                    // items, stolen inventory and vin fletcher expansions
                    case "0134":
                    // items, vin fletcher and attack modifiers expansions
                    case "0145":
                    // items, stolen inventory, vin fletcher and attack modifiers expansions
                    case "01345":
                        {
                            PartyItemInventoryHitChance p = battle.MonstersItemInventoryHitChance[battle.CurrentMonsterPartyNumber];
                            return p;
                        }
                    // gear expansion
                    case "02":
                    // gear and stolen inventory expansions
                    case "023":
                    // items and gear expansions
                    case "012":
                    // items, gear and stolen inventory expansions
                    case "0123":
                        {
                            PartyGearInventory p = battle.MonstersGearInventory[battle.CurrentMonsterPartyNumber];
                            return p;
                        }
                    // gear and vin fletcher expansions
                    case "024":
                    // gear, stolen inventory and vin fletcher expansions
                    case "0234":
                    // items, gear and vin fletcher expansions
                    case "0124":
                    // items, gear, stolen inventory and vin fletcher expansions
                    case "01234":
                        {
                            PartyGearInventoryHitChance p = battle.MonstersPartyGearInventoryHitChances[battle.CurrentMonsterPartyNumber];
                            return p;
                        }
                    // items and attack modifiers expansions
                    case "015":
                    // items, stolen inventory and attack modifiers expansions
                    case "0135":
                        {
                            PartyAttackModifierItemInventory p = battle.MonstersPartyAttackModifierItemInventory[battle.CurrentMonsterPartyNumber];
                            return p;
                        }
                    // gear and attack modifiers expansions
                    case "025":
                    // gear, stolen inventory and attack modifiers expansions
                    case "0235":
                    // items, gear and attack modifiers expansions
                    case "0125":
                    // items, gear, stolen inventory and attack modifiers expansions
                    case "01235":
                        {
                            PartyAttackModifierGearInventory p = battle.MonstersPartyAttackModifierGearInventory[battle.CurrentMonsterPartyNumber];
                            return p;
                        }
                    // only game's status expansion
                    // vin fletcher expansion
                    // attack modifiers expansion
                    // vin fletcher and attack modifiers expansions
                    default:
                        {
                            Party p = battle.Monsters[battle.CurrentMonsterPartyNumber];
                            return p;
                        }
                }
            }
            // if current party type is monsters
            else
            {
                switch (strExpansions)
                {
                    // items expansion
                    case "01":
                    // items and stolen inventory expansions
                    case "013":
                        {
                            Party p = battle.HeroesItemInventory;
                            return p;
                        }
                    // items and vin fletcher expansions
                    case "014":
                    // items, stolen inventory and vin fletcher expansions
                    case "0134":
                    // items, vin fletcher and attack modifiers expansions
                    case "0145":
                    // items, stolen inventory, vin fletcher and attack modifiers expansions
                    case "01345":
                        {
                            PartyItemInventoryHitChance p = battle.HeroesItemInventoryHitChance;
                            return p;
                        }
                    // gear expansion
                    case "02":
                    // gear and stolen inventory expansions
                    case "023":
                    // items and gear expansion
                    case "012":
                    // items, gear and stolen inventory expansions
                    case "0123":
                        {
                            PartyGearInventory p = battle.HeroesGearInventory;
                            return p;
                        }
                    // gear and vin fletcher expansions
                    case "024":
                    // gear, stolen inventory and vin fletcher expansions
                    case "0234":
                    // items, gear and vin fletcher expansions
                    case "0124":
                    // items, gear, stolen inventory and vin fletcher expansions
                    case "01234":
                        {
                            PartyGearInventoryHitChance p = battle.HeroesPartyGearInventoryHitChance;
                            return p;
                        }
                    // items and attack modifiers expansions
                    case "015":
                    // items, stolen inventory and attack modifiers expansions
                    case "0135":
                        {
                            PartyAttackModifierItemInventory p = battle.HeroesPartyAttackModifierItemInventory;
                            return p;
                        }
                    // gear and attack modifiers expansions
                    case "025":
                    // gear, stolen inventory and attack modifiers expansions
                    case "0235":
                    // items, gear attack modifiers expansions
                    case "0125":
                    // items, gear, stolen inventory and attack modifiers expansions
                    case "01235":
                        {
                            PartyAttackModifierGearInventory p = battle.HeroesPartyAttackModifierGearInventory;
                            return p;
                        }
                    // only game's status expansion
                    // vin fletcher expansion
                    // attack modifiers expansion
                    // vin fletcher and attack modifiers expansions
                    default:
                        {
                            Party p = battle.Heroes;
                            return p;
                        }
                }
            }
        }
    }
}