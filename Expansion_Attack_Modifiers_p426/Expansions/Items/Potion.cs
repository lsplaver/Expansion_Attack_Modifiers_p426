namespace Expansion_Attack_Modifiers_p426.Expansions.Items
{
    public enum PotionTypes { POTION_HEALING }
    public enum PotionEffectTypes { HEALING }
    public enum PotionName { HEALING_10 }
    public class Potion : Item
    {
        public PotionName potionName { get; set; }
        public PotionTypes PotionType { get; set; }
        public string EffectDescription { get; set; }
        public PotionEffectTypes PotionEffectType { get; set; }
        public int EffectLevel { get; set; }

        public Potion(string name, ItemTypes itemType, PotionTypes potionType, string effectDescription, PotionEffectTypes potionEffectType, int effectLevel) : base(name, itemType)
        {
            EffectDescription = effectDescription;
            PotionEffectType = potionEffectType;
            EffectLevel = effectLevel;
        }
    }
}
