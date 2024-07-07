namespace Application.CommandHandlers
{
    public class DeleteWashCommandHandler : IRequestHandler<DeleteWashCommand, bool>
    {
        private readonly IWashRepository _repository;
        private readonly IMediator _mediator;

        public DeleteWashCommandHandler(IWashRepository repository, IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        public async Task<bool> Handle(DeleteWashCommand command, CancellationToken cancellationToken)
        {
            var wash = await _repository.GetById(command.Id);

            if (wash == null) return false;

            _repository.Delete(wash);

            return true;
        }
    }
}