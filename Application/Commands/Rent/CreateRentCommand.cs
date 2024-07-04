namespace Application.Commands
{
    public class CreateRentCommand : IRequest<bool>
    {
        public Guid User_Id { get; set; }
        public Guid Parking_Id { get; set; }
        public Guid Car_Id { get; set; }
        public Guid Payment_Id { get; set; }
        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; }
        public int LosedDays { get; set; }

        public CreateRentCommand(Guid user_Id, Guid parking_Id, Guid car_Id, Guid payment_Id, DateTime start_Date, DateTime end_Date, int losedDays)
        {
            User_Id = user_Id;
            Parking_Id = parking_Id;
            Car_Id = car_Id;
            Payment_Id = payment_Id;
            Start_Date = start_Date;
            End_Date = end_Date;
            LosedDays = losedDays;
        }
    }
}