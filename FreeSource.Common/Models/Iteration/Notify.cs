using System;

namespace FreeSource.Common.Models.Iteration
{
    public class Notify
    {
        public virtual int Id { get; set; }
        public virtual DateTime Notification { get; set; }
        public virtual string Text { get; set; }
        public virtual string Title { get; set; }
        public virtual Person.Person Sender{ get; set; }
        public virtual Person.Person Notified { get; set; }
    }
}
