using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHAA3209
{
    public class Friend
    {
        
        public string Name { get; set; }
        public string Email { get; set; }
    }
    internal class Program
    {
        static void TestMailBook()
        {
            MailBook mailbook = new MailBook();
            Console.WriteLine(mailbook.CountFriends());
            foreach (var item in mailbook.Friends)
            {
                Console.WriteLine($"{item.Name} {item.Email}");
            }
            while (true)
            {
                Console.WriteLine("Would you like to:\n[1]search for friends in your address book\n[2]Add friend to your addressbook\n[3]List friends in your addressbook\n[0]Terminate process\n");
                Console.Write("Selection: ");
                string input = Console.ReadLine();
                if (int.TryParse(input,out int answer))
                {
                    if (answer == 1)
                    {
                        // Search option
                        Console.Write("\nSearch persons from addressbook:");
                        string searchinput = Console.ReadLine();
                        var search = mailbook.Friends.Where(x => x.Name.Contains(searchinput)).ToList();
                        if (search.Count() != 0)
                        {
                            Console.WriteLine($"\nFound {search.Count()} matches in search: \n");
                            foreach (var person in search)
                            {

                                Console.WriteLine($"{person.Name} {person.Email}");
                            }
                            Console.Write("\n");
                        }
                        else { Console.WriteLine($"\nNo friends found with search '{searchinput}'\n"); }
                    }
                    else if (answer == 2)
                    {
                        // inputting and saving persons information to csv
                        Console.WriteLine("Adding new friend to addressbook\n");
                        Console.WriteLine("Input name to be saved to addressbook: ");
                        string newname = Console.ReadLine();
                        Console.WriteLine("Input email to be saved to addressbook: ");
                        string newemail = Console.ReadLine();
                        Console.Write($"\nAre you sure you want to save these entries to addressbook Name:{newname} Email:{newemail} [Y]/[n]: ");
                        string csvinput = Console.ReadLine();
                        if (csvinput == "Y" || csvinput == "y")
                        {
                            try
                            {
                                mailbook.SaveToCsv(newname, newemail);
                                Console.WriteLine($"Saving succesful\n");
                            }
                            catch(Exception ex) { Console.WriteLine($"Error writing to file {ex.Message}"); }
                            
                        }
                        else if (csvinput == "N" || csvinput == "n")
                        {
                            Console.WriteLine("Saving cancelled\n");
                        }
                        else { Console.WriteLine("Invalid input returning to start\n"); }
                    }
                    else if (answer == 3)
                    {
                        // showing people in the list of Friends
                        Console.WriteLine($"\n{mailbook.CountFriends()}");
                        foreach (var item in mailbook.Friends)
                        {
                            Console.WriteLine($"{item.Name} {item.Email}");
                           
                        }
                        
                    }
                    else if (answer == 0)
                    {
                        break;
                    }
                    else { Console.WriteLine("Invalid input\n"); }

                }
                else { Console.WriteLine("Invalid input, please input a number!\n"); }

            }
        }
        static void Main(string[] args)
        {
            TestMailBook();
        }
    }
}
