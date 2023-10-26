using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_1651
{
    internal abstract class Employee
    {
        private string name;
        private int age;
        private string position;

        public Employee(string name, int age, string position)
        {
            this.Name = name;
            this.Age = age;
            this.Position = position;
        }
        public string Name
        {
            get { return name; }
            set {
                if (value.Length < 5)
                {
                    throw new ArgumentException("Name must be longer than 5 characters");

                }
                name = value; 
            }
        }
        public int Age
        {

            get { return age; }
            set {
                if (value < 18)
                {
                    throw new ArgumentException("Age must be over 18");

                }
                age = value; 
            }
        }
        public string Position
        {
            get { return position; }
            set
            {
                position = value;
            }
        }
        public abstract void DisplayInfo();


    }
}
