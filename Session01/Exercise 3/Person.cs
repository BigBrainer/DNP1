using System;
namespace Exercise_01
{
    public class Person
    {
        public string Name
        {
            get;
            set;
        }
        public void Introduce()
        {
            Console.WriteLine($"Hello, {Name}, how are you doing?");
        }
    }
}