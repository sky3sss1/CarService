namespace Application.Commands
{
    public class UpdateTarifCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }

        public UpdateTarifCommand(Guid id, string name, int cost)
        {
            Id = id;
            Name = name;
            Cost = cost;
        }
    }
}