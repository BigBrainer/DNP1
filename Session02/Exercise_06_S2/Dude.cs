using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;

namespace Exercise_06_S2
{
    class Dude
    {
        private string WhatDude { get; set; }
        private Bird Bird;

        public Dude(string whatDude, Bird bird)
        {
            WhatDude = whatDude;
            bird.BirdDidThing += ReactToBird;
            Bird = bird;
        }

        private void ReactToBird(string birdsThing)
        {
            if (birdsThing.Equals("Bird attempts to suck its own dick"))
            {
                Console.WriteLine($"{WhatDude}: WOW {Bird.Name},WHAT AN ATTEMPT!!");
            }
            else if(birdsThing.Equals("Bird manages to suck its own dick"))
            {
                Console.WriteLine($"{WhatDude}: WELL DONE {Bird.Name}!!!! WHOOOOOOO!!!!!!!!!!!!");
            }
            else
            {
                Console.WriteLine($"{WhatDude}: {Bird.Name} is pretty boring guys");
            }

        }
    }
}
