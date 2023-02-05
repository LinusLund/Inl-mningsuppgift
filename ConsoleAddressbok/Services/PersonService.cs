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

      

       
        
        internal void FillList()
        {
            try
            {
                var items = JsonConvert.DeserializeObject<List<Person>>(listFile.Read(FilePath));
                if (items != null)
                    contactList = items;

                
            }
            catch { }
            
            
        }


        public void AddPersonToList(IPerson person)
        {
                contactList.Add((Person)person);

            file.Save(FilePath, JsonConvert.SerializeObject(contactList));
        }

        
        public void RemovePersonFromList(IPerson person)
        {
            Console.WriteLine("Please enter the first and last name of the contact you want to remove");
            var _person = Console.ReadLine();

            int index = contactList.FindIndex(x => x.DisplayName == _person);
            if (index == -1)
            {
                Console.WriteLine("Contact not found");
                return;
            }

            Console.Clear();
            Console.WriteLine("Contact found, are you sure you want to remove it? Y for Yes N for No.");
            var userInput = Console.ReadLine();
            if (userInput == "y")
            {
                Console.Clear();
                Console.WriteLine($"{contactList[index].DisplayName}" + " has been removed!");
                contactList.RemoveAt(index);
                file.Save(FilePath, JsonConvert.SerializeObject(contactList));
            }
            else if (userInput == "n")
            {
                Console.WriteLine("You are returning to the main menu, please press any key");
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

