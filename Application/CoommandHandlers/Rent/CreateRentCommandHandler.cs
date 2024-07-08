namespace Application.CommandHandlers
{
    public class CreateRentCommandHandler : IRequestHandler<CreateRentCommand, bool>
    {
        private readonly IRentRepository _repository;
        private readonly IMediator _mediator;

        public CreateRentCommandHandler(IRentRepository repository, IMediator mediator)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Handle(CreateRentCommand command, CancellationToken cancellationToken)
        {
            var rent = new Rent
            (
                command.Parking_Id,
                command.Car_Id,
                command.Payment_Id,
                command.Start_Date,
                command.End_Date
            );
            _repository.Add(rent);
            return true;
        }
    }
}