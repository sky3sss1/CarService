namespace Application.CommandHandlers
{
    public class GetParkingByIdCommandHandler : IRequestHandler<GetParkingByIdCommand, Parking>
    {
        private readonly IParkingRepository _repository;
        private readonly IMediator _mediator;

        public GetParkingByIdCommandHandler(IParkingRepository repository, IMediator mediator)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<Parking> Handle(GetParkingByIdCommand command, CancellationToken cancellationToken)
        {
            return await _repository.GetById(command.Id);
        }
    }
}