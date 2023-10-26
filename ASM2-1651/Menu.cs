using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_1651
{
    internal class Menu
    {
        private List<MenuItem> items;


        public Menu()
        {
            items = new List<MenuItem>();
        }

        public void AddMenuItem(MenuItem item)
        {
            items.Add(item);
        }

        public void RemoveMenuItem(MenuItem item)
        {
            items.Remove(item);
        }

        public void DisplayMenu()
        {
            foreach (var item in items)
            {
                item.DisplayInfoItem();
                Console.WriteLine(item);
            }
        }
        public List<MenuItem> GetItems()
        {
            return items;
        }
    }
}
