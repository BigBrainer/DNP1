using System;
using MathLib;

namespace Exercise_5
{
    class Program
    {
        static void Main(string[] args)
        {
            var calculator = new Calculator();
            int[] numbers = new int[] { 1, 2, 3, 4 };
            calculator.Add(5, 7);
            calculator.Add(numbers);
            calculator.AddWithInput();
        }
    }
}
