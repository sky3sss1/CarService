namespace Application.Commands
{
    public class GetRentByIdCommand : IRequest<Rent>
    {
        public Guid Id { get; set; }

        public GetRentByIdCommand(Guid id)
        {
            Id = id;
        }
    }
}