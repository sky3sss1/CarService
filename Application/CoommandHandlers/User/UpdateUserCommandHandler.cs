namespace Application.CommandHandlers
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, bool>
    {
        private readonly IUserRepository _repository;
        private readonly IMediator _mediator;

        public UpdateUserCommandHandler(IUserRepository repository, IMediator mediator)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
        {
            var user = await _repository.GetById(command.Id);
            if (user == null) return false;
            user.Name = command.Name;
            user.Email = command.Email;
            user.Phone_Number = command.Phone_Number;
            _repository.Update(user);
            return true;
        }
    }
}