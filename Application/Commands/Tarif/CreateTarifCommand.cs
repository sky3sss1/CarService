namespace Application.Commands
{
    public class CreateTarifCommand : IRequest<bool>
    {
        public Guid Wash_Id { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
        public CreateTarifCommand(Guid wash_Id, string name, int cost)
        {
            Wash_Id = wash_Id;
            Name = name;
            Cost = cost;
        }
    }
}