using System;

namespace lesson5
{
    public class Person
    {
        public Guid Id { get; private set; }
        public string Name { get; set; }
        public DateTime Dob { get; set; }
        public int Age 
        { 
            get => (int)((DateTime.Now - Dob).TotalDays / 365);
            // get
            // {
            //     TimeSpan span = DateTime.Now - Dob;
            //     int age = (int)(span.TotalDays / 365);
            //     return age;
            // }
        }

        [Obsolete("Should pass name and DOB parameters.", true)]
        public Person() { }

        public Person(string name, DateTime dob)
        {
            Name = name;
            Dob = dob;
            Id = Guid.NewGuid();
        }
    }
}