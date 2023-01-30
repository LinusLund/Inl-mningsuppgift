using System;

namespace WPFAdressBpk.Models;

internal interface IPerson
{
    Guid Id { get; set; }
    string FirstName { get; set; }
    string LastName { get; set; }
    string Email { get; set; }
}

internal class Person : IPerson
{

    public Guid Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;


    public string DisplayName => $"{FirstName} {LastName}";

}
