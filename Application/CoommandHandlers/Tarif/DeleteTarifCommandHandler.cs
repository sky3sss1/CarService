namespace Application.CommandHandlers
{
    public class DeleteTarifCommandHandler : IRequestHandler<DeleteTarifCommand, bool>
    {
        private readonly ITarifRepository _repository;
        private readonly IMediator _mediator;

        public DeleteTarifCommandHandler(ITarifRepository repository, IMediator mediator)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Handle(DeleteTarifCommand command, CancellationToken cancellationToken)
        {
            var tarif = await _repository.GetById(command.Id);
            if (tarif == null) return false;
            await _repository.Delete(tarif);
            return true;
        }
    }
}