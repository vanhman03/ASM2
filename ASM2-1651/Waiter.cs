using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_1651
{
    internal class Waiter : Employee
    {
        private string shift;

        public Waiter(string name, int age, string position, string shift) : base(name, age, position)
        {
            this.Shift = shift;
        }
        public string Shift
        {
            get { return shift; }
            set { shift = value; }
        }
        public override void DisplayInfo()
        {
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Age: " + Age);
            Console.WriteLine("Position: " + Position);
            Console.WriteLine("Shift: " + Shift);
            Console.WriteLine("-------------------------");
        }
    }
}
