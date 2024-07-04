namespace Domain.Entities
{
    public class Tarif
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public int Cost { get; set; }

        public Tarif(string name, int cost)
        {
            Name = name;
            Cost = cost;
        }
        public Tarif() { }
    }
}
