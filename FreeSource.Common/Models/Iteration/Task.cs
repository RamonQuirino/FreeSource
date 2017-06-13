using System;

namespace FreeSource.Common.Models.Iteration
{
    public class Task
    {
        public virtual int Id { get; set; }
        public virtual DateTime OpenTask { get; set; }
        public virtual Person.Person Requester { get; set; }
        public virtual Person.Person Requested { get; set; }
        public virtual string Description { get; set; }
    }
}
