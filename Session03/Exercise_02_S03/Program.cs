using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace Exercise_02_S03
{
    class Program
    {
        static void Main(string[] args)
        {
            var person1 = new Person()
            {
                FirstName = "Marek",
                LastName = "Gala",
                Age = 20,
                Height = 175,
                IsMarried = false,
                Hobbies = new string[] { "not knowing what to do" },
                Sex = 'm'
            };

            var person2 = new Person()
            {
                FirstName = "Marko",
                LastName = "Gula",
                Age = 20,
                Height = 200,
                IsMarried = false,
                Hobbies = new string[] { "drinking more than he cares to admit" },
                Sex = 'm'
            };

            var person3 = new Person()
            {
                FirstName = "Marekianko",
                LastName = "Gulianko",
                Age = 20,
                Height = 175,
                IsMarried = false,
                Hobbies = new string[] { "reeee", "reeeeeeing" },
                Sex = 'm'
            };

            List<Person> people = new List<Person> { person1, person2, person3, person1};
            StoreObject(people);
            var peeps = ReadObject();
        }
        private static void StoreObject(List<Person> people)
        {
            File.WriteAllText("PeopleJSON.json", JsonSerializer.Serialize(people));
        }

        private static List<Person> ReadObject()
        {
            return JsonSerializer.Deserialize<List<Person>>(File.ReadAllText("PeopleJSON.json"));
        }
    }
}
