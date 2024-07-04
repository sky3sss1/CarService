namespace Application.CommandHandlers
{
    public class UpdateParkingCommandHandler : IRequestHandler<UpdateParkingCommand, bool>
    {
        private readonly IParkingRepository _repository;
        private readonly IMediator _mediator;

        public UpdateParkingCommandHandler(IParkingRepository repository, IMediator mediator)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Handle(UpdateParkingCommand command, CancellationToken cancellationToken)
        {
            var parking = await _repository.GetById(command.Id);
            if (parking == null) return false;
            parking.Floor_Id = command.Floor_Id;
            parking.Place_Id = command.Place_Id;
            _repository.Update(parking);
            return true;
        }
    }
}