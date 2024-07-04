namespace Application.CommandHandlers
{
    public class CreateParkingCommandHandler : IRequestHandler<CreateParkingCommand, bool>
    {
        private readonly IParkingRepository _repository;
        private readonly IMediator _mediator;

        public CreateParkingCommandHandler(IParkingRepository repository, IMediator mediator)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Handle(CreateParkingCommand command, CancellationToken cancellationToken)
        {
            var parking = new Parking(command.Floor_Id, command.Place_Id );
            _repository.Add(parking);
            return true;
        }
    }
}