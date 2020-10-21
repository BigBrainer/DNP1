using System;

namespace Exercise_11
{
    class Program
    {
        static void Main(string[] args)
        {
            var clumps = new ArrayClumps();
            int[] numbers = new int[] { 1, 1, 1, 2, 2, 3,3,3,1,1 };
            Console.WriteLine(clumps.CountClumps(numbers));
        }
    }
}
