using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHAA3209
{
    public class Employee
    {
        public string Name { get; set; }
        public string Profession { get; set; }
        public decimal Salary { get; set; }
        //constuctors
        public Employee()
        {
        }
        public Employee (string name, string profession, decimal salary)
        {
            Name = name;
            Profession = profession;
            Salary = salary;
        }
        //methods
        public override string ToString()
        {
            return $"Name: {Name}\n Profession: {Profession}\n Salary: {Salary}"; 
        }
    }
    public class Boss : Employee
    {
        public string Car { get; set; }
        public decimal Bonus { get; set; }
        //constructors
        public Boss()
        { 
        }
        public Boss (string name,string profession,decimal salary, string car, decimal bonus) : base(name,profession,salary)
        {
            Car = car;
            Bonus = bonus;
        }
        //methods
        public override string ToString()
        {
            return base.ToString() + $"\n Car: {Car}\n Bonus: {Bonus}";
        }
    }
    internal class Program
    {
        static void TestEmployees()
        {
            Employee employee = new Employee("Kalle","Koodari",2500M);
            Console.WriteLine(employee.ToString());
            Boss boss = new Boss("Marjo","Manageri",3500M,"Skoda",1000M);
            Console.WriteLine(boss.ToString());
            Console.WriteLine("Kalle got a promotion and Marjo got a bigger bonus");
            employee.Profession = "Senior Koodari";
            employee.Salary = 3000M;
            boss.Bonus = 1800M;
            Console.WriteLine(employee.ToString());
            Console.WriteLine(boss.ToString());
        }
        static void Main(string[] args)
        {
            TestEmployees();
        }
    }
}
