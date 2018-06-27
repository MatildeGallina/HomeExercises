using System;
using System.Collections.Generic;
using System.Linq;

namespace es1_Person
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            List<Person> persons = new List<Person>
            {
                new Person
                {
                    Id = 1, Name = "Mario", Surname = "Rossi", Age = 33, City = "Udine"
                },

                new Person
                {
                    Id = 2, Name = "Luigi", Surname = "Bianchi", Age = 45, City = "Pordenone"
                },

                new Person
                {
                    Id = 3, Name = "Anna", Surname = "Neri", Age = 29, City = "Gorizia"
                },
            };

            List<string> onlyName = persons
                .Select(x => x.Name)
                .ToList();

            List<string> avgAge = persons
        }
    }

    class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
    }
    
}
