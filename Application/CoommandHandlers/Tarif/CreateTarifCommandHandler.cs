namespace Application.CommandHandlers
{
    public class CreateTarifCommandHandler : IRequestHandler<CreateTarifCommand, bool>
    {
        private readonly ITarifRepository _repository;
        private readonly IMediator _mediator;

        public CreateTarifCommandHandler(ITarifRepository repository, IMediator mediator)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Handle(CreateTarifCommand command, CancellationToken cancellationToken)
        {
            var tarif = new Tarif (command.Name, command.Cost );
            _repository.Add(tarif);
            return true;
        }
    }
}