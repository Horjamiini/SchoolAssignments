using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SHAA3209
{
    public class Student
    {
        private int studentnumber;
        //properties
        public string Firsname { get; set; }
        public string Lastname { get; set; }

        public int StudentNumber 
        {
            get { return studentnumber; }
        }

        //create StudentID from first two letters of first and lastname and add a 4 digit number
        public string StudentID
        {
            get { return Firsname.Substring(0, 2).ToLower() + Lastname.Substring(0, 2).ToLower() + StudentNumber; }
        }
        //create email with StudentID
        public string Email 
        {
            get { return StudentID + "@schooladdress.com"; }
        }
        //constructors
        public Student(string firstname, string lastname)
        {
            Firsname = firstname;
            Lastname = lastname;
            studentnumber = CreateStudentNumber();
        }
        //methods
        public string ShowStudentInfo() 
        {
            return $"Student: {Firsname} {Lastname}\n StudentID: {StudentID}\n Email: {Email}\n";
        }
        private int CreateStudentNumber()
        {
            Random r = new Random();
            int number = r.Next(1000, 10000);
            studentnumber = number;
            // thread.sleep to make new seed for random number
            Thread.Sleep(1);
            return studentnumber;
        }
    }
    internal class Program
    {
        static void TestStudent()
        {
            List<Student> studentList = new List<Student>();
            Student opiskelija1 = new Student("Heinä", "Sorsa");
            Student opiskelija2 = new Student("Heli", "Kopteri");
            Student opiskelija3 = new Student("Sini", "Tiainen");
            Student opiskelija4 = new Student("Ruut", "Ana");
            Student opiskelija5 = new Student("Kim", "Alainen");
            Student opiskelija6 = new Student("Sini", "Sorsa");
            studentList.Add(opiskelija1);
            studentList.Add(opiskelija2);
            studentList.Add(opiskelija3);
            studentList.Add(opiskelija4);
            studentList.Add(opiskelija5);
            studentList.Add(opiskelija6);

            foreach (var student in studentList)
            {
                Console.WriteLine(student.ShowStudentInfo());
            }
        }
        static void Main(string[] args)
        {
            TestStudent();
        }
    }
}
