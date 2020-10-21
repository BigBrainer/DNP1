using System;
namespace Exercise_01_S2
{
    public class PartTimeEmployee : Employee

    {
        private double HourlyWage { get; set; }
        private double HoursPerMonth { get; set; }
        public PartTimeEmployee(double hourlyWage, double hoursPerMonth, string firstName, string lastName) : base(firstName, lastName)
        {
            HourlyWage = hourlyWage;
            HoursPerMonth = hoursPerMonth;
        }

        public override double GetMonthlySalary()
        {
            return HourlyWage * HoursPerMonth;
        }
    }
}