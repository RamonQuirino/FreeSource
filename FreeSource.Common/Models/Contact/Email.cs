namespace FreeSource.Common.Models.Contact
{
    public class Email
    {
        public virtual int Id { get; set; }
        public virtual string Adreess { get; set; }
        public virtual bool Active { get; set; }
        public virtual ContactType Type { get; set; }
        public virtual Person.Person Person { get; set; }
    }
}
