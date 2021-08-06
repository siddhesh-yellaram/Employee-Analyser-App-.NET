using EmployeeAnalyserApp.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAnalyserApp.Services
{
    class GroupByDept
    {
        public static string CountEmpByDept(List<Employee> empList)
        {
            List<string> depts = new List<string> { empList[0].EmpDept };
            List<int> counter = new List<int> {0};
            string str = "";
            int i;
            bool newDept = true;
            foreach (Employee emp in empList)
            {
                i = 0;
                foreach (string currentDept in depts)
                {
                    if (emp.EmpDept == currentDept)
                    {
                        counter[i]++;
                        newDept = false;
                    }
                    i++;
                }
                if (newDept)
                {
                    depts.Add(emp.EmpDept);
                    counter.Add(1);
                }
                newDept = true;
            }
            for (i = 0; i < depts.Count; i++)
            {
                str = str + "Dept No: " + depts[i] + " = " + counter[i] + System.Environment.NewLine;
            }
            return "\nEmployees Grouped by Various Depts Are: \n\n" +str;
        }
    }
}
