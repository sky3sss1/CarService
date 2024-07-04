namespace Application.CommandHandlers
{
    public class DeleteFloorCommandHandler : IRequestHandler<DeleteFloorCommand, bool>
    {
        private readonly IFloorRepository _repository;
        private readonly IMediator _mediator;

        public DeleteFloorCommandHandler(IFloorRepository repository, IMediator mediator)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Handle(DeleteFloorCommand command, CancellationToken cancellationToken)
        {
            var floor = await _repository.GetById(command.Id);
            if (floor == null) return false;
            _repository.Delete(floor);
            return true;
        }
    }
}