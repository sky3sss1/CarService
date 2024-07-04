namespace Application.CommandHandlers
{
    public class GetPlaceByIdCommandHandler : IRequestHandler<GetPlaceByIdCommand, Place>
    {
        private readonly IPlaceRepository _repository;
        private readonly IMediator _mediator;

        public GetPlaceByIdCommandHandler(IPlaceRepository repository, IMediator mediator)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<Place> Handle(GetPlaceByIdCommand command, CancellationToken cancellationToken)
        {
            return await _repository.GetById(command.Id);
        }
    }
}