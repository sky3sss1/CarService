namespace Application.CommandHandlers
{
    public class GetAllUsersCommandHandler : IRequestHandler<GetAllUsersCommand, IEnumerable<User>>
    {
        private readonly IUserRepository _repository;

        public GetAllUsersCommandHandler(IUserRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<IEnumerable<User>> Handle(GetAllUsersCommand request, CancellationToken cancellationToken)
        {
            return await _repository.GetAll();
        }
    }
}