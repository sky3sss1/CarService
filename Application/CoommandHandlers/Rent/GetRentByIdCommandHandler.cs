namespace Application.CommandHandlers
{
    public class GetRentByIdCommandHandler : IRequestHandler<GetRentByIdCommand, Rent>
    {
        private readonly IRentRepository _repository;
        private readonly IMediator _mediator;

        public GetRentByIdCommandHandler(IRentRepository repository, IMediator mediator)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<Rent> Handle(GetRentByIdCommand command, CancellationToken cancellationToken)
        {
            return await _repository.GetById(command.Id);
        }
    }
}