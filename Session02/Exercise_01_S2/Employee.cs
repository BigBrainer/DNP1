using System;
namespace Exercise_01_S2
{
    public abstract class Employee

    {
        public string Name { get; set; }
        public Employee(string firstName, string lastName)
        {
            Name = $"{firstName} {lastName}";
        }
        public abstract double GetMonthlySalary();
    }
}