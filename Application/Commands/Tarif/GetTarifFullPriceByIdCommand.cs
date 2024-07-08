namespace Application.Commands
{
    public class GetTarifFullPriceByIdCommand : IRequest<int>
    {
        public Guid Id { get; set; }

        public GetTarifFullPriceByIdCommand(Guid id)
        {
            Id = id;
        }
    }
}
