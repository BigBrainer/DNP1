using System;

namespace Exercise_06_S2
{
    class Program
    {
        static void Main(string[] args)
        {
            var bird = new Bird("Mockingbird");
            var dude = new Dude("Chad",bird);
            var stupidKid = new StupidKid("LilFuker", bird);
            while(true)
            {
                bird.BirdDoesThing();
            }
        }
    }
}
