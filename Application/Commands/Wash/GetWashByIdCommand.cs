namespace Application.Commands
{
    public class GetWashByIdCommand : IRequest<Wash>
    {
        public Guid Id { get; set; }
        public GetWashByIdCommand(Guid id)
        {
            Id = id;
        }
    }
}
