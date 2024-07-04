namespace Application.CommandHandlers
{
    public class UpdateRentCommandHandler : IRequestHandler<UpdateRentCommand, bool>
    {
        private readonly IRentRepository _repository;
        private readonly IMediator _mediator;

        public UpdateRentCommandHandler(IRentRepository repository, IMediator mediator)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Handle(UpdateRentCommand command, CancellationToken cancellationToken)
        {
            var rent = await _repository.GetById(command.Id);
            if (rent == null) return false;
            rent.User_Id = command.User_Id;
            rent.Parking_Id = command.Parking_Id;
            rent.Car_Id = command.Car_Id;
            rent.Payment_Id = command.Payment_Id;
            rent.Start_Date = command.Start_Date;
            rent.End_Date = command.End_Date;
            rent.LosedDays = command.LosedDays;
            _repository.Update(rent);
            return true;
        }
    }
}