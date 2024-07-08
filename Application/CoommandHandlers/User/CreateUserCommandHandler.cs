namespace Application.CommandHandlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, bool>
    {
        private readonly IUserRepository _repository;
        private readonly IMediator _mediator;

        public CreateUserCommandHandler(IUserRepository repository, IMediator mediator)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            var user = new User(command.Name, command.Email,command.Phone_Number);
            await _repository.Add(user);
            return true;
        }
    }
}