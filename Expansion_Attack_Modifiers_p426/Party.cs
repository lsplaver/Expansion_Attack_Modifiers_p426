using Expansion_Attack_Modifiers_p426.Expansions.Attack_Modifiers;
using Expansion_Attack_Modifiers_p426.Expansions.Gear;
using Expansion_Attack_Modifiers_p426.Expansions.Vin_Fletcher;

namespace Expansion_Attack_Modifiers_p426;


public class Party
{
    public List<Character> Characters { get; set; }
    public PartyType PartyType { get; set; }
    public string Name { get; set; }
    public List<CharacterGearInventory> CharactersGearInventory { get; set; }
    public List<CharacterHitChance> CharactersHitChance { get; set;  }
    public List<CharacterAttackModifier> CharactersAttackModifier { get; set; }
    public List<CharacterAttackModifierHitChance> CharactersAttackModifierHitChance { get; set; }

    public Party(List<Character> characters, PartyType partyType, string name)
    {
        Characters = characters;
        PartyType = partyType;
        Name = name;
    }

    public Party(List<CharacterGearInventory> charactersGearInventory, PartyType partyType, string name)
    {
        CharactersGearInventory = charactersGearInventory;
        PartyType = partyType;
        Name = name;
    }

    public Party(List<CharacterHitChance> charactersHitChance, PartyType partyType, string name)
    {
        CharactersHitChance = charactersHitChance;
        PartyType = partyType;
        Name = name;
    }

    public Party(PartyType partyType, string name)
    {
        PartyType = partyType;
        Name = name;
    }

    public Party(List<CharacterAttackModifier> characters, PartyType partyType, string name)
    {
        CharactersAttackModifier = characters;
        PartyType = partyType;
        Name = name;
    }

    public Party(List<CharacterAttackModifierHitChance> characters, PartyType partyType, string name)
    {
        CharactersAttackModifierHitChance = characters;
        PartyType = partyType;
        Name = name;
    }
}
