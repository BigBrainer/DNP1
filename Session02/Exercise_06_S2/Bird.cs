using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Exercise_06_S2
{
    public class Bird
    {
        public string Name { get; set; }
        private Random random = new Random();

        public Action<string> BirdDidThing;

        public Bird(string name)
        {
            Name = name;
        }

        public string[] _birdThings = { "Bird attempts to suck its own dick", "Bird manages to suck its own dick", "Bird flaps his wings" };

        public string BirdDoesThing()
        {
            int number = random.Next(3);
            Console.WriteLine(_birdThings[number]);
            BirdDidThing(_birdThings[number]);
            Thread.Sleep(4000);
            return Name;

        }
    }
}
