using System;

namespace Exercise_10
{
    class Program
    {
        static void Main(string[] args)
        {
            var bigdiff = new BiggestDifference();
            int[] numbers = new int[] { 5, 7, 2, 100 };
            Console.WriteLine(bigdiff.BigDiff(numbers));
        }
    }
}
