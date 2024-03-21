using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SHAA3209
{
    public class Player
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string GamePosition { get; set; }
        public int Number { get; set; }
        public Player(string firstname,string lastname,string position,int number)
        {
            FirstName = firstname;
            LastName = lastname;
            GamePosition = position;
            Number = number;
        }
        public override string ToString()
        {
            return $"- Name:{FirstName} {LastName} Number:{Number}, Position:{GamePosition}";
        }
    }
    public class Team
    {
        private List<Player> _players;
        public string Name { get; set; }
        public string Hometown { get; set; }
        public List<Player> Players { get { return _players; } }
        public Team(string name)
        {
            Name = name;
            //Could be done with all SMLeague teams
            // if team name is something that isn't in this '3 team league'
            if ((Name == "JYP" || Name == "Jyp"))
            {
                Hometown = "Jyväskylä";
            }
            else if (Name == "KooKoo" || Name == "KOOKOO")
            {
                Hometown = "Kouvola";
            }
            else if (Name == "Ilves" || Name == "ILVES")
            {
                Hometown = "Tampere";
            }
            //if the team does not belong to the SMLEAGUE the teams hometown will be null
            else { Hometown = null; }
            _players = AssignPlayers();
        }
        public override string ToString()
        {
            return $"{Name} from {Hometown}\nPlayers:";
        }
        public void AddPlayer(string firstname,string lastname,string position,int number)
        {
            Players.Add(new Player(firstname, lastname, position, number));
        }
        public void RemovePlayer(int number)
        {
            var item = Players.SingleOrDefault(x => x.Number == number);
            if (item != null)
            {
                Players.Remove(item);
            }
        }
        private  List<Player> AssignPlayers()
        {
            if (Name == "JYP" || Name == "Jyp")
            {
                return new List<Player>()
                {
                new Player("Robert","Rooba","Laitahyökkääjä",88),
                new Player("Kyle","Platzer","Keskushyökkääjä",18),
                new Player("Jerry","Turkulainen","Laitahyökkääjä",32),
                new Player("Tobias","Winberg","Puolustaja",29),
                new Player("Sami","Niku","Puolustaja",8),
                new Player("Veini","Vehviläinen","Maalivahti",35)
                };
            }
            else if (Name == "KooKoo" || Name == "KOOKOO")
            {
                return new List<Player>()
                {
                    new Player("Heikki","Liedes","Laitahyökkääjä",9),
                    new Player("Kasperi","Ojantakanen","Keskushyökkääjä",27),
                    new Player("Joose","Antonen","Laitahyökkääjä",48),
                    new Player("Charles-Edouard","D'astous","Puolustaja",45),
                    new Player("Miska","Kukkonen","Puolustaja",43),
                    new Player("Oskari","Setänen","Maalivahti",32)
                };
            }
            else if (Name == "Ilves" || Name == "ILVES")
            {
                return new List<Player>()
                {
                    new Player("Eemeli","Suomi","Laitahyökkääjä",10),
                    new Player("Balazs","Sebok","Keskushyökkääjä",86),
                    new Player("Joona","Ikonen","Laitahyökkääjä",32),
                    new Player("Jarkko","Parikka","Puolustaja",57),
                    new Player("Lester","Lancaster","Puolustaja",74),
                    new Player("Marek","Langhammer","Maalivahti",94)
                };
            }
            //If team name doen't belong to SMLEAGUE the teams roster will be empty list
            else { return new List<Player>(); }
        }

    }
    internal class Program
    {
        static void TestSMLiiga()
        {
            Team team1 = new Team("Jyp");
            Console.WriteLine(team1);
            foreach (var player in team1.Players)
            {
                Console.WriteLine(player);
            }
            Team team2 = new Team("Panthers");
            Console.WriteLine(team2);
            foreach (var player in team2.Players)
            {
                Console.WriteLine(player);
            }
            Team team3 = new Team("KooKoo");
            Console.WriteLine(team3);
            foreach (var player in team3.Players)
            {
                Console.WriteLine(player);
            }
        }
        static void TestAddingAndRemoving()
        {
            Team team1 = new Team("Ilves");
            Console.WriteLine(team1);
            foreach (var player in team1.Players)
            {
                Console.WriteLine(player);
            }
            //lisätään pelaaja joukkueeseen
            team1.AddPlayer("Petri", "kontiola", "keskushyökkääjä", 27);
            //Poistetaan pelaaja numeroltaan 86 eli Sebok Balazs
            team1.RemovePlayer(86);
            Console.WriteLine("\n");
            Console.WriteLine(team1);
            foreach (var player in team1.Players)
            {
                Console.WriteLine(player);
            }
        }
        static void TestSavingToCSV()
        {
            //tallennetaan joukkuuen pleaajat CSV-tiedostoon
            //joukkue voitaisiin myös kysyä käyttäjältä
            Team team1 = new Team("Jyp");
            SaveToCSV(team1);
        }
        static void Main(string[] args)
        {
            TestSMLiiga();
            TestAddingAndRemoving();
            TestSavingToCSV();
        }
        private static void SaveToCSV(Team team)
        {
            //CSV tallennus metodi
            string file = $@"C:\Projects\{team.Name}.csv";
            String separator = ";";
            StringBuilder output = new StringBuilder();
            foreach (Player player in team.Players)
            {
                String[] newLine = { player.FirstName, player.LastName, player.GamePosition, player.Number.ToString() };
                output.AppendLine(string.Join(separator,newLine));
            }
            try
            {
                File.AppendAllText(file, output.ToString());
                Console.WriteLine($"{team.Name} players have been saved into a CSV file successfully");
            }
            catch (Exception)
            {
                Console.WriteLine("Could not write team data to CSV file :(");
                return;
            }
        }
    }
}
