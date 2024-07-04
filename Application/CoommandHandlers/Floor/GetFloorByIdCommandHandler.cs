namespace Application.CommandHandlers
{
    public class GetFloorByIdCommandHandler : IRequestHandler<GetFloorByIdCommand, Floor>
    {
        private readonly IFloorRepository _repository;
        private readonly IMediator _mediator;

        public GetFloorByIdCommandHandler(IFloorRepository repository, IMediator mediator)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<Floor> Handle(GetFloorByIdCommand command, CancellationToken cancellationToken)
        {
            return await _repository.GetById(command.Id);
        }
    }
}