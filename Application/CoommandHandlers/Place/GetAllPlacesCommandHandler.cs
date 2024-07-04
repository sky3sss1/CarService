namespace Application.CommandHandlers
{
    public class GetAllPlacesCommandHandler : IRequestHandler<GetAllPlacesCommand, IEnumerable<Place>>
    {
        private readonly IPlaceRepository _repository;

        public GetAllPlacesCommandHandler(IPlaceRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<IEnumerable<Place>> Handle(GetAllPlacesCommand command, CancellationToken cancellationToken)
        {
            return await _repository.GetAll();
        }
    }
}