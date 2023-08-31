namespace Expansion_Attack_Modifiers_p426.Expansions.Gear
{
    public enum GearTypes { WEAPON }
    public class Gear
    {
        public GearTypes GearType { get; set; }
        public Gear() { }

        public Gear(GearTypes gearType)
        {
            GearType = gearType;
        }
    }
}
