using System;
namespace Exercise_01_S2
{
    public class FullTimeEmployee : Employee
    {
        private double MonthlySalary { get; set; }
        public FullTimeEmployee(double monthlySalary, string firstName, string lastName) : base(firstName, lastName)
        {
            MonthlySalary = monthlySalary;
        }

        public override double GetMonthlySalary()
        {
            return MonthlySalary;
        }
    }
}