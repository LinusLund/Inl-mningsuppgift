
namespace ConsoleAddressbok.Interfaces
{
    internal interface IPerson
    {
        Guid  Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Email { get; set; }
        string PhoneNumber { get; set; }
        string DisplayName => $"{FirstName} {LastName}";
    }
};
