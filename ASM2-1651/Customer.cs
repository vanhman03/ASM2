using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_1651
{
    internal class Customer
    {
        private string name;
        private int age;
        private int phoneNum;
        private List<Order> orders;
        public Customer(string name, int age, int phoneNum)
        {
            this.Name = name;
            this.Age = age;
            this.PhoneNum = phoneNum;
            this.orders = new List<Order>();
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        public int PhoneNum
        {
            get { return phoneNum; }
            set
            {
                phoneNum = value;
            }
        }



    }
}
