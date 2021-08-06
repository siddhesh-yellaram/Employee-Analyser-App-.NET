using EmployeeAnalyserApp.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAnalyserApp.Services
{
    class GroupByDesignation
    {
        public static string CountEmpByDesignation(List<Employee> empList)
        {
            List<string> designation = new List<string> { empList[0].Designation };
            List<int> counter = new List<int> { 0 };
            string str = "";
            int i;
            bool newDesignation = true;
            foreach (Employee emp in empList)
            {
                i = 0;
                foreach (string currentDesignation in designation)
                {
                    if (emp.Designation == currentDesignation)
                    {
                        counter[i]++;
                        newDesignation = false;
                    }
                    i++;
                }
                if (newDesignation)
                {
                    designation.Add(emp.Designation);
                    counter.Add(1);
                }
                newDesignation = true;
            }
            for (i = 0; i < designation.Count; i++)
            {
                str = str + "Emp with Designation " + designation[i] + " = " + counter[i] + System.Environment.NewLine;
            }
            return "\nEmployees Grouped by Various Designation Are: \n\n" + str;
        }
    }
}
