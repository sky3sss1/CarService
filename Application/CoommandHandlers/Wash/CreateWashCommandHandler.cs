namespace Application.CommandHandlers
{
    public class CreateWashCommandHandler : IRequestHandler<CreateWashCommand, bool>
    {
        private readonly IWashRepository _repository;
        private readonly IMediator _mediator;

        public CreateWashCommandHandler(IWashRepository repository, IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        public async Task<bool> Handle(CreateWashCommand command, CancellationToken cancellationToken)
        {
            var wash = new Wash(command.Price, command.Description);

            _repository.Add(wash);

            return true;
        }
    }
}