using ConsoleAddressbok.Interfaces;
using ConsoleAddressbok.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using ConsoleAddressbok.Services;
using DocumentFormat.OpenXml.Spreadsheet;

namespace ConsoleAddressbok.Services
{
    
    internal class PersonService : IPersonService
    {
        public string FilePath { get; set; } = null!;
        public List<Person> contactList { get; set; } = new List<Person>();

        public FileService file = new FileService();

        private readonly FileService listFile = new();

      

       
        //Får inte den här att fungera
        public void FillList(List<Person> people )
        {
            try
            {
                var items = JsonConvert.DeserializeObject<List<Person>>(listFile.Read(FilePath));
                if (items != null)
                    people = items;

                
            }
            catch { }
            contactList = people;
            
        }


        public void AddPersonToList(IPerson person)
        {
                contactList.Add((Person)person);

            file.Save(FilePath, JsonConvert.SerializeObject(new { person }));
        }

        public void RemovePersonFromList(IPerson person)
        {
            Console.WriteLine("Vänligen skriv in för och efternamn på kontakten du vill ta bort");
            var _person = Console.ReadLine();

            bool personFound = false;


            for (int i = 0; i < contactList.Count; i++)
            {
                if (contactList[i].DisplayName == _person)
                {
                    Console.Clear();
                    personFound = true;

                    Console.WriteLine("Kontakten hittades, Är du säker på att du vill ta bort den? Y för Ja N för Nej. "); 

                    var UserInput = Console.ReadLine();

                    if (UserInput == "y")
                    {
                        Console.Clear();
                        Console.WriteLine($"{contactList[i].DisplayName}" + " Har tagits bort!");
                        contactList.Remove(contactList[i]);
                       
                    }
                    else if (UserInput == "n")
                    {
                        Console.WriteLine("Du återgår till huvudmenyn vänligen tryck vilken knapp som helst");
                    }
                }
            }


        }

        public Person GetPersonFromList(IPerson person)
        {
            var _person = Console.ReadLine();

            bool personFound = false;

            for (int i = 0; i < contactList.Count; i++)
            {
                if (contactList[i].DisplayName == _person)
                {
                    personFound = true;
                    Console.Clear();
                    Console.WriteLine("Kontakten hittades!");
                    Console.WriteLine(contactList[i].DisplayName);
                    Console.WriteLine(contactList[i].StreetName);
                    Console.WriteLine(contactList[i].PhoneNumber);
                    Console.WriteLine(contactList[i].Email);
                 


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
};

