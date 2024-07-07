namespace Application.Commands
{
    public class CreateWashCommand : IRequest<bool>
    {
        public int Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public CreateWashCommand(int price, string description)
        {
            Price = price;
            Description = description;
        }
    }
}
