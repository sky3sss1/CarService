namespace Application.CommandHandlers
{
    public class UpdatePlaceCommandHandler : IRequestHandler<UpdatePlaceCommand, bool>
    {
        private readonly IPlaceRepository _repository;
        private readonly IMediator _mediator;

        public UpdatePlaceCommandHandler(IPlaceRepository repository, IMediator mediator)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Handle(UpdatePlaceCommand command, CancellationToken cancellationToken)
        {
            var place = await _repository.GetById(command.Id);
            if (place == null) return false;
            place.Is_Charge = command.Is_Charge;
            place.Voltage = command.Voltage;
            _repository.Update(place);
            return true;
        }
    }
}