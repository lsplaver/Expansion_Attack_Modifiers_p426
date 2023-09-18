using Expansion_Attack_Modifiers_p426;
using Expansion_Attack_Modifiers_p426.Expansions.Attack_Modifiers;
using Expansion_Attack_Modifiers_p426.Expansions.Gear;
using Expansion_Attack_Modifiers_p426.Expansions.Items;
using Expansion_Attack_Modifiers_p426.Expansions.Vin_Fletcher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expansion_Attack_Modifiers_p426.Expansions.Stolen_Inventory
{
    public class StolenInventories
    {
        // method to steal the inventory from defeated party
        // item and stolen inventory expansions
        public void StolenInventory(Battle battle, PartyItemInventory targetParty, PartyItemInventory currentParty)
        {
            // only triggers if the target party has unuesed potions
            if (targetParty.Inventory.Potions.Count > 0)
            {
                for (int i = 0; i < targetParty.Inventory.Potions.Count; i++)
                {
                    currentParty.Inventory.Potions.Add(targetParty.Inventory.Potions[i]);
                    Console.WriteLine($"The {currentParty.Name} have stolen {targetParty.Inventory.Potions[i].Name} from {targetParty.Name}");
                }
                targetParty.Inventory.Potions.Clear();
            }
        }

        // method to steal the inventory from defeated party
        // item, stolen inventory and vin fletcher expansions
        public void StolenInventory(Battle battle, PartyItemInventoryHitChance targetParty, PartyItemInventoryHitChance currentParty)
        {
            // only triggers if the target party has unuesed potions
            if (targetParty.Inventory.Potions.Count > 0)
            {
                for (int i = 0; i < targetParty.Inventory.Potions.Count; i++)
                {
                    currentParty.Inventory.Potions.Add(targetParty.Inventory.Potions[i]);
                    Console.WriteLine($"The {currentParty.Name} have stolen {targetParty.Inventory.Potions[i].Name} from {targetParty.Name}");
                }
                targetParty.Inventory.Potions.Clear();
            }
        }

        // method to steal the equipped gear from defeated character
        // gear and stolen inventory expansions
        // gear, items and stolen inventory expansions
        public void StolenInventory(Battle battle, CharacterGearInventory targetCharacter, PartyGearInventory currentParty)
        {
            // only triggers if the target character has equipped weapons
            if (targetCharacter.CharacterInventory.Weapons.Count > 0)
            {
                currentParty.Inventory.Weapons.Add(targetCharacter.CharacterInventory.Weapons[0]);
                Console.WriteLine($"The {currentParty.Name} have stolen {targetCharacter.CharacterInventory.Weapons[0].Name} from {targetCharacter.Name}");
                targetCharacter.CharacterInventory.Weapons.RemoveAt(0);
            }
        }

        // method to steal the unequpped gear from defeated party
        // gear and stolen inventory expansions
        // gear, items and stolen inventory expansions
        public void StolenInventory(Battle battle, PartyGearInventory targetParty, PartyGearInventory currentParty)
        {
            // if Items, Gear and Stolen Inventory expansions are active
            if (battle.Expansions.Equals("0123"))
            {
                // only triggers if the target party has unequipped weapons
                if (targetParty.Inventory.Weapons.Count > 0)
                {
                    for (int i = 0; i < targetParty.Inventory.Weapons.Count; i++)
                    {
                        currentParty.Inventory.Weapons.Add(targetParty.Inventory.Weapons[i]);
                        Console.WriteLine($"The {currentParty.Name} have stolen {targetParty.Inventory.Weapons[i].Name} from {targetParty.Name}");
                    }
                    targetParty.Inventory.Weapons.Clear();
                }
                // only triggers if the target party has unused potions
                if (targetParty.Inventory.Potions.Count > 0)
                {
                    for (int i = 0; i < targetParty.Inventory.Potions.Count; i++)
                    {
                        currentParty.Inventory.Potions.Add(targetParty.Inventory.Potions[i]);
                        Console.WriteLine($"The {currentParty.Name} have stolen {targetParty.Inventory.Potions[i].Name} from {targetParty.Name}");
                    }
                    targetParty.Inventory.Potions.Clear();
                }
            }
            // if only Gear and Stolen Inventory expansions are active
            else
            {
                // only triggers if the target party has unequipped weapons
                if (targetParty.Inventory.Weapons.Count > 0)
                {
                    for (int i = 0; i < targetParty.Inventory.Weapons.Count; i++)
                    {
                        currentParty.Inventory.Weapons.Add(targetParty.Inventory.Weapons[i]);
                        Console.WriteLine($"The {currentParty.Name} have stolen {targetParty.Inventory.Weapons[i].Name} from {targetParty.Name}");
                    }
                    targetParty.Inventory.Weapons.Clear();
                }
            }
        }

        // method to steal the unequipped gear from defeated character
        // gear, stolen inventory and vin fletcher expansions
        // gear, items, stolen inventory and vin fletcher expansions
        public void StolenInventory(Battle battle, CharacterGearInventoryHitChance targetCharacter, PartyGearInventoryHitChance currentParty)
        {
            // only triggers if the target character has equipped weapons
            if (targetCharacter.CharacterInventory.WeaponHitChances.Count > 0)
            {
                currentParty.Inventory.WeaponHitChances.Add(targetCharacter.CharacterInventory.WeaponHitChances[0]);
                Console.WriteLine($"The {currentParty.Name} have stolen {targetCharacter.CharacterInventory.WeaponHitChances[0].Name} from {targetCharacter.Name}");
                targetCharacter.CharacterInventory.WeaponHitChances.RemoveAt(0);
            }
        }

        // method to steal the unequpped gear from defeated party
        // gear and stolen inventory expansions
        // gear, items and stolen inventory expansions
        public void StolenInventory(Battle battle, PartyGearInventoryHitChance targetParty, PartyGearInventoryHitChance currentParty)
        {
            // if Items, Gear vin fletcher and Stolen Inventory expansions are active
            if (battle.Expansions.Equals("01234"))
            {
                // only triggers if the target party has unequipped weapons
                if (targetParty.Inventory.WeaponHitChances.Count > 0)
                {
                    for (int i = 0; i < targetParty.Inventory.WeaponHitChances.Count; i++)
                    {
                        currentParty.Inventory.WeaponHitChances.Add(targetParty.Inventory.WeaponHitChances[i]);
                        Console.WriteLine($"The {currentParty.Name} have stolen {targetParty.Inventory.WeaponHitChances[i].Name} from {targetParty.Name}");
                    }
                    targetParty.Inventory.WeaponHitChances.Clear();
                }
                // only triggers if the target party has unused potions
                if (targetParty.Inventory.Potions.Count > 0)
                {
                    for (int i = 0; i < targetParty.Inventory.Potions.Count; i++)
                    {
                        currentParty.Inventory.Potions.Add(targetParty.Inventory.Potions[i]);
                        Console.WriteLine($"The {currentParty.Name} have stolen {targetParty.Inventory.Potions[i].Name} from {targetParty.Name}");
                    }
                    targetParty.Inventory.Potions.Clear();
                }
            }
            // if only Gear, vin fletcher  and Stolen Inventory expansions are active
            else
            {
                // only triggers if the target party has unequipped weapons
                if (targetParty.Inventory.WeaponHitChances.Count > 0)
                {
                    for (int i = 0; i < targetParty.Inventory.WeaponHitChances.Count; i++)
                    {
                        currentParty.Inventory.WeaponHitChances.Add(targetParty.Inventory.WeaponHitChances[i]);
                        Console.WriteLine($"The {currentParty.Name} have stolen {targetParty.Inventory.WeaponHitChances[i].Name} from {targetParty.Name}");
                    }
                    targetParty.Inventory.WeaponHitChances.Clear();
                }
            }
        }

        // method to steal the inventory from defeated party
        // items, stolen inventory and attack modifier expansions
        public void StolenInventory(Battle battle, PartyAttackModifierItemInventory targetParty, PartyAttackModifierItemInventory currentParty)
        {
            if (targetParty.Inventory.Potions.Count > 0)
            {
                for (int i = 0; i < targetParty.Inventory.Potions.Count; i++)
                {
                    currentParty.Inventory.Potions.Add(targetParty.Inventory.Potions[i]);
                    Console.WriteLine($"The {currentParty.Name} have stolen {targetParty.Inventory.Potions[i].Name} from {targetParty.Name}");
                }
                targetParty.Inventory.Potions.Clear();
            }
        }

        // method to steal the unequpped gear from defeated party
        // gear and stolen inventory expansions
        // gear, items and stolen inventory expansions
        public void StolenInventory(Battle battle, PartyAttackModifierGearInventory targetParty, PartyAttackModifierGearInventory currentParty)
        {
            // if Items, Gear and Stolen Inventory expansions are active
            if (battle.Expansions.Equals("01235"))
            {
                // only triggers if the target party has unequipped weapons
                if (targetParty.Inventory.Weapons.Count > 0)
                {
                    for (int i = 0; i < targetParty.Inventory.Weapons.Count; i++)
                    {
                        currentParty.Inventory.Weapons.Add(targetParty.Inventory.Weapons[i]);
                        Console.WriteLine($"The {currentParty.Name} have stolen {targetParty.Inventory.Weapons[i].Name} from {targetParty.Name}");
                    }
                    targetParty.Inventory.Weapons.Clear();
                }
                // only triggers if the target party has unused potions
                if (targetParty.Inventory.Potions.Count > 0)
                {
                    for (int i = 0; i < targetParty.Inventory.Potions.Count; i++)
                    {
                        currentParty.Inventory.Potions.Add(targetParty.Inventory.Potions[i]);
                        Console.WriteLine($"The {currentParty.Name} have stolen {targetParty.Inventory.Potions[i].Name} from {targetParty.Name}");
                    }
                    targetParty.Inventory.Potions.Clear();
                }
            }
            // if only Gear and Stolen Inventory expansions are active
            else
            {
                // only triggers if the target party has unequipped weapons
                if (targetParty.Inventory.Weapons.Count > 0)
                {
                    for (int i = 0; i < targetParty.Inventory.Weapons.Count; i++)
                    {
                        currentParty.Inventory.Weapons.Add(targetParty.Inventory.Weapons[i]);
                        Console.WriteLine($"The {currentParty.Name} have stolen {targetParty.Inventory.Weapons[i].Name} from {targetParty.Name}");
                    }
                    targetParty.Inventory.Weapons.Clear();
                }
            }
        }
    }
}
