using ConsoleAddressbok.Interfaces;
using ConsoleAddressbok.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAddressbok.Services
{
    internal class PersonService : IPersonService
    {

        public List<Person> contactList { get; set; } = new List<Person>();


        public void AddPersonToList(IPerson person)
        {
            var _person = GetPersonFromList(person);
            if (_person == null)
                contactList.Add((Person)person);
        }

        public void RemovePersonFromList(IPerson person)
        {
            var _person = GetPersonFromList(person);
            if (_person != null)
                contactList.Remove((Person)person);
        }

        public Person GetPersonFromList(IPerson person)
        {
            var _person = Console.ReadLine();

            bool personFound = false;

            for (int i = 0; i < contactList.Count; i++)
            {
                if (contactList[i].DisplayName == _person)
                {
                    Console.Clear();
                    Console.WriteLine("Kontakten hittades!");
                    Console.WriteLine(contactList[i].DisplayName);
                    personFound = true;
                }
            }
                if(!personFound)
                {
                    Console.WriteLine("Kontakten kunde inte hittas");
                }
            return null!;
        }
       

        public IEnumerable<IPerson> GetPeopleFromList()
        {
            foreach (var person in contactList)
                Console.WriteLine($"{person.FirstName} {person.LastName} {person.Id}");
            return contactList;
        }

        
    }
}

