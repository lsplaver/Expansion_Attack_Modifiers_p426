using Expansion_Attack_Modifiers_p426.Actions;

namespace Expansion_Attack_Modifiers_p426.Expansions.Gear
{
    public enum WeaponTypes
    {
        SWORD, DAGGER,
        BOW
    }

    //Weapon class is a Gear subclass and integrates an AvailableAction object
    public class Weapon : Gear
    {
        public string Name { get; set; }
        public WeaponTypes WeaponTypes { get; set; }
        public int MinDamage { get; set; }
        public int MaxDamage { get; set; }
        public string WeaponID { get; }
        public AvailableAction AvailableAction { get; set; }

        public Weapon(GearTypes gearTypes, string name, WeaponTypes weaponTypes, int minDamage, int maxDamage, AvailableAction availableAction, string weaponID) : base(gearTypes)
        {
            Name = name;
            WeaponTypes = weaponTypes;
            MinDamage = minDamage;
            MaxDamage = maxDamage;
            AvailableAction = availableAction;
            WeaponID = weaponID;
        }

        public Weapon(GearTypes gearType, string name, WeaponTypes weaponTypes, int minDamage, int maxDamage, string weaponID) : base(gearType)
        {
            Name = name;
            WeaponTypes = weaponTypes;
            MinDamage = minDamage;
            MaxDamage = maxDamage;
            WeaponID = weaponID;
        }
    }
}
