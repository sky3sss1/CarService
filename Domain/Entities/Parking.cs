namespace Domain.Entities
{
    public class Parking
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid Floor_Id { get; set; }
        public Guid Place_Id { get; set; }

        public Parking(Guid floor_Id, Guid place_Id)
        {
            Floor_Id = floor_Id;
            Place_Id = place_Id;
        }
        public Parking() { }
    }
}
