using Expansion_Attack_Modifiers_p426.Expansions.Gear;
using Expansion_Attack_Modifiers_p426.Expansions.Vin_Fletcher.Actions;
using Expansion_Attack_Modifiers_p426.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expansion_Attack_Modifiers_p426.Expansions.Vin_Fletcher
{
    public class WeaponHitChance : Weapon
    {
        public double HitChance { get; set; }
        public AvailableActionHitChance AvailableActionHitChance { get; set; }
        public WeaponHitChance(GearTypes gearTypes, string name, WeaponTypes weaponTypes, int minDamage, int maxDamage, AvailableActionHitChance availableActionHitChance, string weaponID, double hitChance) : base(gearTypes, name, weaponTypes, minDamage, maxDamage, weaponID)
        {
            AvailableActionHitChance = availableActionHitChance;
            HitChance = hitChance;
        }
    }
}
