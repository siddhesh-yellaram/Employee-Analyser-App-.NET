using EmployeeAnalyserApp.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAnalyserApp.Services
{
    class FindMaxSalEmp
    {
        public static string MaxSalaryEmp(List<Employee> empList)
        {
            int maxSalaryIndex = 0;
            string str = "";
            int i = 0;
            foreach (Employee emp in empList)
            {
                if (emp.EmpSalary > empList[maxSalaryIndex].EmpSalary)
                {
                    maxSalaryIndex = i;
                }
                i++;
            }
            str = empList[maxSalaryIndex].ToString();
            return "\nMax salary emp in dept is: \n"+str;
        }
    }
}
