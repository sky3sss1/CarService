namespace Application.Commands
{
    public class DeleteTarifCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        public DeleteTarifCommand(Guid id)
        {
            Id = id;
        }
    }
}