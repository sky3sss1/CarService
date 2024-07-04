namespace Domain.Entities
{
    public class Car
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string GovernmentNumber { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int MinimalVoltage { get; set; } = 0;
        public Car(string governmentNumber, string model, int minimalVoltage)
        {
            GovernmentNumber = governmentNumber;
            Model = model;
            MinimalVoltage = minimalVoltage;
        }
        public Car()
        {

        }
    }
}
