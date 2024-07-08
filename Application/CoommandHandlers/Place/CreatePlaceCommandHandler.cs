namespace Application.CommandHandlers
{
    public class CreatePlaceCommandHandler : IRequestHandler<CreatePlaceCommand, bool>
    {
        private readonly IPlaceRepository _repository;
        private readonly IMediator _mediator;

        public CreatePlaceCommandHandler(IPlaceRepository repository, IMediator mediator)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Handle(CreatePlaceCommand command, CancellationToken cancellationToken)
        {
            var place = new Place (command.Is_Charge, command.Voltage );
            await _repository.Add(place);
            return true;
        }
    }
}