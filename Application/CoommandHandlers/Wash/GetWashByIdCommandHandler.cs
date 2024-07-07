namespace Application.CommandHandlers
{
    public class GetWashByIdCommandHandler : IRequestHandler<GetWashByIdCommand, Wash>
    {
        private readonly IWashRepository _repository;
        private readonly IMediator _mediator;

        public GetWashByIdCommandHandler(IWashRepository repository, IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        public async Task<Wash> Handle(GetWashByIdCommand command, CancellationToken cancellationToken)
        {
            var wash = await _repository.GetById(command.Id);

            return wash;
        }
    }
}