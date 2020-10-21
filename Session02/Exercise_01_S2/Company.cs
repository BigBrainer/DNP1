using System;
using System.Collections.Generic;
namespace Exercise_01_S2
{
    public class Company
    {

        private List<Employee> employees = new List<Employee>();
        public double GetMonthlySalaryTotal()
        {
            double total = 0;
            foreach (Employee employee in employees)
            {
                total = +employee.GetMonthlySalary();
            }
            return total;
        }

        public void HireNewEmployee(Employee employee)
        {
            employees.Add(employee);
        }


    }
}
