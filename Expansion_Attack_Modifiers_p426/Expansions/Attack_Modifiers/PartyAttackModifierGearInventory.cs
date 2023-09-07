using Expansion_Attack_Modifiers_p426.Expansions;
using Expansion_Attack_Modifiers_p426.Expansions.Gear;

namespace Expansion_Attack_Modifiers_p426.Expansions.Attack_Modifiers
{
    public class PartyAttackModifierGearInventory : PartyGearInventory
    {
        //private List<CharacterAttackModifierGearInventory> characters;
        //private PartyType heroes;
        //private string v;
        //private Inventory heroPartyInventory;

        //public PartyAttackModifierGearInventory(List<CharacterAttackModifierGearInventory> characters, PartyType heroes, string v, Inventory heroPartyInventory)
        //{
        //    this.characters = characters;
        //    this.heroes = heroes;
        //    this.v = v;
        //    this.heroPartyInventory = heroPartyInventory;
        //}
        public List<CharacterAttackModifierGearInventory> CharacterAttackModifiersGearInventory {  get; set; }
        public PartyAttackModifierGearInventory(List<CharacterAttackModifierGearInventory> characterAttackModifersGearInventory, PartyType partyType, string name, Inventory inventory) : base(partyType, name, inventory)
        {
            CharacterAttackModifiersGearInventory = characterAttackModifersGearInventory;
        }

        public PartyAttackModifierGearInventory(List<CharacterGearInventory> charactersGearInventory, PartyType partyType, string name, Inventory inventory) : base(charactersGearInventory, partyType, name, inventory)
        {
        }
    }
}