namespace Domain.Entities
{
    public class Tarif
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid Wash_Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public int Cost { get; set; }
        public int CostIfLoosed { get; set; }

        public Tarif(Guid wash_Id, string name, int cost, int costIfLoosed)
        {
            Wash_Id = wash_Id;
            Name = name;
            Cost = cost;
            CostIfLoosed = costIfLoosed;
        }
        public Tarif() { }
    }
}
