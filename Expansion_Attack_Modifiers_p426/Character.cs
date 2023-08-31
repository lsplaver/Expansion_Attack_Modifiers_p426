using Expansion_Attack_Modifiers_p426.Actions;

namespace Expansion_Attack_Modifiers_p426;


public class Character
{
    public string Name { get; set; }
    public List<AvailableAction> AvailableActions { get; set; }
    public int MaxHP { get; set; }
    public int CurrentHP { get; set; }
    public string CharacterID { get; set; }

    public Character(string name, List<AvailableAction> availableActions, int maxHP, string characterID)
    {
        Name = name;
        AvailableActions = availableActions;
        MaxHP = maxHP;
        CurrentHP = MaxHP;
        CharacterID = characterID;
    }

    public Character(string name, int maxHP, string characterID)
    {
        Name = name;
        MaxHP = maxHP;
        CharacterID = characterID;
    }
}
