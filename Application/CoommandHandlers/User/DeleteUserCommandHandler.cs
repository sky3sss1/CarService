namespace Application.CommandHandlers
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, bool>
    {
        private readonly IUserRepository _repository;
        private readonly IMediator _mediator;

        public DeleteUserCommandHandler(IUserRepository repository, IMediator mediator)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
        {
            var user = await _repository.GetById(command.Id);
            if (user == null) return false;
            await _repository.Delete(user);
            return true;
        }
    }
}