using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHAA3209
{
    internal class Program
    {
        static void TestInvoice()
        {
            Invoice invoice = new Invoice() {Customer = "Matti Meikäläinen" };
            invoice.Items.Add(new InvoiceItem() {Name="Redbull",Price=3.49D,Quantity=4});
            invoice.Items.Add(new InvoiceItem() {Name="Milk",Price=1.99D,Quantity=1 });
            invoice.Items.Add(new InvoiceItem() { Name = "Beer", Price = 5.29D, Quantity = 6 });

            Console.WriteLine(PrintInvoice(invoice)); 
        }
        static void Main(string[] args)
        {
            TestInvoice();
        }
        private static string PrintInvoice(Invoice invoice)
        {
            Console.WriteLine($"Customer {invoice.Customer}'s invoice:\n" +
                $"=================================");
            foreach (var item in invoice.Items)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("=================================");
            return $"Total: {invoice.ItemsTogether} pieces {invoice.CountTotal()} euros";
        }
    }
}
