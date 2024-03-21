using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SHAA3209
{
    public interface ICanPlayGame
    {
        bool Controller { get; set; }
        string StartGame(Game game);
        string SaveGame(Game game);
        string QuitGame(Game game);
    }
    public class Game
    {
        private bool currentlyplaying = false;
        private int savestate = 0;
        public string Name { get; set; }
        public string Developer { get; set; }
        public int SaveState { get { return savestate; } }
        public bool CurrentlyPlaying { get { return currentlyplaying; } }
        public Game(string name,string developer)
        {
            Name = name;
            Developer = developer;
        }
        public void RecordPlaying()
        {
            savestate += 1;
        }
        public void RecordCurrentlyPlaying()
        {
            if (currentlyplaying)
            {
                currentlyplaying = false;
            }
            else
            {
                currentlyplaying = true;
            }
        }
        public override string ToString()
        {
            return $"{Name} - Developer: {Developer}";
        }
    }
    internal class Program
    {
        static void TestPC()
        {
            PC pc = new PC("Vistus","HP",false){};
            Game peli1 = new Game("Elden Ring","FromSoftware");
            Game peli2 = new Game("Judgement", "Rya Ga Gotoku Studio");
            Game peli3 = new Game("CS:GO","Valve");
            pc.Games.Add(peli1);
            pc.Games.Add(peli2);
            pc.Games.Add(peli3);          
            Console.WriteLine(pc.ToString());
            foreach (var item in pc.Games)
            {
                Console.WriteLine($"{item.ToString()}");
            }
            Console.Write("\n");
            //Test basic commands and starting same game again
            Console.WriteLine(pc.StartGame(peli1));
            Console.WriteLine(pc.SaveGame(peli1));
            Console.WriteLine(pc.QuitGame(peli1));
            Console.WriteLine(pc.StartGame(peli1));
            Console.WriteLine(pc.QuitGame(peli1));

            //Test saving and quitting games that are not currently being played
            Console.Write("\n");
            Console.WriteLine(pc.SaveGame(peli2));
            Console.WriteLine(pc.QuitGame(peli3));
            Console.Write("\n");

        }
        static void TestPlaystation()
        {
            Playstation ps = new Playstation("Playstation4", "Sony", true);
            Game peli1 = new Game("Bloodborne", "FromSoftware");
            Game peli2 = new Game("Spyro Reignited Trilogy", "Universal");
            Game peli3 = new Game("Crash Bandicoot Trilogy","Naughty Dog");
            ps.Games.Add(peli1);
            ps.Games.Add(peli2);
            // peli3 not added to list for testing later
            Console.WriteLine(ps.ToString());
            foreach (var item in ps.Games)
            {
                Console.WriteLine($"{item.ToString()}");
            }
            Console.WriteLine(ps.StartGame(peli1));
            Console.WriteLine(ps.StartGame(peli2));
            Console.WriteLine(ps.QuitGame(peli2));
            //test saving limit in playstation
            Console.WriteLine(ps.SaveGame(peli1));
            Console.WriteLine(ps.SaveGame(peli1));
            Console.WriteLine(ps.SaveGame(peli1));
            Console.WriteLine(ps.SaveGame(peli1));
            Console.WriteLine(ps.SaveGame(peli2));
            Console.WriteLine(ps.QuitGame(peli1));
            Console.Write("\n");
            Console.WriteLine(ps.StartGame(peli2));
            //test starting game that is not in collection
            Console.WriteLine(ps.StartGame(peli3));


        }
        static void Main(string[] args)
        {
            TestPC();
            TestPlaystation();
        }
    }
}
