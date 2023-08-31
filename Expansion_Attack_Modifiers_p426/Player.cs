namespace Expansion_Attack_Modifiers_p426
{
    public class Player
    {
        public string Name { get; set; }
        public PlayerType PlayerType { get; set; }
        public int PlayerID { get; set; }
        public PartyType PartyType { get; set; }

        public Player(string name, PlayerType playerType, int playerID, PartyType partyType)
        {
            Name = name;
            PlayerType = playerType;
            PlayerID = playerID;
            PartyType = partyType;
        }
    }
}
