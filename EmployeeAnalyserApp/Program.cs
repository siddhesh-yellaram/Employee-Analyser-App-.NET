using EmployeeAnalyserApp.Business;
using EmployeeAnalyserApp.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAnalyserApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> empList;
            string url = "https://swabhav-tech.firebaseapp.com/emp.txt";
            string urlFilePath = @"D:\\test\\.NET\\EmpUrlData.txt";
            string csvFilePath = @"D:\\test\\.NET\\emp.csv";

            using (WebClient wc = new WebClient())
            {
                wc.DownloadFile(url, urlFilePath);
            }

            Console.WriteLine("1.Read By Url");
            Console.WriteLine("2.Read By File");
            Console.Write("Enter your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            if(choice == 1)
            {
                empList = ReturnEmpDetails(urlFilePath);
            }
            else
            {
                empList = ReturnEmpDetails(csvFilePath);
            }

            Console.WriteLine(GroupByDept.CountEmpByDept(empList));
            Console.WriteLine(GroupByDesignation.CountEmpByDesignation(empList));
            Console.WriteLine(FindMaxSalEmp.MaxSalaryEmp(empList));
            Console.ReadLine();
        }

        public static List<Employee> ReturnEmpDetails(string filePath)
        {
            List<Employee> newEmpList = new List<Employee>();
            StreamReader reader;
           
            if (File.Exists(filePath))
            {
                reader = new StreamReader(File.OpenRead(filePath));
                bool sameId = false;

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    int empId = Int32.Parse(values[0]);
                    string empName = values[1];
                    string designation = values[2];
                    int managerId;
                    if (values[3] == "null" || values[3] == "NULL" || values[3] == "")
                    {
                        managerId = 0;
                    }
                    else
                    {
                        managerId = Int32.Parse(values[3]);
                    }
                    string doj = values[4];
                    int salary = Int32.Parse(values[5]);
                    string commision = values[6];
                    string dept = values[7];
                    
                    Employee tempEmp = new Employee(empId, empName, designation, managerId, doj, salary, commision, dept);
                    
                    foreach (Employee e in newEmpList)
                    {
                        if (tempEmp.GetHashCode() == e.GetHashCode())
                        {
                            sameId = true;
                            continue;
                        }
                    }
                    if (!sameId)
                    {
                        newEmpList.Add(new Employee(empId, empName, designation, managerId, doj, salary, commision, dept));
                    }
                    sameId = false;
                }
            }
            else
            {
                Console.WriteLine("File doesn't exist");
            }
            
            foreach (var emp in newEmpList)
            {
                Console.WriteLine(emp);
            }
            
            return newEmpList;
        }
    }
}

