using static System.Net.Mime.MediaTypeNames;

namespace Domain.Entities
{
    public class Floor
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int FloorNumber { get; set; }
        public Floor(int floorNumber)
        {
            FloorNumber = floorNumber;
        }
        public Floor() { }
    }
}
