namespace Application.CommandHandlers
{
    public class DeleteParkingCommandHandler : IRequestHandler<DeleteParkingCommand, bool>
    {
        private readonly IParkingRepository _repository;
        private readonly IMediator _mediator;

        public DeleteParkingCommandHandler(IParkingRepository repository, IMediator mediator)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Handle(DeleteParkingCommand command, CancellationToken cancellationToken)
        {
            var parking = await _repository.GetById(command.Id);
            if (parking == null) return false;
            await _repository.Delete(parking);
            return true;
        }
    }
}