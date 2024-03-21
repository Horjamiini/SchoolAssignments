using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SHAA3209
{
    public abstract class Item
    {
        //properties
        public bool Ownership { get; set; }
        //constuctor
        public Item () {}
        public Item(bool ownership) 
        {
            Ownership = ownership;
        }
        //methods
        private string Owned()
        {
            return Ownership ? "My own" : "Borrowed";
        }
        public override string ToString()
        {
            return $"This item is {Owned()}\n";
        }
    }
    public abstract class PrintedMatter : Item
    {
        //properties
        public string Name { get; set; }
        public int Pages { get; set; }
        public int YearPublished { get; set; }
        public string Publisher { get; set; }
        public decimal Price { get; set; }
        //constructor
        public PrintedMatter(){ }
        public PrintedMatter(bool ownership,string name,int pages,int year,string publisher, decimal price) : base(ownership)
        {
            Name = name;
            Pages = pages;
            YearPublished = year;
            Publisher = publisher;
            Price = price;
        }
        //methods
        public override string ToString()
        {
            return base.ToString() + $"Name: {Name}, Pages: {Pages}, Published: {YearPublished}, Publisher: {Publisher}, Price: {Price}€\n";
        }
    }
    public class Book : PrintedMatter
    {
        //properties
        public string Author { get; set; }
        public string Genre { get; set; }
        //constructors
        public Book () { }
        public Book(bool ownership, string name, int pages, int year, string publisher, decimal price, string author, string genre) : base(ownership,name,pages,year,publisher,price)
        {
            Author = author;
            Genre = genre;
        }
        //methods
        public override string ToString()
        {
            return base.ToString() + $"Author: {Author}, Genre: {Genre}\n\n";
        }
    }
    public class Magazine : PrintedMatter
    {
        //properties
        public string Schedule { get; set; }
        public bool FreeCirculation { get; set; }
        //constuctors
        public Magazine(){ }
        public Magazine(bool ownership, string name, int pages, int year, string publisher, decimal price, string schedule, bool circulation) : base(ownership, name, pages, year, publisher, price)
        {
            Schedule = schedule;
            FreeCirculation = circulation;
        }
        //method
        public override string ToString()
        {
            return base.ToString() + $"Publishing Schedule: {Schedule}, Circulation: {ShowCirculation()}\n\n";
        }
        private string ShowCirculation()
        {
            return FreeCirculation ? "Free" : "Subscription";
        }
    }
    public abstract class Disc : Item
    {
        //properties
        public string Name { get; set; }
        public string Type { get; set; }
        public int YearPublished { get; set; }
        public string Genre { get; set; }
        public double Duration { get; set; }
        public decimal Price { get; set; }
        //constructors
        public Disc() { }
        public Disc(bool ownership, string name, string type, int year, string genre, double duration, decimal price) : base(ownership)
        {
            Name = name;
            Type = type;
            YearPublished = year;
            Genre = genre;
            Duration = duration;
            Price = price;
        }
        //methods
        public override string ToString()
        {
            return base.ToString() + $"Name: {Name}, Type: {Type}, Published: {YearPublished}, Genre: {Genre}, Duration: {Duration}min, Price: {Price}€\n";
        }
    }
    public class CD : Disc
    {
        //properties
        public string Artist { get; set; }
        public int Tracks { get; set; }
        public CD() { }
        public CD (bool ownership, string name, string type, int year, string genre, double duration, decimal price,string artist,int tracks) : base(ownership,name,type,year,genre,duration,price)
        {
            Artist = artist;
            Tracks = tracks;
        }
        //methods
        public override string ToString()
        {
            return base.ToString() + $"Artist: {Artist}, Number of Tracks: {Tracks}\n\n";
        }
    }
    public class DVD : Disc
    {
        //properties
        public int Resolution { get; set; }
        public string Producer { get; set; }
        //constructors
        public DVD() { }
        public DVD(bool ownership, string name, string type, int year, string genre, double duration, decimal price, int resolution, string producer) : base(ownership, name, type, year, genre, duration, price)
        {
            Producer = producer;
            Resolution = resolution;
        }
        //methods
        public override string ToString()
        {
            return base.ToString() + $"Resolution: {Resolution}p, Producer: {Producer}\n\n";
        }
    }
    public class Bluray : Disc 
    {
        
        public int Resolution { get; set; }
        public string Producer { get; set; }
        //constructors
        public Bluray() { }
        public Bluray(bool ownership, string name, string type, int year, string genre, double duration, decimal price, int resolution, string producer) : base(ownership, name, type, year, genre, duration, price)
        {
            Producer = producer;
            Resolution = resolution;
        }
        //methods
        public override string ToString()
        {
            return base.ToString() + $"Resolution: {Resolution}p, Producer: {Producer}\n\n";
        }
    }

    internal class Program
    {
        static void TestPrintedMatter()
        {
            Book kirja = new Book(false,"Seitsemän Veljestä",459,1870,"WSOY",12.00M,"Aleksis Kivi", "Classics, Development Novels"){};
            Magazine aikakausilehti = new Magazine(true,"Seiska",50,2023,"Aller Media",7.99M,"Weekly",false){};
            Console.WriteLine(kirja.ToString() + aikakausilehti.ToString());
        }
        static void TestDiscs()
        {
            CD levy = new CD(true,"NaaraS","Music",2014,"Pop",40,99M,"Jean S.",12) { };
            DVD dvd = new DVD(false, "Suits - Season2", "TV-series", 2013, "Drama", 672, 11.90M, 480, "Hypnotic Films & Television and Universal Cable Productions") { };
            Bluray bluray = new Bluray(true, "Live And Let Die", "Movie", 1973, "Thriller", 121, 6.90M, 1080, "Eon productions") { };
            Console.WriteLine(levy.ToString() + dvd.ToString() + bluray.ToString());
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            TestPrintedMatter();
            TestDiscs();
        }
    }
}
