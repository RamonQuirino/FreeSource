using System.Collections.Generic;
using System.Linq;

namespace FreeSource.Portal.ViewModels.Person
{
    
    public class PersonSearchViewModel: AbstractViewModel
    {
        public string FilterText { get; set; }
        public IList<Common.Models.Person.Person> Persons { get; set; }

        public override bool IsValid()
        {
            return Persons != null && Persons.Any();
        }
    }
}