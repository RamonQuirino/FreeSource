using System;

namespace FreeSource.Common.Models.Iteration
{
    public class Message
    {
        public int Id { get; set; }
        public DateTime Sended { get; set; }
        public DateTime Readed { get; set; }
        public Person.Person Sender { get; set; }
        public Person.Person Recipient { get; set; }
        public string Text { get; set; }
    }
}
