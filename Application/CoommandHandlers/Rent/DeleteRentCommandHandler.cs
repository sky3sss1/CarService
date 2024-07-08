namespace Application.CommandHandlers
{
    public class DeleteRentCommandHandler : IRequestHandler<DeleteRentCommand, bool>
    {
        private readonly IRentRepository _repository;
        private readonly IMediator _mediator;

        public DeleteRentCommandHandler(IRentRepository repository, IMediator mediator)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Handle(DeleteRentCommand command, CancellationToken cancellationToken)
        {
            var rent = await _repository.GetById(command.Id);
            if (rent == null) return false;
            await _repository.Delete(rent);
            return true;
        }
    }
}