using FreeSource.Common.Models.Authorization;

namespace FreeSource.Portal.ViewModels.Customer
{
    public class IndexViewModel: AbstractViewModel
    {
        public User User { get; set; }

        public override bool IsValid()
        {
            return User?.Person?.Customers != null;
        }
    }
}