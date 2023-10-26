using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_1651
{
    internal interface IEmployeeManager
    {
        void AddEmployee(Employee employee);
        void RemoveEmployee(Employee employee);
        void DisplayAllEmployees();
    }
}
