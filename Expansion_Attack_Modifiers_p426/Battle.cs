using Expansion_Attack_Modifiers_p426.Expansions.Attack_Modifiers;
using Expansion_Attack_Modifiers_p426.Expansions.Gear;
using Expansion_Attack_Modifiers_p426.Expansions.Items;
using Expansion_Attack_Modifiers_p426.Expansions.Vin_Fletcher;

namespace Expansion_Attack_Modifiers_p426
{
    public class Battle
    {
        public Party Heroes { get; set; }
        public List<Party> Monsters { get; set; }
        public Character CurrentCharacter { get; set; }
        public PartyType CurrentPartyType { get; set; }
        public List<Player> Players { get; set; }
        public Player CurrentPlayer { get; set; }
        public PartyItemInventory CurrentPartyItemInventory { get; set; }
        public int CurrentMonsterPartyNumber { get; set; }
        public Party CurrentParty { get; set; }
        public PartyGearInventory HeroesGearInventory { get; set; }
        public List<PartyGearInventory> MonstersGearInventory { get; set; }
        public PartyGearInventory CurrentPartyGearInventory { get; set; }
        public string Expansions { get; set; }
        public PartyItemInventory HeroesItemInventory { get; set; }
        public List<PartyItemInventory> MonstersItemInventory { get; set; }
        public CharacterGearInventory CurrentCharacterGearInventory { get; set; }
        public CharacterHitChance CurrentCharacterHitChance { get; set; }
        public PartyItemInventoryHitChance HeroesItemInventoryHitChance { get; set; }
        public List<PartyItemInventoryHitChance> MonstersItemInventoryHitChance { get; set; }
        public Player Player { get; set; }
        public PartyItemInventoryHitChance CurrentPartyItemInventoryHitChance { get; set; }
        public PartyGearInventoryHitChance HeroesPartyGearInventoryHitChance { get; set; }
        public List<PartyGearInventoryHitChance> MonstersPartyGearInventoryHitChances { get; set; }
        public CharacterGearInventoryHitChance CurrentCharacterGearInventoryHitChance { get; set; }
        public PartyGearInventoryHitChance CurrentPartyGearInventoryHitChance { get; set; }
        public CharacterAttackModifier CurrentCharacterAttackModifier { get; set; }
        public PartyAttackModifierItemInventory HeroesPartyAttackModifierItemInventory { get; set; }
        public PartyAttackModifierItemInventory CurrentPartyAttackModifierItemInventory { get; set; }
        public List<PartyAttackModifierItemInventory> MonstersPartyAttackModifierItemInventory { get; set; }

        public Battle(Party heroes, List<Party> monsters, Character currentCharacter, PartyType currentPartyType, List<Player> players, Player currentPlayer, Party currentParty, string expansions)
        {
            Heroes = heroes;
            Monsters = monsters;
            CurrentCharacter = currentCharacter;
            CurrentPartyType = currentPartyType;
            Players = players;
            CurrentPlayer = currentPlayer;
            CurrentParty = currentParty;
            Expansions = expansions;
        }

        public Battle(Party heroes, List<Party> monsters, CharacterHitChance currentCharacterHitChance, PartyType currentPartyType, List<Player> players, Player currentPlayer, Party currentParty, string expansions)
        {
            Heroes = heroes;
            Monsters = monsters;
            CurrentCharacterHitChance = currentCharacterHitChance;
            CurrentPartyType = currentPartyType;
            Players = players;
            CurrentPlayer = currentPlayer;
            CurrentParty = currentParty;
            Expansions = expansions;
        }

        public Battle(PartyItemInventory heroes, List<PartyItemInventory> monsters, Character currentCharacter, PartyType currentPartyType, List<Player> players, Player currentPlayer, PartyItemInventory currentPartyGearInventory, string expansions)
        {
            HeroesItemInventory = heroes;
            MonstersItemInventory = monsters;
            CurrentCharacter = currentCharacter;
            CurrentPartyType = currentPartyType;
            Players = players;
            CurrentPlayer = currentPlayer;
            CurrentPartyItemInventory = currentPartyGearInventory;
            Expansions = expansions;
        }

        public Battle(PartyGearInventory heroes, List<PartyGearInventory> monsters, CharacterGearInventory currentCharacterGearInventory, PartyType currentPartyType, List<Player> players, Player currentPlayer, PartyGearInventory currentPartyGearInventory, string expansions)
        {
            HeroesGearInventory = heroes;
            MonstersGearInventory = monsters;
            CurrentCharacterGearInventory = currentCharacterGearInventory;
            CurrentPartyType = currentPartyType;
            Players = players;
            CurrentPlayer = currentPlayer;
            CurrentPartyGearInventory = currentPartyGearInventory;
            Expansions = expansions;
        }

        public Battle(PartyItemInventoryHitChance heroesItemInventoryHitChance, List<PartyItemInventoryHitChance> monstersItemInventoryHitChance, CharacterHitChance currentCharacterHitChance, PartyType currentPartyType, List<Player> players, Player player, PartyItemInventoryHitChance currentPartyItemInventoryHitChance, string expansions)
        {
            HeroesItemInventoryHitChance = heroesItemInventoryHitChance;
            MonstersItemInventoryHitChance = monstersItemInventoryHitChance;
            CurrentCharacterHitChance = currentCharacterHitChance;
            CurrentPartyType = currentPartyType;
            Players = players;
            Player = player;
            CurrentPartyItemInventoryHitChance = currentPartyItemInventoryHitChance;
            Expansions = expansions;
        }

        public Battle(PartyGearInventoryHitChance heroesGearInventoryHitChance, List<PartyGearInventoryHitChance> monstersGearInventoryHitChance, CharacterGearInventoryHitChance currentCharacterGearInventoryHitChance, PartyType currentPartyType, List<Player> players, Player player, PartyGearInventoryHitChance currentPartyGearInventoryHitChance, string expansions)
        {
            HeroesPartyGearInventoryHitChance = heroesGearInventoryHitChance;
            MonstersPartyGearInventoryHitChances = monstersGearInventoryHitChance;
            CurrentCharacterGearInventoryHitChance = currentCharacterGearInventoryHitChance;
            CurrentPartyType = currentPartyType;
            Players = players;
            Player = player;
            CurrentPartyGearInventoryHitChance = currentPartyGearInventoryHitChance;
            Expansions = expansions;
        }

        public Battle(PartyAttackModifierItemInventory heroesPartyAttackModifierItemInventory, List<PartyAttackModifierItemInventory> monstersPartyAttackModifierItemInventory, /*CharacterAttackModifier currentCharacterAttackModifier*/ Character currentCharacter, PartyType currentPartyType, List<Player> players, Player player, PartyAttackModifierItemInventory currentPartyAttackModifierItemInventory, string expansions)
        {
            HeroesPartyAttackModifierItemInventory = heroesPartyAttackModifierItemInventory;
            MonstersPartyAttackModifierItemInventory = monstersPartyAttackModifierItemInventory;
            CurrentCharacter /*CurrentCharacterAttackModifier*/ = currentCharacter /*currentCharacterAttackModifier*/;
            CurrentPartyType = currentPartyType;
            Players = players;
            Player = player;
            CurrentPartyAttackModifierItemInventory = currentPartyAttackModifierItemInventory;
            Expansions = expansions;
        }
    }
}
