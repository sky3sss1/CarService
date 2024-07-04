namespace Domain.Entities
{
    public class Place
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public bool Is_Charge { get; set; }
        public int Voltage { get; set; } = 0;

        public Place(bool is_Charge, int voltage)
        {
            Is_Charge = is_Charge;
            Voltage = voltage;
        }
        public Place() { }
    }
}
