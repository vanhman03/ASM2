using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_1651
{
    internal class Order
    {
        private List<MenuItem> items;
        public Customer Customer { get; set; }
        public Order()
        {
            items = new List<MenuItem>();
        }
        public void AddItem(MenuItem item)
        {
            items.Add(item);
        }



        public decimal CalculateTotal()
        {
            decimal total = 0;
            foreach (var item in items)
            {
                total += item.Price;
            }
            return total;
        }
        public List<MenuItem> GetItems()
        {
            return items;
        }
    }
}
