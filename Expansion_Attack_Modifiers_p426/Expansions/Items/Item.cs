namespace Expansion_Attack_Modifiers_p426.Expansions.Items
{
    public enum ItemTypes { POTION }
    public class Item
    {
        public string Name { get; set; }
        public ItemTypes ItemType { get; set; }
        public Item() { }

        public Item(string name, ItemTypes itemType)
        {
            Name = name;
            ItemType = itemType;
        }
    }
}
