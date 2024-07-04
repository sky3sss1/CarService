namespace Application.CommandHandlers
{
    public class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommand, bool>
    {
        private readonly ICarRepository _repository;
        private readonly IMediator _mediator;

        public UpdateCarCommandHandler(ICarRepository repository, IMediator mediator)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Handle(UpdateCarCommand command, CancellationToken cancellationToken)
        {
            var car = await _repository.GetById(command.Id);
            if (car == null) return false;
            car.GovernmentNumber = command.GovernmentNumber;
            car.Model = command.Model;
            car.MinimalVoltage = command.MinimalVoltage;
            _repository.Update(car);
            return true;
        }
    }
}