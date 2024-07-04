namespace Application.CommandHandlers
{
    public class GetCarByIdCommandHandler : IRequestHandler<GetCarByIdCommand, Car>
    {
        private readonly ICarRepository _repository;
        private readonly IMediator _mediator;

        public GetCarByIdCommandHandler(ICarRepository repository, IMediator mediator)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<Car> Handle(GetCarByIdCommand command, CancellationToken cancellationToken)
        {
            return await _repository.GetById(command.Id);
        }
    }
}