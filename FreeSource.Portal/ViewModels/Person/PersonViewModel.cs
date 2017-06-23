using System;


namespace FreeSource.Portal.ViewModels.Person
{
    public class PersonViewModel : AbstractViewModel
    {

        public Common.Models.Person.Person Person { get; set; }

        public override bool IsValid()
        {
            return true;
        }
    }
}