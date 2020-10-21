using System;

namespace Exercise_01_S2
{
    class Program
    {
        static void Main(string[] args)
        {
            var company1 = new Company();

            var fullTime1 = new FullTimeEmployee(400, "Marekiano", "Galiano");
            var fullTime2 = new FullTimeEmployee(500, "TheOGManazeris", "Marekiano");
            var partTime1 = new PartTimeEmployee(25, 40, "PartTime", "Zebracik");
            var partTime2 = new PartTimeEmployee(25, 40, "PartTime", "Zebrakiano");

            company1.HireNewEmployee(fullTime1);
            company1.HireNewEmployee(fullTime2);
            company1.HireNewEmployee(partTime1);
            company1.HireNewEmployee(partTime2);

            Console.WriteLine(company1.GetMonthlySalaryTotal());
            Console.WriteLine(fullTime1.GetMonthlySalary());
            Console.WriteLine(partTime1.Name);
        }
    }
}
