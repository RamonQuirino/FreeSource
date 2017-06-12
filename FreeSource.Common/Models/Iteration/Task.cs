using System;

namespace FreeSource.Common.Models.Iteration
{
    public class Task
    {
        public int Id { get; set; }
        public DateTime OpenTask { get; set; }
        public Person.Person Requester { get; set; }
        public Person.Person Requested { get; set; }
        public string Description { get; set; }
    }
}
