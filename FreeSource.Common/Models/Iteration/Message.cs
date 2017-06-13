using System;

namespace FreeSource.Common.Models.Iteration
{
    public class Message
    {
        public virtual int Id { get; set; }
        public virtual DateTime Sended { get; set; }
        public virtual DateTime Readed { get; set; }
        public virtual Person.Person Sender { get; set; }
        public virtual Person.Person Recipient { get; set; }
        public virtual string Text { get; set; }
    }
}
