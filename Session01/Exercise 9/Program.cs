using System;

namespace Exercise_9
{
    class Program
    {
        static void Main(string[] args)
        {
            var twister = new WordTwister();
            Console.WriteLine(twister.Twister("Pomegranate", 2));
            Console.WriteLine(twister.SubstringTwister("Pomegranate", 2));
        }
    }
}
