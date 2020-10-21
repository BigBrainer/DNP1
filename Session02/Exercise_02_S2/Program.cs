using System;

namespace Exercise_02_S2
{
    class Program
    {
        static void Main(string[] args)
        {
            var time = new Time(0, 0);
            time.AddMinutes(1441);
            time.SubtractMinutes(2);
            Console.WriteLine(time.ToString());
            Console.WriteLine(time.Minutes);
            Console.WriteLine(time.Hours);
        }
    }
}
