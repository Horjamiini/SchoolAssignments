using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHAA3209
{
    public  class Invoice
    {
        private List<InvoiceItem> _items;
        public string Customer { get; set; }
        public List<InvoiceItem> Items { get { return _items; } }
        public int ItemsCount { get { return Items.Count; } }
        public int ItemsTogether { get
            {
                int itemstogether = 0;
                foreach (var item in Items)
                {
                    itemstogether += item.Quantity;
                }
                return itemstogether;
            } 
        }
        public Invoice()
        {
            _items = new List<InvoiceItem>();
        }
        public double CountTotal()
        {
            double itemstotal = 0;
            foreach (var item in Items)
            {
                itemstotal += item.Total;
            }
            return itemstotal;
        }
    }
}
