using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace MathLib
{
    class Calculator
    {
        public void Add(int x, int y)
        {
            int sum = x + y;
            Console.WriteLine(sum);
        }

        public void Add(int[] arrayOfNumbers)
        {
            int sum = 0;
            foreach(int number in arrayOfNumbers)
            {
                sum += number;
            }
            Console.WriteLine(sum);
        }

        public void AddWithInput()
        {
            Console.WriteLine("Enter the first number of the addition");
            int x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the second number of the addition");
            int y = Convert.ToInt32(Console.ReadLine());
            int sum = x + y;
            Console.WriteLine($"The sum of the two numbers is {sum}");
        }
    }
}
