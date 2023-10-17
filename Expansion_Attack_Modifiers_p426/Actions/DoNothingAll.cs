using Expansion_Attack_Modifiers_p426;
using Expansion_Attack_Modifiers_p426.Interfaces;

namespace Expansion_Attack_Modifiers_p426.Actions
{
    public class DoNothingAll : IActionDoNothing
    {
        public void Actions(Battle battle, string characterName, ActionTypes characterAction, string strExpansions)
        {
            switch (strExpansions)
            {
                // gear expansion
                case "02":
                // items and gear expansions
                case "012":
                // gear and stolen inventory expansions
                case "023":
                // items, gear and stolen inventory expansions
                case "0123":
                    {
                        Console.WriteLine($"It is {battle.CurrentCharacterGearInventory.Name}'s turn...");
                        Console.WriteLine($"{battle.CurrentCharacterGearInventory.Name} did {characterAction}\n");
                        break;
                    }
                // gear and vin fletcher expansions
                case "024":
                // items, gear and vin fletcher expansions
                case "0124":
                // gear, stolen inventory and vin fletcher expansion
                case "0234":
                // items, gear, stolen inventory and vin fletcher expansions
                case "01234":
                    {
                        Console.WriteLine($"It is {battle.CurrentCharacterGearInventoryHitChance.Name}'s turn...");
                        Console.WriteLine($"{battle.CurrentCharacterGearInventoryHitChance.Name} did {characterAction}\n");
                        break;
                    }
                // vin fletcher expansion
                case "04":
                // items and vin fletcher expansions
                case "014":
                // items, stolen inventory and vin fletcher expansions
                case "0134":
                    {
                        Console.WriteLine($"It is {battle.CurrentCharacterHitChance.Name}'s turn...");
                        Console.WriteLine($"{battle.CurrentCharacterHitChance.Name} did {characterAction}\n");
                        break;
                    }
                // gear and attack modifiers expansions
                case "025":
                // items, gear and attack modifiers expansions
                case "0125":
                // gear, stolen inventory and attack modifiers expansions
                case "0235":
                // items, gear, stolen and attack modifiers inventory expansions
                case "01235":
                    {
                        Console.WriteLine($"It is {battle.CurrentCharacterAttackModifierGearInventory.Name}'s turn...");
                        Console.WriteLine($"{battle.CurrentCharacterAttackModifierGearInventory.Name} did {characterAction}\n");
                        break;
                    }
                // vin fletcher and attack modifiers expansions
                case "045":
                    {
                        Console.WriteLine($"It is {battle.CurrentCharacterAttackModifierHitChance.Name}'s turn...");
                        Console.WriteLine($"{battle.CurrentCharacterAttackModifierHitChance.Name} did {characterAction}\n");
                        break;
                    }
                // items, vin fletcher and attack modifiers expansions
                case "0145":
                // items, stolen inventory, vin fletcher and attack modifiers expansions
                case "01345":
                    {
                        Console.WriteLine($"It is {battle.CurrentCharacterAttackModifierHitChance.Name}'s turn...");
                        Console.WriteLine($"{battle.CurrentCharacterAttackModifierHitChance.Name} did {characterAction}\n");
                        break;
                    }
                // gear, vin fletcher and attack modifiers expansions
                case "0245":
                // items, gear, vin fletcher and attack modifiers expansions
                case "01245":
                // gear, stolen inventory, vin fletcher and attack modifiers expansions
                case "02345":
                // items, gear, stolen inventory, vin fletcher and attack modifiers inventory expansions
                case "012345":
                    {
                        Console.WriteLine($"It is {battle.CurrentCharacterAttackModifierGearInventoryHitChance.Name}'s turn...");
                        Console.WriteLine($"{battle.CurrentCharacterAttackModifierGearInventoryHitChance.Name} did {characterAction}\n");
                        break;
                    }
                // game's status expansion
                default:
                    {
                        Console.WriteLine($"It is {battle.CurrentCharacter.Name}'s turn...");
                        Console.WriteLine($"{battle.CurrentCharacter.Name} did {characterAction}\n");
                        break;
                    }
            }
        }
    }
}
