using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class Person
    {
        public Person() { }

        public Person(string name, string surname, string email, string phone)
        {
            Name = name;
            Surname = surname;
            Email = email;
            Phone = phone;
        }

        /// <summary> Copying constructor </summary>
        /// <param name="person"> person to copy </param>
        public Person(Person person)
        {
            Name = person.Name;
            Surname = person.Surname;
            Email = person.Email;
            Phone = person.Phone;
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

    }
}
