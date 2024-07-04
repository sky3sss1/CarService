namespace Application.CommandHandlers
{
    public class GetUserByIdCommandHandler : IRequestHandler<GetUserByIdCommand, User>
    {
        private readonly IUserRepository _repository;
        private readonly IMediator _mediator;

        public GetUserByIdCommandHandler(IUserRepository repository, IMediator mediator)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<User> Handle(GetUserByIdCommand command, CancellationToken cancellationToken)
        {
            return await _repository.GetById(command.Id);
        }
    }
}