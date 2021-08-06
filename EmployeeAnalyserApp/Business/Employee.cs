using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAnalyserApp.Business
{
    class Employee
    {
        private int _empId;
        private string _empName;
        private string _designation;
        private int _managerId;
        private string _doj;
        private int _salary;
        private string _commision;
        private string _deptNo;

        public Employee(int empId, string empName, string designation, int managerId, string doj, int salary, string commision, string deptNo)
        {
            _empId = empId;
            _empName = empName;
            _designation = designation;
            _managerId = managerId;
            _doj = doj;
            _salary = salary;
            _commision = commision;
            _deptNo = deptNo;
        }

        public override string ToString()
        {
            return "\nEmp Id: "+_empId+" Name: "+_empName+" Designation: "+_designation+" Manager Id: "+_managerId+" DOJ: "+_doj+" Salary: "+_salary+" Commision: "+_commision+" Dept No: "+_deptNo;
        }

        public int EmpId
        {
            get
            {
                return _empId;
            }
        }

        public string EmpName
        {
            get
            {
                return _empName;
            }
        }

        public string Designation
        {
            get
            {
                return _designation;
            }
        }

        public int ManagerId
        {
            get
            {
                return _managerId;
            }
        }

        public string DOJ
        {
            get
            {
                return _doj;
            }
        }

        public int EmpSalary
        {
            get
            {
                return _salary;
            }
        }

        public string Commision
        {
            get
            {
                return _commision;
            }
        }

        public string EmpDept
        {
            get
            {
                return _deptNo;
            }
        }
        public override int GetHashCode()
        {
            return _empId;
        }
    }
}
