namespace Application.Commands
{
    public class GetTarifPriceByIdCommand : IRequest<int>
    {
        public Guid Id { get; set; }

        public GetTarifPriceByIdCommand(Guid id)
        {
            Id = id;
        }
    }
}
