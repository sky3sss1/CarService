namespace Application.Commands
{
    public class GetTarifByIdCommand : IRequest<Tarif>
    {
        public Guid Id { get; set; }

        public GetTarifByIdCommand(Guid id)
        {
            Id = id;
        }
    }
}