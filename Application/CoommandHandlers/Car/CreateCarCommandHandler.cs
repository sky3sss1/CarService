namespace Application.CoommandHandlers
{
    public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, Car>
    {
        private readonly ICarRepository _repository;
        private readonly IMediator _mediator;

        public CreateCarCommandHandler(ICarRepository repository, IMediator mediator)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<Car> Handle(CreateCarCommand command, CancellationToken cancellationToken)
        {
            var car = new Car(command.User_Id,command.GovernmentNumber, command.Model, command.MinimalVoltage);
            await _repository.Add(car);
            return car;
        }
    }
}
