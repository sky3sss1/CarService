namespace Application.CommandHandlers
{
    public class DeletePlaceCommandHandler : IRequestHandler<DeletePlaceCommand, bool>
    {
        private readonly IPlaceRepository _repository;
        private readonly IMediator _mediator;

        public DeletePlaceCommandHandler(IPlaceRepository repository, IMediator mediator)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Handle(DeletePlaceCommand command, CancellationToken cancellationToken)
        {
            var place = await _repository.GetById(command.Id);
            if (place == null) return false;
            _repository.Delete(place);
            return true;
        }
    }
}