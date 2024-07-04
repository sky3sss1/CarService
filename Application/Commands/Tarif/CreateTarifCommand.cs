namespace Application.Commands
{
    public class CreateTarifCommand : IRequest<bool>
    {
        public string Name { get; set; }
        public int Cost { get; set; }

        public CreateTarifCommand(string name, int cost)
        {
            Name = name;
            Cost = cost;
        }
    }
}