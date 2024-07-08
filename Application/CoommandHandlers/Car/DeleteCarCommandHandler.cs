namespace Application.CommandHandlers
{
    public class DeleteCarCommandHandler : IRequestHandler<DeleteCarCommand, bool>
    {
        private readonly ICarRepository _repository;
        private readonly IMediator _mediator;

        public DeleteCarCommandHandler(ICarRepository repository, IMediator mediator)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Handle(DeleteCarCommand command, CancellationToken cancellationToken)
        {
            var car = await _repository.GetById(command.Id);
            if (car == null) return false;
            await _repository.Delete(car);
            return true;
        }
    }
}