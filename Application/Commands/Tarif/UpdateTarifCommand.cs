namespace Application.Commands
{
    public class UpdateTarifCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public Guid Wash_Id { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
        public int CostIfLoosed { get; set; }

        public UpdateTarifCommand(Guid wash_Id, Guid id, string name, int cost, int costIfLoosed)
        {
            Wash_Id = wash_Id;
            Id = id;
            Name = name;
            Cost = cost;
            CostIfLoosed = costIfLoosed;
        }
    }
}