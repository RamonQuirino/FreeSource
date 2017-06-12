using System;

namespace FreeSource.Common.Models.Iteration
{
    public class Notify
    {
        public int Id { get; set; }
        public DateTime Notification { get; set; }
        public string Text { get; set; }
        public string Title { get; set; }
    }
}
