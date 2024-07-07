namespace Application.CoommandHandlers
{
    public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, bool>
    {
        private readonly ICarRepository _repository;
        private readonly IMediator _mediator;

        public CreateCarCommandHandler(ICarRepository repository, IMediator mediator)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Handle(CreateCarCommand command, CancellationToken cancellationToken)
        {
            var car = new Car(command.User_Id,command.GovernmentNumber, command.Model, command.MinimalVoltage);
            _repository.Add(car);
            return true;
        }
    }
}
