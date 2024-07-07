namespace Domain.Entities
{
    public class Wash
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int Price { get; set; }
        public string Description { get; set; } =string.Empty;
        public Wash(){}
        public Wash(int price, string description)
        {
            Price = price;
            Description = description;
        }
    }
}
