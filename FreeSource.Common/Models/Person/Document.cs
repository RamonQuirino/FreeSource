
namespace FreeSource.Common.Models.Person
{
    public class Document
    {
        public virtual int Id { get; set; }
        public virtual string Number { get; set; }
        public virtual DocumentType Type { get; set; }
    }
}
