namespace Application.CommandHandlers
{
    public class CreateFloorCommandHandler : IRequestHandler<CreateFloorCommand, bool>
    {
        private readonly IFloorRepository _repository;
        private readonly IMediator _mediator;

        public CreateFloorCommandHandler(IFloorRepository repository, IMediator mediator)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Handle(CreateFloorCommand command, CancellationToken cancellationToken)
        {
            var floor = new Floor (command.FloorNumber);
            await _repository.Add(floor);
            return true;
        }
    }
}