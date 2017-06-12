namespace FreeSource.Common.Models.Contact
{
    public class Email
    {
        public int Id { get; set; }
        public string Adreess { get; set; }
        public bool Active { get; set; }
        public ContactType Type { get; set; }
    }
}
