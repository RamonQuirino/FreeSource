using System;

namespace FreeSource.Common.Models
{
    public class Image
    {
        public int Id { get; set; }
        public DateTime Upload { get; set; }
        public byte[] ImageSource { get; set; }
    }
}
