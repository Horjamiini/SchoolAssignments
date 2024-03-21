using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHAA3209
{
    public class CD
    {
        private TimeSpan totallength;
        private List<Song> _songs;
        public string Name { get; set; }
        public string Artist { get; set; }
        public int NumberOfSongs 
        {
            get { return Songs.Count(); }
        }
        public string TotalLength
        {
            get
            {
                //getting the total length of CD with loop and adding every song-objects
                //length into totallength TimeSpan field
                foreach (Song song in Songs)
                {
                    totallength += song.Length;
                }
                var min = string.Format("***{0}min {1}sec***", totallength.Minutes, totallength.Seconds);
                return min;
            }
        }
        public List<Song> Songs { get { return _songs; } }
        //constructor
        public CD(string name,string artist)
        {
            Name = name;
            Artist = artist;
            _songs = new List<Song>();
        }
        //methods
        public override string ToString()
        {
            return $"You have a CD:\n- Name: {Name}\n- Artist: {Artist}\n- TotalLength: {TotalLength}\n- {NumberOfSongs} songs:";
        }
    }
    public class Song
    {
        public string Name { get; set; }
        public TimeSpan Length { get; set; }
        public string Feature { get; set; }
        //constuctor
        public Song(string name,string length, string feature)
        {
            Name = name;
            Length = TimeSpan.Parse(length);
            Feature = feature;
        }
        //methods
        public override string ToString()
        {
            // different return depending on if song has a featuring artist or not
            if (Feature != null)
            {
                return $"  -{Name}, {Length:mm\\:ss}, feat.{Feature}";
            }
            else
            {
                return $"  -{Name}, {Length:mm\\:ss}";
            }
        }
    }
    internal class Program
    {
        static void TestCD()
        {
            CD cd = new CD("Kaikki loppuu", "Timo Pieni Huijaus");
            Song biisi1 = new Song("Kaikki Loppuu", "00:04:33",null);
            Song biisi2 = new Song("Kuutamokeikkaa", "00:03:43","Elastinen");
            Song biisi3 = new Song("Pahoillani Äiti", "00:03:41",null);
            Song biisi4 = new Song("Keskellä", "00:03:44", null);
            Song biisi5 = new Song("Suomi-neito", "00:03:37",null);
            Song biisi6 = new Song("Listan Ykkönen", "00:03:35","JVG");
            Song biisi7 = new Song("Ysiseiska", "00:05:32","Andu");
            Song biisi8 = new Song("Jos Te Vaan Seisotte Vieres", "00:03:24",null);
            Song biisi9 = new Song("Pleiboi", "00:03:37",null);
            Song biisi10 = new Song("Ruusuja", "00:04:05", "Illi");
            Song biisi11 = new Song("Sydämeni", "00:04:05", "Tasis");
            Song biisi12 = new Song("Paratiisi", "00:03:37", null);
            Song biisi13= new Song("Viimeinen Hidas", "00:05:34", "Illi");
            cd.Songs.Add(biisi1);
            cd.Songs.Add(biisi2);
            cd.Songs.Add(biisi3);
            cd.Songs.Add(biisi4);
            cd.Songs.Add(biisi5);
            cd.Songs.Add(biisi6);
            cd.Songs.Add(biisi7);
            cd.Songs.Add(biisi8);
            cd.Songs.Add(biisi9);
            cd.Songs.Add(biisi10);
            cd.Songs.Add(biisi11);
            cd.Songs.Add(biisi12);
            cd.Songs.Add(biisi13);
            Console.WriteLine(cd.ToString());
            foreach(Song song in cd.Songs)
            {
                Console.WriteLine($"{song}");
            }
        }
        static void Main(string[] args)
        {
            TestCD();
        }
    }
}
