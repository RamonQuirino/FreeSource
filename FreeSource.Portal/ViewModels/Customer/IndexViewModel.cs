using System.Collections.Generic;
using FreeSource.Common.Models.Authorization;

namespace FreeSource.Portal.ViewModels.Customer
{
    public class IndexViewModel : AbstractViewModel
    {
        public User User { get; set; }
        public IList<Common.Models.Customer.Customer> Customers { get; set; }

        public override bool IsValid()
        {
            return User != null && Customers != null;
        }
    }
}