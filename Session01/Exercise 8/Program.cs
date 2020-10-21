using System;

namespace Exercise_8
{
    class Program
    {
        static void Main(string[] args)
        {
            var surround = new SurroundString();
            Console.WriteLine(surround.MakeOutWord("<<>>", "Hello"));
        }
    }
}
