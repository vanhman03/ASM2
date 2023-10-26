using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_1651
{
    internal class Restaurant : IEmployeeManager
    {
        private List<Employee> employees;


        public Menu menu { get; set; }
        public Restaurant()
        {
            employees = new List<Employee>();
            menu = new Menu();
        }

        public void AddEmployee(Employee employee)
        {
            employees.Add(employee);
        }

        public void RemoveEmployee(Employee employee)
        {
            employees.Remove(employee);
        }

        public void DisplayAllEmployees()
        {
            foreach (var employee in employees)
            {
                employee.DisplayInfo();
                Console.WriteLine(employee);
            }
        }



        public List<Employee> GetEmployees()
        {
            return employees;
        }

    }
}
