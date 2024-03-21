using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace SHAA3209
{
    public interface ITransaction
    {
        //interface memebers
        string ShowTransaction();
        float Money { get; set; }
    }
    public class PaidWithCard : ITransaction
    {
        private float sales = 0;
        public float Money { get; set; }
        public string CardNumber { get; set; }
        public PaidWithCard(float money,string cardnumber)
        {
            Money = money;
            CardNumber = cardnumber;
        }
        public void AddTransaction(float money,string cardnumber)
        {
            Money = money;
            CardNumber = cardnumber;
        }
        public string ShowTransaction()
        {
            sales += Money;
            return $"Transaction complete. Charged from card: {CardNumber} TimeofTransaction: {DateTime.Now} Amount: {Money}";
        }
        public float ShowTotal()
        {
            return sales;
        }
    }
    public class PaidWithCash : ITransaction
    {
        private float sales = 0;
        public float Money { get; set; }
        public string BillNumber { get; set; }
        public PaidWithCash(float money,string billnumber)
        {
            Money = money;
            BillNumber = billnumber;
        }
        public void AddTransaction(float money, string billnumber)
        {
            Money = money;
            BillNumber = billnumber;
        }
        public string ShowTransaction()
        {
            sales += Money;
            return $"Cash payment complete: Billnumber: {BillNumber} TimeofTransaction: {DateTime.Now} Amount: {Money}";
        }
        public float ShowCash()
        {
            return sales; ;
        }
    }
    internal class Program
    {
        static void TestPayingMethods()
        {
            PaidWithCard korttimaksu = new PaidWithCard(50.55F,"1010-4000");
            PaidWithCash käteismaksu = new PaidWithCash(14.11F, "0001");
            Console.WriteLine(korttimaksu.ShowTransaction());
            korttimaksu.AddTransaction(42.86F, "1020-3330");
            Console.WriteLine(korttimaksu.ShowTransaction());
            Console.WriteLine(käteismaksu.ShowTransaction()) ;
            käteismaksu.AddTransaction(27.14F,"0002");
            Console.WriteLine(käteismaksu.ShowTransaction());
            Console.WriteLine($"Total money paid with card: {korttimaksu.ShowTotal()}");
            Console.WriteLine($"Total money paid with cash: {käteismaksu.ShowCash()}");
            Console.WriteLine($"Total sales today {DateTime.Now.DayOfWeek} {DateTime.Now.Day}/{DateTime.Now.Month}/{DateTime.Now.Year} is {korttimaksu.ShowTotal() + käteismaksu.ShowCash()}  ");
        }
        static void Main(string[] args)
        {
            TestPayingMethods();
        }
    }
}
