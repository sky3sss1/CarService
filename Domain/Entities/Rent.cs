namespace Domain.Entities
{
    public class Rent
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid Parking_Id { get; set; }
        public Guid Car_Id { get; set; }
        public Guid Payment_Id { get; set; }
        public DateTime Start_Date { get; set; } = DateTime.Today.ToUniversalTime();
        public DateTime End_Date { get; set; }
        public int LosedDays { get; set; } = 0;

        public Rent(Guid parking_Id, Guid car_Id, Guid payment_Id, DateTime start_Date, DateTime end_Date)
        {
            Parking_Id = parking_Id;
            Car_Id = car_Id;
            Payment_Id = payment_Id;
            Start_Date = start_Date;
            End_Date = end_Date;
        }
        public Rent() { }
    }
}
