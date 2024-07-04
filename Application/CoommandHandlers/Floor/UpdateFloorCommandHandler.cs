namespace Application.CommandHandlers
{
    public class UpdateFloorCommandHandler : IRequestHandler<UpdateFloorCommand, bool>
    {
        private readonly IFloorRepository _repository;
        private readonly IMediator _mediator;

        public UpdateFloorCommandHandler(IFloorRepository repository, IMediator mediator)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Handle(UpdateFloorCommand command, CancellationToken cancellationToken)
        {
            var floor = await _repository.GetById(command.Id);
            if (floor == null) return false;
            floor.FloorNumber = command.FloorNumber;
            _repository.Update(floor);
            return true;
        }
    }
}