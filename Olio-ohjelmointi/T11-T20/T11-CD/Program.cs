using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace SHAA3209
{
    public class CD
    {
        //properties
        public string Name { get; set; }
        public string Artist { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
        public List<Song> Songs { get; set; }
        //constructors
        public CD()
        {
            Songs = new List<Song>();
        }
        //methods
        public override string ToString()
        {
            return $"-Name: {Name}\n-Artist: {Artist}\n-Price: {Price}€\n-Genre: {Genre}\nSongs:";
        }
    }
    public class Song
    {
        public string Name { get; set; }
        public  string Length { get; set; }
    }

    internal class Program
    {
        static void TestCD()
        {
            CD levy = new CD
            {
                Name = "Avojaloin",
                Artist = "Jean S.",
                Genre = "Rock, Funk/Soul, Pop",
                Price = 3.99M
            };
            Song song1 = new Song
            {
                Name = "Avojaloin",
                Length = "4:18"
                
            };
            Song song2 = new Song
            {
                Name = "Pompitaan",
                Length = "3:20"

            };
            Song song3 = new Song
            {
                Name = "Savon Heimo",
                Length = "2:37"

            };
            Song song4 = new Song
            {
                Name = "Kuopio tanssii ja soi",
                Length = "2:45"

            };
            Song song5 = new Song
            {
                Name = "Kolmen tähden hotellissa",
                Length = "4:20"

            };
            Song song6 = new Song
            {
                Name = "Dyynillä",
                Length = "4:32"

            };
            Song song7 = new Song
            {
                Name = "Kantatie 66",
                Length = "4:15"

            };
            Song song8 = new Song
            {
                Name = "Jykevä on rakkaus",
                Length = "3:42"

            };
            Song song9 = new Song
            {
                Name = "Lootusasentoon",
                Length = "3:11"

            };
            Song song10 = new Song
            {
                Name = "Kung Fu taistelee",
                Length = "3:07"

            };
            Song song11 = new Song
            {
                Name = "Hawaii Five-O",
                Length = "1:39"

            };
            List<Song> songlist = levy.Songs;
            songlist.Add(song1);
            songlist.Add(song2);
            songlist.Add(song3);
            songlist.Add(song4);
            songlist.Add(song5);
            songlist.Add(song6);
            songlist.Add(song7);
            songlist.Add(song8);
            songlist.Add(song9);
            songlist.Add(song10);
            songlist.Add(song11);

            Console.WriteLine(levy.ToString());
            foreach (Song song in songlist)
            {
                Console.WriteLine($"---Name: {song.Name} - {song.Length}");
            }

        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            TestCD();
        }
    }
}
