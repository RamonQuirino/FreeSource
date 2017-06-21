

namespace FreeSource.Common.Models.Vehicle
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Plate { get; set; }
        public string Description { get; set; }
        public virtual VehicleType Type { get; set; }
        public virtual Person.Person Person { get; set; }
    }
}
