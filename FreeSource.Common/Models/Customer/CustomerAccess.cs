
using FreeSource.Common.Models.Person;

namespace FreeSource.Common.Models.Customer
{
    public class CustomerAccess
    {
        public virtual int Id { get; set; }
        public virtual Customer Customer { get; set; }        
        public virtual PersonRole PersonRole { get; set; }
        public virtual bool Active { get; set; }
    }
}
