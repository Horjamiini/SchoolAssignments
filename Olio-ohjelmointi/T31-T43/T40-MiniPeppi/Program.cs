using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SHAA3209
{
    public class Student
    {
        private static int runningnumber = 1;
        private string  sid;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SID { get { return sid; } set { sid = value; } }
        public string Group { get; set; }
        public Student() { }
        public Student(string firstname,string lastname,string group)
        {
            this.FirstName = firstname;
            this.LastName = lastname;
            this.Group = group;
            CreateSID();
        }
        public void CreateSID()
        {
            string createdsid = FirstName.Substring(0, 1).ToUpper() + LastName.Substring(0, 1).ToUpper() + string.Format("{0:000}", runningnumber++);
            sid = createdsid;
        }
        public override string ToString()
        {
            return $"{FirstName} {LastName} {SID} {Group}";
        }
    }
    public class MiniPeppi
    {
        private List<Student> _students;
        public List<Student> Students { get { return _students; }}
        public int StudentCount { get { return _students.Count(); } }
        public MiniPeppi()
        {
            _students = new List<Student>();
        }
        public string ShowFirstAndLast()
        {
            return $"\nThe first student in the MiniPeppi: \n{Students.First()}\nThe last student in the MiniPeppi: \n{Students.Last()}";
        }
        public string DeleteStudent(string studentid)
        {
            if (_students.Any(x => x.SID == studentid))
            {
                var studentToRemove = _students.SingleOrDefault(x => x.SID == studentid);
                _students.Remove(studentToRemove);
                return $"Student {studentToRemove.FirstName} {studentToRemove.LastName} has been removed from the MiniPeppi";
            }
            else { return $"Couldn't find the student you are trying to remove"; }
        }
        public bool DeleteSearchHelper(string studentid)
        {
            if (_students.Any(x=>x.SID == studentid))
            {
                return true ;
            }
            else { return false; }
        }
        public string AddStudent(string firstname,string lastname,string sid,string group)
        {
            if (_students.Any(x => x.SID == sid))
            {
                return $"Sid {sid} already exists in the MiniPeppi, couldn't add the student {firstname} {lastname}.";
            }
            else {
                _students.Add(new Student() { FirstName = firstname[0].ToString().ToUpper() + firstname.Substring(1), LastName = lastname[0].ToString().ToUpper() + lastname.Substring(1), SID = sid.ToUpper(), Group = group });
                return $"Student {firstname[0].ToString().ToUpper() + firstname.Substring(1)} {lastname[0].ToString().ToUpper() + lastname.Substring(1)} added succesfully. There are now {StudentCount} students in MiniPeppi.";
            }
        }
        public string SearchStudent(string studentid)
        {
            if (_students.Any(x => x.SID == studentid))
            {
                var StudentToFind = _students.SingleOrDefault(_x => _x.SID == studentid);
                return $"Matching student found: \n Firstname: {StudentToFind.FirstName}\n Lastname: {StudentToFind.LastName}\n SID: {StudentToFind.SID}\n Group: {StudentToFind.Group}";
            }
            else { return $"Couldn't find student with SID {studentid}"; }
        }
    }
    internal class Program
    {
        static void TestMiniPeppi()
        {
            MiniPeppi miniPeppi = new MiniPeppi();
            miniPeppi.Students.Add(new Student("Hanna", "Husso", "TTV19S1"));
            miniPeppi.Students.Add(new Student("Kirsi", "Kernell", "TTV19S2"));
            miniPeppi.Students.Add(new Student("Masa", "Niemi", "TTV19S3"));
            miniPeppi.Students.Add(new Student("Teppo", "Tester", "TTV19SM"));
            miniPeppi.Students.Add(new Student("Allan", "Aalto", "TTV19MM"));
            Console.WriteLine("Welcome to MiniPeppi");
            while (true)
            {
                Console.Write("\nWould you like to:\n List the students[L/l]\n Add a new to student[A/a]\n Search for a student by SID[S/s]\n Delete a student by SID[D/d]\n Quit[Q/q]\n\nSelection: ");
                string input = Console.ReadLine();
                if (input == "L" || input == "l")
                {
                    Console.Write("Would you like to:\n List all student[A/a]\n Get first and last student in the program[F/f]\n List students in alphabetical order by lastname[O/o]\n Go back[B/b]\n\nSelection: ");
                    string listinput = Console.ReadLine();
                    if (listinput == "A" || listinput == "a")
                    {
                        Console.WriteLine($"All {miniPeppi.StudentCount} students in the MiniPeppi:");
                        foreach (var item in miniPeppi.Students)
                        {
                            Console.WriteLine(item.ToString());
                        }
                    }
                    else if (listinput == "F" || listinput == "f")
                    {
                        Console.WriteLine(miniPeppi.ShowFirstAndLast());
                    }
                    else if (listinput == "O" || listinput == "o")
                    {
                        //Ordering by Lastname
                        List<Student> SortedList = miniPeppi.Students.OrderBy(x => x.LastName).ToList();
                        Console.WriteLine("Student in alphabetical order:");
                        foreach (var item in SortedList)
                        {
                            Console.WriteLine($"{item.FirstName} {item.LastName}");
                        }
                    }
                    else if (listinput == "B" || listinput == "b")
                    {
                        continue;
                    }
                    else { Console.WriteLine("Invalid input. Please use the input given!."); }
                }
                else if (input == "A" || input == "a")
                {
                    while (true)
                    {
                        Console.WriteLine("\nAdding new student into MiniPeppi, please input students information\n!Empty input at any point stop the process!");
                        Console.Write("SID: ");
                        string sidinput = Console.ReadLine();
                        if (string.IsNullOrEmpty(sidinput))
                        {
                            Console.WriteLine("Returnin to main selection...");
                            break;
                        }
                        Console.Write("Firstname: ");
                        string firstnameinput = Console.ReadLine();
                        if (string.IsNullOrEmpty(firstnameinput))
                        {
                            Console.WriteLine("Returnin to main selection...");
                            break;
                        }
                        Console.Write("Lastname: ");
                        string lastnameinput = Console.ReadLine();
                        if (string.IsNullOrEmpty(lastnameinput))
                        {
                            Console.WriteLine("Returnin to main selection...");
                            break;
                        }
                        Console.Write("Group: ");
                        string groupinput = Console.ReadLine();
                        if (string.IsNullOrEmpty(groupinput))
                        {
                            Console.WriteLine("Returnin to main selection...");
                            break;
                        }
                        Console.WriteLine(miniPeppi.AddStudent(firstnameinput, lastnameinput, sidinput, groupinput));
                        break;
                    }
                }
                else if (input == "S" || input == "s")
                {
                    while (true)
                    {
                        Console.WriteLine("Input SID of a astudent you want to search\n!Empty input stops the search!");
                        Console.Write("SID: ");
                        string sidinput = Console.ReadLine();
                        if (string.IsNullOrEmpty(sidinput))
                        {
                            Console.WriteLine("Returnin to main selection...");
                            break;
                        }
                        Console.WriteLine(miniPeppi.SearchStudent(sidinput));
                        break;
                    }
                }
                else if (input == "D" || input == "d")
                {
                    while (true)
                    {
                        Console.WriteLine("Input SId of the student you want to remove\n!Empty input at any point stop the process!");
                        Console.Write("SID: ");
                        string sidinput = Console.ReadLine();
                        if (string.IsNullOrEmpty(sidinput))
                        {
                            Console.WriteLine("Returnin to main selection...");
                            break;
                        }
                        if (miniPeppi.DeleteSearchHelper(sidinput))
                        {
                            Console.WriteLine(miniPeppi.SearchStudent(sidinput));
                            Console.Write("Are you sure you want to delete student from minipeppi?[Y/N]: ");
                            string answer = Console.ReadLine();
                            if (answer == "Y" || answer == "y")
                            {
                                Console.WriteLine(miniPeppi.DeleteStudent(sidinput));
                                break;
                            }
                            else if (answer == "N" || answer == "n")
                            {
                                Console.WriteLine("Deleting student cancelled...\nReturnin to main selection.");
                                break;
                            }
                            else { Console.WriteLine("Invalid input. Please try again!"); }
                        }
                        else
                        {
                            Console.WriteLine(miniPeppi.DeleteStudent(sidinput));
                        }
                    }
                }
                else if (input == "Q" || input == "q")
                {
                    Console.WriteLine("Quitting MiniPeppi...");
                    break;
                }
                else { Console.WriteLine("Invalid input. Please use the inputs given!"); }

            }
        }
        static void Main(string[] args)
        {
            TestMiniPeppi();
        }
    }
}
