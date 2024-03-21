using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHAA3209
{
    public abstract class Game
    {
        private int minplayers;
        private int maxplayers;
        public bool Multiplayer { get; set; }
        public int MinPlayers 
        {
            get { return minplayers; }
            set
            {
                if (Multiplayer == false)
                {
                    minplayers = 1;
                }
                else { minplayers = value; }
            }
        }
        public int MaxPlayers 
        {
            get { return maxplayers; }
            set
            {
                if (Multiplayer == false)
                {
                    maxplayers = 1;
                }
                else { maxplayers = value; }
            } 
        }
        public Game() { }
        public Game(bool multiplayer,int minplayers,int maxplayers)
        {
            Multiplayer = multiplayer;
            MinPlayers = minplayers;
            MaxPlayers = maxplayers;
        }
        public abstract string PlayGame();
        public abstract string ShowInfo();
    }
    public class VideoGame : Game
    {
        public string Name { get; set; }
        public string Genre { get; set; }
        public string System { get; set; }
        public string Developer { get; set; }
        public VideoGame() { }
        public VideoGame(bool multiplayer, int minplayers, int maxplayers,string name,string genre,string system,string developer) : base(multiplayer,minplayers,maxplayers)
        { 
            Name = name;
            Genre = genre;
            System = system;
            Developer = developer;
        }
        public override string PlayGame()
        {
            if (Genre == "FPS" || Genre == "Shooter")
            {
                return $"*Pew* *Pew* *Pew* shooting enemies in {Name}\n";
            }
            else if (Genre == "Fighting")
            {
                return $"*Whack* *Thump* hitting and kicking enemies in {Name}\n";
            }
            else if (Genre == "Horror")
            {
                return $"*SCREAMS* are you frigtened in {Name}\n";
            }
            else
            {
                return $"*Game sounds* playing {Name}\n";
            }
        }
        public override string ShowInfo()
        {
            return $"{Name} is a {Genre} game to {System} from {Developer}.\nIt supports {MinPlayers} to {MaxPlayers} amount of players\n\n";
        }
    }
    public class TabletopGame : Game
    {
        public string Name { get; set; }
        public string Genre { get; set; }
        public string Creator { get; set; }
        public bool HasDice { get; set; }
        public TabletopGame() { }
        public TabletopGame(bool multiplayer, int minplayers, int maxplayers, string name, string genre, string creator, bool dice) : base(multiplayer, minplayers, maxplayers)
        {
            Name = name;
            Genre = genre;
            Creator = creator;
            HasDice = dice;
        }
        public override string PlayGame()
        {
            if (HasDice == true)
            {
                return $"*Roll* *Roll* rolling dice in {Name}\n";
            }
            else
            {
                return $"*Tabletop sounds with no rolling* playing some {Name}\n";
            }
        }
        public override string ShowInfo()
        {
            if (HasDice == true)
            {
                return $"{Name} is a tabletop game. It is a {Genre} game created by {Creator}. It is played using dice and supports {MinPlayers} to {MaxPlayers} amount of players.\n\n";
            }
            else
            {
                return $"{Name} is a tabletop game. It is a {Genre} game created by {Creator}. It is played without using dice and supports {MinPlayers} to {MaxPlayers} amount of players..\n\n";
            }
        }
    }
        public class CardGame : Game
        {
            public string Name { get; set; }
            public int NumberOfCards { get; set; }
            public CardGame() { }
            public CardGame(bool multiplayer, int minplayers, int maxplayers, string name,int cards) : base(multiplayer, minplayers, maxplayers)
            {
                Name = name;
                NumberOfCards = cards;
            }
            public override string PlayGame()
            {
                return $"*Shuffle* *Swish* playing some {Name} \n";
            }
            public override string ShowInfo()
            {
                return $"{Name} is a card game, played with {NumberOfCards} cards and supports {MinPlayers} to {MaxPlayers} amount of players.\n\n";
            }
        }
    internal class Program
    {
        static void TestVideoGames()
        {
            VideoGame videogame1 = new VideoGame(true,1,20,"CallOfDuty","FPS","PC,Playstation,Xbox","Activision");
            VideoGame videogame2 = new VideoGame(false, 1, 1, "Judgement", "Fighting", "PC,Playstation", "Ryu Ga Gotoku Studio");
            VideoGame videogame3 = new VideoGame(false, 1, 3, "Crash Bandicoot", "Adventure/Platforming", "Playstation1", "Naughtydog");
            Console.WriteLine(videogame1.PlayGame() + videogame1.ShowInfo());
            Console.WriteLine(videogame2.PlayGame() + videogame2.ShowInfo());
            Console.WriteLine(videogame3.PlayGame() + videogame3.ShowInfo());
        }
        static void TestTabletopGames()
        {
            TabletopGame lautapeli1 = new TabletopGame(true,2,4,"Afrikantähti","Adventure", "Kari Mannerla",true);
            TabletopGame lautapeli2 = new TabletopGame(true, 2, 5, "Carcassonne", "Strategy", "Klaus-Jürgen Wrede", false);
            Console.WriteLine(lautapeli1.PlayGame() + lautapeli1.ShowInfo());
            Console.WriteLine(lautapeli2.PlayGame() + lautapeli2.ShowInfo());
        }
        static void TestCardGames()
        {
            CardGame korttipeli1 = new CardGame(true,2,6,"Ristiseiska",52);
            CardGame korttipeli2 = new CardGame(true,2,10,"Uno",108);
            Console.WriteLine(korttipeli1.PlayGame() + korttipeli1.ShowInfo());
            Console.WriteLine(korttipeli2.PlayGame() + korttipeli2.ShowInfo());
        }
        static void Main(string[] args)
        {
            TestVideoGames();
            TestTabletopGames();
            TestCardGames();
        }
    }
}
