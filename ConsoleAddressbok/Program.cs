using ConsoleAddressbok.Interfaces;
using ConsoleAddressbok.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ConsoleAddressbok.Services;
using System.Security.Cryptography;


var PersonService = new PersonService();


bool isRunning = true;
while (isRunning)
{
    Console.Clear();
    Console.WriteLine("[1] Lägg till Kontakt");
    Console.WriteLine("[2] Visa Kontaktlista");
    Console.WriteLine("[3] Sök efter en kontakt");
    Console.WriteLine("[4] Ta bort en kontakt");
    Console.WriteLine("[5] Avsluta Programmet");

    int.TryParse(Console.ReadLine(), out int input);

    switch (input)
    {
        case 1:
            Console.Clear();

            var newPerson = new Person();

            newPerson.Id = Guid.NewGuid();

            Console.Write("Ange förnamn: ");
            newPerson.FirstName = Console.ReadLine() ?? "";

            Console.Write("Ange Efternamn: ");
            newPerson.LastName = Console.ReadLine() ?? "";

            Console.Write("Ange E-postadress: ");
            newPerson.Email = Console.ReadLine() ?? "";

            Console.Write("Vänligen skriv in ett telefonnummer: ");
            newPerson.PhoneNumber = Console.ReadLine() ?? "";

            Console.Write("Vänligen skriv in  Adressen: ");
            newPerson.StreetName = Console.ReadLine() ?? "";

            PersonService.AddPersonToList(newPerson);

            Console.Clear();
            Console.WriteLine($"{newPerson.DisplayName}" +" har lagts till");
            Console.ReadKey();
            
            break;

        case 2:
            Console.Clear();
            Console.WriteLine("Dina Kontakter");
            PersonService.GetPeopleFromList();
            Console.ReadKey();
            break;

        case 3:
            Console.Clear();
            Console.WriteLine("Vänligen Skriv in för och efternamn på den du vill hitta");
            PersonService.GetPersonFromList(null!);
            Console.ReadKey();
            break;

        case 4:
            Console.Clear();
            Console.WriteLine("Vänligen Skriv in för och efternamn på den du vill ta bort");
            PersonService.GetPersonFromList(null!);
            Console.WriteLine("Är du säker på att du vill ta bort ");
            Console.ReadLine();
            break;

        case 5:
            Console.Clear();
            Console.WriteLine("Programmet avslutas,tryck vilken knapp som helst");
            isRunning = false;
            break;

        default: 
            Console.WriteLine("vänligen välj ett av alternativen");
            break;

            
    }

}

Console.Clear();
Console.ReadLine();
