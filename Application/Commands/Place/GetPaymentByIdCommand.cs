namespace Application.Commands
{
    public class GetPlaceByIdCommand : IRequest<Place>
    {
        public Guid Id { get; set; }
        public GetPlaceByIdCommand(Guid id)
        {
            Id = id;
        }
    }
}
