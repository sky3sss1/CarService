namespace Application.CommandHandlers
{
    public class GetTarifByIdCommandHandler : IRequestHandler<GetTarifByIdCommand, Tarif>
    {
        private readonly ITarifRepository _repository;
        private readonly IMediator _mediator;

        public GetTarifByIdCommandHandler(ITarifRepository repository, IMediator mediator)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<Tarif> Handle(GetTarifByIdCommand command, CancellationToken cancellationToken)
        {
            return await _repository.GetById(command.Id);
        }
    }
}