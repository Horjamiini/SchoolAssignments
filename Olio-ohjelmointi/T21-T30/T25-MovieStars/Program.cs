using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SHAA3209
{
    public abstract class Human
    {
        public string Name { get; set; }
        public int BirthYear { get; set; }
        public Human(string name,int year)
        {
            Name = name;
            BirthYear = year;
        }
        public override string ToString()
        {
            return $"- {Name},{BirthYear}";
        }
    }
    public class Actor : Human
    {
        public Actor(string name,int year) : base(name,year)
        {

        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
    public class Director : Human
    {
        public Director(string name, int year) : base(name, year)
        {

        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
    public class Movie
    {
        private Director _director;
        private List<Actor> _actors;
        public string Name { get; set; }
        public int PublishYear { get; set; }
        public Director Director { get { return _director; } }
        public List<Actor> Actors { get { return _actors; } }
        //constructor
        public Movie(string name,int publishyear,Director director)
        {
            Name = name;
            PublishYear = publishyear;
            _director = director;
            _actors = new List<Actor>();
        }
        //method
        public override string ToString()
        {
            return $"Movie: {Name} directed by {Director} was released in {PublishYear} and it features these actors:";
        }
    }
    internal class Program
    {
        static void TestMovies()
        {
            Actor actor1 = new Actor("Samuel L. Jackson", 1948);
            Actor actor2 = new Actor("Chrisopher Waltz", 1956);
            Actor actor4 = new Actor("Brad Pitt", 1963);
            Actor actor5 = new Actor("Zoë Bell", 1978);
            Actor actor6 = new Actor("Uma Thurman", 1970);
            Actor actor7 = new Actor("Leonardo Di Caprio", 1974);
            Actor actor8 = new Actor("Mark Ruffalo", 1967);
            Actor actor9 = new Actor("Margot Robbie", 1990);
            Director director1 = new Director("Quentin Tarantino", 1963);
            Director director2 = new Director("Martin Scorsese", 1942);



            Movie movie1 = new Movie("Inglorious Basterds",2009,director1);
            movie1.Actors.Add(actor1);
            movie1.Actors.Add(actor2);
            movie1.Actors.Add(actor4);
            movie1.Actors.Add(actor5);

            Movie movie2 = new Movie("Pulp Fiction", 1994, director1);
            movie2.Actors.Add(actor1);
            movie2.Actors.Add(actor6);

            Movie movie3 = new Movie("Shutter Island", 2010, director2);
            movie3.Actors.Add(actor7);
            movie3.Actors.Add(actor8);

            Movie movie4 = new Movie("The Wolf Of Wall Street", 2013, director2);
            movie4.Actors.Add(actor7);
            movie4.Actors.Add(actor9);

            Console.WriteLine(movie1.ToString());
            foreach (var item in movie1.Actors)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("\n");

            Console.WriteLine(movie2.ToString());
            foreach (var item in movie2.Actors)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine("\n");
            Console.WriteLine(movie3.ToString());
            foreach (var item in movie3.Actors)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine("\n");
            Console.WriteLine(movie4.ToString());
            foreach (var item in movie4.Actors)
            {
                Console.WriteLine(item.ToString());
            }

        }
        static void TestMoviesWithUserInput()
        {
            Console.WriteLine("\n");
            List<Movie> movielist = new List<Movie>();
            while (true)
            {
                Console.Write("Give me a movie name: ");
                string moviename = Console.ReadLine();
                Console.Write("When was the movie published(year): ");
                string movieyear = Console.ReadLine();
                if (Int32.TryParse(movieyear, out int year))
                {
                    Console.Write("Who directed the movie?: ");
                    string directorname = Console.ReadLine();
                    Console.Write("When was the director born(year): ");
                    string directorbday = Console.ReadLine();
                    if (Int32.TryParse(directorbday, out int directoryear))
                    {
                        Director director = new Director(directorname, directoryear);
                        Movie movie1 = new Movie(moviename, year, director);
                        for (int i = 3; i > 0; i--)
                        {
                            Console.Write($"Give me {i} actor(s) and their birhtyear that act in the movie example(name,birthyear): ");
                            string actordata = Console.ReadLine();
                            string[] actorinfo = actordata.Split(',');
                            string actorname = actorinfo[0];
                            if (Int32.TryParse(actorinfo[1], out int actoryear))
                            {
                                movie1.Actors.Add(new Actor(actorname, actoryear));

                            }
                            else { Console.WriteLine("Actors birthday wasn't a year"); }
                            
                        }
                        movielist.Add(movie1);
                    }
                    else { Console.WriteLine("Your directors birthyear wasn't a number"); }

                }
                else { Console.WriteLine("Your movie publishing year wasnt a year"); }
                Console.WriteLine("Would you like to add another movie?(empty input will exit)?");
                string answer = Console.ReadLine();
                if (String.IsNullOrEmpty(answer))
                {
                    break;
                }
            }
            Console.WriteLine("Here are the movies that you added:");
            foreach (var movie in movielist)
            {
                Console.WriteLine(movie.ToString());
                foreach (var actor in movie.Actors)
                {
                    Console.WriteLine(actor.ToString());
                }
            }
            
        }
        static void Main(string[] args)
        {
            TestMovies();
            TestMoviesWithUserInput();
        }
    }
}
