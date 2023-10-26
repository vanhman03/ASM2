using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_1651
{
    internal class Manager : Employee
    {
        private int yearOfExperience;
        public Manager(string name, int age, string position, int yearOfExperience) : base(name, age, position)
        {
            this.YearOfExperience = yearOfExperience;
        }
        public int YearOfExperience
        {
            get { return yearOfExperience; }
            set { yearOfExperience = value; }
        }
        public override void DisplayInfo()
        {
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Age: " + Age);
            Console.WriteLine("Position: " + Position);
            Console.WriteLine("Year of Experience: " + YearOfExperience);
            Console.WriteLine("-------------------------");
        }
    }
}
