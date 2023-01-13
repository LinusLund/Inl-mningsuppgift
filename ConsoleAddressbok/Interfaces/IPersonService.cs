using ConsoleAddressbok.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAddressbok.Interfaces
{
    internal interface IPersonService
    {
        void AddPersonToList(IPerson person);
        void RemovePersonFromList(IPerson person);
        IEnumerable<IPerson> GetPeopleFromList();
        Person GetPersonFromList(IPerson person);
    }
}
