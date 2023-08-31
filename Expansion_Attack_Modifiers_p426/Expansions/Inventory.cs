using Expansion_Attack_Modifiers_p426.Expansions.Gear;
using Expansion_Attack_Modifiers_p426.Expansions.Items;
using Expansion_Attack_Modifiers_p426.Expansions.Vin_Fletcher;

namespace Expansion_Attack_Modifiers_p426.Expansions
{
    public class Inventory
    {
        public List<Potion?> Potions { get; set; }
        public List<Weapon?> Weapons { get; set; }
        public List<WeaponHitChance> WeaponHitChances { get; set; }
        public Inventory() { }
        public Inventory(List<Potion?> potions)
        {
            Potions = potions;
        }
        public Inventory(List<Weapon?> weapons)
        {
            Weapons = weapons;
        }
        public Inventory(List<WeaponHitChance> weaponHitChances)
        {
            WeaponHitChances = weaponHitChances;
        }
        public Inventory(List<Potion?> potions, List<Weapon?> weapons)
        {
            Potions = potions;
            Weapons = weapons;
        }
        public Inventory(List<Potion?> potions, List<WeaponHitChance> weaponHitChances)
        {
            Potions = potions;
            WeaponHitChances = weaponHitChances;
        }
    }
}
