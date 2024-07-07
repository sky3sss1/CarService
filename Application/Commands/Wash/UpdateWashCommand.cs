namespace Application.Commands
{
    public class UpdateWashCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public int Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public UpdateWashCommand(Guid id, int price, string description)
        {
            Id = id;
            Price = price;
            Description = description;
        }
    }
}
