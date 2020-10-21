using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_06_S2
{
    class StupidKid
    {
        private Bird bird;
        private string _kidsName;
        private Bird Bird;
        public StupidKid(string kidsName, Bird bird)
        {
            _kidsName = kidsName;
            bird.BirdDidThing += ReactToBird;
            Bird = bird;
        }

        private void ReactToBird(string birdsThing)
        {
            if (birdsThing.Equals("Bird attempts to suck its own dick"))
            {
                Console.WriteLine($"{_kidsName}: Wook mommy the {Bird.Name} is twying to scwatch its bewwy");
            }
            else if (birdsThing.Equals("Bird manages to suck its own dick"))
            {
                Console.WriteLine($"{_kidsName}: What is the {Bird.Name} doing mommy?");
            }
            else
            {
                Console.WriteLine($"{_kidsName}: HAHAHAHA LOOK THE {Bird.Name.ToUpper()} IS SO GREAT");
            }

        }
    }
}
