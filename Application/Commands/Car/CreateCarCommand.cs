namespace Application.Commands
{
    public class CreateCarCommand : IRequest<bool>
    {
        public Guid User_Id { get; set; }
        public string GovernmentNumber { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int MinimalVoltage { get; set; } = 0;
        public CreateCarCommand(Guid user_Id, string governmentNumber, string model, int minimalVoltage)
        {
            User_Id = user_Id;
            GovernmentNumber = governmentNumber;
            Model = model;
            MinimalVoltage = minimalVoltage;
        }
    }
}
