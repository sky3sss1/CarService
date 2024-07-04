namespace Application.Commands
{
    public class GetCarByIdCommand : IRequest<Car>
    {
        public Guid Id { get; set; }
        public GetCarByIdCommand(Guid id)
        {
            Id = id;
        }
    }
}
